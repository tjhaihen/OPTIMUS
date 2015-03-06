Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ThoroughVisualReportHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _tviHdID, _projectID, _reportNo, _tviTypeSCode, _description As String
        Private _serialNo, _WLLSWL, _dimension, _length, _manufacture, _defectFound, _examineWith, _result, _note As String
        Private _reportDate, _nextInspectionDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO ThoroughVisualReportHd " + _
                                        "(tviHdID, projectID, reportNo, tviTypeSCode, description, " + _
                                        "serialNo, WLLSWL, dimension, length, manufacture, defectFound, examineWith, result, note, " + _
                                        "reportDate, nextInspectionDate, insertDate, updateDate, " + _
                                        "userIDInsert, userIDUpdate) " + _
                                        "VALUES " + _
                                        "(@tviHdID, @projectID, @reportNo, @tviTypeSCode, @description, " + _
                                        "@serialNo, @WLLSWL, @dimension, @length, @manufacture, @defectFound, @examineWith, @result, @note, " + _
                                        "@reportDate, @nextInspectionDate, GETDATE(), GETDATE(), " + _
                                        "@userIDInsert, @userIDUpdate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("ThoroughVisualReportHd", "tviHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@tviHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@tviTypeSCode", _tviTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@WLLSWL", _WLLSWL)
                cmdToExecute.Parameters.AddWithValue("@dimension", _dimension)
                cmdToExecute.Parameters.AddWithValue("@length", _length)
                cmdToExecute.Parameters.AddWithValue("@manufacture", _manufacture)
                cmdToExecute.Parameters.AddWithValue("@defectFound", _defectFound)
                cmdToExecute.Parameters.AddWithValue("@examineWith", _examineWith)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@note", _note)
                cmdToExecute.Parameters.AddWithValue("@nextInspectionDate", _nextInspectionDate)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _tviHdID = strID
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
            cmdToExecute.CommandText = "UPDATE ThoroughVisualReportHd " + _
                                        "SET reportNo=@reportNo, reportDate=@reportDate, nextInspectionDate=@nextInspectionDate, " + _
                                        "tviTypeSCode=@tviTypeSCode, description=@description, serialNo=@serialNo, " + _
                                        "WLLSWL=@WLLSWL, dimension=@dimension, length=@length, manufacture=@manufacture, " + _
                                        "defectFound=@defectFound, examineWith=@examineWith, result=@result, note=@note, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE UTSpotCheckHdID=@UTSpotCheckHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@tviHdID", _tviHdID)
                cmdToExecute.Parameters.AddWithValue("@reportNo", _reportNo)
                cmdToExecute.Parameters.AddWithValue("@tviTypeSCode", _tviTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@serialNo", _serialNo)
                cmdToExecute.Parameters.AddWithValue("@WLLSWL", _WLLSWL)
                cmdToExecute.Parameters.AddWithValue("@dimension", _dimension)
                cmdToExecute.Parameters.AddWithValue("@length", _length)
                cmdToExecute.Parameters.AddWithValue("@manufacture", _manufacture)
                cmdToExecute.Parameters.AddWithValue("@defectFound", _defectFound)
                cmdToExecute.Parameters.AddWithValue("@examineWith", _examineWith)
                cmdToExecute.Parameters.AddWithValue("@result", _result)
                cmdToExecute.Parameters.AddWithValue("@note", _note)
                cmdToExecute.Parameters.AddWithValue("@nextInspectionDate", _nextInspectionDate)
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
            cmdToExecute.CommandText = "SELECT * FROM ThoroughVisualReportHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ThoroughVisualReportHd")
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
            cmdToExecute.CommandText = "SELECT * FROM ThoroughVisualReportHd WHERE tviHdID=@tviHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ThoroughVisualReportHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@tviHdID", _tviHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _tviHdID = CType(toReturn.Rows(0)("tviHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _reportNo = CType(toReturn.Rows(0)("reportNo"), String)
                    _tviTypeSCode = CType(toReturn.Rows(0)("tviTypeSCode"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _serialNo = CType(toReturn.Rows(0)("serialNo"), String)
                    _WLLSWL = CType(toReturn.Rows(0)("WLLSWL"), String)
                    _dimension = CType(toReturn.Rows(0)("dimension"), String)
                    _length = CType(toReturn.Rows(0)("length"), String)
                    _manufacture = CType(toReturn.Rows(0)("manufacture"), String)
                    _defectFound = CType(toReturn.Rows(0)("defectFound"), String)
                    _examineWith = CType(toReturn.Rows(0)("examineWith"), String)
                    _result = CType(toReturn.Rows(0)("result"), String)
                    _note = CType(toReturn.Rows(0)("note"), String)
                    _nextInspectionDate = CType(toReturn.Rows(0)("nextInspectionDate"), DateTime)
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
            cmdToExecute.CommandText = "DELETE FROM ThoroughVisualReportHd " + _
                                        "WHERE tviHdID=@tviHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@tviHdID", _tviHdID)

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
                                        "FROM ThoroughVisualReportHd WHERE projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ThoroughVisualReportHd")
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
        Public Property [tviHdID]() As String
            Get
                Return _tviHdID
            End Get
            Set(ByVal Value As String)
                _tviHdID = Value
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

        Public Property [tviTypeSCode]() As String
            Get
                Return _tviTypeSCode
            End Get
            Set(ByVal Value As String)
                _tviTypeSCode = Value
            End Set
        End Property

        Public Property [Description]() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Public Property [SerialNo]() As String
            Get
                Return _serialNo
            End Get
            Set(ByVal Value As String)
                _serialNo = Value
            End Set
        End Property

        Public Property [WLLSWL]() As String
            Get
                Return _WLLSWL
            End Get
            Set(ByVal Value As String)
                _WLLSWL = Value
            End Set
        End Property

        Public Property [Dimension]() As String
            Get
                Return _dimension
            End Get
            Set(ByVal Value As String)
                _dimension = Value
            End Set
        End Property

        Public Property [Length]() As String
            Get
                Return _length
            End Get
            Set(ByVal Value As String)
                _length = Value
            End Set
        End Property

        Public Property [Manufacture]() As String
            Get
                Return _manufacture
            End Get
            Set(ByVal Value As String)
                _manufacture = Value
            End Set
        End Property

        Public Property [DefectFound]() As String
            Get
                Return _defectFound
            End Get
            Set(ByVal Value As String)
                _defectFound = Value
            End Set
        End Property

        Public Property [ExamineWith]() As String
            Get
                Return _examineWith
            End Get
            Set(ByVal Value As String)
                _examineWith = Value
            End Set
        End Property

        Public Property [Result]() As String
            Get
                Return _result
            End Get
            Set(ByVal Value As String)
                _result = Value
            End Set
        End Property

        Public Property [Note]() As String
            Get
                Return _note
            End Get
            Set(ByVal Value As String)
                _note = Value
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

        Public Property [NextInspectionDate]() As DateTime
            Get
                Return _nextInspectionDate
            End Get
            Set(ByVal Value As DateTime)
                _nextInspectionDate = Value
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
