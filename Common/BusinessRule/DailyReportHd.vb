Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class DailyReportHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _dailyReportHdID, _projectID, _reportNo, _remarks As String
        Private _userIDinsert, _userIDupdate As String
        Private _customerPICName, _customerPICTitle As String
        Private _reportDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO DailyReportHd " + _
                                        "(dailyReportHdID, projectID, reportNo, remarks, reportDate, " + _
                                        "customerPICName, customerPICTitle, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@dailyReportHdID, @projectID, @reportNo, @remarks, @reportDate, " + _
                                        "@customerPICName, @customerPICTitle, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strDailyReportHdID As String = ID.GenerateIDNumber("DailyReportHd", "dailyReportHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportHdID", strDailyReportHdID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)                
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@customerPICName", _customerPICName)
                cmdToExecute.Parameters.AddWithValue("@customerPICTitle", _customerPICTitle)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _dailyReportHdID = strDailyReportHdID
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
            cmdToExecute.CommandText = "UPDATE DailyReportHd " + _
                                        "SET reportNo=@reportNo, remarks=@remarks, reportDate=@reportDate, " + _
                                        "customerPICName=@customerPICName, customerPICTitle=@customerPICTitle, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE dailyReportHdID=@dailyReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportHdID", _dailyReportHdID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@customerPICName", _customerPICName)
                cmdToExecute.Parameters.AddWithValue("@customerPICTitle", _customerPICTitle)
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
            cmdToExecute.CommandText = "SELECT * FROM DailyReportHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DailyReportHd")
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
            cmdToExecute.CommandText = "SELECT * FROM DailyReportHd WHERE dailyReportHdID=@dailyReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DailyReportHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportHdID", _dailyReportHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _dailyReportHdID = CType(toReturn.Rows(0)("dailyReportHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _reportDate = CType(toReturn.Rows(0)("reportDate"), DateTime)
                    _customerPICName = CType(toReturn.Rows(0)("customerPICName"), String)
                    _customerPICTitle = CType(toReturn.Rows(0)("customerPICTitle"), String)
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
            cmdToExecute.CommandText = "DELETE FROM DailyReportHd " + _
                                        "WHERE dailyReportHdID=@dailyReportHdID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dailyReportHdID", _dailyReportHdID)

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
        Public Function SelectByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT drh.* " +
                                        "FROM DailyReportHd drh WHERE drh.projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DailyReportHd")
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

        Public Property [projectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
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

        Public Property [remarks]() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
            End Set
        End Property

        Public Property [reportDate]() As DateTime
            Get
                Return _reportDate
            End Get
            Set(ByVal Value As DateTime)
                _reportDate = Value
            End Set
        End Property

        Public Property [customerPICName]() As String
            Get
                Return _customerPICName
            End Get
            Set(ByVal Value As String)
                _customerPICName = Value
            End Set
        End Property

        Public Property [customerPICTitle]() As String
            Get
                Return _customerPICTitle
            End Get
            Set(ByVal Value As String)
                _customerPICTitle = Value
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
