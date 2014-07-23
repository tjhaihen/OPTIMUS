Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Data
Imports System.Security
Imports System.Data.SqlClient
Imports System.Security.Permissions

Imports Raven
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Security

    <StrongNameIdentityPermissionAttribute(SecurityAction.LinkDemand, PublicKey:="0024000004800000940000000602000000240000525341310004000001000100B5C8DAC10359BBDC968B03CC7972D770032BFCCDCE4324E01E728E0C982320E3B723CDC1C6CE9D02288D5D9225590FAD94A05E7F650281A614ED2D53FB37AFB84AFEF5D0491CF4C6B464D68565FF6CFAE3F7FB13FACD533C26D67AFC21EC7ECE6AAC5127A4043EA23D0889CF93ABD21F73B897BE75679AE6F0423EF436FC1FEB")> _
    Public Class UserManagement
        Inherits MarshalByRefObject

        Public Sub New()
        End Sub

#Region "Methods - return dataset"
        Public Overloads Function GetUserDataset(ByVal UserID As String, ByVal Password As String) As DataSet
            '
            '   validate User Name and Password
            '
            ApplicationAssert.CheckCondition(Len(UserID) > 0, "User name is required", ApplicationAssert.LineNumber)
            ApplicationAssert.CheckCondition(Len(Password) > 0, "Password is required", ApplicationAssert.LineNumber)

            Const PRM_UID As String = "@UserID"

            Dim strSQL_Modules, strSQL_User As String
            Dim cnn As SqlConnection = New SqlConnection(SysConfig.ConfigurationConnectionString)

            ' // Create new Dataset
            Dim ds As New DataSet
            ds.Tables.Add(New DataTable("Users"))
            ds.Tables.Add(New DataTable("UserModules"))

            strSQL_Modules = _
            "select usermod.userid, usermod.moduleid, usermod.r_read, usermod.r_edit, usermod.r_delete, " & _
            "mod.description, mod.url, mod.modulegroup, mod.keterangan, mod.mgroup, mod.counter, mod.headerdetil, mod.headerid, mod.modlevel " & _
            "from dbo.usermodules usermod inner join dbo.modules mod on usermod.moduleid = mod.moduleid " & _
            "where usermod.userid = @UserID and mod.app = 'RJ_' and mod.aktif = 1"

            strSQL_User = _
            "SELECT UserID, Password, userName, jobTitle, workPhone, homePhone, fax, mobilePhone, email, department, " & _
            "managerName, assistantName, isEnable, isAdmin " & _
            "from Users " & _
            "where (isEnable=1) AND (UserID=@UserID)"

            Try
                '// Get User data
                Dim cmdUser As New SqlCommand

                cmdUser.CommandType = CommandType.Text
                cmdUser.CommandText = strSQL_User
                cmdUser.Connection = cnn

                cmdUser.Parameters.Add(New SqlParameter(PRM_UID, SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, UserID))

                Dim adapterUser As SqlDataAdapter = New SqlDataAdapter(cmdUser)
                adapterUser.Fill(ds.Tables("Users"))

                cmdUser.Dispose()
                cmdUser = Nothing
                adapterUser.Dispose()
                adapterUser = Nothing

                '//   verify the user's password
                With ds.Tables("Users")
                    If (.Rows.Count = 1) Then
                        If CType(.Rows(0)("Password"), String).Equals(Password) Then

                            ApplicationAssert.CheckCondition(Common.ProcessNull.GetBoolean(.Rows(0)("isEnable")) = True, "Can not login; Account disable.", ApplicationAssert.LineNumber)
                            '
                            ' //  Get user's modules
                            '
                            Dim cmdModules As New SqlCommand

                            cmdModules.CommandType = CommandType.Text
                            cmdModules.CommandText = strSQL_Modules
                            cmdModules.Connection = cnn

                            Dim adapterModules As SqlDataAdapter = New SqlDataAdapter(cmdModules)

                            cmdModules.Parameters.Add(New SqlParameter(PRM_UID, SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, UserID))
                            adapterModules.Fill(ds.Tables("UserModules"))

                            cmdModules.Dispose()
                            cmdModules = Nothing
                            adapterModules.Dispose()
                            adapterModules = Nothing
                        End If
                    End If
                End With

            Catch e As Exception
                ExceptionManager.Publish(e)
            End Try

            Return ds
        End Function

        Public Overloads Function GetUserDataSetByUserGroup(ByVal UserGroupID As String, ByVal UserID As String, ByVal Password As String) As DataSet
            '
            '   validate User Name and Password
            '
            ApplicationAssert.CheckCondition(Len(UserID) > 0, "User Name is required", ApplicationAssert.LineNumber)
            ApplicationAssert.CheckCondition(Len(Password) > 0, "Password is required", ApplicationAssert.LineNumber)

            Const PRM_UGID As String = "@UserGroupID"
            Const PRM_UID As String = "@UserID"

            Dim strSQL_Menu, strSQL_User As String
            Dim cnn As SqlConnection = New SqlConnection(SysConfig.ConfigurationConnectionString)

            ' // Create new Dataset
            Dim ds As New DataSet
            ds.Tables.Add(New DataTable("User"))
            ds.Tables.Add(New DataTable("UserGroupMenu"))

            strSQL_Menu = _
            "select um.UserGroupID, um.MenuID, um.isAllowRead, um.isAllowAdd, um.isAllowEdit, " & _
            "um.isAllowDelete, um.isAllowApprove, um.isAllowVoid, um.isAllowPrint, " & _
            "m.Description, m.URL, m.Caption, m.[Counter], m.Line, m.ImageUrl, m.MenuType " & _
            "from UserGroupMenu um inner join Menu m on um.MenuID = m.MenuID " & _
            "where um.UserGroupID = @UserGroupID and m.appID = 'RS_' and m.IsActive = 1 "

            strSQL_User = _
            "SELECT * FROM [User] " & _
            "WHERE (IsActive=1) AND (UserID=@UserID)"

            Try
                cnn.Open()

                '// Get User data
                Dim cmdUser As New SqlCommand

                cmdUser.CommandType = CommandType.Text
                cmdUser.CommandText = strSQL_User
                cmdUser.Connection = cnn

                cmdUser.Parameters.Add(New SqlParameter(PRM_UID, SqlDbType.VarChar, 15, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, UserID))

                Dim adapterUser As SqlDataAdapter = New SqlDataAdapter(cmdUser)
                adapterUser.Fill(ds.Tables("User"))

                cmdUser.Dispose()
                cmdUser = Nothing
                adapterUser.Dispose()
                adapterUser = Nothing

                '//   verify the user's password
                With ds.Tables("User")
                    If (.Rows.Count = 1) Then
                        If CType(.Rows(0)("Password"), String).Equals(Password) Then

                            ApplicationAssert.CheckCondition(Common.ProcessNull.GetBoolean(.Rows(0)("isActive")) = True, "Your account is disabled. Please contact your System Administrator.", ApplicationAssert.LineNumber)
                            '
                            ' //  Get user's Menu
                            '
                            Dim cmdMenu As New SqlCommand

                            cmdMenu.CommandType = CommandType.Text
                            cmdMenu.CommandText = strSQL_Menu
                            cmdMenu.Connection = cnn

                            Dim adapterMenu As SqlDataAdapter = New SqlDataAdapter(cmdMenu)

                            cmdMenu.Parameters.Add(New SqlParameter(PRM_UGID, SqlDbType.VarChar, 15, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, UserGroupID))
                            adapterMenu.Fill(ds.Tables("UserGroupMenu"))

                            cmdMenu.Dispose()
                            cmdMenu = Nothing
                            adapterMenu.Dispose()
                            adapterMenu = Nothing
                        Else
                            ds = Nothing
                        End If
                    Else
                        ds = Nothing
                    End If
                End With

                cnn.Close()

            Catch e As Exception
                ExceptionManager.Publish(e)
            End Try

            Return ds
        End Function
#End Region

    End Class

End Namespace