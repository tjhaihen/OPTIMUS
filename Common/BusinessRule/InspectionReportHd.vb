Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class InspectionReportHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _inspectionReportHdID, _projectID, _reportNo, _inspectionReportTypeSCode As String
        Private _description, _notes, _customerPICName As String
        Private _isMPI, _isVisualThread, _isDimensional, _isBlacklightConnection, _isVisualBodyInspection As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO InspectionReportHd " + _
                                        "(inspectionReportHdID, projectID, reportNo, reportDate, " + _
                                        "inspectionReportTypeSCode, isMPI, isVisualThread, isDimensional, " + _
                                        "isBlacklightConnection, isVisualBodyInspection, " + _
                                        "description, notes, customerPICName, " + _
                                        "insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@inspectionReportHdID, @projectID, @reportNo, @reportDate, " + _
                                        "@inspectionReportTypeSCode, @isMPI, @isVisualThread, @isDimensional, " + _
                                        "@isBlacklightConnection, @isVisualBodyInspection, " + _
                                        "@description, @notes, @customerPICName, " + _
                                        "GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("InspectionReportHd", "inspectionReportHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@inspectionReportTypeSCode", _inspectionReportTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@isMPI", _isMPI)
                cmdToExecute.Parameters.AddWithValue("@isVisualThread", _isVisualThread)
                cmdToExecute.Parameters.AddWithValue("@isDimensional", _isDimensional)
                cmdToExecute.Parameters.AddWithValue("@isBlacklightConnection", _isBlacklightConnection)
                cmdToExecute.Parameters.AddWithValue("@isVisualBodyInspection", _isVisualBodyInspection)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@notes", _notes)
                cmdToExecute.Parameters.AddWithValue("@customerPICName", _customerPICName)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _inspectionReportHdID = strID
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
            cmdToExecute.CommandText = "UPDATE InspectionReportHd " + _
                                        "SET reportNo=@reportNo, reportDate=@reportDate, " + _
                                        "inspectionReportTypeSCode=@inspectionReportTypeSCode, isMPI=@isMPI, " + _
                                        "isVisualThread=@isVisualThread, isDimensional=@isDimensional, " + _
                                        "isBlacklightConnection=@isBlacklightConnection, isVisualBodyInspection=@isVisualBodyInspection, " + _
                                        "description=@description, notes=@notes, customerPICName=@customerPICName, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE inspectionReportHdID=@inspectionReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@inspectionReportTypeSCode", _inspectionReportTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@isMPI", _isMPI)
                cmdToExecute.Parameters.AddWithValue("@isVisualThread", _isVisualThread)
                cmdToExecute.Parameters.AddWithValue("@isDimensional", _isDimensional)
                cmdToExecute.Parameters.AddWithValue("@isBlacklightConnection", _isBlacklightConnection)
                cmdToExecute.Parameters.AddWithValue("@isVisualBodyInspection", _isVisualBodyInspection)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@notes", _notes)
                cmdToExecute.Parameters.AddWithValue("@customerPICName", _customerPICName)
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionReportHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportHd")
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
            cmdToExecute.CommandText = "SELECT * FROM InspectionReportHd WHERE inspectionReportHdID=@inspectionReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _inspectionReportHdID = CType(toReturn.Rows(0)("inspectionReportHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _reportDate = CType(toReturn.Rows(0)("reportDate"), DateTime)
                    _inspectionReportTypeSCode = CType(toReturn.Rows(0)("inspectionReportTypeSCode"), String)
                    _isMPI = CType(toReturn.Rows(0)("isMPI"), Boolean)
                    _isVisualThread = CType(toReturn.Rows(0)("isVisualThread"), Boolean)
                    _isDimensional = CType(toReturn.Rows(0)("isDimensional"), Boolean)
                    _isBlacklightConnection = CType(toReturn.Rows(0)("isBlacklightConnection"), Boolean)
                    _isVisualBodyInspection = CType(toReturn.Rows(0)("isVisualBodyInspection"), Boolean)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _notes = CType(toReturn.Rows(0)("notes"), String)
                    _customerPICName = CType(toReturn.Rows(0)("customerPICName"), String)
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
            cmdToExecute.CommandText = "DELETE FROM InspectionReportHd " + _
                                        "WHERE inspectionReportHdID=@inspectionReportHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@inspectionReportHdID", _inspectionReportHdID)

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
                                        "FROM InspectionReportHd WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("InspectionReportHd")
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
        Public Property [inspectionReportHdID]() As String
            Get
                Return _inspectionReportHdID
            End Get
            Set(ByVal Value As String)
                _inspectionReportHdID = Value
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

        Public Property [reportDate]() As DateTime
            Get
                Return _reportDate
            End Get
            Set(ByVal Value As DateTime)
                _reportDate = Value
            End Set
        End Property

        Public Property [inspectionReportTypeSCode]() As String
            Get
                Return _inspectionReportTypeSCode
            End Get
            Set(ByVal Value As String)
                _inspectionReportTypeSCode = Value
            End Set
        End Property

        Public Property [isMPI]() As Boolean
            Get
                Return _isMPI
            End Get
            Set(ByVal Value As Boolean)
                _isMPI = Value
            End Set
        End Property

        Public Property [isVisualThread]() As Boolean
            Get
                Return _isVisualThread
            End Get
            Set(ByVal Value As Boolean)
                _isVisualThread = Value
            End Set
        End Property

        Public Property [isDimensional]() As Boolean
            Get
                Return _isDimensional
            End Get
            Set(ByVal Value As Boolean)
                _isDimensional = Value
            End Set
        End Property

        Public Property [isBlacklightConnection]() As Boolean
            Get
                Return _isBlacklightConnection
            End Get
            Set(ByVal Value As Boolean)
                _isBlacklightConnection = Value
            End Set
        End Property

        Public Property [isVisualBodyInspection]() As Boolean
            Get
                Return _isVisualBodyInspection
            End Get
            Set(ByVal Value As Boolean)
                _isVisualBodyInspection = Value
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

        Public Property [notes]() As String
            Get
                Return _notes
            End Get
            Set(ByVal Value As String)
                _notes = Value
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
