Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ProductReportType
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _productReportTypeID, _productID, _reportTypeID, _reportTypeName As String
        Private _userIDinsert As String
        Private _insertDate As DateTime

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region "Insert"
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ProductReportType (ProductReportTypeID, ProductID, ReportTypeID, userIDinsert, insertDate) " & _
                                        "VALUES (@ProductReportTypeID, @ProductID, @ReportTypeID, @userIDinsert, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strProductReportTypeID As String = ID.GenerateIDNumber("ProductReportType", "ProductReportTypeID")

            Try
                cmdToExecute.Parameters.AddWithValue("@ProductReportTypeID", strProductReportTypeID)
                cmdToExecute.Parameters.AddWithValue("@ProductID", _productID)
                cmdToExecute.Parameters.AddWithValue("@ReportTypeID", _reportTypeID)
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

            cmdToExecute.CommandText = "DELETE FROM ProductReportType WHERE ProductReportTypeID=@ProductReportTypeID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProductReportTypeID", _productReportTypeID)

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

        Public Function SelectReportTypeByProductID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT pm.*, (SELECT ReportTypeName FROM ReportType WHERE ReportTypeID=pm.ReportTypeID) AS ReportTypeName FROM ProductReportType pm " + _
                                        "WHERE pm.ProductID=@ProductID ORDER BY pm.ReportTypeID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportTypeByProductID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProductID", _productID)

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

        Public Function SelectReportTypeNotInProdctReportTypeByProductID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM ReportType WHERE ReportTypeID NOT IN " & _
                                        "(SELECT ReportTypeID FROM ProductReportType WHERE ProductID=@ProductID)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportTypeNotInProdctReportTypeByProductID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProductID", _productID)

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

#Region " Class Property Declarations "

        Public Property [ProductReportTypeID]() As String
            Get
                Return _productReportTypeID
            End Get
            Set(ByVal Value As String)
                _productReportTypeID = Value
            End Set
        End Property

        Public Property [ProductID]() As String
            Get
                Return _productID
            End Get
            Set(ByVal Value As String)
                _productID = Value
            End Set
        End Property

        Public Property [ReportTypeID]() As String
            Get
                Return _reportTypeID
            End Get
            Set(ByVal Value As String)
                _reportTypeID = Value
            End Set
        End Property

        Public Property [ReportTypeName]() As String
            Get
                Return _reportTypeName
            End Get
            Set(ByVal Value As String)
                _reportTypeName = Value
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
