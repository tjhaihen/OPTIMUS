Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class InspectionTallyReportHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _InspectionTallyHdID, _projectID, _reportNo, _inspectionTallyTypeSCode, _driftSizeLength As String
        Private _driftSizeOD, _size, _grade, _weight, _connection, _range, _nominalWT, _ACcaption1, _
                    _ACcaption2, _ACcaption3, _ACcaption4 As String
        Private _isAC1, _isAC2, _isAC3, _isAC4 As Boolean
        Private _reportDate, _insertDate, _updateDate As DateTime
        Private _userIDInsert, _userIDUpdate As String
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
            cmdToExecute.CommandText = "INSERT INTO InspectionTallyReportHd " + _
                                        "(InspectionTallyHdID, projectID, reportNo, inspectionTallyTypeSCode, driftSizeLength, " + _
                                        "driftSizeOD, size, grade, weight, connection, range, nominalWT, " + _
                                        "ACcaption1, ACcaption2, ACcaption3, ACcaption4, " + _
                                        "isAC1, isAC2, isAC3, isAC4, " + _
                                        "reportDate, insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@InspectionTallyHdID, @projectID, @reportNo, @inspectionTallyTypeSCode, @driftSizeLength, " + _
                                        "@driftSizeOD, @size, @grade, @weight, @connection, @range, @nominalWT, " + _
                                        "@ACcaption1, @ACcaption2, @ACcaption3, @ACcaption4, " + _
                                        "@isAC1, @isAC2, @isAC3, @isAC4, " + _
                                        "@reportDate, GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("InspectionTallyReportHd", "InspectionTallyHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@inspectionTallyTypeSCode", _inspectionTallyTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@driftSizeLength", _driftSizeLength)
                cmdToExecute.Parameters.AddWithValue("@driftSizeOD", _driftSizeOD)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@grade", _grade)
                cmdToExecute.Parameters.AddWithValue("@weight", _weight)
                cmdToExecute.Parameters.AddWithValue("@connection", _connection)
                cmdToExecute.Parameters.AddWithValue("@range", _range)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@ACcaption1", _ACcaption1)
                cmdToExecute.Parameters.AddWithValue("@ACcaption2", _ACcaption2)
                cmdToExecute.Parameters.AddWithValue("@ACcaption3", _ACcaption3)
                cmdToExecute.Parameters.AddWithValue("@ACcaption4", _ACcaption4)
                cmdToExecute.Parameters.AddWithValue("@isAC1", _isAC1)
                cmdToExecute.Parameters.AddWithValue("@isAC2", _isAC2)
                cmdToExecute.Parameters.AddWithValue("@isAC3", _isAC3)
                cmdToExecute.Parameters.AddWithValue("@isAC4", _isAC4)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _InspectionTallyHdID = strID
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
            cmdToExecute.CommandText = "UPDATE InspectionTallyReportHd " + _
                                        "SET reportNo=@reportNo, reportDate=@reportDate, " + _
                                        "inspectionTallyTypeSCode=@inspectionTallyTypeSCode, driftSizeOD=@driftSizeOD, " + _
                                        "size=@size, grade=@grade, weight=@weight, " + _
                                        "connection=@connection, range=@range, nominalWT=@nominalWT, " + _
                                        "ACcaption1=@ACcaption1, ACcaption2=@ACcaption2, ACcaption3=@ACcaption3, ACcaption4=@ACcaption4, " + _
                                        "isAC1=@isAC1, isAC2=@isAC2, isAC3=@isAC3, isAC4=@isAC4, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE InspectionTallyHdID=@InspectionTallyHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyHdID", _InspectionTallyHdID)                
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@inspectionTallyTypeSCode", _inspectionTallyTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@driftSizeOD", _driftSizeOD)
                cmdToExecute.Parameters.AddWithValue("@size", _size)
                cmdToExecute.Parameters.AddWithValue("@grade", _grade)
                cmdToExecute.Parameters.AddWithValue("@weight", _weight)
                cmdToExecute.Parameters.AddWithValue("@connection", _connection)
                cmdToExecute.Parameters.AddWithValue("@range", _range)
                cmdToExecute.Parameters.AddWithValue("@nominalWT", _nominalWT)
                cmdToExecute.Parameters.AddWithValue("@ACcaption1", _ACcaption1)
                cmdToExecute.Parameters.AddWithValue("@ACcaption2", _ACcaption2)
                cmdToExecute.Parameters.AddWithValue("@ACcaption3", _ACcaption3)
                cmdToExecute.Parameters.AddWithValue("@ACcaption4", _ACcaption4)
                cmdToExecute.Parameters.AddWithValue("@isAC1", _isAC1)
                cmdToExecute.Parameters.AddWithValue("@isAC2", _isAC2)
                cmdToExecute.Parameters.AddWithValue("@isAC3", _isAC3)
                cmdToExecute.Parameters.AddWithValue("@isAC4", _isAC4)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

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
            cmdToExecute.CommandText = "SELECT * FROM InspectionTallyReportHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionTallyReportHd")
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionTallyReportHd WHERE InspectionTallyHdID=@InspectionTallyHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionTallyReportHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyHdID", _InspectionTallyHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _InspectionTallyHdID = CType(toReturn.Rows(0)("InspectionTallyHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _inspectionTallyTypeSCode = CType(toReturn.Rows(0)("inspectionTallyTypeSCode"), String)
                    _driftSizeLength = CType(toReturn.Rows(0)("driftSizeLength"), String)
                    _driftSizeOD = CType(toReturn.Rows(0)("driftSizeOD"), String)
                    _size = CType(toReturn.Rows(0)("size"), String)
                    _grade = CType(toReturn.Rows(0)("grade"), String)
                    _weight = CType(toReturn.Rows(0)("weight"), String)
                    _connection = CType(toReturn.Rows(0)("connection"), String)
                    _range = CType(toReturn.Rows(0)("range"), String)
                    _nominalWT = CType(toReturn.Rows(0)("nominalWT"), String)
                    _ACcaption1 = CType(toReturn.Rows(0)("ACcaption1"), String)
                    _ACcaption2 = CType(toReturn.Rows(0)("ACcaption2"), String)
                    _ACcaption3 = CType(toReturn.Rows(0)("ACcaption3"), String)
                    _ACcaption4 = CType(toReturn.Rows(0)("ACcaption4"), String)
                    _isAC1 = CType(toReturn.Rows(0)("isAC1"), Boolean)
                    _isAC2 = CType(toReturn.Rows(0)("isAC2"), Boolean)
                    _isAC3 = CType(toReturn.Rows(0)("isAC3"), Boolean)
                    _isAC4 = CType(toReturn.Rows(0)("isAC4"), Boolean)
                    _reportDate = CType(toReturn.Rows(0)("reportDate"), DateTime)
                    _userIDInsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDUpdate = CType(toReturn.Rows(0)("userIDupdate"), String)
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
            cmdToExecute.CommandText = "DELETE FROM InspectionTallyReportHd " + _
                                        "WHERE InspectionTallyHdID=@InspectionTallyHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@InspectionTallyHdID", _InspectionTallyHdID)

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
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM InspectionTallyReportHd WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionTallyReportHd")
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
        Public Property [InspectionTallyHdID]() As String
            Get
                Return _InspectionTallyHdID
            End Get
            Set(ByVal Value As String)
                _InspectionTallyHdID = Value
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

        Public Property [inspectionTallyTypeSCode]() As String
            Get
                Return _inspectionTallyTypeSCode
            End Get
            Set(ByVal Value As String)
                _inspectionTallyTypeSCode = Value
            End Set
        End Property

        Public Property [driftSizeLength]() As String
            Get
                Return _driftSizeLength
            End Get
            Set(ByVal Value As String)
                _driftSizeLength = Value
            End Set
        End Property

        Public Property [driftSizeOD]() As String
            Get
                Return _driftSizeOD
            End Get
            Set(ByVal Value As String)
                _driftSizeOD = Value
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

        Public Property [grade]() As String
            Get
                Return _grade
            End Get
            Set(ByVal Value As String)
                _grade = Value
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

        Public Property [ACcaption1]() As String
            Get
                Return _ACcaption1
            End Get
            Set(ByVal Value As String)
                _ACcaption1 = Value
            End Set
        End Property

        Public Property [ACcaption2]() As String
            Get
                Return _ACcaption2
            End Get
            Set(ByVal Value As String)
                _ACcaption2 = Value
            End Set
        End Property

        Public Property [ACcaption3]() As String
            Get
                Return _ACcaption3
            End Get
            Set(ByVal Value As String)
                _ACcaption3 = Value
            End Set
        End Property

        Public Property [ACcaption4]() As String
            Get
                Return _ACcaption4
            End Get
            Set(ByVal Value As String)
                _ACcaption4 = Value
            End Set
        End Property

        Public Property [isAC1]() As Boolean
            Get
                Return _isAC1
            End Get
            Set(ByVal Value As Boolean)
                _isAC1 = Value
            End Set
        End Property

        Public Property [isAC2]() As Boolean
            Get
                Return _isAC2
            End Get
            Set(ByVal Value As Boolean)
                _isAC2 = Value
            End Set
        End Property

        Public Property [isAC3]() As Boolean
            Get
                Return _isAC3
            End Get
            Set(ByVal Value As Boolean)
                _isAC3 = Value
            End Set
        End Property

        Public Property [isAC4]() As Boolean
            Get
                Return _isAC4
            End Get
            Set(ByVal Value As Boolean)
                _isAC4 = Value
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
                Return _userIDInsert
            End Get
            Set(ByVal Value As String)
                _userIDInsert = Value
            End Set
        End Property

        Public Property [userIDupdate]() As String
            Get
                Return _userIDUpdate
            End Get
            Set(ByVal Value As String)
                _userIDUpdate = Value
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
