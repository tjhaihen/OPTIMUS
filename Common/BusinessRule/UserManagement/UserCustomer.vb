Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class UserCustomer
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _UserCustomerID, _CustomerID, _UserID As String        
        Private _UserIDInsert As String

#End Region

        Public Sub New()
            ConnectionString = SysConfig.ConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO UserCustomer " + _
                                        "(userCustomerID, userID, CustomerID, " + _
                                        "userIDinsert, insertDate) " + _
                                        "VALUES " + _
                                        "(@userCustomerID, @userID, @CustomerID, " + _
                                        "@userIDinsert, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strUserCustomerID As String = ID.GenerateIDNumber("UserCustomer", "userCustomerID")

            Try
                cmdToExecute.Parameters.AddWithValue("@userCustomerID", strUserCustomerID)
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@CustomerID", _CustomerID)                
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _UserIDInsert)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _UserCustomerID = strUserCustomerID
                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM UserCustomer " + _
                                        "WHERE UserCustomerID=@UserCustomerID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserCustomerID", _UserCustomerID)

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

#Region " Custom Functions "
        Public Function SelectCustomerByUserID(ByVal UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT us.*, (SELECT CustomerName FROM Customer WHERE CustomerID=us.CustomerID) AS CustomerName FROM UserCustomer us " + _
                                        "WHERE us.UserID=@UserID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("CustomerByUserID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", UserID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _CustomerID = CType(toReturn.Rows(0)("customerID"), String)
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

        Public Function SelectCustomerNotInUserCustomerByUserID(ByVal UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Customer WHERE CustomerID NOT IN (SELECT CustomerID FROM UserCustomer WHERE UserID=@UserID)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("CustomerNotInUserCustomerByUserID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", UserID)

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

#Region " Class Property Declarations "
        Public Property [UserCustomerID]() As String
            Get
                Return _UserCustomerID
            End Get
            Set(ByVal Value As String)
                _UserCustomerID = Value
            End Set
        End Property

        Public Property [UserID]() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        Public Property [CustomerID]() As String
            Get
                Return _CustomerID
            End Get
            Set(ByVal Value As String)
                _CustomerID = Value
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
#End Region

    End Class
End Namespace
