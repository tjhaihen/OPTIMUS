Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class UserProfile
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _UserProfileID, _ProfileID, _UserID As String        
        Private _IsDefault As Boolean
        Private _UserIDInsert, _UserIDUpdate As String

#End Region

        Public Sub New()
            ConnectionString = SysConfig.ConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO UserProfile " + _
                                        "(userProfileID, userID, profileID, isDefault, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@userProfileID, @userID, @profileID, @isDefault, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strUserProfileID As String = ID.GenerateIDNumber("UserProfile", "userProfileID")

            Try
                cmdToExecute.Parameters.AddWithValue("@userProfileID", strUserProfileID)
                cmdToExecute.Parameters.AddWithValue("@UserID", _UserID)
                cmdToExecute.Parameters.AddWithValue("@ProfileID", _ProfileID)
                cmdToExecute.Parameters.AddWithValue("@isDefault", _IsDefault)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _UserIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _UserIDUpdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _UserProfileID = strUserProfileID
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
            cmdToExecute.CommandText = "DELETE FROM UserProfile " + _
                                        "WHERE UserProfileID=@UserProfileID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserProfileID", _UserProfileID)

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
        Public Function SelectProfileByUserID(ByVal UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT up.*, (SELECT ProfileName FROM Profile WHERE ProfileID=up.ProfileID) AS ProfileName FROM UserProfile up " + _
                                        "WHERE up.UserID=@UserID ORDER BY up.IsDefault DESC"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ProfileByUserID")
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

        Public Function SelectProfileNotInUserProfileByUserID(ByVal UserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Profile WHERE ProfileID NOT IN (SELECT ProfileID FROM UserProfile WHERE UserID=@UserID)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ProfileNotInUserProfileByUserID")
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
        Public Property [UserProfileID]() As String
            Get
                Return _UserProfileID
            End Get
            Set(ByVal Value As String)
                _UserProfileID = Value
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

        Public Property [ProfileID]() As String
            Get
                Return _ProfileID
            End Get
            Set(ByVal Value As String)
                _ProfileID = Value
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

        Public Property [UserIDUpdate]() As String
            Get
                Return _UserIDUpdate
            End Get
            Set(ByVal Value As String)
                _UserIDUpdate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
