Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Product
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _productID, _productCode, _parentProductCode, _productName As String
        Private _userIDinsert, _userIDupdate As String        
        Private _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO Product " + _
                                        "(productID, productCode, parentProductCode, productName, " + _
                                        "isActive, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@productID, @productCode, @parentProductCode, @productName, " + _
                                        "@isActive, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strProductID As String = ID.GenerateIDNumber("Product", "ProductID")

            Try
                cmdToExecute.Parameters.AddWithValue("@productID", strProductID)
                cmdToExecute.Parameters.AddWithValue("@productCode", _productCode)
                cmdToExecute.Parameters.AddWithValue("@parentProductCode", _parentProductCode)
                cmdToExecute.Parameters.AddWithValue("@productName", _productName)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _productID = strProductID
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
            cmdToExecute.CommandText = "UPDATE Product " + _
                                        "SET productCode=@productCode, parentProductCode=@parentProductCode, productName=@productName, " + _
                                        "isActive=@isActive, userIDupdate=@userIDupdate, " + _
                                        "updateDate=GETDATE() " + _
                                        "WHERE productID=@productID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)
                cmdToExecute.Parameters.AddWithValue("@productCode", _productCode)
                cmdToExecute.Parameters.AddWithValue("@parentProductCode", _parentProductCode)
                cmdToExecute.Parameters.AddWithValue("@productName", _productName)
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
            cmdToExecute.CommandText = "SELECT * FROM Product ORDER BY ProductCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Product")
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
            cmdToExecute.CommandText = "SELECT * FROM Product WHERE productID=@productID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Product")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _productID = CType(toReturn.Rows(0)("productID"), String)
                    _productCode = CType(toReturn.Rows(0)("productCode"), String)
                    _parentProductCode = CType(toReturn.Rows(0)("parentProductCode"), String)
                    _productName = CType(toReturn.Rows(0)("productName"), String)
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
            cmdToExecute.CommandText = "DELETE FROM Product " + _
                                        "WHERE productID=@productID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)
                
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
        Public Property [productID]() As String
            Get
                Return _productID
            End Get
            Set(ByVal Value As String)
                _productID = Value
            End Set
        End Property

        Public Property [productCode]() As String
            Get
                Return _productCode
            End Get
            Set(ByVal Value As String)
                _productCode = Value
            End Set
        End Property

        Public Property [parentProductCode]() As String
            Get
                Return _parentProductCode
            End Get
            Set(ByVal Value As String)
                _parentProductCode = Value
            End Set
        End Property

        Public Property [productName]() As String
            Get
                Return _productName
            End Get
            Set(ByVal Value As String)
                _productName = Value
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
