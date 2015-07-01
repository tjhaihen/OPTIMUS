Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class SummaryOfInspection
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _summaryOfInspectionID, _projectID, _sequenceNo, _descriptionOfEquipment, _serialIDNo, _location, _manufacture, _SWL_WWL_MGW, _
            _dimensional, _defectFound, _result, _reportNo, _typeOfInspectionSCode, _interval, _remarks, _detailReportSection, _
            _userIDinsert, _userIDupdate, _approvalBy, _fileName, _fileExtension As String
        Private _inspectorName, _reportNo_1 As String
        Private _isToiV, _isToiN, _isToiT, _isApproval As Boolean
        Private _isDS1CAT3to5, _isDS1CAT4, _isAPISPEC7, _isAPIRP7G, _isHardbanding, _isIntExtCleaning, _isUTSlipUpsetArea As Boolean
        Private _examDate, _expireDate, _insertDate, _updateDate, _approvalDate As DateTime
        
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
            cmdToExecute.CommandText = "INSERT INTO SummaryOfInspection " + _
                                        "(summaryOfInspectionID, projectID, sequenceNo, descriptionOfEquipment, serialIDNo, location, " + _
                                        "manufacture, SWL_WWL_MGW, dimensional, defectFound, result, reportNo,  " + _
                                        "typeOfInspectionSCode, isToiV, isToiN, isToiT, interval, remarks, detailReportSection,  " + _
                                        "examDate, expireDate, fileName, fileExtension, " + _
                                        "inspectorName, reportNo_1, " + _
                                        "isDS1CAT3to5, isDS1CAT4, isAPISPEC7, isAPIRP7G, isHardbanding, isIntExtCleaning, isUTSlipUpsetArea, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@summaryOfInspectionID, @projectID, @sequenceNo, @descriptionOfEquipment, @serialIDNo, @location, " + _
                                        "@manufacture, @SWL_WWL_MGW, @dimensional, @defectFound, @result, @reportNo,  " + _
                                        "@typeOfInspectionSCode, @isToiV, @isToiN, @isToiT, @interval, @remarks, @detailReportSection,  " + _
                                        "@examDate, @expireDate, @fileName, @fileExtension, " + _
                                        "@inspectorName, @reportNo_1, " + _
                                        "@isDS1CAT3to5, @isDS1CAT4, @isAPISPEC7, @isAPIRP7G, @isHardbanding, @isIntExtCleaning, @isUTSlipUpsetArea, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strSummaryOfInspectionID As String = ID.GenerateIDNumber("SummaryOfInspection", "summaryOfInspectionID")

            Try
                cmdToExecute.Parameters.AddWithValue("@summaryOfInspectionID", strSummaryOfInspectionID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@descriptionOfEquipment", _descriptionOfEquipment)
                cmdToExecute.Parameters.AddWithValue("@serialIDNo", _serialIDNo)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@manufacture", _manufacture)
                cmdToExecute.Parameters.AddWithValue("@SWL_WWL_MGW", _SWL_WWL_MGW)
                cmdToExecute.Parameters.AddWithValue("@dimensional", _dimensional)
                cmdToExecute.Parameters.AddWithValue("@defectFound", _defectFound)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspectionSCode", _typeOfInspectionSCode)
                cmdToExecute.Parameters.AddWithValue("@isToiV", _isToiV)
                cmdToExecute.Parameters.AddWithValue("@isToiN", _isToiN)
                cmdToExecute.Parameters.AddWithValue("@isToiT", _isToiT)
                cmdToExecute.Parameters.AddWithValue("@interval", _interval)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@detailReportSection", _detailReportSection)
                cmdToExecute.Parameters.AddWithValue("@examDate", _examDate)
                cmdToExecute.Parameters.AddWithValue("@expireDate", _expireDate)
                cmdToExecute.Parameters.AddWithValue("@fileName", _fileName)
                cmdToExecute.Parameters.AddWithValue("@fileExtension", _fileExtension)
                cmdToExecute.Parameters.AddWithValue("@inspectorName", _inspectorName)
                cmdToExecute.Parameters.AddWithValue("@reportNo_1", _reportNo_1)
                cmdToExecute.Parameters.AddWithValue("@isDS1CAT3to5", _isDS1CAT3to5)
                cmdToExecute.Parameters.AddWithValue("@isDS1CAT4", _isDS1CAT4)
                cmdToExecute.Parameters.AddWithValue("@isAPISPEC7", _isAPISPEC7)
                cmdToExecute.Parameters.AddWithValue("@isAPIRP7G", _isAPIRP7G)
                cmdToExecute.Parameters.AddWithValue("@isHardbanding", _isHardbanding)
                cmdToExecute.Parameters.AddWithValue("@isIntExtCleaning", _isIntExtCleaning)
                cmdToExecute.Parameters.AddWithValue("@isUTSlipUpsetArea", _isUTSlipUpsetArea)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _summaryOfInspectionID = strSummaryOfInspectionID
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
            cmdToExecute.CommandText = "UPDATE SummaryOfInspection " + _
                                        "SET sequenceNo=@sequenceNo, descriptionOfEquipment=@descriptionOfEquipment, serialIDNo=@serialIDNo, " + _
                                        "location=@location, manufacture=@manufacture, SWL_WWL_MGW=@SWL_WWL_MGW, " + _
                                        "dimensional=@dimensional, defectFound=@defectFound, result=@result, reportNo=@reportNo, " + _
                                        "typeOfInspectionSCode=@typeOfInspectionSCode, isToiV=@isToiV, isToiN=@isToiN, isToiT=@isToiT, " +
                                        "interval=@interval, remarks=@remarks, detailReportSection=@detailReportSection, " + _
                                        "examDate=@examDate, expireDate=@expireDate, " + _
                                        "fileName=@fileName, fileExtension=@fileExtension, " + _
                                        "inspectorName=@inspectorName, reportNo_1=@reportNo_1, isDS1CAT3to5=@isDS1CAT3to5, " + _
                                        "isDS1CAT4=@isDS1CAT4, isAPISPEC7=@isAPISPEC7, isAPIRP7G=@isAPIRP7G, " + _
                                        "isHardbanding=@isHardbanding, isIntExtCleaning=@isIntExtCleaning, isUTSlipUpsetArea=@isUTSlipUpsetArea, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE summaryOfInspectionID=@summaryOfInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@summaryOfInspectionID", _summaryOfInspectionID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@descriptionOfEquipment", _descriptionOfEquipment)
                cmdToExecute.Parameters.AddWithValue("@serialIDNo", _serialIDNo)
                cmdToExecute.Parameters.AddWithValue("@location", _location)
                cmdToExecute.Parameters.AddWithValue("@manufacture", _manufacture)
                cmdToExecute.Parameters.AddWithValue("@SWL_WWL_MGW", _SWL_WWL_MGW)
                cmdToExecute.Parameters.AddWithValue("@dimensional", _dimensional)
                cmdToExecute.Parameters.AddWithValue("@defectFound", _defectFound)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@typeOfInspectionSCode", _typeOfInspectionSCode)
                cmdToExecute.Parameters.AddWithValue("@isToiV", _isToiV)
                cmdToExecute.Parameters.AddWithValue("@isToiN", _isToiN)
                cmdToExecute.Parameters.AddWithValue("@isToiT", _isToiT)
                cmdToExecute.Parameters.AddWithValue("@interval", _interval)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@detailReportSection", _detailReportSection)
                cmdToExecute.Parameters.AddWithValue("@examDate", _examDate)
                cmdToExecute.Parameters.AddWithValue("@expireDate", _expireDate)
                cmdToExecute.Parameters.AddWithValue("@fileName", _fileName)
                cmdToExecute.Parameters.AddWithValue("@fileExtension", _fileExtension)
                cmdToExecute.Parameters.AddWithValue("@inspectorName", _inspectorName)
                cmdToExecute.Parameters.AddWithValue("@reportNo_1", _reportNo_1)
                cmdToExecute.Parameters.AddWithValue("@isDS1CAT3to5", _isDS1CAT3to5)
                cmdToExecute.Parameters.AddWithValue("@isDS1CAT4", _isDS1CAT4)
                cmdToExecute.Parameters.AddWithValue("@isAPISPEC7", _isAPISPEC7)
                cmdToExecute.Parameters.AddWithValue("@isAPIRP7G", _isAPIRP7G)
                cmdToExecute.Parameters.AddWithValue("@isHardbanding", _isHardbanding)
                cmdToExecute.Parameters.AddWithValue("@isIntExtCleaning", _isIntExtCleaning)
                cmdToExecute.Parameters.AddWithValue("@isUTSlipUpsetArea", _isUTSlipUpsetArea)
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
            cmdToExecute.CommandText = "SELECT * FROM SummaryOfInspection"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SummaryOfInspection")
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
            cmdToExecute.CommandText = "SELECT * FROM SummaryOfInspection WHERE summaryOfInspectionID=@summaryOfInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SummaryOfInspection")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@summaryOfInspectionID", _summaryOfInspectionID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _summaryOfInspectionID = CType(toReturn.Rows(0)("summaryOfInspectionID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _sequenceNo = CType(toReturn.Rows(0)("sequenceNo"), String)
                    _descriptionOfEquipment = CType(toReturn.Rows(0)("descriptionOfEquipment"), String)
                    _serialIDNo = CType(toReturn.Rows(0)("serialIDNo"), String)
                    _location = CType(toReturn.Rows(0)("location"), String)
                    _manufacture = CType(toReturn.Rows(0)("manufacture"), String)
                    _SWL_WWL_MGW = CType(toReturn.Rows(0)("SWL_WWL_MGW"), String)
                    _dimensional = CType(toReturn.Rows(0)("dimensional"), String)
                    _defectFound = CType(toReturn.Rows(0)("defectFound"), String)
                    _result = CType(toReturn.Rows(0)("result"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _typeOfInspectionSCode = CType(toReturn.Rows(0)("typeOfInspectionSCode"), String)
                    _isToiV = CType(toReturn.Rows(0)("isToiV"), Boolean)
                    _isToiN = CType(toReturn.Rows(0)("isToiN"), Boolean)
                    _isToiT = CType(toReturn.Rows(0)("isToiT"), Boolean)
                    _interval = CType(toReturn.Rows(0)("interval"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _detailReportSection = CType(toReturn.Rows(0)("detailReportSection"), String)
                    _examDate = CType(toReturn.Rows(0)("examDate"), DateTime)
                    _expireDate = CType(toReturn.Rows(0)("expireDate"), DateTime)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    _isApproval = CType(toReturn.Rows(0)("isApproval"), Boolean)
                    _approvalBy = CType(toReturn.Rows(0)("approvalBy"), String)
                    _approvalDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("approvalDate")), DateTime)
                    _fileName = CType(toReturn.Rows(0)("fileName"), String)
                    _fileExtension = CType(toReturn.Rows(0)("fileExtension"), String)
                    _inspectorName = CType(toReturn.Rows(0)("inspectorName"), String)
                    _reportNo_1 = CType(toReturn.Rows(0)("reportNo_1"), String)
                    _isDS1CAT3to5 = CType(toReturn.Rows(0)("isDS1CAT3to5"), Boolean)
                    _isDS1CAT4 = CType(toReturn.Rows(0)("isDS1CAT4"), Boolean)
                    _isAPISPEC7 = CType(toReturn.Rows(0)("isAPISPEC7"), Boolean)
                    _isAPIRP7G = CType(toReturn.Rows(0)("isAPIRP7G"), Boolean)
                    _isHardbanding = CType(toReturn.Rows(0)("isHardbanding"), Boolean)
                    _isIntExtCleaning = CType(toReturn.Rows(0)("isIntExtCleaning"), Boolean)
                    _isUTSlipUpsetArea = CType(toReturn.Rows(0)("isUTSlipUpsetArea"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM SummaryOfInspection " + _
                                        "WHERE summaryOfInspectionID=@summaryOfInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@summaryOfInspectionID", _summaryOfInspectionID)

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
        Public Function UpdateApproval() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE SummaryOfInspection " + _
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

        Public Function SelectByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT sr.*, " +
                                        "fileUrl = " + _
                                        "CASE " + _
                                        "WHEN(LEN(fileName) > 0) THEN((SELECT value FROM CommonCode WHERE code='SOIDIRV' AND groupCode='FILEDIR') + fileName) " + _
                                        "ELSE('#') " + _
                                        "END " + _
                                        "FROM SummaryOfInspection sr WHERE sr.projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SummaryOfInspection")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _isApproval = CType(toReturn.Rows(0)("isApproval"), Boolean)
                    _approvalBy = CType(toReturn.Rows(0)("approvalBy"), String)
                    _approvalDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("approvalDate")), DateTime)
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
#End Region

