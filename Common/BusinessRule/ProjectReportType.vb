Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ProjectReportType
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _projectReportTypeID, _projectID, _reportTypeID, _reportTypeName As String
        Private _userIDinsert, _userIDprepare, _userIDapproval As String
        Private _prepareDate As DateTime

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub


        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region "Insert"
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ProjectReportType (ProjectReportTypeID, ProjectID, ReportTypeID, " & _
                                        "userIDinsert, userIDprepare, userIDapproval, insertDate, prepareDate, approvalDate) " & _
                                        "VALUES (@ProjectReportTypeID, @ProjectID, @ReportTypeID, " & _
                                        "@userIDinsert, @userIDprepare, NULL, GETDATE(), GETDATE(), NULL)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strProjectReportTypeID As String = ID.GenerateIDNumber("ProjectReportType", "ProjectReportTypeID")

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectReportTypeID", strProjectReportTypeID)
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@ReportTypeID", _reportTypeID)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDprepare", _userIDprepare)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region "Delete"
        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM ProjectReportType WHERE ProjectReportTypeID=@ProjectReportTypeID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectReportTypeID", _projectReportTypeID)

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Custom Functions "
        Public Function InsertMandatoryReport() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ProjectReportType (ProjectReportTypeID, ProjectID, ReportTypeID, " & _
                                        "userIDinsert, userIDprepare, userIDapproval, insertDate, prepareDate, approvalDate) " & _
                                        "SELECT @ProjectReportTypeID, @ProjectID, ReportTypeID, " & _
                                        "@userIDinsert, @userIDprepare, NULL, GETDATE(), GETDATE(), NULL " & _
                                        "FROM ReportType WHERE isMandatory=1 AND isActive=1"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strProjectReportTypeID As String = ID.GenerateIDNumber("ProjectReportType", "ProjectReportTypeID")

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectReportTypeID", strProjectReportTypeID)
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)                
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDprepare", _userIDprepare)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function GetReportTypeByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "sp_ReportTypeByProjectID"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("GetReportTypeByProjectID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectReportTypeNotInProjectReportTypeByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM ReportType WHERE ReportTypeID NOT IN " & _
                                        "(SELECT ReportTypeID FROM ProjectReportType WHERE ProjectID=@ProjectID) " & _
                                        "AND isActive=1"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportTypeNotInProjectReportTypeByProjectID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "

        Public Property [ProjectReportTypeID]() As String
            Get
                Return _projectReportTypeID
            End Get
            Set(ByVal Value As String)
                _projectReportTypeID = Value
            End Set
        End Property

        Public Property [ProjectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
            End Set
        End Property

        Public Property [ReportTypeID]() As String
            Get
                Return _reportTypeID
            End Get
            Set(ByVal Value As String)
                _reportTypeID = Value
            End Set
        End Property

        Public Property [ReportTypeName]() As String
            Get
                Return _reportTypeName
            End Get
            Set(ByVal Value As String)
                _reportTypeName = Value
            End Set
        End Property

        Public Property [UserIDInsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property

        Public Property [UserIDPrepare]() As String
            Get
                Return _userIDprepare
            End Get
            Set(ByVal Value As String)
                _userIDprepare = Value
            End Set
        End Property

        Public Property [UserIDApproval]() As String
            Get
                Return _userIDapproval
            End Get
            Set(ByVal Value As String)
                _userIDapproval = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
