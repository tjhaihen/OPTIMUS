Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ReportType
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _reportTypeID, _reportTypeCode, _parentreportTypeCode, _reportTypeName, _panelID, _sequence As String
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime
        Private _isActive As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO reportType " + _
                                        "(reportTypeID, reportTypeCode, parentreportTypeCode, reportTypeName, sequence, " + _
                                        "isActive, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@reportTypeID, @reportTypeCode, @parentreportTypeCode, @reportTypeName, @sequence, " + _
                                        "@isActive, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strreportTypeID As String = ID.GenerateIDNumber("reportType", "reportTypeID")

            Try
                cmdToExecute.Parameters.AddWithValue("@reportTypeID", strreportTypeID)
                cmdToExecute.Parameters.AddWithValue("@reportTypeCode", _reportTypeCode)
                cmdToExecute.Parameters.AddWithValue("@parentreportTypeCode", _parentreportTypeCode)
                cmdToExecute.Parameters.AddWithValue("@reportTypeName", _reportTypeName)
                cmdToExecute.Parameters.AddWithValue("@sequence", _sequence)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _reportTypeID = strreportTypeID
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
            cmdToExecute.CommandText = "UPDATE reportType " + _
                                        "SET reportTypeCode=@reportTypeCode, parentreportTypeCode=@parentreportTypeCode, reportTypeName=@reportTypeName, " + _
                                        "sequence=@sequence, isActive=@isActive, userIDupdate=@userIDupdate, " + _
                                        "updateDate=GETDATE() " + _
                                        "WHERE reportTypeID=@reportTypeID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@reportTypeID", _reportTypeID)
                cmdToExecute.Parameters.AddWithValue("@reportTypeCode", _reportTypeCode)
                cmdToExecute.Parameters.AddWithValue("@parentreportTypeCode", _parentreportTypeCode)
                cmdToExecute.Parameters.AddWithValue("@reportTypeName", _reportTypeName)
                cmdToExecute.Parameters.AddWithValue("@sequence", _sequence)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
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
            cmdToExecute.CommandText = "SELECT * FROM reportType ORDER BY sequence"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("reportType")
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
            cmdToExecute.CommandText = "SELECT * FROM reportType WHERE reportTypeID=@reportTypeID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("reportType")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@reportTypeID", _reportTypeID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _reportTypeID = CType(toReturn.Rows(0)("reportTypeID"), String)
                    _reportTypeCode = CType(toReturn.Rows(0)("reportTypeCode"), String)
                    _parentreportTypeCode = CType(toReturn.Rows(0)("parentreportTypeCode"), String)
                    _reportTypeName = CType(toReturn.Rows(0)("reportTypeName"), String)
                    _sequence = CType(toReturn.Rows(0)("sequence"), String)
                    _panelID = CType(toReturn.Rows(0)("panelID"), String)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM reportType " + _
                                        "WHERE reportTypeID=@reportTypeID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@reportTypeID", _reportTypeID)

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
        Public Property [reportTypeID]() As String
            Get
                Return _reportTypeID
            End Get
            Set(ByVal Value As String)
                _reportTypeID = Value
            End Set
        End Property

        Public Property [reportTypeCode]() As String
            Get
                Return _reportTypeCode
            End Get
            Set(ByVal Value As String)
                _reportTypeCode = Value
            End Set
        End Property

        Public Property [parentreportTypeCode]() As String
            Get
                Return _parentreportTypeCode
            End Get
            Set(ByVal Value As String)
                _parentreportTypeCode = Value
            End Set
        End Property

        Public Property [reportTypeName]() As String
            Get
                Return _reportTypeName
            End Get
            Set(ByVal Value As String)
                _reportTypeName = Value
            End Set
        End Property

        Public Property [sequence]() As String
            Get
                Return _sequence
            End Get
            Set(ByVal Value As String)
                _sequence = Value
            End Set
        End Property

        Public Property [panelID]() As String
            Get
                Return _panelID
            End Get
            Set(ByVal Value As String)
                _panelID = Value
            End Set
        End Property

        Public Property [isActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
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
