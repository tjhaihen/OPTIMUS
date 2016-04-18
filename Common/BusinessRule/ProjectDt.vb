Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ProjectDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _projectID, _projectDtID, _description, _descriptionDetail, _referenceNo, _unitOfMeasurement, _productID As String
        Private _qty, _qtyActual As Decimal
        Private _isOther As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO ProjectDt " + _
                                        "(projectID, projectDtID, description, descriptionDetail, referenceNo, " + _
                                        "qty, unitOfMeasurement, productID, isOther, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@projectID, @projectDtID, @description, @descriptionDetail, @referenceNo, " + _
                                        "@qty, @unitOfMeasurement, @productID, @isOther, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strProjectDtID As String = ID.GenerateIDNumber("ProjectDt", "ProjectDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@projectDtID", strProjectDtID)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@descriptionDetail", _descriptionDetail)
                cmdToExecute.Parameters.AddWithValue("@referenceNo", _referenceNo)
                cmdToExecute.Parameters.AddWithValue("@qty", _qty)                
                cmdToExecute.Parameters.AddWithValue("@unitOfMeasurement", _unitOfMeasurement)
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)
                cmdToExecute.Parameters.AddWithValue("@isOther", _isOther)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _projectDtID = strProjectDtID
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
                                        "WHERE projectDtID=@projectDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try                
                cmdToExecute.Parameters.AddWithValue("@projectDtID", _projectDtID)
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
            cmdToExecute.CommandText = "SELECT * FROM ProjectDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectDt")
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
            cmdToExecute.CommandText = "SELECT * FROM ProjectDt WHERE projectDtID=@projectDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Project")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _projectDtID = CType(toReturn.Rows(0)("projectDtID"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _descriptionDetail = CType(toReturn.Rows(0)("descriptionDetail"), String)
                    _referenceNo = CType(toReturn.Rows(0)("referenceNo"), String)
                    _qty = CType(toReturn.Rows(0)("qty"), Decimal)
                    _qtyActual = CType(toReturn.Rows(0)("qtyActual"), Decimal)
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
            cmdToExecute.CommandText = "DELETE FROM ProjectDt " + _
                                        "WHERE projectDtID=@projectDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectDtID", _projectDtID)

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
        Public Function SelectByProjectID(Optional ByVal _isIncludeOther As Boolean = False) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT dt.*, ISNULL((SELECT productName FROM product WHERE productID=dt.productID),'') AS productName FROM ProjectDt dt WHERE dt.ProjectID=@ProjectID"
            If _isIncludeOther = False Then
                cmdToExecute.CommandText += " AND dt.isOther=0"
            End If
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)

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

        Public Function UpdateQtyActual() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE ProjectDt " + _
                                        "SET qtyActual=@qtyActual, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE projectDtID=@projectDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectDtID", _projectDtID)
                cmdToExecute.Parameters.AddWithValue("@qtyActual", _qtyActual)
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
#End Region

#Region " Class Property Declarations "
        Public Property [projectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
            End Set
        End Property

        Public Property [projectDetailID]() As String
            Get
                Return _projectDtID
            End Get
            Set(ByVal Value As String)
                _projectDtID = Value
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

        Public Property [qtyActual]() As Decimal
            Get
                Return _qtyActual
            End Get
            Set(ByVal Value As Decimal)
                _qtyActual = Value
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

        Public Property [isOther]() As Boolean
            Get
                Return _isOther
            End Get
            Set(ByVal Value As Boolean)
                _isOther = Value
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
