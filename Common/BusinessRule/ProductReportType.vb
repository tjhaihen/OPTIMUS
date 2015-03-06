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

        Public Function SelectReportTypeByProductIDWithNoProductID(ByVal _projectID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT pm.*, rt.ReportTypeCode, rt.ReportTypeName AS ReportTypeName, rt.PanelID FROM ProductReportType pm " + _
                                        "INNER JOIN ReportType rt ON pm.ReportTypeID=rt.ReportTypeID " + _
                                        "WHERE pm.ProductID=@ProductID " + _
                                        "UNION ALL " + _
                                        "SELECT 'NO PRODUCT ID' AS productReportTypeID, 'NO PRODUCT ID' AS productID, 'NO PRODUCT ID' AS reportTypeID, 'NO PRODUCT ID' AS userIDinsert, GETDATE() AS insertDate, " + _
                                        "rt.ReportTypeCode, rt.ReportTypeName, rt.PanelID FROM ReportType rt " + _
                                        "WHERE rt.ReportTypeID NOT IN (SELECT reportTypeID FROM ProductReportType) " + _
                                        "AND rt.reportTypeID IN (SELECT reportTypeID FROM ProjectReportType WHERE projectID=@projectID)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportTypeByProductIDWithNoProductID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProductID", _productID)
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)

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

        Public Function SelectReportTypeNotInProdctReportType() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM ReportType WHERE ReportTypeID NOT IN " & _
                                        "(SELECT ReportTypeID FROM ProductReportType)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportTypeNotInProdctReportType")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
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

        Public Function GetProductReportTypeByProjectID(ByVal _projectID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT DISTINCT p.productID, p.productCode, p.productName, " + _
                    "FROM ProductReportType pt " + _
                    "INNER JOIN ProjectReportType pr ON pt.reportTypeID=pr.reportTypeID " + _
                    "INNER JOIN Product p ON pt.productID=p.productID " + _
                    "WHERE pr.projectID=@ProjectID AND p.isActive=1 " +
                    "UNION ALL " + _
                    "SELECT 'NO PRODUCT ID' AS productID, 'NO PRODUCT ID' AS productCode, 'NO PRODUCT ID' AS productName "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetProductReportTypeByProjectID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
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
