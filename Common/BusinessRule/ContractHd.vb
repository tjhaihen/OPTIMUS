Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ContractHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _contractHdID, _contractNo, _customerID, _description As String
        Private _userIDinsert, _userIDupdate As String
        Private _startDate, _endDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO ContractHd " + _
                                        "(contractHdID, contractNo, customerID, description, " + _
                                        "startDate, endDate, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@contractHdID, @contractNo, @customerID, @description, " + _
                                        "@startDate, @endDate, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE()) "
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strcontractHdID As String = ID.GenerateIDNumber("ContractHd", "contractHdID")
            
            Try
                cmdToExecute.Parameters.AddWithValue("@contractHdID", strcontractHdID)
                cmdToExecute.Parameters.AddWithValue("@contractNo", _contractNo)
                cmdToExecute.Parameters.AddWithValue("@customerID", _customerID)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@startDate", _startDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", _endDate)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)
                
                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _contractHdID = strcontractHdID
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
            cmdToExecute.CommandText = "UPDATE ContractHd " + _
                                        "SET contractNo=@contractNo, customerID=@customerID, description=@description, " + _
                                        "startDate=@startDate, endDate=@endDate, userIDupdate=@userIDupdate, updateDate=GETDATE(), " + _
                                        "WHERE contractHdID=@contractHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@contractHdID", _contractHdID)
                cmdToExecute.Parameters.AddWithValue("@customerID", _customerID)
                cmdToExecute.Parameters.AddWithValue("@contractNo", _contractNo)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@startDate", _startDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", _endDate)
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
            cmdToExecute.CommandText = "SELECT * FROM ContractHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ContractHd")
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
            cmdToExecute.CommandText = "SELECT * FROM ContractHd WHERE contractHdID=@contractHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ContractHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@contractHdID", _contractHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _contractHdID = CType(toReturn.Rows(0)("contractHdID"), String)
                    _customerID = CType(toReturn.Rows(0)("customerID"), String)
                    _contractNo = CType(toReturn.Rows(0)("contractNo"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _startDate = CType(toReturn.Rows(0)("startDate"), DateTime)
                    _endDate = CType(toReturn.Rows(0)("endDate"), DateTime)
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
            cmdToExecute.CommandText = "SET XACT_ABORT ON " + _
                                        "BEGIN TRAN " + _
                                        "DELETE FROM ContractDt " + _
                                        "WHERE contractHdID=@contractHdID " + _
                                        "DELETE FROM ContractHd " + _
                                        "WHERE contractHdID=@contractHdID " + _
                                        "COMMIT TRAN"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@contractHdID", _contractHdID)

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
        Public Property [contractHdID]() As String
            Get
                Return _contractHdID
            End Get
            Set(ByVal Value As String)
                _contractHdID = Value
            End Set
        End Property

        Public Property [customerID]() As String
            Get
                Return _customerID
            End Get
            Set(ByVal Value As String)
                _customerID = Value
            End Set
        End Property

        Public Property [contractNo]() As String
            Get
                Return _contractNo
            End Get
            Set(ByVal Value As String)
                _contractNo = Value
            End Set
        End Property

        Public Property [description]() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Public Property [startDate]() As DateTime
            Get
                Return _startDate
            End Get
            Set(ByVal Value As DateTime)
                _startDate = Value
            End Set
        End Property

        Public Property [endDate]() As DateTime
            Get
                Return _endDate
            End Get
            Set(ByVal Value As DateTime)
                _endDate = Value
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
