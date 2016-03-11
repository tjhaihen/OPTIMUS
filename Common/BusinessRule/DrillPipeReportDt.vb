Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class DrillPipeReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _drillPipeReportHdID, _drillPipeReportDtID, _sequenceNo, _serialNo, _remarks As String
        Private _bod001CaptionID, _bod002CaptionID, _bod003CaptionID, _bod004CaptionID, _bod005CaptionID, _bod006CaptionID, _bod007CaptionID, _
                    _bod008CaptionID, _bod009CaptionID As String
        Private _bod001Value, _bod002Value, _bod003Value, _bod004Value, _bod005Value, _bod006Value, _bod007Value, _bod008Value, _
                    _bod009Value As String
        Private _pin001CaptionID, _pin002CaptionID, _pin003CaptionID, _pin004CaptionID, _pin005CaptionID, _pin006CaptionID, _
                    _pin007CaptionID, _pin008CaptionID, _pin009CaptionID, _pin010CaptionID, _pin011CaptionID, _
                    _pin012CaptionID, _pin013CaptionID As String
        Private _pin001Value, _pin002Value, _pin003Value, _pin004Value, _pin005Value, _pin006Value, _pin007Value, _pin008Value, _
                    _pin009Value, _pin010Value, _pin011Value, _pin012Value, _pin013Value As String
        Private _box001CaptionID, _box002CaptionID, _box003CaptionID, _box004CaptionID, _box005CaptionID, _box006CaptionID, _
                    _box007CaptionID, _box008CaptionID, _box009CaptionID, _box010CaptionID, _box011CaptionID As String
        Private _box001Value, _box002Value, _box003Value, _box004Value, _box005Value, _box006Value, _box007Value, _box008Value, _
                    _box009Value, _box010Value, _box011Value As String
        Private _isBodBent, _isPinHB, _isBoxHB, _isPinReface, _isBoxReface As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO DrillPipeReportDt " + _
                                        "(drillPipeReportHdID, drillPipeReportDtID, sequenceNo, serialNo, remarks, " + _
                                        "bod001CaptionID, bod002CaptionID, bod003CaptionID, bod004CaptionID, bod005CaptionID, bod006CaptionID, " + _
                                        "bod007CaptionID, bod008CaptionID, bod009CaptionID, " + _
                                        "bod001Value, bod002Value, bod003Value, bod004Value, bod005Value, bod006Value, " + _
                                        "bod007Value, bod008Value, bod009Value, " + _
                                        "pin001CaptionID, pin002CaptionID, pin003CaptionID, pin004CaptionID, pin005CaptionID, pin006CaptionID, " + _
                                        "pin007CaptionID, pin008CaptionID, pin009CaptionID, pin010CaptionID, pin011CaptionID, pin012CaptionID, pin013CaptionID, " + _
                                        "pin001Value, pin002Value, pin003Value, pin004Value, pin005Value, pin006Value, " + _
                                        "pin007Value, pin008Value, pin009Value, pin010Value, pin011Value, pin012Value, pin013Value, " + _
                                        "box001CaptionID, box002CaptionID, box003CaptionID, box004CaptionID, box005CaptionID, box006CaptionID, " + _
                                        "box007CaptionID, box008CaptionID, box009CaptionID, box010CaptionID, box011CaptionID, " + _
                                        "box001Value, box002Value, box003Value, box004Value, box005Value, box006Value, " + _
                                        "box007Value, box008Value, box009Value, box010Value, box011Value, " + _
                                        "isBodBent, isPinHB, isBoxHB, isPinReface, isBoxReface, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@drillPipeReportHdID, @drillPipeReportDtID, @sequenceNo, @serialNo, @remarks, " + _
                                        "@bod001CaptionID, @bod002CaptionID, @bod003CaptionID, @bod004CaptionID, @bod005CaptionID, @bod006CaptionID, " + _
                                        "@bod007CaptionID, @bod008CaptionID, @bod009CaptionID, " + _
                                        "@bod001Value, @bod002Value, @bod003Value, @bod004Value, @bod005Value, @bod006Value, " + _
                                        "@bod007Value, @bod008Value, @bod009Value, " + _
                                        "@pin001CaptionID, @pin002CaptionID, @pin003CaptionID, @pin004CaptionID, @pin005CaptionID, @pin006CaptionID, " + _
                                        "@pin007CaptionID, @pin008CaptionID, @pin009CaptionID, @pin010CaptionID, @pin011CaptionID, @pin012CaptionID, @pin013CaptionID, " + _
                                        "@pin001Value, @pin002Value, @pin003Value, @pin004Value, @pin005Value, @pin006Value, " + _
                                        "@pin007Value, @pin008Value, @pin009Value, @pin010Value, @pin011Value, @pin012Value, @pin013Value, " + _
                                        "@box001CaptionID, @box002CaptionID, @box003CaptionID, @box004CaptionID, @box005CaptionID, @box006CaptionID, " + _
                                        "@box007CaptionID, @box008CaptionID, @box009CaptionID, @box010CaptionID, @box011CaptionID, " + _
                                        "@box001Value, @box002Value, @box003Value, @box004Value, @box005Value, @box006Value, " + _
                                        "@box007Value, @box008Value, @box009Value, @box010Value, @box011Value, " + _
                                        "@isBodBent, @isPinHB, @isBoxHB, @isPinReface, @isBoxReface, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strDrillPipeReportDtID As String = ID.GenerateIDNumber("DrillPipeReportDt", "drillPipeReportDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", _drillPipeReportHdID)
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", strDrillPipeReportDtID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@bod001CaptionID", _bod001CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod002CaptionID", _bod002CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod003CaptionID", _bod003CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod004CaptionID", _bod004CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod005CaptionID", _bod005CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod006CaptionID", _bod006CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod007CaptionID", _bod007CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod008CaptionID", _bod008CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod009CaptionID", _bod009CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod001Value", _bod001Value)
                cmdToExecute.Parameters.AddWithValue("@bod002Value", _bod002Value)
                cmdToExecute.Parameters.AddWithValue("@bod003Value", _bod003Value)
                cmdToExecute.Parameters.AddWithValue("@bod004Value", _bod004Value)
                cmdToExecute.Parameters.AddWithValue("@bod005Value", _bod005Value)
                cmdToExecute.Parameters.AddWithValue("@bod006Value", _bod006Value)
                cmdToExecute.Parameters.AddWithValue("@bod007Value", _bod007Value)
                cmdToExecute.Parameters.AddWithValue("@bod008Value", _bod008Value)
                cmdToExecute.Parameters.AddWithValue("@bod009Value", _bod009Value)
                cmdToExecute.Parameters.AddWithValue("@pin001CaptionID", _pin001CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin002CaptionID", _pin002CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin003CaptionID", _pin003CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin004CaptionID", _pin004CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin005CaptionID", _pin005CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin006CaptionID", _pin006CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin007CaptionID", _pin007CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin008CaptionID", _pin008CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin009CaptionID", _pin009CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin010CaptionID", _pin010CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin011CaptionID", _pin011CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin012CaptionID", _pin012CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin013CaptionID", _pin013CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin001Value", _pin001Value)
                cmdToExecute.Parameters.AddWithValue("@pin002Value", _pin002Value)
                cmdToExecute.Parameters.AddWithValue("@pin003Value", _pin003Value)
                cmdToExecute.Parameters.AddWithValue("@pin004Value", _pin004Value)
                cmdToExecute.Parameters.AddWithValue("@pin005Value", _pin005Value)
                cmdToExecute.Parameters.AddWithValue("@pin006Value", _pin006Value)
                cmdToExecute.Parameters.AddWithValue("@pin007Value", _pin007Value)
                cmdToExecute.Parameters.AddWithValue("@pin008Value", _pin008Value)
                cmdToExecute.Parameters.AddWithValue("@pin009Value", _pin009Value)
                cmdToExecute.Parameters.AddWithValue("@pin010Value", _pin010Value)
                cmdToExecute.Parameters.AddWithValue("@pin011Value", _pin011Value)
                cmdToExecute.Parameters.AddWithValue("@pin012Value", _pin012Value)
                cmdToExecute.Parameters.AddWithValue("@pin013Value", _pin013Value)
                cmdToExecute.Parameters.AddWithValue("@box001CaptionID", _box001CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box002CaptionID", _box002CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box003CaptionID", _box003CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box004CaptionID", _box004CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box005CaptionID", _box005CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box006CaptionID", _box006CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box007CaptionID", _box007CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box008CaptionID", _box008CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box009CaptionID", _box009CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box010CaptionID", _box010CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box011CaptionID", _box011CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box001Value", _box001Value)
                cmdToExecute.Parameters.AddWithValue("@box002Value", _box002Value)
                cmdToExecute.Parameters.AddWithValue("@box003Value", _box003Value)
                cmdToExecute.Parameters.AddWithValue("@box004Value", _box004Value)
                cmdToExecute.Parameters.AddWithValue("@box005Value", _box005Value)
                cmdToExecute.Parameters.AddWithValue("@box006Value", _box006Value)
                cmdToExecute.Parameters.AddWithValue("@box007Value", _box007Value)
                cmdToExecute.Parameters.AddWithValue("@box008Value", _box008Value)
                cmdToExecute.Parameters.AddWithValue("@box009Value", _box009Value)
                cmdToExecute.Parameters.AddWithValue("@box010Value", _box010Value)
                cmdToExecute.Parameters.AddWithValue("@box011Value", _box011Value)
                cmdToExecute.Parameters.AddWithValue("@isBodBent", _isBodBent)
                cmdToExecute.Parameters.AddWithValue("@isPinHB", _isPinHB)
                cmdToExecute.Parameters.AddWithValue("@isBoxHB", _isBoxHB)
                cmdToExecute.Parameters.AddWithValue("@isPinReface", _isPinReface)
                cmdToExecute.Parameters.AddWithValue("@isBoxReface", _isBoxReface)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _drillPipeReportDtID = strDrillPipeReportDtID
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
            cmdToExecute.CommandText = "UPDATE DrillPipeReportDt " + _
                                        "SET sequenceNo=@sequenceNo, serialNo=@serialNo, remarks=@remarks, " + _
                                        "bod001CaptionID=@bod001CaptionID, bod002CaptionID=@bod002CaptionID, bod003CaptionID=@bod003CaptionID, " + _
                                        "bod004CaptionID=@bod004CaptionID, bod005CaptionID=@bod005CaptionID, bod006CaptionID=@bod006CaptionID, " + _
                                        "bod007CaptionID=@bod007CaptionID, bod008CaptionID=@bod008CaptionID, bod009CaptionID=@bod009CaptionID, " + _
                                        "bod001Value=@bod001Value, bod002Value=@bod002Value, bod003Value=@bod003Value, " + _
                                        "bod004Value=@bod004Value, bod005Value=@bod005Value, bod006Value=@bod006Value, " + _
                                        "bod007Value=@bod007Value, bod008Value=@bod008Value, bod009Value=@bod009Value, " + _
                                        "pin001CaptionID=@pin001CaptionID, pin002CaptionID=@pin002CaptionID, pin003CaptionID=@pin003CaptionID, " + _
                                        "pin004CaptionID=@pin004CaptionID, pin005CaptionID=@pin005CaptionID, pin006CaptionID=@pin006CaptionID, " + _
                                        "pin007CaptionID=@pin007CaptionID, pin008CaptionID=@pin008CaptionID, pin009CaptionID=@pin009CaptionID, " + _
                                        "pin010CaptionID=@pin010CaptionID, pin011CaptionID=@pin011CaptionID, " + _
                                        "pin012CaptionID=@pin012CaptionID, pin013CaptionID=@pin013CaptionID, " + _
                                        "pin001Value=@pin001Value, pin002Value=@pin002Value, pin003Value=@pin003Value, " + _
                                        "pin004Value=@pin004Value, pin005Value=@pin005Value, pin006Value=@pin006Value, " + _
                                        "pin007Value=@pin007Value, pin008Value=@pin008Value, pin009Value=@pin009Value, " + _
                                        "pin010Value=@pin010Value, pin011Value=@pin011Value, " + _
                                        "pin012Value=@pin012Value, pin013Value=@pin013Value, " + _
                                        "box001CaptionID=@box001CaptionID, box002CaptionID=@box002CaptionID, box003CaptionID=@box003CaptionID, " + _
                                        "box004CaptionID=@box004CaptionID, box005CaptionID=@box005CaptionID, box006CaptionID=@box006CaptionID, " + _
                                        "box007CaptionID=@box007CaptionID, box008CaptionID=@box008CaptionID, box009CaptionID=@box009CaptionID, " + _
                                        "box010CaptionID=@box010CaptionID, box011CaptionID=@box011CaptionID, " + _
                                        "box001Value=@box001Value, box002Value=@box002Value, box003Value=@box003Value, " + _
                                        "box004Value=@box004Value, box005Value=@box005Value, box006Value=@box006Value, " + _
                                        "box007Value=@box007Value, box008Value=@box008Value, box009Value=@box009Value, " + _
                                        "box010Value=@box010Value, box011Value=@box011Value, " + _
                                        "isBodBent=@isBodBent, isPinHB=@isPinHB, isBoxHB=@isBoxHB, isPinReface=@isPinReface, isBoxReface=@isBoxReface, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE drillPipeReportDtID=@drillPipeReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try                
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", _drillPipeReportDtID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@bod001CaptionID", _bod001CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod002CaptionID", _bod002CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod003CaptionID", _bod003CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod004CaptionID", _bod004CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod005CaptionID", _bod005CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod006CaptionID", _bod006CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod007CaptionID", _bod007CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod008CaptionID", _bod008CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod009CaptionID", _bod009CaptionID)
                cmdToExecute.Parameters.AddWithValue("@bod001Value", _bod001Value)
                cmdToExecute.Parameters.AddWithValue("@bod002Value", _bod002Value)
                cmdToExecute.Parameters.AddWithValue("@bod003Value", _bod003Value)
                cmdToExecute.Parameters.AddWithValue("@bod004Value", _bod004Value)
                cmdToExecute.Parameters.AddWithValue("@bod005Value", _bod005Value)
                cmdToExecute.Parameters.AddWithValue("@bod006Value", _bod006Value)
                cmdToExecute.Parameters.AddWithValue("@bod007Value", _bod007Value)
                cmdToExecute.Parameters.AddWithValue("@bod008Value", _bod008Value)
                cmdToExecute.Parameters.AddWithValue("@bod009Value", _bod009Value)
                cmdToExecute.Parameters.AddWithValue("@pin001CaptionID", _pin001CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin002CaptionID", _pin002CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin003CaptionID", _pin003CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin004CaptionID", _pin004CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin005CaptionID", _pin005CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin006CaptionID", _pin006CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin007CaptionID", _pin007CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin008CaptionID", _pin008CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin009CaptionID", _pin009CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin010CaptionID", _pin010CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin011CaptionID", _pin011CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin012CaptionID", _pin012CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin013CaptionID", _pin013CaptionID)
                cmdToExecute.Parameters.AddWithValue("@pin001Value", _pin001Value)
                cmdToExecute.Parameters.AddWithValue("@pin002Value", _pin002Value)
                cmdToExecute.Parameters.AddWithValue("@pin003Value", _pin003Value)
                cmdToExecute.Parameters.AddWithValue("@pin004Value", _pin004Value)
                cmdToExecute.Parameters.AddWithValue("@pin005Value", _pin005Value)
                cmdToExecute.Parameters.AddWithValue("@pin006Value", _pin006Value)
                cmdToExecute.Parameters.AddWithValue("@pin007Value", _pin007Value)
                cmdToExecute.Parameters.AddWithValue("@pin008Value", _pin008Value)
                cmdToExecute.Parameters.AddWithValue("@pin009Value", _pin009Value)
                cmdToExecute.Parameters.AddWithValue("@pin010Value", _pin010Value)
                cmdToExecute.Parameters.AddWithValue("@pin011Value", _pin011Value)
                cmdToExecute.Parameters.AddWithValue("@pin012Value", _pin012Value)
                cmdToExecute.Parameters.AddWithValue("@pin013Value", _pin013Value)
                cmdToExecute.Parameters.AddWithValue("@box001CaptionID", _box001CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box002CaptionID", _box002CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box003CaptionID", _box003CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box004CaptionID", _box004CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box005CaptionID", _box005CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box006CaptionID", _box006CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box007CaptionID", _box007CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box008CaptionID", _box008CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box009CaptionID", _box009CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box010CaptionID", _box010CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box011CaptionID", _box011CaptionID)
                cmdToExecute.Parameters.AddWithValue("@box001Value", _box001Value)
                cmdToExecute.Parameters.AddWithValue("@box002Value", _box002Value)
                cmdToExecute.Parameters.AddWithValue("@box003Value", _box003Value)
                cmdToExecute.Parameters.AddWithValue("@box004Value", _box004Value)
                cmdToExecute.Parameters.AddWithValue("@box005Value", _box005Value)
                cmdToExecute.Parameters.AddWithValue("@box006Value", _box006Value)
                cmdToExecute.Parameters.AddWithValue("@box007Value", _box007Value)
                cmdToExecute.Parameters.AddWithValue("@box008Value", _box008Value)
                cmdToExecute.Parameters.AddWithValue("@box009Value", _box009Value)
                cmdToExecute.Parameters.AddWithValue("@box010Value", _box010Value)
                cmdToExecute.Parameters.AddWithValue("@box011Value", _box011Value)
                cmdToExecute.Parameters.AddWithValue("@isBodBent", _isBodBent)
                cmdToExecute.Parameters.AddWithValue("@isPinHB", _isPinHB)
                cmdToExecute.Parameters.AddWithValue("@isBoxHB", _isBoxHB)
                cmdToExecute.Parameters.AddWithValue("@isPinReface", _isPinReface)
                cmdToExecute.Parameters.AddWithValue("@isBoxReface", _isBoxReface)
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
            cmdToExecute.CommandText = "SELECT * FROM DrillPipeReportDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportDt")
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
            cmdToExecute.CommandText = "SELECT * FROM DrillPipeReportDt WHERE drillPipeReportDtID=@drillPipeReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", _drillPipeReportDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _drillPipeReportHdID = CType(toReturn.Rows(0)("drillPipeReportHdID"), String)
                    _drillPipeReportDtID = CType(toReturn.Rows(0)("drillPipeReportDtID"), String)
                    _sequenceNo = CType(toReturn.Rows(0)("sequenceNo"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _bod001CaptionID = CType(toReturn.Rows(0)("bod001CaptionID"), String)
                    _bod002CaptionID = CType(toReturn.Rows(0)("bod002CaptionID"), String)
                    _bod003CaptionID = CType(toReturn.Rows(0)("bod003CaptionID"), String)
                    _bod004CaptionID = CType(toReturn.Rows(0)("bod004CaptionID"), String)
                    _bod005CaptionID = CType(toReturn.Rows(0)("bod005CaptionID"), String)
                    _bod006CaptionID = CType(toReturn.Rows(0)("bod006CaptionID"), String)
                    _bod007CaptionID = CType(toReturn.Rows(0)("bod007CaptionID"), String)
                    _bod008CaptionID = CType(toReturn.Rows(0)("bod008CaptionID"), String)
                    _bod009CaptionID = CType(toReturn.Rows(0)("bod009CaptionID"), String)
                    _bod001Value = CType(toReturn.Rows(0)("bod001Value"), String)
                    _bod002Value = CType(toReturn.Rows(0)("bod002Value"), String)
                    _bod003Value = CType(toReturn.Rows(0)("bod003Value"), String)
                    _bod004Value = CType(toReturn.Rows(0)("bod004Value"), String)
                    _bod005Value = CType(toReturn.Rows(0)("bod005Value"), String)
                    _bod006Value = CType(toReturn.Rows(0)("bod006Value"), String)
                    _bod007Value = CType(toReturn.Rows(0)("bod007Value"), String)
                    _bod008Value = CType(toReturn.Rows(0)("bod008Value"), String)
                    _bod009Value = CType(toReturn.Rows(0)("bod009Value"), String)
                    _pin001CaptionID = CType(toReturn.Rows(0)("pin001CaptionID"), String)
                    _pin002CaptionID = CType(toReturn.Rows(0)("pin002CaptionID"), String)
                    _pin003CaptionID = CType(toReturn.Rows(0)("pin003CaptionID"), String)
                    _pin004CaptionID = CType(toReturn.Rows(0)("pin004CaptionID"), String)
                    _pin005CaptionID = CType(toReturn.Rows(0)("pin005CaptionID"), String)
                    _pin006CaptionID = CType(toReturn.Rows(0)("pin006CaptionID"), String)
                    _pin007CaptionID = CType(toReturn.Rows(0)("pin007CaptionID"), String)
                    _pin008CaptionID = CType(toReturn.Rows(0)("pin008CaptionID"), String)
                    _pin009CaptionID = CType(toReturn.Rows(0)("pin009CaptionID"), String)
                    _pin010CaptionID = CType(toReturn.Rows(0)("pin010CaptionID"), String)
                    _pin011CaptionID = CType(toReturn.Rows(0)("pin011CaptionID"), String)
                    _pin012CaptionID = CType(toReturn.Rows(0)("pin012CaptionID"), String)
                    _pin013CaptionID = CType(toReturn.Rows(0)("pin013CaptionID"), String)
                    _pin001Value = CType(toReturn.Rows(0)("pin001Value"), String)
                    _pin002Value = CType(toReturn.Rows(0)("pin002Value"), String)
                    _pin003Value = CType(toReturn.Rows(0)("pin003Value"), String)
                    _pin004Value = CType(toReturn.Rows(0)("pin004Value"), String)
                    _pin005Value = CType(toReturn.Rows(0)("pin005Value"), String)
                    _pin006Value = CType(toReturn.Rows(0)("pin006Value"), String)
                    _pin007Value = CType(toReturn.Rows(0)("pin007Value"), String)
                    _pin008Value = CType(toReturn.Rows(0)("pin008Value"), String)
                    _pin009Value = CType(toReturn.Rows(0)("pin009Value"), String)
                    _pin010Value = CType(toReturn.Rows(0)("pin010Value"), String)
                    _pin011Value = CType(toReturn.Rows(0)("pin011Value"), String)
                    _pin012Value = CType(toReturn.Rows(0)("pin012Value"), String)
                    _pin013Value = CType(toReturn.Rows(0)("pin013Value"), String)
                    _box001CaptionID = CType(toReturn.Rows(0)("box001CaptionID"), String)
                    _box002CaptionID = CType(toReturn.Rows(0)("box002CaptionID"), String)
                    _box003CaptionID = CType(toReturn.Rows(0)("box003CaptionID"), String)
                    _box004CaptionID = CType(toReturn.Rows(0)("box004CaptionID"), String)
                    _box005CaptionID = CType(toReturn.Rows(0)("box005CaptionID"), String)
                    _box006CaptionID = CType(toReturn.Rows(0)("box006CaptionID"), String)
                    _box007CaptionID = CType(toReturn.Rows(0)("box007CaptionID"), String)
                    _box008CaptionID = CType(toReturn.Rows(0)("box008CaptionID"), String)
                    _box009CaptionID = CType(toReturn.Rows(0)("box009CaptionID"), String)
                    _box010CaptionID = CType(toReturn.Rows(0)("box010CaptionID"), String)
                    _box011CaptionID = CType(toReturn.Rows(0)("box011CaptionID"), String)
                    _box001Value = CType(toReturn.Rows(0)("box001Value"), String)
                    _box002Value = CType(toReturn.Rows(0)("box002Value"), String)
                    _box003Value = CType(toReturn.Rows(0)("box003Value"), String)
                    _box004Value = CType(toReturn.Rows(0)("box004Value"), String)
                    _box005Value = CType(toReturn.Rows(0)("box005Value"), String)
                    _box006Value = CType(toReturn.Rows(0)("box006Value"), String)
                    _box007Value = CType(toReturn.Rows(0)("box007Value"), String)
                    _box008Value = CType(toReturn.Rows(0)("box008Value"), String)
                    _box009Value = CType(toReturn.Rows(0)("box009Value"), String)
                    _box010Value = CType(toReturn.Rows(0)("box010Value"), String)
                    _box011Value = CType(toReturn.Rows(0)("box011Value"), String)
                    _isBodBent = CType(toReturn.Rows(0)("isBodBent"), Boolean)
                    _isPinHB = CType(toReturn.Rows(0)("isPinHB"), Boolean)
                    _isBoxHB = CType(toReturn.Rows(0)("isBoxHB"), Boolean)
                    _isPinReface = CType(toReturn.Rows(0)("isPinReface"), Boolean)
                    _isBoxReface = CType(toReturn.Rows(0)("isBoxReface"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM DrillPipeReportDt " + _
                                        "WHERE drillPipeReportDtID=@drillPipeReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportDtID", _drillPipeReportDtID)

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
        Public Function SelectByDrillPipeReportHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_DrillPipeReportDtByDrillPipeReportHdID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("DrillPipeReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", _drillPipeReportHdID)

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
        Public Property [drillPipeReportHdID]() As String
            Get
                Return _drillPipeReportHdID
            End Get
            Set(ByVal Value As String)
                _drillPipeReportHdID = Value
            End Set
        End Property

        Public Property [drillPipeReportDtID]() As String
            Get
                Return _drillPipeReportDtID
            End Get
            Set(ByVal Value As String)
                _drillPipeReportDtID = Value
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

        Public Property [serialNo]() As String
            Get
                Return _serialNo
            End Get
            Set(ByVal Value As String)
                _serialNo = Value
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

        Public Property [bod001CaptionID]() As String
            Get
                Return _bod001CaptionID
            End Get
            Set(ByVal Value As String)
                _bod001CaptionID = Value
            End Set
        End Property

        Public Property [bod002CaptionID]() As String
            Get
                Return _bod002CaptionID
            End Get
            Set(ByVal Value As String)
                _bod002CaptionID = Value
            End Set
        End Property

        Public Property [bod003CaptionID]() As String
            Get
                Return _bod003CaptionID
            End Get
            Set(ByVal Value As String)
                _bod003CaptionID = Value
            End Set
        End Property

        Public Property [bod004CaptionID]() As String
            Get
                Return _bod004CaptionID
            End Get
            Set(ByVal Value As String)
                _bod004CaptionID = Value
            End Set
        End Property

        Public Property [bod005CaptionID]() As String
            Get
                Return _bod005CaptionID
            End Get
            Set(ByVal Value As String)
                _bod005CaptionID = Value
            End Set
        End Property

        Public Property [bod006CaptionID]() As String
            Get
                Return _bod006CaptionID
            End Get
            Set(ByVal Value As String)
                _bod006CaptionID = Value
            End Set
        End Property

        Public Property [bod007CaptionID]() As String
            Get
                Return _bod007CaptionID
            End Get
            Set(ByVal Value As String)
                _bod007CaptionID = Value
            End Set
        End Property

        Public Property [bod008CaptionID]() As String
            Get
                Return _bod008CaptionID
            End Get
            Set(ByVal Value As String)
                _bod008CaptionID = Value
            End Set
        End Property

        Public Property [bod009CaptionID]() As String
            Get
                Return _bod009CaptionID
            End Get
            Set(ByVal Value As String)
                _bod009CaptionID = Value
            End Set
        End Property

        Public Property [bod001Value]() As String
            Get
                Return _bod001Value
            End Get
            Set(ByVal Value As String)
                _bod001Value = Value
            End Set
        End Property

        Public Property [bod002Value]() As String
            Get
                Return _bod002Value
            End Get
            Set(ByVal Value As String)
                _bod002Value = Value
            End Set
        End Property

        Public Property [bod003Value]() As String
            Get
                Return _bod003Value
            End Get
            Set(ByVal Value As String)
                _bod003Value = Value
            End Set
        End Property

        Public Property [bod004Value]() As String
            Get
                Return _bod004Value
            End Get
            Set(ByVal Value As String)
                _bod004Value = Value
            End Set
        End Property

        Public Property [bod005Value]() As String
            Get
                Return _bod005Value
            End Get
            Set(ByVal Value As String)
                _bod005Value = Value
            End Set
        End Property

        Public Property [bod006Value]() As String
            Get
                Return _bod006Value
            End Get
            Set(ByVal Value As String)
                _bod006Value = Value
            End Set
        End Property

        Public Property [bod007Value]() As String
            Get
                Return _bod007Value
            End Get
            Set(ByVal Value As String)
                _bod007Value = Value
            End Set
        End Property

        Public Property [bod008Value]() As String
            Get
                Return _bod008Value
            End Get
            Set(ByVal Value As String)
                _bod008Value = Value
            End Set
        End Property

        Public Property [bod009Value]() As String
            Get
                Return _bod009Value
            End Get
            Set(ByVal Value As String)
                _bod009Value = Value
            End Set
        End Property

        Public Property [pin001CaptionID]() As String
            Get
                Return _pin001CaptionID
            End Get
            Set(ByVal Value As String)
                _pin001CaptionID = Value
            End Set
        End Property

        Public Property [pin002CaptionID]() As String
            Get
                Return _pin002CaptionID
            End Get
            Set(ByVal Value As String)
                _pin002CaptionID = Value
            End Set
        End Property

        Public Property [pin003CaptionID]() As String
            Get
                Return _pin003CaptionID
            End Get
            Set(ByVal Value As String)
                _pin003CaptionID = Value
            End Set
        End Property

        Public Property [pin004CaptionID]() As String
            Get
                Return _pin004CaptionID
            End Get
            Set(ByVal Value As String)
                _pin004CaptionID = Value
            End Set
        End Property

        Public Property [pin005CaptionID]() As String
            Get
                Return _pin005CaptionID
            End Get
            Set(ByVal Value As String)
                _pin005CaptionID = Value
            End Set
        End Property

        Public Property [pin006CaptionID]() As String
            Get
                Return _pin006CaptionID
            End Get
            Set(ByVal Value As String)
                _pin006CaptionID = Value
            End Set
        End Property

        Public Property [pin007CaptionID]() As String
            Get
                Return _pin007CaptionID
            End Get
            Set(ByVal Value As String)
                _pin007CaptionID = Value
            End Set
        End Property

        Public Property [pin008CaptionID]() As String
            Get
                Return _pin008CaptionID
            End Get
            Set(ByVal Value As String)
                _pin008CaptionID = Value
            End Set
        End Property

        Public Property [pin009CaptionID]() As String
            Get
                Return _pin009CaptionID
            End Get
            Set(ByVal Value As String)
                _pin009CaptionID = Value
            End Set
        End Property

        Public Property [pin010CaptionID]() As String
            Get
                Return _pin010CaptionID
            End Get
            Set(ByVal Value As String)
                _pin010CaptionID = Value
            End Set
        End Property

        Public Property [pin011CaptionID]() As String
            Get
                Return _pin011CaptionID
            End Get
            Set(ByVal Value As String)
                _pin011CaptionID = Value
            End Set
        End Property

        Public Property [pin012CaptionID]() As String
            Get
                Return _pin012CaptionID
            End Get
            Set(ByVal Value As String)
                _pin012CaptionID = Value
            End Set
        End Property

        Public Property [pin013CaptionID]() As String
            Get
                Return _pin013CaptionID
            End Get
            Set(ByVal Value As String)
                _pin013CaptionID = Value
            End Set
        End Property

        Public Property [pin001Value]() As String
            Get
                Return _pin001Value
            End Get
            Set(ByVal Value As String)
                _pin001Value = Value
            End Set
        End Property

        Public Property [pin002Value]() As String
            Get
                Return _pin002Value
            End Get
            Set(ByVal Value As String)
                _pin002Value = Value
            End Set
        End Property

        Public Property [pin003Value]() As String
            Get
                Return _pin003Value
            End Get
            Set(ByVal Value As String)
                _pin003Value = Value
            End Set
        End Property

        Public Property [pin004Value]() As String
            Get
                Return _pin004Value
            End Get
            Set(ByVal Value As String)
                _pin004Value = Value
            End Set
        End Property

        Public Property [pin005Value]() As String
            Get
                Return _pin005Value
            End Get
            Set(ByVal Value As String)
                _pin005Value = Value
            End Set
        End Property

        Public Property [pin006Value]() As String
            Get
                Return _pin006Value
            End Get
            Set(ByVal Value As String)
                _pin006Value = Value
            End Set
        End Property

        Public Property [pin007Value]() As String
            Get
                Return _pin007Value
            End Get
            Set(ByVal Value As String)
                _pin007Value = Value
            End Set
        End Property

        Public Property [pin008Value]() As String
            Get
                Return _pin008Value
            End Get
            Set(ByVal Value As String)
                _pin008Value = Value
            End Set
        End Property

        Public Property [pin009Value]() As String
            Get
                Return _pin009Value
            End Get
            Set(ByVal Value As String)
                _pin009Value = Value
            End Set
        End Property

        Public Property [pin010Value]() As String
            Get
                Return _pin010Value
            End Get
            Set(ByVal Value As String)
                _pin010Value = Value
            End Set
        End Property

        Public Property [pin011Value]() As String
            Get
                Return _pin011Value
            End Get
            Set(ByVal Value As String)
                _pin011Value = Value
            End Set
        End Property

        Public Property [pin012Value]() As String
            Get
                Return _pin012Value
            End Get
            Set(ByVal Value As String)
                _pin012Value = Value
            End Set
        End Property

        Public Property [pin013Value]() As String
            Get
                Return _pin013Value
            End Get
            Set(ByVal Value As String)
                _pin013Value = Value
            End Set
        End Property

        Public Property [box001CaptionID]() As String
            Get
                Return _box001CaptionID
            End Get
            Set(ByVal Value As String)
                _box001CaptionID = Value
            End Set
        End Property

        Public Property [box002CaptionID]() As String
            Get
                Return _box002CaptionID
            End Get
            Set(ByVal Value As String)
                _box002CaptionID = Value
            End Set
        End Property

        Public Property [box003CaptionID]() As String
            Get
                Return _box003CaptionID
            End Get
            Set(ByVal Value As String)
                _box003CaptionID = Value
            End Set
        End Property

        Public Property [box004CaptionID]() As String
            Get
                Return _box004CaptionID
            End Get
            Set(ByVal Value As String)
                _box004CaptionID = Value
            End Set
        End Property

        Public Property [box005CaptionID]() As String
            Get
                Return _box005CaptionID
            End Get
            Set(ByVal Value As String)
                _box005CaptionID = Value
            End Set
        End Property

        Public Property [box006CaptionID]() As String
            Get
                Return _box006CaptionID
            End Get
            Set(ByVal Value As String)
                _box006CaptionID = Value
            End Set
        End Property

        Public Property [box007CaptionID]() As String
            Get
                Return _box007CaptionID
            End Get
            Set(ByVal Value As String)
                _box007CaptionID = Value
            End Set
        End Property

        Public Property [box008CaptionID]() As String
            Get
                Return _box008CaptionID
            End Get
            Set(ByVal Value As String)
                _box008CaptionID = Value
            End Set
        End Property

        Public Property [box009CaptionID]() As String
            Get
                Return _box009CaptionID
            End Get
            Set(ByVal Value As String)
                _box009CaptionID = Value
            End Set
        End Property

        Public Property [box010CaptionID]() As String
            Get
                Return _box010CaptionID
            End Get
            Set(ByVal Value As String)
                _box010CaptionID = Value
            End Set
        End Property

        Public Property [box011CaptionID]() As String
            Get
                Return _box011CaptionID
            End Get
            Set(ByVal Value As String)
                _box011CaptionID = Value
            End Set
        End Property

        Public Property [box001Value]() As String
            Get
                Return _box001Value
            End Get
            Set(ByVal Value As String)
                _box001Value = Value
            End Set
        End Property

        Public Property [box002Value]() As String
            Get
                Return _box002Value
            End Get
            Set(ByVal Value As String)
                _box002Value = Value
            End Set
        End Property

        Public Property [box003Value]() As String
            Get
                Return _box003Value
            End Get
            Set(ByVal Value As String)
                _box003Value = Value
            End Set
        End Property

        Public Property [box004Value]() As String
            Get
                Return _box004Value
            End Get
            Set(ByVal Value As String)
                _box004Value = Value
            End Set
        End Property

        Public Property [box005Value]() As String
            Get
                Return _box005Value
            End Get
            Set(ByVal Value As String)
                _box005Value = Value
            End Set
        End Property

        Public Property [box006Value]() As String
            Get
                Return _box006Value
            End Get
            Set(ByVal Value As String)
                _box006Value = Value
            End Set
        End Property

        Public Property [box007Value]() As String
            Get
                Return _box007Value
            End Get
            Set(ByVal Value As String)
                _box007Value = Value
            End Set
        End Property

        Public Property [box008Value]() As String
            Get
                Return _box008Value
            End Get
            Set(ByVal Value As String)
                _box008Value = Value
            End Set
        End Property

        Public Property [box009Value]() As String
            Get
                Return _box009Value
            End Get
            Set(ByVal Value As String)
                _box009Value = Value
            End Set
        End Property

        Public Property [box010Value]() As String
            Get
                Return _box010Value
            End Get
            Set(ByVal Value As String)
                _box010Value = Value
            End Set
        End Property

        Public Property [box011Value]() As String
            Get
                Return _box011Value
            End Get
            Set(ByVal Value As String)
                _box011Value = Value
            End Set
        End Property

        Public Property [isBodBent]() As Boolean
            Get
                Return _isBodBent
            End Get
            Set(ByVal Value As Boolean)
                _isBodBent = Value
            End Set
        End Property

        Public Property [isPinHB]() As Boolean
            Get
                Return _isPinHB
            End Get
            Set(ByVal Value As Boolean)
                _isPinHB = Value
            End Set
        End Property

        Public Property [isBoxHB]() As Boolean
            Get
                Return _isBoxHB
            End Get
            Set(ByVal Value As Boolean)
                _isBoxHB = Value
            End Set
        End Property

        Public Property [isPinReface]() As Boolean
            Get
                Return _isPinReface
            End Get
            Set(ByVal Value As Boolean)
                _isPinReface = Value
            End Set
        End Property

        Public Property [isBoxReface]() As Boolean
            Get
                Return _isBoxReface
            End Get
            Set(ByVal Value As Boolean)
                _isBoxReface = Value
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
