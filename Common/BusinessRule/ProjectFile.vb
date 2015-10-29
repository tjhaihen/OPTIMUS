Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ProjectFile
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _projectFileID, _projectID, _dirName, _fileName, _fileExtension, _fileNo, _description As String
        Private _isShared As Boolean
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime

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

            cmdToExecute.CommandText = "INSERT INTO ProjectFile (projectFileID, projectID, dirName, fileName, fileExtension, fileNo, description, " & _
                                        "isShared, userIDinsert, userIDupdate, insertDate, updateDate) " & _
                                        "VALUES (@projectFileID, @projectID, @dirName, @fileName, @fileExtension, @fileNo, @description, " & _
                                        "@isShared, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("ProjectFile", "projectFileID")

            Try
                cmdToExecute.Parameters.AddWithValue("@projectFileID", strID)
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@dirName", _dirName)
                cmdToExecute.Parameters.AddWithValue("@fileName", _fileName)
                cmdToExecute.Parameters.AddWithValue("@fileExtension", _fileExtension)
                cmdToExecute.Parameters.AddWithValue("@fileNo", _fileNo)
                cmdToExecute.Parameters.AddWithValue("@description", _description)
                cmdToExecute.Parameters.AddWithValue("@isShared", _isShared)
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM ProjectFile WHERE projectFileID=@projectFileID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectFile")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectFileID", _projectFileID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _projectFileID = CType(toReturn.Rows(0)("projectFileID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _dirName = CType(toReturn.Rows(0)("dirName"), String)
                    _fileName = CType(toReturn.Rows(0)("fileName"), String)
                    _fileExtension = CType(toReturn.Rows(0)("fileExtension"), String)
                    _fileNo = CType(toReturn.Rows(0)("fileNo"), String)
                    _description = CType(toReturn.Rows(0)("description"), String)
                    _isShared = CType(toReturn.Rows(0)("isShared"), Boolean)
                    _userIDInsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDUpdate = CType(toReturn.Rows(0)("userIDupdate"), String)
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

            cmdToExecute.CommandText = "DELETE FROM ProjectFile WHERE projectFileID=@projectFileID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectFileID", _projectFileID)

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
        Public Function GetFileByProjectID(ByVal isSharedOnly As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT pf.*, " + _
                                        "fileUrl = " + _
                                        "CASE " + _
                                        "WHEN(LEN(pf.dirName) > 0 AND LEN(pf.fileName) > 0) THEN((SELECT [value] FROM SystemParameter WHERE code='FileAccessUrl') + pf.dirName + pf.[fileName])" + _
                                        "WHEN(LEN(pf.dirName) = 0 AND LEN(pf.fileName) > 0) THEN((SELECT [value] FROM SystemParameter WHERE code='FileAccessUrl') + pf.[fileName]) " + _
                                        "ELSE('#') " + _
                                        "END, " + _
                                        "userName = (SELECT userName FROM [User] WHERE userID=pf.userIDinsert)" + _
                                        "FROM ProjectFile pf WHERE pf.projectID=@projectID"
            If isSharedOnly = True Then
                cmdToExecute.CommandText += " AND pf.isShared=1"
            End If
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetFileByProjectID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)

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
#End Region

#Region " Class Property Declarations "

        Public Property [projectFileID]() As String
            Get
                Return _projectFileID
            End Get
            Set(ByVal Value As String)
                _projectFileID = Value
            End Set
        End Property

        Public Property [projectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
            End Set
        End Property

        Public Property [dirName]() As String
            Get
                Return _dirName
            End Get
            Set(ByVal Value As String)
                _dirName = Value
            End Set
        End Property

        Public Property [fileName]() As String
            Get
                Return _fileName
            End Get
            Set(ByVal Value As String)
                _fileName = Value
            End Set
        End Property

        Public Property [fileExtension]() As String
            Get
                Return _fileExtension
            End Get
            Set(ByVal Value As String)
                _fileExtension = Value
            End Set
        End Property

        Public Property [fileNo]() As String
            Get
                Return _fileNo
            End Get
            Set(ByVal Value As String)
                _fileNo = Value
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

        Public Property [isShared]() As Boolean
            Get
                Return _isShared
            End Get
            Set(ByVal Value As Boolean)
                _isShared = Value
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
