Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class UserSite
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _UserSiteID, _SiteID, _UserID As String
        Private _IsDefault As Boolean
        Private _UserIDInsert As String

#End Region

        Public Sub New()
            ConnectionString = SysConfig.ConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO UserSite " + _
                                        "(userSiteID, userID, siteID, isDefault, " + _
                                        "userIDinsert, insertDate) " + _
                                        "VALUES " + _
                                        "(@userSiteID, @userID, @siteID, @isDefault, " + _
                                        "@userIDinsert, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strUserSiteID As String = ID.GenerateIDNumber("UserSite", "userSiteID")

            Try
                cmdToExecute.Parameters.AddWithValue("@userSiteID", strUserSiteID)
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@SiteID", _SiteID)
                cmdToExecute.Parameters.AddWithValue("@isDefault", _IsDefault)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _UserIDInsert)                

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _UserSiteID = strUserSiteID
                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM UserSite " + _
                                        "WHERE UserSiteID=@UserSiteID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserSiteID", _UserSiteID)

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

#Region " Custom Functions "
        Public Function SelectSiteByUserID(ByVal UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT us.*, (SELECT SiteName FROM Site WHERE SiteID=us.SiteID) AS SiteName FROM UserSite us " + _
                                        "WHERE us.UserID=@UserID ORDER BY us.IsDefault DESC"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SiteByUserID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", UserID)

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

        Public Function SelectSiteNotInUserSiteByUserID(ByVal UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Site WHERE SiteID NOT IN (SELECT SiteID FROM UserSite WHERE UserID=@UserID)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SiteNotInUserSiteByUserID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", UserID)

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
        Public Property [UserSiteID]() As String
            Get
                Return _UserSiteID
            End Get
            Set(ByVal Value As String)
                _UserSiteID = Value
            End Set
        End Property

        Public Property [UserID]() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        Public Property [SiteID]() As String
            Get
                Return _SiteID
            End Get
            Set(ByVal Value As String)
                _SiteID = Value
            End Set
        End Property

        Public Property [IsDefault]() As Boolean
            Get
                Return _IsDefault
            End Get
            Set(ByVal Value As Boolean)
                _IsDefault = Value
            End Set
        End Property

        Public Property [UserIDInsert]() As String
            Get
                Return _UserIDInsert
            End Get
            Set(ByVal Value As String)
                _UserIDInsert = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
