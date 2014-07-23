Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class User
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _UserID, _UserName, _Password, _NewPassword, _AuthorizePassword As String
        Private _PersonID As String        
        Private _UserIDInsert, _UserIDUpdate As String
        Private _InsertDate, _UpdateDate As String
        Private _isActive As Boolean        

#End Region

        Public Sub New()
            ConnectionString = SysConfig.ConnectionString
        End Sub

#Region "Main Functions"
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            With cmdToExecute
                .CommandText = "INSERT INTO [User] " & _
                                "(UserID, UserName, PersonID, Password, AuthorizePassword, " & _
                                "IsActive, UserIDInsert, UserIDUpdate, InsertDate, UpdateDate) " & _
                                "VALUES " & _
                                "(@UserID, @UserName, @PersonID, @Password, @AuthorizePassword, " & _
                                "@IsActive, @UserIDInsert, @UserIDUpdate, GetDate(), GetDate())"
                .CommandType = CommandType.Text
                .Connection = _mainConnection
            End With

            Dim strUserID As String = ID.GenerateIDNumber("[User]", "UserID")

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", strUserID)
                cmdToExecute.Parameters.AddWithValue("@UserName", _UserName)
                cmdToExecute.Parameters.AddWithValue("@PersonID", _PersonID)
                cmdToExecute.Parameters.AddWithValue("@Password", _Password)
                cmdToExecute.Parameters.AddWithValue("@AuthorizePassword", _AuthorizePassword)
                cmdToExecute.Parameters.AddWithValue("@IsActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@UserIDInsert", _UserIDInsert)
                cmdToExecute.Parameters.AddWithValue("@UserIDUpdate", _UserIDUpdate)

                _mainConnection.Open()

                cmdToExecute.ExecuteNonQuery()

                _UserID = strUserID
                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            With cmdToExecute
                .CommandText = "UPDATE [User] " & _
                                "SET " & _
                                "UserName = @UserName, " & _
                                "IsActive = @IsActive, " & _
                                "UserIDUpdate = @UserIDUpdate, " & _
                                "UpdateDate = GetDate() " & _
                                "WHERE UserID = @UserID"
                .CommandType = CommandType.Text
                .Connection = _mainConnection
            End With

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@UserName", _UserName)
                cmdToExecute.Parameters.AddWithValue("@IsActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@UserIDUpdate", _UserIDUpdate)

                _mainConnection.Open()

                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT u.* " & _
                                        "FROM [User] u " & _
                                        "ORDER BY u.UserID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM [User] WHERE UserID = @UserID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM [User] WHERE UserID > @UserID ORDER BY UserID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM [User] WHERE UserID < @UserID ORDER BY UserID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _UserID = CType(toReturn.Rows(0)("UserID"), String)
                    _UserName = CType(toReturn.Rows(0)("UserName"), String)
                    _Password = CType(toReturn.Rows(0)("Password"), String)
                    _PersonID = CType(toReturn.Rows(0)("PersonID"), String)
                    _AuthorizePassword = CType(toReturn.Rows(0)("AuthorizePassword"), String)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
                    _UserIDInsert = CType(toReturn.Rows(0)("UserIDInsert"), String)
                    _UserIDUpdate = CType(toReturn.Rows(0)("UserIDUpdate"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                End If

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

#End Region

#Region "Custom Functions"
        Public Function UpdateAll(ByVal IsResetPassword As Boolean, ByVal IsResetAuthorizePassword As Boolean) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strSQLUpdatePassword As String = String.Empty
            If IsResetPassword = True Then
                strSQLUpdatePassword += "Password = @Password, "
            End If
            If IsResetAuthorizePassword = True Then
                strSQLUpdatePassword += "AuthorizePassword = @AuthorizePassword, "
            End If

            cmdToExecute.CommandText = "UPDATE [User] " & _
                                        "SET " & _
                                        "UserName = @UserName, " & _
                                        strSQLUpdatePassword.Trim & _
                                        "IsActive = @IsActive, " & _
                                        "UserIDUpdate = @UserIDUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE UserID = @UserID"

            With cmdToExecute
                .CommandType = CommandType.Text
                .Connection = _mainConnection
            End With

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@UserName", _UserName)
                cmdToExecute.Parameters.AddWithValue("@IsActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@UserIDUpdate", _UserIDUpdate)
                If IsResetPassword = True Then
                    cmdToExecute.Parameters.AddWithValue("@Password", _Password)
                End If
                If IsResetAuthorizePassword = True Then
                    cmdToExecute.Parameters.AddWithValue("@AuthorizePassword", _AuthorizePassword)
                End If

                _mainConnection.Open()

                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function UpdatePassword() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE [User] " & _
                            "SET Password = @NewPassword " & _
                            "WHERE UserID = @UserID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection


            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@NewPassword", _NewPassword)

                _mainConnection.Open()

                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function SelectByUserID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT u.UserID, u.UserName, u.Password, ISNULL(up.ProfileID,'') AS ProfileID, " & _
                                       "ISNULL((SELECT profileName FROM Profile WHERE ProfileID = up.ProfileID),'') AS ProfileName, " & _
                                       "ISNULL(us.SiteID,'') AS SiteID, " & _
                                       "ISNULL((SELECT siteName FROM Site WHERE SiteID = us.SiteID),'') AS SiteName " & _
                                       "FROM [User] u " & _
                                       "LEFT JOIN [UserProfile] up ON u.UserID = up.UserID " & _
                                       "LEFT JOIN [UserSite] us ON u.UserID = us.UserID " & _
                                       "WHERE UserID = @UserID and IsActive = 1"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)

                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectByUserName() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT u.UserID, u.Password, u.UserName, p.FirstName, p.MiddleName, p.LastName, " & _
                                       "'' AS ProfileID, '' AS SiteID " & _
                                       "FROM [User] u " & _
                                       "INNER JOIN Person p ON u.PersonID = p.PersonID " & _
                                       "WHERE UserName = @UserName and IsActive = 1"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserName", _UserName)

                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectUserPerson() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT u.userID, u.userName, u.password, u.authorizePassword, u.isActive, " & _
                                        "p.salutation, p.firstName, p.middleName, p.lastName, p.academicTitle, " & _
                                        "p.address1, p.address2, p.address3, p.city, p.postalCode, " & _
                                        "p.phone, p.mobile, p.fax, p.email, p.url, " & _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='SEX' AND code=p.sexSCode) AS SexName, " & _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='SEX' AND code=p.genderSCode) AS GenderName, " & _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='RELIGION' AND code=p.religionSCode) AS ReligionName, " & _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='NATIONALITY' AND code=p.nationalitySCode) AS NationalityName " & _
                                        "FROM [User] u " & _
                                        "INNER JOIN Person p ON u.PersonID=p.PersonID " & _
                                        "ORDER BY u.Username"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("User")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region

