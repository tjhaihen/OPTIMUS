Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Application
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _appID, _appName, _appImageFileName As String
        Private _IsActive As Boolean

#End Region

        Public Sub New()
            ConnectionString = SysConfig.ConnectionString
        End Sub

#Region " Custom Functions "
        Public Function SelectApplicationAuthorizationByProfileID(ByVal ProfileID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT DISTINCT a.appID, " & _
                                        "a.appName, a.appImageFileName, a.IsActive " & _
                                        "FROM ProfileMenu pm " & _
                                        "INNER JOIN Profile p on p.ProfileID = pm.ProfileID " & _
                                        "INNER JOIN Menu m on m.MenuID = pm.MenuID " & _
                                        "INNER JOIN Application a ON m.appID = a.appID " & _
                                        "WHERE pm.ProfileID = @ProfileID AND m.isActive = 1 AND p.isActive = 1 AND a.isActive = 1"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ApplicationAuthorizationByProfileID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)                

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
        Public Property [appID]() As String
            Get
                Return _appID
            End Get
            Set(ByVal Value As String)
                _appID = Value
            End Set
        End Property

        Public Property [appName]() As String
            Get
                Return _appName
            End Get
            Set(ByVal Value As String)
                _appName = Value
            End Set
        End Property

        Public Property [appImageFileName]() As String
            Get
                Return _appImageFileName
            End Get
            Set(ByVal Value As String)
                _appImageFileName = Value
            End Set
        End Property

        Public Property [IsActive]() As Boolean
            Get
                Return _IsActive
            End Get
            Set(ByVal Value As Boolean)
                _IsActive = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
