Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class CommonCode
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _code, _groupCode, _caption, _value As String
        Private _isDefault, _isActive, _isSystem As Boolean
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO CommonCode " + _
                                        "(code, groupCode, caption, value, " + _
                                        "isDefault, isActive, isSystem, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@code, @groupCode, @caption, @value, " + _
                                        "@isDefault, @isActive, @isSystem, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@code", _code)
                cmdToExecute.Parameters.AddWithValue("@groupCode", _groupCode)
                cmdToExecute.Parameters.AddWithValue("@caption", _caption)
                cmdToExecute.Parameters.AddWithValue("@value", _value)
                cmdToExecute.Parameters.AddWithValue("@isDefault", _isDefault)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@isSystem", _isSystem)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
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

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE CommonCode " + _
                                        "SET caption=@caption, value=@value, " + _
                                        "isDefault=@isDefault, isActive=@isActive, isSystem=@isSystem, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE code=@code and groupCode=@groupCode"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@code", _code)
                cmdToExecute.Parameters.AddWithValue("@groupCode", _groupCode)
                cmdToExecute.Parameters.AddWithValue("@caption", _caption)
                cmdToExecute.Parameters.AddWithValue("@value", _value)
                cmdToExecute.Parameters.AddWithValue("@isDefault", _isDefault)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@isSystem", _isSystem)                
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
            cmdToExecute.CommandText = "SELECT * FROM CommonCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CommonCode")
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
            cmdToExecute.CommandText = "SELECT * FROM CommonCode WHERE code=@code AND groupCode=@groupCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CommonCode")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@code", _code)
                cmdToExecute.Parameters.AddWithValue("@groupCode", _groupCode)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _code = CType(toReturn.Rows(0)("code"), String)
                    _groupCode = CType(toReturn.Rows(0)("groupCode"), String)
                    _caption = CType(toReturn.Rows(0)("caption"), String)
                    _value = CType(toReturn.Rows(0)("value"), String)
                    _isDefault = CType(toReturn.Rows(0)("isDefault"), Boolean)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
                    _isSystem = CType(toReturn.Rows(0)("isSystem"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM CommonCode " + _
                                        "WHERE code=@code AND groupCode=@groupCode"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@code", _code)
                cmdToExecute.Parameters.AddWithValue("@groupCode", _groupCode)

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

#Region " Custom "
        Public Function SelectByGroupCode() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM CommonCode WHERE groupCode=@groupCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectByGroupCode")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@groupCode", _groupCode)

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
#End Region

#Region " Class Property Declarations "
        Public Property [Code]() As String
            Get
                Return _code
            End Get
            Set(ByVal Value As String)
                _code = Value
            End Set
        End Property

        Public Property [GroupCode]() As String
            Get
                Return _groupCode
            End Get
            Set(ByVal Value As String)
                _groupCode = Value
            End Set
        End Property

        Public Property [Caption]() As String
            Get
                Return _caption
            End Get
            Set(ByVal Value As String)
                _caption = Value
            End Set
        End Property

        Public Property [Value]() As String
            Get
                Return _value
            End Get
            Set(ByVal Value As String)
                _value = Value
            End Set
        End Property

        Public Property [IsDefault]() As Boolean
            Get
                Return _isDefault
            End Get
            Set(ByVal Value As Boolean)
                _isDefault = Value
            End Set
        End Property

        Public Property [IsActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
            End Set
        End Property

        Public Property [IsSystem]() As Boolean
            Get
                Return _isSystem
            End Get
            Set(ByVal Value As Boolean)
                _isSystem = Value
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
