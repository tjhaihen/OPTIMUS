Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ProjectHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _projectID, _customerID, _siteID, _projectCode, _projectName, _workOrderNo, _workLocation, _jobDescription As String
        Private _prioritySCode, _productID, _serviceName, _assetNo, _model, _serialNo, _manufacturer As String
        Private _userIDinsert, _userIDupdate As String
        Private _workOrderDate, _requiredDate, _startDate, _endDate, _expiredDate, _insertDate, _updateDate As DateTime

        Private _toDepartment, _reference, _note, _customerPIC, _companyToProvide, _customerToProvide As String
        Private _workLocationDescription, _termsAndConditions As String
        Private _requestedBy, _ackBy, _preparedBy, _checkedBy, _approvedBy As String        

        Private _isNoExpiredDate As Boolean
        Private _isProposed, _isApproval, _isDone As Boolean
        Private _proposedBy, _approvalBy, _doneBy, _warehousePIC As String
        Private _proposedDate, _approvalDate, _doneDate As DateTime

        Private _totalWorkOrder, _totalItemInspected, _totalItemAccepted, _totalItemRejected As Decimal
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
            cmdToExecute.CommandText = "INSERT INTO ProjectHd " + _
                                        "(projectID, customerID, siteID, projectCode, projectName, workOrderNo, " + _
                                        "workOrderDate, workLocation, jobDescription, requiredDate, startDate, endDate, " + _
                                        "expiredDate, isNoExpiredDate, prioritySCode, productID, serviceName, assetNo, model, serialNo, manufacturer, " + _
                                        "workLocationDescription, termsAndConditions, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate, " + _
                                        "toDepartment, reference, note, customerPIC, companyToProvide, customerToProvide, " + _
                                        "requestedBy, ackBy, preparedBy, checkedBy, approvedBy, warehousePIC, " + _
                                        "isProposed, proposedBy, isApproval, approvalBy) " + _
                                        "VALUES " + _
                                        "(@projectID, @customerID, @siteID, @projectCode, @projectName, @workOrderNo, " + _
                                        "@workOrderDate, @workLocation, @jobDescription, @requiredDate, @startDate, @endDate, " + _
                                        "@expiredDate, @isNoExpiredDate, @prioritySCode, @productID, @serviceName, @assetNo, @model, @serialNo, @manufacturer, " + _
                                        "@workLocationDescription, @termsAndConditions, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE(), " + _
                                        "@toDepartment, @reference, @note, @customerPIC, @companyToProvide, @customerToProvide, " + _
                                        "@requestedBy, @ackBy, @preparedBy, @checkedBy, @approvedBy, @warehousePIC, " + _
                                        "0, '', 0, '')"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strProjectID As String = ID.GenerateIDNumber("ProjectHd", "ProjectID")
            Dim strProjectCode As String = ID.GenerateIDNumber("ProjectHd", "ProjectCode", Common.Constants.IDPrefix.WorkRequestPrefix, "", "Y")            

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@customerID", _customerID)
                cmdToExecute.Parameters.AddWithValue("@siteID", _siteID)
                cmdToExecute.Parameters.AddWithValue("@projectCode", strProjectCode)
                cmdToExecute.Parameters.AddWithValue("@projectName", _projectName)
                cmdToExecute.Parameters.AddWithValue("@workOrderNo", _workOrderNo)
                cmdToExecute.Parameters.AddWithValue("@workOrderDate", _workOrderDate)
                cmdToExecute.Parameters.AddWithValue("@workLocation", _workLocation)
                cmdToExecute.Parameters.AddWithValue("@jobDescription", _jobDescription)
                cmdToExecute.Parameters.AddWithValue("@requiredDate", _requiredDate)
                cmdToExecute.Parameters.AddWithValue("@startDate", _startDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", _endDate)
                cmdToExecute.Parameters.AddWithValue("@expiredDate", _expiredDate)
                cmdToExecute.Parameters.AddWithValue("@isNoExpiredDate", _isNoExpiredDate)
                cmdToExecute.Parameters.AddWithValue("@prioritySCode", _prioritySCode)
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)
                cmdToExecute.Parameters.AddWithValue("@serviceName", _serviceName)
                cmdToExecute.Parameters.AddWithValue("@assetNo", _assetNo)
                cmdToExecute.Parameters.AddWithValue("@model", _model)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@manufacturer", _manufacturer)
                cmdToExecute.Parameters.AddWithValue("@workLocationDescription", _workLocationDescription)
                cmdToExecute.Parameters.AddWithValue("@termsAndConditions", _termsAndConditions)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)
                cmdToExecute.Parameters.AddWithValue("@toDepartment", _toDepartment)
                cmdToExecute.Parameters.AddWithValue("@reference", _reference)
                cmdToExecute.Parameters.AddWithValue("@note", _note)
                cmdToExecute.Parameters.AddWithValue("@customerPIC", _customerPIC)
                cmdToExecute.Parameters.AddWithValue("@companyToProvide", _companyToProvide)
                cmdToExecute.Parameters.AddWithValue("@customerToProvide", _customerToProvide)
                cmdToExecute.Parameters.AddWithValue("@requestedBy", _requestedBy)
                cmdToExecute.Parameters.AddWithValue("@ackBy", _ackBy)
                cmdToExecute.Parameters.AddWithValue("@preparedBy", _preparedBy)
                cmdToExecute.Parameters.AddWithValue("@checkedBy", _checkedBy)
                cmdToExecute.Parameters.AddWithValue("@approvedBy", _approvedBy)
                cmdToExecute.Parameters.AddWithValue("@warehousePIC", _warehousePIC)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _projectID = strProjectID
                _projectCode = strProjectCode
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
                                        "SET customerID=@customerID, siteID=@siteID, projectCode=@projectCode, " + _
                                        "projectName=@projectName, workOrderNo=@workOrderNo, workOrderDate=@workOrderDate, " + _
                                        "workLocation=@workLocation, jobDescription=@jobDescription, requiredDate=@requiredDate, " + _
                                        "expiredDate=@expiredDate, isNoExpiredDate=@isNoExpiredDate, prioritySCode=@prioritySCode, productID=@productID, " + _
                                        "serviceName=@serviceName, assetNo=@assetNo, model=@model, serialNo=@serialNo, manufacturer=@manufacturer, " + _
                                        "startDate=@startDate, endDate=@endDate, userIDupdate=@userIDupdate, updateDate=GETDATE(), " + _
                                        "toDepartment=@toDepartment, reference=@reference, note=@note, customerPIC=@customerPIC, " + _
                                        "companyToProvide=@companyToProvide, customerToProvide=@customerToProvide, " + _
                                        "workLocationDescription=@workLocationDescription, termsAndConditions=@termsAndConditions, " + _
                                        "requestedBy=@requestedBy, ackBy=@ackBy, preparedBy=@preparedBy, checkedBy=@checkedBy, " + _
                                        "approvedBy=@approvedBy, warehousePIC=@warehousePIC " + _
                                        "WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@customerID", _customerID)
                cmdToExecute.Parameters.AddWithValue("@siteID", _siteID)
                cmdToExecute.Parameters.AddWithValue("@projectCode", _projectCode)
                cmdToExecute.Parameters.AddWithValue("@projectName", _projectName)
                cmdToExecute.Parameters.AddWithValue("@workOrderNo", _workOrderNo)
                cmdToExecute.Parameters.AddWithValue("@workOrderDate", _workOrderDate)
                cmdToExecute.Parameters.AddWithValue("@workLocation", _workLocation)
                cmdToExecute.Parameters.AddWithValue("@jobDescription", _jobDescription)
                cmdToExecute.Parameters.AddWithValue("@requiredDate", _requiredDate)
                cmdToExecute.Parameters.AddWithValue("@startDate", _startDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", _endDate)
                cmdToExecute.Parameters.AddWithValue("@expiredDate", _expiredDate)
                cmdToExecute.Parameters.AddWithValue("@isNoExpiredDate", _isNoExpiredDate)
                cmdToExecute.Parameters.AddWithValue("@prioritySCode", _prioritySCode)
                cmdToExecute.Parameters.AddWithValue("@productID", _productID)
                cmdToExecute.Parameters.AddWithValue("@serviceName", _serviceName)
                cmdToExecute.Parameters.AddWithValue("@assetNo", _assetNo)
                cmdToExecute.Parameters.AddWithValue("@model", _model)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@manufacturer", _manufacturer)
                cmdToExecute.Parameters.AddWithValue("@workLocationDescription", _workLocationDescription)
                cmdToExecute.Parameters.AddWithValue("@termsAndConditions", _termsAndConditions)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)
                cmdToExecute.Parameters.AddWithValue("@toDepartment", _toDepartment)
                cmdToExecute.Parameters.AddWithValue("@reference", _reference)
                cmdToExecute.Parameters.AddWithValue("@note", _note)
                cmdToExecute.Parameters.AddWithValue("@customerPIC", _customerPIC)
                cmdToExecute.Parameters.AddWithValue("@companyToProvide", _companyToProvide)
                cmdToExecute.Parameters.AddWithValue("@customerToProvide", _customerToProvide)
                cmdToExecute.Parameters.AddWithValue("@requestedBy", _requestedBy)
                cmdToExecute.Parameters.AddWithValue("@ackBy", _ackBy)
                cmdToExecute.Parameters.AddWithValue("@preparedBy", _preparedBy)
                cmdToExecute.Parameters.AddWithValue("@checkedBy", _checkedBy)
                cmdToExecute.Parameters.AddWithValue("@approvedBy", _approvedBy)
                cmdToExecute.Parameters.AddWithValue("@warehousePIC", _warehousePIC)

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
            cmdToExecute.CommandText = "SELECT * FROM ProjectHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectHd")
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
            cmdToExecute.CommandText = "SELECT * FROM ProjectHd WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectHd")
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
                    _customerID = CType(toReturn.Rows(0)("customerID"), String)
                    _siteID = CType(toReturn.Rows(0)("siteID"), String)
                    _projectCode = CType(toReturn.Rows(0)("projectCode"), String)
                    _projectName = CType(toReturn.Rows(0)("projectName"), String)
                    _workOrderNo = CType(toReturn.Rows(0)("workOrderNo"), String)
                    _workOrderDate = CType(toReturn.Rows(0)("workOrderDate"), DateTime)
                    _workLocation = CType(toReturn.Rows(0)("workLocation"), String)
                    _jobDescription = CType(toReturn.Rows(0)("jobDescription"), String)
                    _requiredDate = CType(toReturn.Rows(0)("requiredDate"), DateTime)
                    _startDate = CType(toReturn.Rows(0)("startDate"), DateTime)
                    _endDate = CType(toReturn.Rows(0)("endDate"), DateTime)
                    _expiredDate = CType(toReturn.Rows(0)("expiredDate"), DateTime)
                    _isNoExpiredDate = CType(toReturn.Rows(0)("isNoExpiredDate"), Boolean)
                    _prioritySCode = CType(toReturn.Rows(0)("prioritySCode"), String)
                    _productID = CType(toReturn.Rows(0)("productID"), String)
                    _serviceName = CType(toReturn.Rows(0)("serviceName"), String)
                    _assetNo = CType(toReturn.Rows(0)("assetNo"), String)
                    _model = CType(toReturn.Rows(0)("model"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _manufacturer = CType(toReturn.Rows(0)("manufacturer"), String)
                    _workLocationDescription = CType(toReturn.Rows(0)("workLocationDescription"), String)
                    _termsAndConditions = CType(toReturn.Rows(0)("termsAndConditions"), String)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    _toDepartment = CType(toReturn.Rows(0)("toDepartment"), String)
                    _reference = CType(toReturn.Rows(0)("reference"), String)
                    _note = CType(toReturn.Rows(0)("note"), String)
                    _customerPIC = CType(toReturn.Rows(0)("customerPIC"), String)
                    _companyToProvide = CType(toReturn.Rows(0)("companyToProvide"), String)
                    _customerToProvide = CType(toReturn.Rows(0)("customerToProvide"), String)
                    _requestedBy = CType(toReturn.Rows(0)("requestedBy"), String)
                    _ackBy = CType(toReturn.Rows(0)("ackBy"), String)
                    _preparedBy = CType(toReturn.Rows(0)("preparedBy"), String)
                    _checkedBy = CType(toReturn.Rows(0)("checkedBy"), String)
                    _approvedBy = CType(toReturn.Rows(0)("approvedBy"), String)
                    _warehousePIC = CType(toReturn.Rows(0)("warehousePIC"), String)
                    _isProposed = CType(toReturn.Rows(0)("isProposed"), Boolean)
                    _proposedBy = CType(toReturn.Rows(0)("proposedBy"), String)
                    _proposedDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("proposedDate")), DateTime)
                    _isApproval = CType(toReturn.Rows(0)("isApproval"), Boolean)
                    _approvalBy = CType(toReturn.Rows(0)("approvalBy"), String)
                    _approvalDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("approvalDate")), DateTime)
                    _isDone = CType(toReturn.Rows(0)("isDone"), Boolean)
                    _doneBy = CType(toReturn.Rows(0)("doneBy"), String)
                    _doneDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("doneDate")), DateTime)
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
                                        "DELETE FROM ProjectDt " + _
                                        "WHERE projectID=@projectID " + _
                                        "DELETE FROM ProjectReportType " + _
                                        "WHERE projectID=@projectID " + _
                                        "DELETE FROM ProjectResource " + _
                                        "WHERE projectID=@projectID " + _
                                        "DELETE FROM ProjectHd " + _
                                        "WHERE projectID=@projectID " + _
                                        "COMMIT TRAN"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)

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
        Public Function GetCustomerInspectionInformation(ByVal strCustomerID As String, ByVal strInformationType As String, ByVal intValue As Integer) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_CustomerInspectionInformation"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("sp_CustomerInspectionInformation")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", strCustomerID)
                cmdToExecute.Parameters.AddWithValue("@informationType", strInformationType)
                cmdToExecute.Parameters.AddWithValue("@value", intValue)

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

        Public Function GetInspectionInformation(ByVal strCustomerID As String, ByVal strWRStatus As String, ByVal intValue As Integer) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_InspectionInformation"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("sp_InspectionInformation")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", strCustomerID)
                cmdToExecute.Parameters.AddWithValue("@WRStatus", strWRStatus)
                cmdToExecute.Parameters.AddWithValue("@value", intValue)

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

        Public Function GetTotalInspectionByCustomer(ByVal strCustomerID As String, ByVal startDate As Date, ByVal endDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_GetTotalInspectionByCustomerID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("sp_GetTotalInspectionByCustomerID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", strCustomerID)
                cmdToExecute.Parameters.AddWithValue("@startDate", startDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", endDate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _totalWorkOrder = CType(toReturn.Rows(0)("TotalWorkOrder"), Decimal)
                    _totalItemInspected = CType(toReturn.Rows(0)("TotalItemInspected"), Decimal)
                    _totalItemAccepted = CType(toReturn.Rows(0)("TotalItemAccepted"), Decimal)
                    _totalItemRejected = CType(toReturn.Rows(0)("TotalItemRejected"), Decimal)
                Else
                    _totalWorkOrder = 0
                    _totalItemInspected = 0
                    _totalItemAccepted = 0
                    _totalItemRejected = 0
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

        Public Function GetListOfItemDueToExpiredInspectionByCustomer(ByVal strCustomerID As String, ByVal strInformationType As String, ByVal intValue As Integer, ByVal startDate As Date, ByVal endDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case strInformationType
                Case "Due"
                    cmdToExecute.CommandText = "sp_GetListOfItemDueToExpiredInspectionByCustomerID"
                Case Else
                    cmdToExecute.CommandText = "sp_GetListOfItemInspectionByCustomerID"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("sp_GetListOfItemInspectionByCustomerID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", strCustomerID)
                Select Case strInformationType
                    Case "Due"
                        cmdToExecute.Parameters.AddWithValue("@value", intValue)
                    Case Else
                        cmdToExecute.Parameters.AddWithValue("@startDate", startDate)
                        cmdToExecute.Parameters.AddWithValue("@endDate", endDate)
                End Select                

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

        Public Function GetListOfInspectionByCustomerIDSerialIDNo(ByVal strCustomerID As String, ByVal strSerialIDNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_GetListOfInspectionByCustomerIDSerialIDNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("sp_GetListOfInspectionByCustomerIDSerialIDNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", strCustomerID)
                cmdToExecute.Parameters.AddWithValue("@serialIDNo", strSerialIDNo)

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

        Public Function GetWorkRequestListByStatus(ByVal doneStatus As String, Optional ByVal searchText As String = "", Optional ByVal intValue As Integer = 50, Optional ByVal strCustomerID As String = "") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_WorkRequest"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("sp_WorkRequest")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@doneStatus", doneStatus)
                cmdToExecute.Parameters.AddWithValue("@searchText", searchText)
                cmdToExecute.Parameters.AddWithValue("@value", intValue)
                cmdToExecute.Parameters.AddWithValue("@customerID", strCustomerID)

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

        Public Function UpdateProposed() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE ProjectHd " + _
                                        "SET isProposed=@isProposed, proposedBy=@proposedBy, proposedDate=GETDATE() " + _
                                        "WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@isProposed", _isProposed)
                cmdToExecute.Parameters.AddWithValue("@proposedBy", _proposedBy)

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

        Public Function UpdateApproval() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE ProjectHd " + _
                                        "SET isApproval=@isApproval, approvalBy=@approvalBy, approvalDate=GETDATE() " + _
                                        "WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@isApproval", _isApproval)
                cmdToExecute.Parameters.AddWithValue("@approvalBy", _approvalBy)

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

        Public Function UpdateDone() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE ProjectHd " + _
                                        "SET isDone=@isDone, doneBy=@doneBy, doneDate=GETDATE() " + _
                                        "WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@isDone", _isDone)
                cmdToExecute.Parameters.AddWithValue("@doneBy", _doneBy)

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

        Public Property [customerID]() As String
            Get
                Return _customerID
            End Get
            Set(ByVal Value As String)
                _customerID = Value
            End Set
        End Property

        Public Property [siteID]() As String
            Get
                Return _siteID
            End Get
            Set(ByVal Value As String)
                _siteID = Value
            End Set
        End Property

        Public Property [projectCode]() As String
            Get
                Return _projectCode
            End Get
            Set(ByVal Value As String)
                _projectCode = Value
            End Set
        End Property

        Public Property [projectName]() As String
            Get
                Return _projectName
            End Get
            Set(ByVal Value As String)
                _projectName = Value
            End Set
        End Property

        Public Property [workOrderNo]() As String
            Get
                Return _workOrderNo
            End Get
            Set(ByVal Value As String)
                _workOrderNo = Value
            End Set
        End Property

        Public Property [workOrderDate]() As DateTime
            Get
                Return _workOrderDate
            End Get
            Set(ByVal Value As DateTime)
                _workOrderDate = Value
            End Set
        End Property

        Public Property [requiredDate]() As DateTime
            Get
                Return _requiredDate
            End Get
            Set(ByVal Value As DateTime)
                _requiredDate = Value
            End Set
        End Property

        Public Property [workLocation]() As String
            Get
                Return _workLocation
            End Get
            Set(ByVal Value As String)
                _workLocation = Value
            End Set
        End Property

        Public Property [jobDescription]() As String
            Get
                Return _jobDescription
            End Get
            Set(ByVal Value As String)
                _jobDescription = Value
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

        Public Property [expiredDate]() As DateTime
            Get
                Return _expiredDate
            End Get
            Set(ByVal Value As DateTime)
                _expiredDate = Value
            End Set
        End Property

        Public Property [isNoExpiredDate]() As Boolean
            Get
                Return _isNoExpiredDate
            End Get
            Set(ByVal Value As Boolean)
                _isNoExpiredDate = Value
            End Set
        End Property

        Public Property [prioritySCode]() As String
            Get
                Return _prioritySCode
            End Get
            Set(ByVal Value As String)
                _prioritySCode = Value
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

        Public Property [serviceName]() As String
            Get
                Return _serviceName
            End Get
            Set(ByVal Value As String)
                _serviceName = Value
            End Set
        End Property

        Public Property [assetNo]() As String
            Get
                Return _assetNo
            End Get
            Set(ByVal Value As String)
                _assetNo = Value
            End Set
        End Property

        Public Property [model]() As String
            Get
                Return _model
            End Get
            Set(ByVal Value As String)
                _model = Value
            End Set
        End Property

        Public Property [serialNo]() As String
            Get
                Return _serialNo
            End Get
            Set(ByVal Value As String)
                _serialNo = Value
            End Set
        End Property

        Public Property [manufacturer]() As String
            Get
                Return _manufacturer
            End Get
            Set(ByVal Value As String)
                _manufacturer = Value
            End Set
        End Property

        Public Property [workLocationDescription]() As String
            Get
                Return _workLocationDescription
            End Get
            Set(ByVal Value As String)
                _workLocationDescription = Value
            End Set
        End Property

        Public Property [termsAndConditions]() As String
            Get
                Return _termsAndConditions
            End Get
            Set(ByVal Value As String)
                _termsAndConditions = Value
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

        Public Property [toDepartment]() As String
            Get
                Return _toDepartment
            End Get
            Set(ByVal Value As String)
                _toDepartment = Value
            End Set
        End Property

        Public Property [reference]() As String
            Get
                Return _reference
            End Get
            Set(ByVal Value As String)
                _reference = Value
            End Set
        End Property

        Public Property [note]() As String
            Get
                Return _note
            End Get
            Set(ByVal Value As String)
                _note = Value
            End Set
        End Property

        Public Property [customerPIC]() As String
            Get
                Return _customerPIC
            End Get
            Set(ByVal Value As String)
                _customerPIC = Value
            End Set
        End Property

        Public Property [companyToProvide]() As String
            Get
                Return _companyToProvide
            End Get
            Set(ByVal Value As String)
                _companyToProvide = Value
            End Set
        End Property

        Public Property [customerToProvide]() As String
            Get
                Return _customerToProvide
            End Get
            Set(ByVal Value As String)
                _customerToProvide = Value
            End Set
        End Property

        Public Property [requestedBy]() As String
            Get
                Return _requestedBy
            End Get
            Set(ByVal Value As String)
                _requestedBy = Value
            End Set
        End Property

        Public Property [ackBy]() As String
            Get
                Return _ackBy
            End Get
            Set(ByVal Value As String)
                _ackBy = Value
            End Set
        End Property

        Public Property [preparedBy]() As String
            Get
                Return _preparedBy
            End Get
            Set(ByVal Value As String)
                _preparedBy = Value
            End Set
        End Property

        Public Property [checkedBy]() As String
            Get
                Return _checkedBy
            End Get
            Set(ByVal Value As String)
                _checkedBy = Value
            End Set
        End Property

        Public Property [approvedBy]() As String
            Get
                Return _approvedBy
            End Get
            Set(ByVal Value As String)
                _approvedBy = Value
            End Set
        End Property

        Public Property [warehousePIC]() As String
            Get
                Return _warehousePIC
            End Get
            Set(ByVal Value As String)
                _warehousePIC = Value
            End Set
        End Property

        Public Property [isProposed]() As Boolean
            Get
                Return _isProposed
            End Get
            Set(ByVal Value As Boolean)
                _isProposed = Value
            End Set
        End Property

        Public Property [isApproval]() As Boolean
            Get
                Return _isApproval
            End Get
            Set(ByVal Value As Boolean)
                _isApproval = Value
            End Set
        End Property

        Public Property [isDone]() As Boolean
            Get
                Return _isDone
            End Get
            Set(ByVal Value As Boolean)
                _isDone = Value
            End Set
        End Property

        Public Property [proposedBy]() As String
            Get
                Return _proposedBy
            End Get
            Set(ByVal Value As String)
                _proposedBy = Value
            End Set
        End Property

        Public Property [approvalBy]() As String
            Get
                Return _approvalBy
            End Get
            Set(ByVal Value As String)
                _approvalBy = Value
            End Set
        End Property

        Public Property [doneBy]() As String
            Get
                Return _doneBy
            End Get
            Set(ByVal Value As String)
                _doneBy = Value
            End Set
        End Property

        Public Property [proposedDate]() As DateTime
            Get
                Return _proposedDate
            End Get
            Set(ByVal Value As DateTime)
                _proposedDate = Value
            End Set
        End Property

        Public Property [approvalDate]() As DateTime
            Get
                Return _approvalDate
            End Get
            Set(ByVal Value As DateTime)
                _approvalDate = Value
            End Set
        End Property

        Public Property [doneDate]() As DateTime
            Get
                Return _doneDate
            End Get
            Set(ByVal Value As DateTime)
                _doneDate = Value
            End Set
        End Property

#Region " Customer Information "
        Public Property [totalWorkOrder]() As Decimal
            Get
                Return _totalWorkOrder
            End Get
            Set(ByVal Value As Decimal)
                _totalWorkOrder = Value
            End Set
        End Property

        Public Property [totalItemInspected]() As Decimal
            Get
                Return _totalItemInspected
            End Get
            Set(ByVal Value As Decimal)
                _totalItemInspected = Value
            End Set
        End Property

        Public Property [totalItemAccepted]() As Decimal
            Get
                Return _totalItemAccepted
            End Get
            Set(ByVal Value As Decimal)
                _totalItemAccepted = Value
            End Set
        End Property

        Public Property [totalItemRejected]() As Decimal
            Get
                Return _totalItemRejected
            End Get
            Set(ByVal Value As Decimal)
                _totalItemRejected = Value
            End Set
        End Property
#End Region
#End Region

    End Class
End Namespace
