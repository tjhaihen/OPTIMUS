Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ReportImage
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _reportImageID, _reportTypeID, _reportHdID, _picDescription, _picType As String
        Private _picSize As Integer
        Private _reportpic As SqlBinary
        Private _isShowOnMainReport As Boolean
        Private _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO ReportImage " + _
                                        "(reportTypeID, reportHdID, ReportImageID, reportpic, " + _
                                        "picDescription, picSize, picType, isShowOnMainReport, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@reportTypeID, @reportHdID, @ReportImageID, @reportpic, " + _
                                        "@picDescription, @picSize, @picType, @isShowOnMainReport, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("ReportImage", "ReportImageID")

            Try
                cmdToExecute.Parameters.AddWithValue("@reportTypeID", _reportTypeID)
                cmdToExecute.Parameters.AddWithValue("@reportHdID", _reportHdID)
                cmdToExecute.Parameters.AddWithValue("@ReportImageID", strID)
                cmdToExecute.Parameters.AddWithValue("@reportpic", _reportpic)
                cmdToExecute.Parameters.AddWithValue("@picDescription", _picDescription)
                cmdToExecute.Parameters.AddWithValue("@picSize", _picSize)
                cmdToExecute.Parameters.AddWithValue("@picType", _picType)
                cmdToExecute.Parameters.AddWithValue("@isShowOnMainReport", _isShowOnMainReport)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _reportImageID = strID
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
            cmdToExecute.CommandText = "UPDATE ReportImage " + _
                                        "SET picDescription=@picDescription, " + _
                                        "isShowOnMainReport=@isShowOnMainReport, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE ReportImageID=@ReportImageID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ReportImageID", _ReportImageID)
                cmdToExecute.Parameters.AddWithValue("@picDescription", _picDescription)
                cmdToExecute.Parameters.AddWithValue("@isShowOnMainReport", _isShowOnMainReport)
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
            cmdToExecute.CommandText = "SELECT * FROM ReportImage"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ReportImage")
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
            cmdToExecute.CommandText = "SELECT * FROM ReportImage WHERE ReportImageID=@ReportImageID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ReportImage")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ReportImageID", _ReportImageID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _reportTypeID = CType(toReturn.Rows(0)("reportTypeID"), String)
                    _reportHdID = CType(toReturn.Rows(0)("reportHdID"), String)
                    _reportImageID = CType(toReturn.Rows(0)("ReportImageID"), String)
                    _reportpic = CType(toReturn.Rows(0)("reportpic"), Byte())
                    _picDescription = CType(toReturn.Rows(0)("picDescription"), String)
                    _picSize = CType(toReturn.Rows(0)("picSize"), Integer)
                    _picType = CType(toReturn.Rows(0)("picType"), String)
                    _isShowOnMainReport = CType(toReturn.Rows(0)("isShowOnMainReport"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM ReportImage " + _
                                        "WHERE ReportImageID=@ReportImageID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ReportImageID", _ReportImageID)

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
        Public Function SelectByReportTypeIDReportHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM ReportImage WHERE reportTypeID=@reportTypeID AND reportHdID=@reportHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ReportImage")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@reportTypeID", _reportTypeID)
                cmdToExecute.Parameters.AddWithValue("@reportHdID", _reportHdID)

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
        Public Property [reportTypeID]() As String
            Get
                Return _reportTypeID
            End Get
            Set(ByVal Value As String)
                _reportTypeID = Value
            End Set
        End Property

        Public Property [reportHdID]() As String
            Get
                Return _reportHdID
            End Get
            Set(ByVal Value As String)
                _reportHdID = Value
            End Set
        End Property

        Public Property [ReportImageID]() As String
            Get
                Return _reportImageID
            End Get
            Set(ByVal Value As String)
                _reportImageID = Value
            End Set
        End Property

        Public Property [reportpic]() As SqlBinary
            Get
                Return _reportpic
            End Get
            Set(ByVal Value As SqlBinary)
                _reportpic = Value
            End Set
        End Property

        Public Property [picDescription]() As String
            Get
                Return _picDescription
            End Get
            Set(ByVal Value As String)
                _picDescription = Value
            End Set
        End Property

        Public Property [picSize]() As Integer
            Get
                Return _picSize
            End Get
            Set(ByVal Value As Integer)
                _picSize = Value
            End Set
        End Property

        Public Property [picType]() As String
            Get
                Return _picType
            End Get
            Set(ByVal Value As String)
                _picType = Value
            End Set
        End Property

        Public Property [isShowOnMainReport]() As Boolean
            Get
                Return _isShowOnMainReport
            End Get
            Set(ByVal Value As Boolean)
                _isShowOnMainReport = Value
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