#Region " Class Property Declarations "
        Public Property [summaryOfInspectionID]() As String
            Get
                Return _summaryOfInspectionID
            End Get
            Set(ByVal Value As String)
                _summaryOfInspectionID = Value
            End Set
        End Property

        Public Property [projectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
            End Set
        End Property

        Public Property [sequenceNo]() As String
            Get
                Return _sequenceNo
            End Get
            Set(ByVal Value As String)
                _sequenceNo = Value
            End Set
        End Property

        Public Property [descriptionOfEquipment]() As String
            Get
                Return _descriptionOfEquipment
            End Get
            Set(ByVal Value As String)
                _descriptionOfEquipment = Value
            End Set
        End Property

        Public Property [serialIDNo]() As String
            Get
                Return _serialIDNo
            End Get
            Set(ByVal Value As String)
                _serialIDNo = Value
            End Set
        End Property

        Public Property [location]() As String
            Get
                Return _location
            End Get
            Set(ByVal Value As String)
                _location = Value
            End Set
        End Property

        Public Property [manufacture]() As String
            Get
                Return _manufacture
            End Get
            Set(ByVal Value As String)
                _manufacture = Value
            End Set
        End Property

        Public Property [SWL_WWL_MGW]() As String
            Get
                Return _SWL_WWL_MGW
            End Get
            Set(ByVal Value As String)
                _SWL_WWL_MGW = Value
            End Set
        End Property

        Public Property [dimensional]() As String
            Get
                Return _dimensional
            End Get
            Set(ByVal Value As String)
                _dimensional = Value
            End Set
        End Property

        Public Property [defectFound]() As String
            Get
                Return _defectFound
            End Get
            Set(ByVal Value As String)
                _defectFound = Value
            End Set
        End Property

        Public Property [result]() As String
            Get
                Return _result
            End Get
            Set(ByVal Value As String)
                _result = Value
            End Set
        End Property

        Public Property [reportNo]() As String
            Get
                Return _reportNo
            End Get
            Set(ByVal Value As String)
                _reportNo = Value
            End Set
        End Property

        Public Property [typeOfInspectionSCode]() As String
            Get
                Return _typeOfInspectionSCode
            End Get
            Set(ByVal Value As String)
                _typeOfInspectionSCode = Value
            End Set
        End Property

        Public Property [isToiV]() As Boolean
            Get
                Return _isToiV
            End Get
            Set(ByVal Value As Boolean)
                _isToiV = Value
            End Set
        End Property

        Public Property [isToiN]() As Boolean
            Get
                Return _isToiN
            End Get
            Set(ByVal Value As Boolean)
                _isToiN = Value
            End Set
        End Property

        Public Property [isToiT]() As Boolean
            Get
                Return _isToiT
            End Get
            Set(ByVal Value As Boolean)
                _isToiT = Value
            End Set
        End Property

        Public Property [interval]() As String
            Get
                Return _interval
            End Get
            Set(ByVal Value As String)
                _interval = Value
            End Set
        End Property

        Public Property [remarks]() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
            End Set
        End Property

        Public Property [detailReportSection]() As String
            Get
                Return _detailReportSection
            End Get
            Set(ByVal Value As String)
                _detailReportSection = Value
            End Set
        End Property

        Public Property [examDate]() As DateTime
            Get
                Return _examDate
            End Get
            Set(ByVal Value As DateTime)
                _examDate = Value
            End Set
        End Property

        Public Property [expireDate]() As DateTime
            Get
                Return _expireDate
            End Get
            Set(ByVal Value As DateTime)
                _expireDate = Value
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

        Public Property [isApproval]() As Boolean
            Get
                Return _isApproval
            End Get
            Set(ByVal Value As Boolean)
                _isApproval = Value
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

        Public Property [approvalDate]() As DateTime
            Get
                Return _approvalDate
            End Get
            Set(ByVal Value As DateTime)
                _approvalDate = Value
            End Set
        End Property

        Public Property [fileName]() As String
            Get
                Return _fileName
            End Get
            Set(ByVal Value As String)
                _fileName = Value
            End Set
        End Property

        Public Property [fileExtension]() As String
            Get
                Return _fileExtension
            End Get
            Set(ByVal Value As String)
                _fileExtension = Value
            End Set
        End Property

        Public Property [inspectorName]() As String
            Get
                Return _inspectorName
            End Get
            Set(ByVal Value As String)
                _inspectorName = Value
            End Set
        End Property

        Public Property [reportNo_1]() As String
            Get
                Return _reportNo_1
            End Get
            Set(ByVal Value As String)
                _reportNo_1 = Value
            End Set
        End Property

        Public Property [isDS1CAT3to5]() As Boolean
            Get
                Return _isDS1CAT3to5
            End Get
            Set(ByVal Value As Boolean)
                _isDS1CAT3to5 = Value
            End Set
        End Property

        Public Property [isDS1CAT4]() As Boolean
            Get
                Return _isDS1CAT4
            End Get
            Set(ByVal Value As Boolean)
                _isDS1CAT4 = Value
            End Set
        End Property

        Public Property [isAPISPEC7]() As Boolean
            Get
                Return _isAPISPEC7
            End Get
            Set(ByVal Value As Boolean)
                _isAPISPEC7 = Value
            End Set
        End Property

        Public Property [isAPIRP7G]() As Boolean
            Get
                Return _isAPIRP7G
            End Get
            Set(ByVal Value As Boolean)
                _isAPIRP7G = Value
            End Set
        End Property

        Public Property [isHardbanding]() As Boolean
            Get
                Return _isHardbanding
            End Get
            Set(ByVal Value As Boolean)
                _isHardbanding = Value
            End Set
        End Property

        Public Property [isIntExtCleaning]() As Boolean
            Get
                Return _isIntExtCleaning
            End Get
            Set(ByVal Value As Boolean)
                _isIntExtCleaning = Value
            End Set
        End Property

        Public Property [isUTSlipUpsetArea]() As Boolean
            Get
                Return _isUTSlipUpsetArea
            End Get
            Set(ByVal Value As Boolean)
                _isUTSlipUpsetArea = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
