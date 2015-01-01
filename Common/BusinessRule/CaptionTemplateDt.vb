Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class CaptionTemplateDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _captionTemplateDtID, _captionTemplateHdID, _captionID, _captionGroupSCode, _sequenceNo, _captionName As String
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
            cmdToExecute.CommandText = "INSERT INTO captionTemplateDt " + _
                                        "(captionTemplateDtID captionTemplateHdID, captionID, captionGroupSCode, sequenceNo) " + _
                                        "VALUES " + _
                                        "(@captionTemplateDtID @captionTemplateHdID, @captionID, @captionGroupSCode, @sequenceNo)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("captionTemplateDt", "captionTemplateDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", _captionTemplateHdID)
                cmdToExecute.Parameters.AddWithValue("@captionID", _captionID)
                cmdToExecute.Parameters.AddWithValue("@captionGroupSCode", _captionGroupSCode)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)

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
            cmdToExecute.CommandText = "UPDATE captionTemplateDt " + _
                                        "SET captionID=@captionID, captionGroupSCode=@captionGroupSCode, sequenceNo=@sequenceNo " + _
                                        "WHERE captionTemplateDtID=@captionTemplateDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateDtID", _captionTemplateDtID)                
                cmdToExecute.Parameters.AddWithValue("@captionID", _captionID)
                cmdToExecute.Parameters.AddWithValue("@captionGroupSCode", _captionGroupSCode)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)

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
            cmdToExecute.CommandText = "SELECT * FROM captionTemplateDt ORDER BY captionTemplateDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("captionTemplateDt")
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
            cmdToExecute.CommandText = "SELECT * FROM captionTemplateDt WHERE captionTemplateDtID=@captionTemplateDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("captionTemplateDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateDtID", _captionTemplateDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _captionTemplateDtID = CType(toReturn.Rows(0)("captionTemplateDtID"), String)
                    _captionTemplateHdID = CType(toReturn.Rows(0)("captionTemplateHdID"), String)
                    _captionID = CType(toReturn.Rows(0)("captionID"), String)
                    _captionGroupSCode = CType(toReturn.Rows(0)("captionGroupSCode"), String)
                    _sequenceNo = CType(toReturn.Rows(0)("sequenceNo"), String)
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
            cmdToExecute.CommandText = "DELETE FROM captionTemplateDt WHERE captionTemplateDtID=@captionTemplateDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateDtID", _captionTemplateDtID)

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
        Public Function SelectForCaptionLabel() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT TOP 1 dt.captionID, c.captionName " +
                                        "FROM CaptionTemplateDt dt " + _
                                        "INNER JOIN Caption c ON dt.captionID=c.captionID " + _
                                        "WHERE dt.captionTemplateHdID=@captionTemplateHdID AND dt.captionGroupSCode=@captionGroupSCode " + _
                                        "AND dt.sequenceNo=@sequenceNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("CaptionTemplate")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@captionTemplateHdID", _captionTemplateHdID)
                cmdToExecute.Parameters.AddWithValue("@captionGroupSCode", _captionGroupSCode)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _captionID = CType(toReturn.Rows(0)("captionID"), String)
                    _captionName = CType(toReturn.Rows(0)("captionName"), String)
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
        Public Property [captionTemplateDtID]() As String
            Get
                Return _captionTemplateDtID
            End Get
            Set(ByVal Value As String)
                _captionTemplateDtID = Value
            End Set
        End Property

        Public Property [captionTemplateHdID]() As String
            Get
                Return _captionTemplateHdID
            End Get
            Set(ByVal Value As String)
                _captionTemplateHdID = Value
            End Set
        End Property

        Public Property [captionID]() As String
            Get
                Return _captionID
            End Get
            Set(ByVal Value As String)
                _captionID = Value
            End Set
        End Property

        Public Property [captionGroupSCode]() As String
            Get
                Return _captionGroupSCode
            End Get
            Set(ByVal Value As String)
                _captionGroupSCode = Value
            End Set
        End Property

        Public Property [sequenceNo]() As String
            Get
                Return _sequenceNo
            End Get
            Set(ByVal Value As String)
                _sequenceNo = Value
            End Set
        End Property

        Public Property [captionName]() As String
            Get
                Return _captionName
            End Get
            Set(ByVal Value As String)
                _captionName = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
