Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ProjectResource
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _projectResourceID, _projectID, _resourceID, _resourceRoleSCode, _resourceRoleName, _resourceSignatureID As String
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime

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

            cmdToExecute.CommandText = "INSERT INTO ProjectResource (ProjectResourceID, ProjectID, ResourceID, ResourceRoleSCode, ResourceSignatureID, " & _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " & _
                                        "VALUES (@ProjectResourceID, @ProjectID, @ResourceID, @ResourceRoleSCode, @ResourceSignatureID, " & _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strProjectResourceID As String = ID.GenerateIDNumber("ProjectResource", "ProjectResourceID")

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectResourceID", strProjectResourceID)
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@ResourceID", _resourceID)
                cmdToExecute.Parameters.AddWithValue("@ResourceRoleSCode", _resourceRoleSCode)
                cmdToExecute.Parameters.AddWithValue("@resourceSignatureID", _resourceSignatureID)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

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

            cmdToExecute.CommandText = "DELETE FROM ProjectResource WHERE ProjectResourceID=@ProjectResourceID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectResourceID", _projectResourceID)

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

        Public Function GetResourceByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT pr.*, " + _
                    "r.resourceCode, r.personID, p.firstName, p.middleName, p.lastName, " + _
                    "RTRIM(RTRIM(p.firstName)+' '+RTRIM(p.middleName)+' '+RTRIM(p.lastName)) AS resourceName, " + _
                    "(SELECT caption FROM CommonCode WHERE groupCode='" + Common.Constants.GroupCode.ResourceType_SCode + "' " + _
                        "AND value=pr.resourceRoleSCode) AS resourceRoleName, r.resourceJobTitle, " + _
                    "rs.signaturePic, rs.description AS signatureDescription " + _
                    "FROM ProjectResource pr " + _
                    "INNER JOIN [Resource] r ON pr.resourceID=r.resourceID " + _
                    "INNER JOIN [Person] p ON r.personID=p.personID " + _
                    "LEFT JOIN [ResourceSignature] rs ON pr.resourceSignatureID=rs.resourceSignatureID " + _
                    "WHERE pr.projectID=@ProjectID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetResourceByProjectID")
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

#Region " Class Property Declarations "

        Public Property [ProjectResourceID]() As String
            Get
                Return _projectResourceID
            End Get
            Set(ByVal Value As String)
                _projectResourceID = Value
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

        Public Property [ResourceID]() As String
            Get
                Return _resourceID
            End Get
            Set(ByVal Value As String)
                _resourceID = Value
            End Set
        End Property

        Public Property [ResourceRoleSCode]() As String
            Get
                Return _resourceRoleSCode
            End Get
            Set(ByVal Value As String)
                _resourceRoleSCode = Value
            End Set
        End Property

        Public Property [ResourceSignatureID]() As String
            Get
                Return _resourceSignatureID
            End Get
            Set(ByVal Value As String)
                _resourceSignatureID = Value
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

        Public Property [UserIDUpdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
            End Set
        End Property

        Public Property [InsertDate]() As DateTime
            Get
                Return _insertDate
            End Get
            Set(ByVal Value As DateTime)
                _insertDate = Value
            End Set
        End Property

        Public Property [UpdateDate]() As DateTime
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
