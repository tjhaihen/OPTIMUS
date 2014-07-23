Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ProfileMenu
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _profileMenuID, _profileID, _menuID, _userIDinsert As String
        Private _isAllowCreate, _isAllowRead, _isAllowUpdate, _isAllowDelete As Boolean

#End Region

        Private Sub init()
            'add more initiation here if any
        End Sub

        Public Sub New()
            ' // Nothing for now.
            init()
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
            init()
        End Sub

#Region "Insert"
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ProfileMenu (ProfileMenuID, ProfileID, MenuID, isAllowCreate, isAllowRead, isAllowUpdate, isAllowDelete, userIDinsert, insertDate) " & _
                                        "VALUES (@ProfileMenuID, @ProfileID, @MenuID, @isAllowCreate, @isAllowRead, @isAllowUpdate, @isAllowDelete, @userIDinsert, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strProfileMenuID As String = ID.GenerateIDNumber("ProfileMenu", "profileMenuID")

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileMenuID", strProfileMenuID)
                cmdToExecute.Parameters.AddWithValue("@ProfileID", _profileID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _menuID)
                cmdToExecute.Parameters.AddWithValue("@isAllowCreate", _isAllowCreate)
                cmdToExecute.Parameters.AddWithValue("@isAllowRead", _isAllowRead)
                cmdToExecute.Parameters.AddWithValue("@isAllowUpdate", _isAllowUpdate)
                cmdToExecute.Parameters.AddWithValue("@isAllowDelete", _isAllowDelete)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region "Delete"
        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM ProfileMenu WHERE ProfileMenuID=@ProfileMenuID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileMenuID", _profileMenuID)                

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

#End Region

#Region "Select All"
        
#End Region

#Region " Otorisasi Menu "
        Public Function SelectAuthorizeCRUDMenuByProfileIDMenuID() As DataTable
            Dim cn As New SqlConnection(SysConfig.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM ProfileMenu WHERE ProfileID=@ProfileID AND MenuID=@MenuID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ProfileMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = cn

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", _profileID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _menuID)

                ' // Open connection.
                cn.Open()

                ' // Execute query.
                adapter.Fill(toReturn)                
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Function SelectMenuByProfileID(ByVal ProfileID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT pm.*, (SELECT description FROM Menu WHERE MenuID=pm.MenuID) AS description FROM ProfileMenu pm " + _
                                        "WHERE pm.ProfileID=@ProfileID ORDER BY pm.MenuID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("MenuByProfileID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)

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

        Public Function SelectMenuNotInProfileMenuByProfileID(ByVal ProfileID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Menu WHERE MenuID NOT IN (SELECT MenuID FROM ProfileMenu WHERE ProfileID=@ProfileID)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("MenuNotInProfileMenuByProfileID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)

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

        Public Function SelectMenuByAppIDandParentID(ByVal AppID As String, ByVal ParentIDFilter As String) As DataTable
            Dim cn As New SqlConnection(SysConfig.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If ParentIDFilter.Trim = "NULL" Then
                ParentIDFilter = "AND m.ParentMenuID IS NULL"
            Else
                ParentIDFilter = "AND m.ParentMenuID='" + ParentIDFilter.Trim + "'"
            End If
            cmdToExecute.CommandText = "SELECT * FROM Menu m INNER JOIN ProfileMenu u ON m.MenuID=u.MenuID " + _
                "WHERE m.isActive=1 AND m.AppID=@AppID AND u.ProfileID=@ProfileID " + _
                ParentIDFilter.Trim + _
                " ORDER BY m.MenuID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ActiveMenuByAppIDandProfileID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = cn

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", _profileID)
                cmdToExecute.Parameters.AddWithValue("@AppID", AppID)

                ' // Open connection.
                cn.Open()

                ' // Execute query.
                adapter.Fill(toReturn)                
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Function ImportTemplateProfileMenu(ByVal TemplateProfileID As String) As Boolean
            Dim cn As New SqlConnection(SysConfig.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spImportProfileMenu]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = cn

            Try
                cmdToExecute.Parameters.AddWithValue("@TemplateProfileID", TemplateProfileID)
                cmdToExecute.Parameters.AddWithValue("@ProfileID", _profileID)

                ' // Open connection.
                cn.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "

        Public Property [ProfileMenuID]() As String
            Get
                Return _profileMenuID
            End Get
            Set(ByVal Value As String)
                _profileMenuID = Value
            End Set
        End Property

        Public Property [ProfileID]() As String
            Get
                Return _profileID
            End Get
            Set(ByVal Value As String)
                _profileID = Value
            End Set
        End Property

        Public Property [MenuID]() As String
            Get
                Return _menuID
            End Get
            Set(ByVal Value As String)
                _menuID = Value
            End Set
        End Property

        Public Property [isAllowCreate]() As Boolean
            Get
                Return _isAllowCreate
            End Get
            Set(ByVal Value As Boolean)
                _isAllowCreate = Value
            End Set
        End Property

        Public Property [isAllowRead]() As Boolean
            Get
                Return _isAllowRead
            End Get
            Set(ByVal Value As Boolean)
                _isAllowRead = Value
            End Set
        End Property

        Public Property [isAllowUpdate]() As Boolean
            Get
                Return _isAllowUpdate
            End Get
            Set(ByVal Value As Boolean)
                _isAllowUpdate = Value
            End Set
        End Property

        Public Property [isAllowDelete]() As Boolean
            Get
                Return _isAllowDelete
            End Get
            Set(ByVal Value As Boolean)
                _isAllowDelete = Value
            End Set
        End Property

        Public Property [UserIDInsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
