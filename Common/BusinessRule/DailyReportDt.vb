﻿Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class DailyReportDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _dailyReportHdID, _dailyReportDtID, _sequenceNo, _weatherConditionSCode, _description, _result As String
        Private _beginningQty, _currentQty, _endingQty As Decimal
        Private _beginningUOM, _currentUOM, _endingUOM, _materialDetail, _categoryInspectionID As String
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
            cmdToExecute.CommandText = "INSERT INTO DailyReportDt " + _
                                        "(dailyReportHdID, dailyReportDtID, sequenceNo, weatherConditionSCode, description, result, " + _
                                        "beginningQty, currentQty, endingQty, " + _
                                        "beginningUOM, currentUOM, endingUOM, materialDetail, categoryInspectionID, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@dailyReportHdID, @dailyReportDtID, @sequenceNo, @weatherConditionSCode, @description, @result, " + _
                                        "@beginningQty, @currentQty, @endingQty, " + _
                                        "@beginningUOM, @currentUOM, @endingUOM, @materialDetail, @categoryInspectionID, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strDailyReportDtID As String = ID.GenerateIDNumber("DailyReportDt", "dailyReportDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportHdID", _dailyReportHdID)
                cmdToExecute.Parameters.AddWithValue("@dailyReportDtID", strDailyReportDtID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@weatherConditionSCode", _weatherConditionSCode)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@beginningQty", _beginningQty)
                cmdToExecute.Parameters.AddWithValue("@currentQty", _currentQty)
                cmdToExecute.Parameters.AddWithValue("@endingQty", _endingQty)
                cmdToExecute.Parameters.AddWithValue("@beginningUOM", _beginningUOM)
                cmdToExecute.Parameters.AddWithValue("@currentUOM", _currentUOM)
                cmdToExecute.Parameters.AddWithValue("@endingUOM", _endingUOM)
                cmdToExecute.Parameters.AddWithValue("@materialDetail", _materialDetail)
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionID", _categoryInspectionID)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _dailyReportDtID = strDailyReportDtID
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
            cmdToExecute.CommandText = "UPDATE DailyReportDt " + _
                                        "SET sequenceNo=@sequenceNo, weatherConditionSCode=@weatherConditionSCode, description=@description, " + _
                                        "result=@result, beginningQty=@beginningQty, currentQty=@currentQty, endingQty=@endingQty, " + _
                                        "beginningUOM=@beginningUOM, currentUOM=@currentUOM, endingUOM=@endingUOM, materialDetail=@materialDetail, " + _
                                        "categoryInspectionID=@categoryInspectionID, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE dailyReportDtID=@dailyReportDtID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportDtID", _dailyReportDtID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@weatherConditionSCode", _weatherConditionSCode)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@beginningQty", _beginningQty)
                cmdToExecute.Parameters.AddWithValue("@currentQty", _currentQty)
                cmdToExecute.Parameters.AddWithValue("@endingQty", _endingQty)
                cmdToExecute.Parameters.AddWithValue("@beginningUOM", _beginningUOM)
                cmdToExecute.Parameters.AddWithValue("@currentUOM", _currentUOM)
                cmdToExecute.Parameters.AddWithValue("@endingUOM", _endingUOM)
                cmdToExecute.Parameters.AddWithValue("@materialDetail", _materialDetail)
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionID", _categoryInspectionID)
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
            cmdToExecute.CommandText = "SELECT * FROM DailyReportDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DailyReportDt")
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
            cmdToExecute.CommandText = "SELECT * FROM DailyReportDt WHERE dailyReportDtID=@dailyReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DailyReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportDtID", _dailyReportDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _dailyReportHdID = CType(toReturn.Rows(0)("dailyReportHdID"), String)
                    _dailyReportDtID = CType(toReturn.Rows(0)("dailyReportDtID"), String)
                    _sequenceNo = CType(toReturn.Rows(0)("sequenceNo"), String)
                    _weatherConditionSCode = CType(toReturn.Rows(0)("weatherConditionSCode"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _result = CType(toReturn.Rows(0)("result"), String)
                    _beginningQty = CType(toReturn.Rows(0)("beginningQty"), Decimal)
                    _currentQty = CType(toReturn.Rows(0)("currentQty"), Decimal)
                    _endingQty = CType(toReturn.Rows(0)("endingQty"), Decimal)
                    _beginningUOM = CType(toReturn.Rows(0)("beginningUOM"), String)
                    _currentUOM = CType(toReturn.Rows(0)("currentUOM"), String)
                    _endingUOM = CType(toReturn.Rows(0)("endingUOM"), String)
                    _materialDetail = CType(toReturn.Rows(0)("materialDetail"), String)
                    _categoryInspectionID = CType(toReturn.Rows(0)("categoryInspectionID"), String)
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
            cmdToExecute.CommandText = "DELETE FROM DailyReportDt " + _
                                        "WHERE dailyReportDtID=@dailyReportDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportDtID", _dailyReportDtID)

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
        Public Function SelectByDailyReportHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT drd.*, (SELECT caption FROM CommonCode WHERE groupCode='WEATHER' " +
                                        "AND value=drd.weatherConditionSCode) AS weatherConditionName " +
                                        "FROM DailyReportDt drd WHERE drd.dailyReportHdID=@dailyReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DailyReportDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportHdID", _dailyReportHdID)

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
        Public Property [dailyReportHdID]() As String
            Get
                Return _dailyReportHdID
            End Get
            Set(ByVal Value As String)
                _dailyReportHdID = Value
            End Set
        End Property

        Public Property [dailyReportDtID]() As String
            Get
                Return _dailyReportDtID
            End Get
            Set(ByVal Value As String)
                _dailyReportDtID = Value
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

        Public Property [weatherConditionSCode]() As String
            Get
                Return _weatherConditionSCode
            End Get
            Set(ByVal Value As String)
                _weatherConditionSCode = Value
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

        Public Property [result]() As String
            Get
                Return _result
            End Get
            Set(ByVal Value As String)
                _result = Value
            End Set
        End Property

        Public Property [beginningQty]() As Decimal
            Get
                Return _beginningQty
            End Get
            Set(ByVal Value As Decimal)
                _beginningQty = Value
            End Set
        End Property

        Public Property [currentQty]() As Decimal
            Get
                Return _currentQty
            End Get
            Set(ByVal Value As Decimal)
                _currentQty = Value
            End Set
        End Property

        Public Property [endingQty]() As Decimal
            Get
                Return _endingQty
            End Get
            Set(ByVal Value As Decimal)
                _endingQty = Value
            End Set
        End Property

        Public Property [beginningUOM]() As String
            Get
                Return _beginningUOM
            End Get
            Set(ByVal Value As String)
                _beginningUOM = Value
            End Set
        End Property

        Public Property [currentUOM]() As String
            Get
                Return _currentUOM
            End Get
            Set(ByVal Value As String)
                _currentUOM = Value
            End Set
        End Property

        Public Property [endingUOM]() As String
            Get
                Return _endingUOM
            End Get
            Set(ByVal Value As String)
                _endingUOM = Value
            End Set
        End Property

        Public Property [materialDetail]() As String
            Get
                Return _materialDetail
            End Get
            Set(ByVal Value As String)
                _materialDetail = Value
            End Set
        End Property

        Public Property [categoryInspectionID]() As String
            Get
                Return _categoryInspectionID
            End Get
            Set(ByVal Value As String)
                _categoryInspectionID = Value
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
