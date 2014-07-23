Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Profile
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _ProfileID, _ProfileCode, _ProfileName As String
        Private _IsActive, _IsSystem As Boolean
        Private _UserIDInsert, _UserIDUpdate As String
        Private _InsertDate, _UpdateDate As DateTime

#End Region

        Public Sub New()
            ConnectionString = SysConfig.ConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO Profile " + _
                                        "(profileID, profileCode, profileName, " + _
                                        "isActive, isSystem, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@profileID, @profileCode, @profileName, " + _
                                        "@isActive, @isSystem, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strProfileID As String = ID.GenerateIDNumber("Profile", "profileID")

            Try
                cmdToExecute.Parameters.AddWithValue("@profileID", strProfileID)
                cmdToExecute.Parameters.AddWithValue("@profileCode", _profileCode)
                cmdToExecute.Parameters.AddWithValue("@profileName", _profileName)
                cmdToExecute.Parameters.AddWithValue("@isActive", _IsActive)
                cmdToExecute.Parameters.AddWithValue("@isSystem", _IsSystem)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _ProfileID = strProfileID
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
            cmdToExecute.CommandText = "UPDATE Profile " + _
                                        "SET profileCode=@profileCode, profileName=@profileName, " + _
                                        "isActive=@isActive, userIDupdate=@userIDupdate, " + _
                                        "updateDate=GETDATE() " + _
                                        "WHERE profileID=@profileID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@profileID", _profileID)
                cmdToExecute.Parameters.AddWithValue("@profileCode", _profileCode)
                cmdToExecute.Parameters.AddWithValue("@profileName", _profileName)
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
            cmdToExecute.CommandText = "SELECT * FROM Profile"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Profile")
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

            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM Profile WHERE ProfileID=@ProfileID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM Profile WHERE ProfileID=@ProfileID"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM Profile WHERE ProfileID=@ProfileID"
            End Select

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Profile")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", _ProfileID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ProfileID = CType(toReturn.Rows(0)("ProfileID"), String)
                    _ProfileCode = CType(toReturn.Rows(0)("ProfileCode"), String)
                    _ProfileName = CType(toReturn.Rows(0)("ProfileName"), String)
                    _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
                    _IsSystem = CType(toReturn.Rows(0)("IsSystem"), Boolean)
                    _UserIDInsert = CType(toReturn.Rows(0)("UserIDInsert"), String)
                    _UserIDUpdate = CType(toReturn.Rows(0)("UserIDUpdate"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
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
            cmdToExecute.CommandText = "DELETE FROM Profile " + _
                                        "WHERE profileID=@profileID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@profileID", _ProfileID)

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
        
#End Region

#Region " Class Property Declarations "
        Public Property [ProfileID]() As String
            Get
                Return _ProfileID
            End Get
            Set(ByVal Value As String)
                _ProfileID = Value
            End Set
        End Property

        Public Property [ProfileCode]() As String
            Get
                Return _ProfileCode
            End Get
            Set(ByVal Value As String)
                _ProfileCode = Value
            End Set
        End Property

        Public Property [ProfileName]() As String
            Get
                Return _ProfileName
            End Get
            Set(ByVal Value As String)
                _ProfileName = Value
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

        Public Property [IsSystem]() As Boolean
            Get
                Return _IsSystem
            End Get
            Set(ByVal Value As Boolean)
                _IsSystem = Value
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

        Public Property [InsertDate]() As DateTime
            Get
                Return _InsertDate
            End Get
            Set(ByVal Value As DateTime)
                _InsertDate = Value
            End Set
        End Property

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
