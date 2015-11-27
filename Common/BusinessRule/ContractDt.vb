Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ContractDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _contractHdID, _contractDtID, _description, _descriptionDetail, _referenceNo, _unitOfMeasurement, _productID As String
        Private _qty As Decimal
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
            cmdToExecute.CommandText = "INSERT INTO ContractDt " + _
                                        "(contractHdID, contractDtID, description, descriptionDetail, referenceNo, " + _
                                        "qty, unitOfMeasurement, productID, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@contractHdID, @contractDtID, @description, @descriptionDetail, @referenceNo, " + _
                                        "@qty, @unitOfMeasurement, @productID, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strcontractDtID As String = ID.GenerateIDNumber("ContractDt", "contractDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@contractHdID", _contractHdID)
                cmdToExecute.Parameters.AddWithValue("@contractDtID", strcontractDtID)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@descriptionDetail", _descriptionDetail)
                cmdToExecute.Parameters.AddWithValue("@referenceNo", _referenceNo)
                cmdToExecute.Parameters.AddWithValue("@qty", _qty)
                cmdToExecute.Parameters.AddWithValue("@unitOfMeasurement", _unitOfMeasurement)
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _ContractDtID = strcontractDtID
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
            cmdToExecute.CommandText = "UPDATE ProjectHd " + _
                                        "SET description=@description, descriptionDetail=@descriptionDetail, referenceNo=@referenceNo, " + _
                                        "qty=@qty, unitOfMeasurement=@unitOfMeasurement, productID=@productID, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE contractDtID=@contractDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@contractDtID", _ContractDtID)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@descriptionDetail", _descriptionDetail)
                cmdToExecute.Parameters.AddWithValue("@referenceNo", _referenceNo)
                cmdToExecute.Parameters.AddWithValue("@qty", _qty)
                cmdToExecute.Parameters.AddWithValue("@unitOfMeasurement", _unitOfMeasurement)
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)
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
            cmdToExecute.CommandText = "SELECT * FROM ContractDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ContractDt")
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
            cmdToExecute.CommandText = "SELECT * FROM ContractDt WHERE contractDtID=@contractDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Project")
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
                    _ContractDtID = CType(toReturn.Rows(0)("contractDtID"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _descriptionDetail = CType(toReturn.Rows(0)("descriptionDetail"), String)
                    _referenceNo = CType(toReturn.Rows(0)("referenceNo"), String)
                    _qty = CType(toReturn.Rows(0)("qty"), Decimal)
                    _unitOfMeasurement = CType(toReturn.Rows(0)("unitOfMeasurement"), String)
                    _productID = CType(toReturn.Rows(0)("productID"), String)
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
            cmdToExecute.CommandText = "DELETE FROM ContractDt " + _
                                        "WHERE contractDtID=@contractDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@contractDtID", _ContractDtID)

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

#Region " Custom Function "
        Public Function SelectByContractHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT dt.*, (SELECT productName FROM product WHERE productID=dt.productID) AS productName FROM ContractDt dt WHERE dt.contractHdID=@contractHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ContractDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@contractHdID", _contractHdID)

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
        Public Property [contractHdID]() As String
            Get
                Return _contractHdID
            End Get
            Set(ByVal Value As String)
                _contractHdID = Value
            End Set
        End Property

        Public Property [contractDtID]() As String
            Get
                Return _contractDtID
            End Get
            Set(ByVal Value As String)
                _contractDtID = Value
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

        Public Property [descriptionDetail]() As String
            Get
                Return _descriptionDetail
            End Get
            Set(ByVal Value As String)
                _descriptionDetail = Value
            End Set
        End Property

        Public Property [qty]() As Decimal
            Get
                Return _qty
            End Get
            Set(ByVal Value As Decimal)
                _qty = Value
            End Set
        End Property

        Public Property [referenceNo]() As String
            Get
                Return _referenceNo
            End Get
            Set(ByVal Value As String)
                _referenceNo = Value
            End Set
        End Property

        Public Property [unitOfMeasurement]() As String
            Get
                Return _unitOfMeasurement
            End Get
            Set(ByVal Value As String)
                _unitOfMeasurement = Value
            End Set
        End Property

        Public Property [productID]() As String
            Get
                Return _productID
            End Get
            Set(ByVal Value As String)
                _productID = Value
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
