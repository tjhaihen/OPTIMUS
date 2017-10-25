Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class JournalHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _bookID, _journalID, _journalNo, _journalTypeID, _journalDescription, _journalStatusSCode As String
        Private _journalDate As Date
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
            cmdToExecute.CommandText = "INSERT INTO accJournalHd " + _
                                        "(bookID, journalID, journalNo, journalTypeID, journalDescription, " + _
                                        "journalStatusSCode, journalDate, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@bookID, @journalID, @journalNo, @journalTypeID, @journalDescription, " + _
                                        "@journalStatusSCode, @journalDate, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("accJournalHd", "journalID")

            Try
                cmdToExecute.Parameters.AddWithValue("@journalID", strID)
                cmdToExecute.Parameters.AddWithValue("@bookID", _bookID)
                cmdToExecute.Parameters.AddWithValue("@journalNo", _journalNo)
                cmdToExecute.Parameters.AddWithValue("@journalTypeID", _journalTypeID)
                cmdToExecute.Parameters.AddWithValue("@journalDate", _journalDate)
                cmdToExecute.Parameters.AddWithValue("@journalDescription", _journalDescription)
                cmdToExecute.Parameters.AddWithValue("@journalStatusSCode", _journalStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _journalID = strID
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
            cmdToExecute.CommandText = "UPDATE accJournalHd " + _
                                        "SET bookID=@bookID, " + _
                                        "journalNo=@journalNo, journalTypeID=@journalTypeID, journalDate=@journalDate, " + _
                                        "journalDescription=@journalDescription, journalStatusSCode=@journalStatusSCode, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE journalID=@journalID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@journalID", _journalID)
                cmdToExecute.Parameters.AddWithValue("@bookID", _bookID)
                cmdToExecute.Parameters.AddWithValue("@journalNo", _journalNo)
                cmdToExecute.Parameters.AddWithValue("@journalTypeID", _journalTypeID)
                cmdToExecute.Parameters.AddWithValue("@journalDate", _journalDate)
                cmdToExecute.Parameters.AddWithValue("@journalDescription", _journalDescription)
                cmdToExecute.Parameters.AddWithValue("@journalStatusSCode", _journalStatusSCode)
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
            cmdToExecute.CommandText = "SELECT * FROM accJournalHd ORDER BY journalID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accJournalHd")
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
            cmdToExecute.CommandText = "SELECT * FROM accJournalHd WHERE journalID=@journalID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accJournalHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@journalID", _journalID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _journalID = CType(toReturn.Rows(0)("journalID"), String)
                    _bookID = CType(toReturn.Rows(0)("bookID"), String)
                    _journalNo = CType(toReturn.Rows(0)("journalNo"), String)
                    _journalTypeID = CType(toReturn.Rows(0)("journalTypeID"), String)
                    _journalDate = CType(toReturn.Rows(0)("journalDate"), Date)
                    _journalDescription = CType(toReturn.Rows(0)("journalDescription"), String)
                    _journalStatusSCode = CType(toReturn.Rows(0)("journalStatusSCode"), String)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
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
            cmdToExecute.CommandText = "DELETE FROM accJournalHd " + _
                                        "WHERE journalID=@journalID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@bookID", _bookID)

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
        Public Property [journalID]() As String
            Get
                Return _journalID
            End Get
            Set(ByVal Value As String)
                _journalID = Value
            End Set
        End Property

        Public Property [bookID]() As String
            Get
                Return _bookID
            End Get
            Set(ByVal Value As String)
                _bookID = Value
            End Set
        End Property

        Public Property [journalNo]() As String
            Get
                Return _journalNo
            End Get
            Set(ByVal Value As String)
                _journalNo = Value
            End Set
        End Property

        Public Property [journalTypeID]() As String
            Get
                Return _journalTypeID
            End Get
            Set(ByVal Value As String)
                _journalTypeID = Value
            End Set
        End Property

        Public Property [journalDate]() As Date
            Get
                Return _journalDate
            End Get
            Set(ByVal Value As Date)
                _journalDate = Value
            End Set
        End Property

        Public Property [journalDescription]() As String
            Get
                Return _journalDescription
            End Get
            Set(ByVal Value As String)
                _journalDescription = Value
            End Set
        End Property

        Public Property [journalStatusSCode]() As String
            Get
                Return _journalStatusSCode
            End Get
            Set(ByVal Value As String)
                _journalStatusSCode = Value
            End Set
        End Property

        Public Property [userIDinsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property

        Public Property [userIDupdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
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
