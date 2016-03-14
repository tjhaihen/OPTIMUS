Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class CategoryInspection
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _categoryInspectionID, _categoryInspectionName, _shortName As String        
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
            cmdToExecute.CommandText = "INSERT INTO CategoryInspection " + _
                                        "(categoryInspectionID, categoryInspectionName, shortName) " + _
                                        "VALUES " + _
                                        "(@categoryInspectionID, @categoryInspectionName, @shortName)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("CategoryInspection", "categoryInspectionID")

            Try
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionID", strID)
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionName", _categoryInspectionName)
                cmdToExecute.Parameters.AddWithValue("@shortName", _shortName)                

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _categoryInspectionID = strID
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
            cmdToExecute.CommandText = "UPDATE CategoryInspection " + _
                                        "SET categoryInspectionName=@categoryInspectionName, " + _
                                        "shortName=@shortName " + _
                                        "WHERE categoryInspectionID=@categoryInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionID", _categoryInspectionID)
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionName", _categoryInspectionName)
                cmdToExecute.Parameters.AddWithValue("@shortName", _shortName)

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
            cmdToExecute.CommandText = "SELECT * FROM CategoryInspection ORDER BY categoryInspectionName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CategoryInspection")
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
            cmdToExecute.CommandText = "SELECT * FROM CategoryInspection WHERE categoryInspectionID=@categoryInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CategoryInspection")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionID", _categoryInspectionID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _categoryInspectionID = CType(toReturn.Rows(0)("categoryInspectionID"), String)
                    _categoryInspectionName = CType(toReturn.Rows(0)("categoryInspectionName"), String)
                    _shortName = CType(toReturn.Rows(0)("shortName"), String)
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
            cmdToExecute.CommandText = "DELETE FROM CategoryInspection " + _
                                        "WHERE categoryInspectionID=@categoryInspectionID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@categoryInspectionID", _categoryInspectionID)

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
        
#End Region

#Region " Class Property Declarations "
        Public Property [categoryInspectionID]() As String
            Get
                Return _categoryInspectionID
            End Get
            Set(ByVal Value As String)
                _categoryInspectionID = Value
            End Set
        End Property

        Public Property [categoryInspectionName]() As String
            Get
                Return _categoryInspectionName
            End Get
            Set(ByVal Value As String)
                _categoryInspectionName = Value
            End Set
        End Property

        Public Property [shortName]() As String
            Get
                Return _shortName
            End Get
            Set(ByVal Value As String)
                _shortName = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
