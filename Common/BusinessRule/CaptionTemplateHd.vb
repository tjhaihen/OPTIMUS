Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class CaptionTemplateHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _captionTemplateHdID, _captionTemplateName As String
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
            cmdToExecute.CommandText = "INSERT INTO captionTemplateHd " + _
                                        "(captionTemplateHdID, captionTemplateName) " + _
                                        "VALUES " + _
                                        "(@captionTemplateHdID, @captionTemplateName)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("captionTemplateHd", "captionTemplateHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@captionTemplateName", _captionTemplateName)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _captionTemplateHdID = strID
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
            cmdToExecute.CommandText = "UPDATE captionTemplateHd " + _
                                        "SET captionTemplateName=@captionTemplateName " + _
                                        "WHERE captionTemplateHdID=@captionTemplateHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", _captionTemplateHdID)
                cmdToExecute.Parameters.AddWithValue("@captionTemplateName", _captionTemplateName)

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
            cmdToExecute.CommandText = "SELECT * FROM captionTemplateHd ORDER BY captionTemplateName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("captionTemplateHd")
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
            cmdToExecute.CommandText = "SELECT * FROM captionTemplateHd WHERE captionTemplateHdID=@captionTemplateHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("captionTemplateHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", _captionTemplateHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _captionTemplateHdID = CType(toReturn.Rows(0)("captionTemplateHdID"), String)
                    _captionTemplateName = CType(toReturn.Rows(0)("captionTemplateName"), String)                    
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
            cmdToExecute.CommandText = "SET XACT_ABORT ON " + _
                                        "BEGIN TRAN " + _
                                        "DELETE FROM captionTemplateDt WHERE captionTemplateHdID=@captionTemplateHdID " + _
                                        "DELETE FROM captionTemplateHd WHERE captionTemplateHdID=@captionTemplateHdID " + _
                                        "COMMIT TRAN"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", _captionTemplateHdID)

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
        Public Property [captionTemplateHdID]() As String
            Get
                Return _captionTemplateHdID
            End Get
            Set(ByVal Value As String)
                _captionTemplateHdID = Value
            End Set
        End Property

        Public Property [captionTemplateName]() As String
            Get
                Return _captionTemplateName
            End Get
            Set(ByVal Value As String)
                _captionTemplateName = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
