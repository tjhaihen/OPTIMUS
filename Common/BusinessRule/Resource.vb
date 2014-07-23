Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Resource
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _resourceID, _resourceCode, _personID, _userID, _resourceTypeSCode, _resourceJobTitle As String
        Private _userIDinsert, _userIDupdate As String
        Private _workingSDate, _workingEDate, _insertDate, _updateDate As DateTime
        Private _isActive As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO Resource " + _
                                        "(resourceID, resourceCode, personID, userID, resourceTypeSCode, resourceJobTitle, " + _
                                        "workingSDate, workingEDate, isActive, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@resourceID, @resourceCode, @personID, @userID, @resourceTypeSCode, @resourceJobTitle, " + _
                                        "@workingSDate, @workingEDate, @isActive, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strResourceID As String = ID.GenerateIDNumber("Resource", "ResourceID")

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceID", strResourceID)
                cmdToExecute.Parameters.AddWithValue("@resourceCode", _resourceCode)
                cmdToExecute.Parameters.AddWithValue("@personID", _personID)
                cmdToExecute.Parameters.AddWithValue("@userID", _userID)
                cmdToExecute.Parameters.AddWithValue("@resourceTypeSCode", _resourceTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@resourceJobTitle", _resourceJobTitle)
                cmdToExecute.Parameters.AddWithValue("@workingSDate", _workingSDate)
                cmdToExecute.Parameters.AddWithValue("@workingEDate", _workingEDate)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _resourceID = strResourceID
                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Resource " + _
                                        "SET resourceCode=@resourceCode, userID=@userID, resourceTypeSCode=@resourceTypeSCode, resourceJobTitle=@resourceJobTitle, " + _
                                        "workingSDate=@workingSDate, workingEDate=@workingEDate, isActive=@isActive, userIDupdate=@userIDupdate, " + _
                                        "updateDate=GETDATE() " + _
                                        "WHERE resourceID=@resourceID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceID", _resourceID)
                cmdToExecute.Parameters.AddWithValue("@resourceCode", _resourceCode)                
                cmdToExecute.Parameters.AddWithValue("@userID", _userID)
                cmdToExecute.Parameters.AddWithValue("@resourceTypeSCode", _resourceTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@resourceJobTitle", _resourceJobTitle)
                cmdToExecute.Parameters.AddWithValue("@workingSDate", _workingSDate)
                cmdToExecute.Parameters.AddWithValue("@workingEDate", _workingEDate)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)                
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Resource"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Resource")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Resource WHERE resourceID=@resourceID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Resource")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceID", _resourceID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _resourceID = CType(toReturn.Rows(0)("resourceID"), String)
                    _resourceCode = CType(toReturn.Rows(0)("resourceCode"), String)
                    _personID = CType(toReturn.Rows(0)("personID"), String)
                    _userID = CType(toReturn.Rows(0)("userID"), String)
                    _resourceTypeSCode = CType(toReturn.Rows(0)("resourceTypeSCode"), String)
                    _resourceJobTitle = CType(toReturn.Rows(0)("resourceJobTitle"), String)
                    _workingSDate = CType(toReturn.Rows(0)("workingSDate"), DateTime)
                    _workingEDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("workingEDate")), DateTime)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                End If                
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM Resource " + _
                                        "WHERE resourceID=@resourceID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceID", _resourceID)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "
        Public Property [resourceID]() As String
            Get
                Return _resourceID
            End Get
            Set(ByVal Value As String)
                _resourceID = Value
            End Set
        End Property

        Public Property [resourceCode]() As String
            Get
                Return _resourceCode
            End Get
            Set(ByVal Value As String)
                _resourceCode = Value
            End Set
        End Property

        Public Property [personID]() As String
            Get
                Return _personID
            End Get
            Set(ByVal Value As String)
                _personID = Value
            End Set
        End Property

        Public Property [userID]() As String
            Get
                Return _userID
            End Get
            Set(ByVal Value As String)
                _userID = Value
            End Set
        End Property

        Public Property [resourceTypeSCode]() As String
            Get
                Return _resourceTypeSCode
            End Get
            Set(ByVal Value As String)
                _resourceTypeSCode = Value
            End Set
        End Property

        Public Property [resourceJobTitle]() As String
            Get
                Return _resourceJobTitle
            End Get
            Set(ByVal Value As String)
                _resourceJobTitle = Value
            End Set
        End Property

        Public Property [workingSDate]() As DateTime
            Get
                Return _workingSDate
            End Get
            Set(ByVal Value As DateTime)
                _workingSDate = Value
            End Set
        End Property

        Public Property [workingEDate]() As DateTime
            Get
                Return _workingEDate
            End Get
            Set(ByVal Value As DateTime)
                _workingEDate = Value
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

        Public Property [userIDinsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property

        Public Property [userIDupdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
            End Set
        End Property

        Public Property [insertDate]() As DateTime
            Get
                Return _insertDate
            End Get
            Set(ByVal Value As DateTime)
                _insertDate = Value
            End Set
        End Property

        Public Property [updateDate]() As DateTime
            Get
                Return _updateDate
            End Get
            Set(ByVal Value As DateTime)
                _updateDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
