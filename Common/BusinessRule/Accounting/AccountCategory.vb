Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class AccountCategory
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _accountCategoryID, _accountCategoryName, _normalBalance As String
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
            cmdToExecute.CommandText = "INSERT INTO accAccountCategory " + _
                                        "(accountCategoryID, accountCategoryName, normalBalance) " + _
                                        "VALUES " + _
                                        "(@accountCategoryID, @accountCategoryName, @normalBalance)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("accAccountCategory", "accountCategoryID")

            Try
                cmdToExecute.Parameters.AddWithValue("@accountCategoryID", strID)
                cmdToExecute.Parameters.AddWithValue("@accountCategoryName", _accountCategoryName)
                cmdToExecute.Parameters.AddWithValue("@normalBalance", _normalBalance)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _accountCategoryID = strID
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
            cmdToExecute.CommandText = "UPDATE accAccountCategory " + _
                                        "SET accountCategoryName=@accountCategoryName, " + _
                                        "normalBalance = @normalBalance " + _
                                        "WHERE accountCategoryID=@accountCategoryID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@accountCategoryID", _accountCategoryID)
                cmdToExecute.Parameters.AddWithValue("@accountCategoryName", _accountCategoryName)
                cmdToExecute.Parameters.AddWithValue("@normalBalance", _normalBalance)

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
            cmdToExecute.CommandText = "SELECT * FROM accAccountCategory ORDER BY accountCategoryName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accAccountCategory")
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
            cmdToExecute.CommandText = "SELECT * FROM accAccountCategory WHERE accountCategoryID=@accountCategoryID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accAccountCategory")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@accountCategoryID", _accountCategoryID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _accountCategoryID = CType(toReturn.Rows(0)("accountCategoryID"), String)
                    _accountCategoryName = CType(toReturn.Rows(0)("accountCategoryName"), String)
                    _normalBalance = CType(toReturn.Rows(0)("normalBalance"), String)
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
            cmdToExecute.CommandText = "DELETE FROM accAccountCategory " + _
                                        "WHERE accountCategoryID=@accountCategoryID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@accountCategoryID", _accountCategoryID)

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
        Public Property [accountCategoryID]() As String
            Get
                Return _accountCategoryID
            End Get
            Set(ByVal Value As String)
                _accountCategoryID = Value
            End Set
        End Property

        Public Property [accountCategoryName]() As String
            Get
                Return _accountCategoryName
            End Get
            Set(ByVal Value As String)
                _accountCategoryName = Value
            End Set
        End Property

        Public Property [normalBalance]() As String
            Get
                Return _normalBalance
            End Get
            Set(ByVal Value As String)
                _normalBalance = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
