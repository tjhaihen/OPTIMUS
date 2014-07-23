Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class TimeSheet
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _timeSheetID, _projectResourceID, _workingTypeSCode, _remarks As String
        Private _userIDinsert, _userIDupdate As String
        Private _workingDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO TimeSheet " + _
                                        "(timeSheetID, projectResourceID, workingDate, workingTypeSCode, " + _
                                        "remarks, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@timeSheetID, @projectResourceID, @workingDate, @workingTypeSCode, " + _
                                        "@remarks, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strTimeSheetID As String = ID.GenerateIDNumber("TimeSheet", "timeSheetID")

            Try
                cmdToExecute.Parameters.AddWithValue("@timeSheetID", strTimeSheetID)            
                cmdToExecute.Parameters.AddWithValue("@projectResourceID", _projectResourceID)
                cmdToExecute.Parameters.AddWithValue("@workingDate", _workingDate)
                cmdToExecute.Parameters.AddWithValue("@workingTypeSCode", _workingTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _timeSheetID = strTimeSheetID
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
            cmdToExecute.CommandText = "UPDATE TimeSheet " + _
                                        "SET workingTypeSCode=@workingTypeSCode, remarks=@remarks, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE timeSheetID=@timeSheetID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@timeSheetID", _timeSheetID)                
                cmdToExecute.Parameters.AddWithValue("@workingTypeSCode", _workingTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)                
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
            cmdToExecute.CommandText = "SELECT * FROM TimeSheet"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("TimeSheet")
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
            cmdToExecute.CommandText = "SELECT * FROM TimeSheet WHERE timeSheetID=@timeSheetID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("TimeSheet")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@timeSheetID", _timeSheetID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _timeSheetID = CType(toReturn.Rows(0)("timeSheetID"), String)
                    _projectResourceID = CType(toReturn.Rows(0)("projectResourceID"), String)
                    _workingDate = CType(toReturn.Rows(0)("workingDate"), DateTime)
                    _workingTypeSCode = CType(toReturn.Rows(0)("workingTypeSCode"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
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
            cmdToExecute.CommandText = "DELETE FROM TimeSheet " + _
                                        "WHERE timeSheetID=@timeSheetID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@timeSheetID", _timeSheetID)

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

#Region " Custom "
        Public Function SelectByProjectResourceIDWorkingDate() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT TOP 1 * FROM TimeSheet WHERE projectResourceID=@projectResourceID " + _
                                        "AND CONVERT(VARCHAR,workingDate,112)=CONVERT(VARCHAR,@workingDate,112)"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("TimeSheet_SelectByrojectResourceIDWorkingDate")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectResourceID", _projectResourceID)
                cmdToExecute.Parameters.AddWithValue("@workingDate", _workingDate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _timeSheetID = CType(toReturn.Rows(0)("timeSheetID"), String)
                    _projectResourceID = CType(toReturn.Rows(0)("projectResourceID"), String)
                    _workingDate = CType(toReturn.Rows(0)("workingDate"), DateTime)
                    _workingTypeSCode = CType(toReturn.Rows(0)("workingTypeSCode"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
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
#End Region

#Region " Class Property Declarations "
        Public Property [timeSheetID]() As String
            Get
                Return _timeSheetID
            End Get
            Set(ByVal Value As String)
                _timeSheetID = Value
            End Set
        End Property

        Public Property [projectResourceID]() As String
            Get
                Return _projectResourceID
            End Get
            Set(ByVal Value As String)
                _projectResourceID = Value
            End Set
        End Property

        Public Property [workingDate]() As DateTime
            Get
                Return _workingDate
            End Get
            Set(ByVal Value As DateTime)
                _workingDate = Value
            End Set
        End Property

        Public Property [workingTypeSCode]() As String
            Get
                Return _workingTypeSCode
            End Get
            Set(ByVal Value As String)
                _workingTypeSCode = Value
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