#Region "Class Property Declarations"
        Public Property [UserID]() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        Public Property [UserName]() As String
            Get
                Return _UserName
            End Get
            Set(ByVal Value As String)
                _UserName = Value
            End Set
        End Property

        Public Property [PersonID]() As String
            Get
                Return _PersonID
            End Get
            Set(ByVal Value As String)
                _PersonID = Value
            End Set
        End Property

        Public Property [Password]() As String
            Get
                Return _Password
            End Get
            Set(ByVal Value As String)
                _Password = Value
            End Set
        End Property

        Public Property [AuthorizePassword]() As String
            Get
                Return _AuthorizePassword
            End Get
            Set(ByVal Value As String)
                _AuthorizePassword = Value
            End Set
        End Property

        Public Property [NewPassword]() As String
            Get
                Return _NewPassword
            End Get
            Set(ByVal Value As String)
                _NewPassword = Value
            End Set
        End Property

        Public Property [isActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
            End Set
        End Property

        Public Property [UserIDInsert]() As String
            Get
                Return _UserIDInsert
            End Get
            Set(ByVal Value As String)
                _UserIDInsert = Value
            End Set
        End Property

        Public Property [UserIDUpdate]() As String
            Get
                Return _UserIDUpdate
            End Get
            Set(ByVal Value As String)
                _UserIDUpdate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
