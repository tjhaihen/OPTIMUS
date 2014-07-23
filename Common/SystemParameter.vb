Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common
    Public Class SystemParameter

#Region " Class Member Declarations "
        Private Shared _code, _caption, _remark, _value, _userIDupdate As String
        Private Shared _isSystem As Boolean
        Private Shared _updateDate As DateTime
#End Region

        Public Sub New()
        End Sub

        Public Shared Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)
            cmdToExecute.CommandText = "UPDATE SystemParameter SET value=@value, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE code=@code"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@code", _code)
                cmdToExecute.Parameters.AddWithValue("@value", _value)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

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

        Public Function GetValue(ByVal code As String) As String
            Dim retVal As String = String.Empty
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)
            cmdToExecute.CommandText = "SELECT * FROM SystemParameter WHERE code=@code"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SystemParameter")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@code", code)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _code = CType(toReturn.Rows(0)("code"), String)
                    _caption = CType(toReturn.Rows(0)("caption"), String)
                    _remark = CType(toReturn.Rows(0)("remark"), String)
                    _value = CType(toReturn.Rows(0)("value"), String)

                    retVal = _value.Trim
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

            Return retVal
        End Function

        Public Shared Function SelectOne() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)
            cmdToExecute.CommandText = "SELECT * FROM SystemParameter WHERE code=@code"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SystemParameter")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@code", _code)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _code = CType(toReturn.Rows(0)("code"), String)
                    _caption = CType(toReturn.Rows(0)("caption"), String)
                    _remark = CType(toReturn.Rows(0)("remark"), String)
                    _value = CType(toReturn.Rows(0)("value"), String)
                    _isSystem = CType(toReturn.Rows(0)("isSystem"), Boolean)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDUpdate"), String)
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

        Public Shared Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)
            cmdToExecute.CommandText = "SELECT * FROM SystemParameter"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SystemParameter")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
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

#Region " Class Property Declarations "

        Public Shared Property [Code]() As String
            Get
                Return _code
            End Get
            Set(ByVal Value As String)
                _code = Value
            End Set
        End Property

        Public Shared Property [Caption]() As String
            Get
                Return _caption
            End Get
            Set(ByVal Value As String)
                _caption = Value
            End Set
        End Property

        Public Shared Property [Remark]() As String
            Get
                Return _remark
            End Get
            Set(ByVal Value As String)
                _remark = Value
            End Set
        End Property

        Public Shared Property [Value]() As String
            Get
                Return _value
            End Get
            Set(ByVal Value As String)
                _value = Value
            End Set
        End Property

        Public Shared Property [IsSystem]() As Boolean
            Get
                Return _isSystem
            End Get
            Set(ByVal Value As Boolean)
                _isSystem = Value
            End Set
        End Property

        Public Shared Property [UserIDUpdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
            End Set
        End Property

        Public Shared Property [UpdateDate]() As DateTime
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
