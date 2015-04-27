Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ResourceSignature
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _resourceSignatureID, _resourceID, _description As String
        Private _signaturePic As SqlBinary
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
            cmdToExecute.CommandText = "INSERT INTO ResourceSignature " + _
                                        "(resourceSignatureID, resourceID, signaturePic, " + _
                                        "description, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@resourceSignatureID, @resourceID, @signaturePic, " + _
                                        "@description, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("ResourceSignature", "ResourceSignatureID")

            Try                
                cmdToExecute.Parameters.AddWithValue("@resourceSignatureID", strID)
                cmdToExecute.Parameters.AddWithValue("@resourceID", _resourceID)
                cmdToExecute.Parameters.AddWithValue("@signaturePic", _signaturePic)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDInsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _resourceSignatureID = strID
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
            cmdToExecute.CommandText = "UPDATE ResourceSignature " + _
                                        "SET description=@description, " + _
                                        "signaturePic=@signaturePic, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE resourceSignatureID=@resourceSignatureID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceSignatureID", _resourceSignatureID)                
                cmdToExecute.Parameters.AddWithValue("@signaturePic", _signaturePic)
                cmdToExecute.Parameters.AddWithValue("@description", _description)                
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
            cmdToExecute.CommandText = "SELECT * FROM ResourceSignature"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ResourceSignature")
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
            cmdToExecute.CommandText = "SELECT * FROM ResourceSignature WHERE resourceSignatureID=@resourceSignatureID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ResourceSignature")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceSignatureID", _resourceSignatureID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _resourceSignatureID = CType(toReturn.Rows(0)("resourceSignatureID"), String)
                    _resourceID = CType(toReturn.Rows(0)("resourceID"), String)
                    _signaturePic = CType(toReturn.Rows(0)("signaturePic"), Byte())
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _userIDInsert = CType(toReturn.Rows(0)("userIDinsert"), String)
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
            cmdToExecute.CommandText = "DELETE FROM ResourceSignature " + _
                                        "WHERE resourceSignatureID=@resourceSignatureID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceSignatureID", _resourceSignatureID)

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
        Public Function SelectByResourceID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " +
                                        "FROM ResourceSignature WHERE resourceID=@resourceID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ResourceSignature")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@resourceID", _resourceID)

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
        Public Property [resourceSignatureID]() As String
            Get
                Return _resourceSignatureID
            End Get
            Set(ByVal Value As String)
                _resourceSignatureID = Value
            End Set
        End Property

        Public Property [resourceID]() As String
            Get
                Return _resourceID
            End Get
            Set(ByVal Value As String)
                _resourceID = Value
            End Set
        End Property

        Public Property [signaturePic]() As SqlBinary
            Get
                Return _signaturePic
            End Get
            Set(ByVal Value As SqlBinary)
                _signaturePic = Value
            End Set
        End Property

        Public Property [description]() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
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
