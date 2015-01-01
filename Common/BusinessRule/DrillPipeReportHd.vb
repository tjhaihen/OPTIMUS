Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class DrillPipeReportHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _drillPipeReportHdID, _projectID, _inspectionSpecID, _reportNo, _remarks As String
        Private _size, _weight, _grade, _connection, _range, _nominalWT As String
        Private _captionTemplateHdID As String
        Private _userIDinsert, _userIDupdate As String
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
            cmdToExecute.CommandText = "INSERT INTO DrillPipeReportHd " + _
                                        "(drillPipeReportHdID, projectID, inspectionSpecID, reportNo, reportDate, remarks, " + _
                                        "size, weight, grade, connection, range, nominalWT, captionTemplateHdID, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@drillPipeReportHdID, @projectID, @inspectionSpecID, @reportNo, @reportDate, @remarks, " + _
                                        "@size, @weight, @grade, @connection, @range, @nominalWT, @captionTemplateHdID, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strDrillPipeReportHdID As String = ID.GenerateIDNumber("DrillPipeReportHd", "drillPipeReportHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", strDrillPipeReportHdID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecID", _inspectionSpecID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@weight", _weight)
                cmdToExecute.Parameters.AddWithValue("@grade", _grade)
                cmdToExecute.Parameters.AddWithValue("@connection", _connection)
                cmdToExecute.Parameters.AddWithValue("@range", _range)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", _captionTemplateHdID)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _drillPipeReportHdID = strDrillPipeReportHdID
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
            cmdToExecute.CommandText = "UPDATE DrillPipeReportHd " + _
                                        "SET inspectionSpecID=@inspectionSpecID, reportNo=@reportNo, reportDate=@reportDate, remarks=@remarks, " + _
                                        "size=@size, weight=@weight, grade=@grade, connection=@connection, range=@range, nominalWT=@nominalWT, " + _
                                        "captionTemplateHdID=@captionTemplateHdID, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE drillPipeReportHdID=@drillPipeReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", _drillPipeReportHdID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@inspectionSpecID", _inspectionSpecID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)                
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@weight", _weight)
                cmdToExecute.Parameters.AddWithValue("@grade", _grade)
                cmdToExecute.Parameters.AddWithValue("@connection", _connection)
                cmdToExecute.Parameters.AddWithValue("@range", _range)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", _captionTemplateHdID)
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
            cmdToExecute.CommandText = "SELECT * FROM DrillPipeReportHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportHd")
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
            cmdToExecute.CommandText = "SELECT * FROM DrillPipeReportHd WHERE drillPipeReportHdID=@drillPipeReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", _drillPipeReportHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _drillPipeReportHdID = CType(toReturn.Rows(0)("drillPipeReportHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _inspectionSpecID = CType(toReturn.Rows(0)("inspectionSpecID"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _reportDate = CType(toReturn.Rows(0)("reportDate"), DateTime)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _size = CType(toReturn.Rows(0)("size"), String)
                    _weight = CType(toReturn.Rows(0)("weight"), String)
                    _grade = CType(toReturn.Rows(0)("grade"), String)
                    _connection = CType(toReturn.Rows(0)("connection"), String)
                    _range = CType(toReturn.Rows(0)("range"), String)
                    _nominalWT = CType(toReturn.Rows(0)("nominalWT"), String)
                    _captionTemplateHdID = CType(toReturn.Rows(0)("captionTemplateHdID"), String)
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
            cmdToExecute.CommandText = "DELETE FROM DrillPipeReportHd " + _
                                        "WHERE drillPipeReportHdID=@drillPipeReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drillPipeReportHdID", _drillPipeReportHdID)

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
                                        "FROM DrillPipeReportHd drh WHERE drh.projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrillPipeReportHd")
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
        Public Property [drillPipeReportHdID]() As String
            Get
                Return _drillPipeReportHdID
            End Get
            Set(ByVal Value As String)
                _drillPipeReportHdID = Value
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

        Public Property [inspectionSpecID]() As String
            Get
                Return _inspectionSpecID
            End Get
            Set(ByVal Value As String)
                _inspectionSpecID = Value
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

        Public Property [size]() As String
            Get
                Return _size
            End Get
            Set(ByVal Value As String)
                _size = Value
            End Set
        End Property

        Public Property [weight]() As String
            Get
                Return _weight
            End Get
            Set(ByVal Value As String)
                _weight = Value
            End Set
        End Property

        Public Property [grade]() As String
            Get
                Return _grade
            End Get
            Set(ByVal Value As String)
                _grade = Value
            End Set
        End Property

        Public Property [connection]() As String
            Get
                Return _connection
            End Get
            Set(ByVal Value As String)
                _connection = Value
            End Set
        End Property

        Public Property [range]() As String
            Get
                Return _range
            End Get
            Set(ByVal Value As String)
                _range = Value
            End Set
        End Property

        Public Property [nominalWT]() As String
            Get
                Return _nominalWT
            End Get
            Set(ByVal Value As String)
                _nominalWT = Value
            End Set
        End Property

        Public Property [captionTemplateHdID]() As String
            Get
                Return _captionTemplateHdID
            End Get
            Set(ByVal Value As String)
                _captionTemplateHdID = Value
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
