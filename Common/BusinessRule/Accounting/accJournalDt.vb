Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class JournalDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _journalDtID, _journalID, _accountID, _journalRemarks, _referenceNo As String
        Private _debitAmount, _creditAmount As Decimal
        Private _isSystemProcess, _isDeleted As Boolean
        Private _userIDinsert, _userIDupdate, _userIDdeleted As String
        Private _insertDate, _updateDate, _deletedDate As DateTime

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
            cmdToExecute.CommandText = "INSERT INTO accJournalDt " + _
                                        "(journalDtID, journalID, accountID, journalRemarks, referenceNo, " + _
                                        "debitAmount, creditAmount, " + _
                                        "isSystemProcess, isDeleted, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@journalDtID, @journalID, @accountID, @journalRemarks, @referenceNo, " + _
                                        "@debitAmount, @creditAmount, " + _
                                        "@isSystemProcess, @isDeleted, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("accJournalDt", "journalDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@journalDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@journalID", _journalID)
                cmdToExecute.Parameters.AddWithValue("@accountID", _accountID)
                cmdToExecute.Parameters.AddWithValue("@journalRemarks", _journalRemarks)
                cmdToExecute.Parameters.AddWithValue("@referenceNo", _referenceNo)
                cmdToExecute.Parameters.AddWithValue("@debitAmount", _debitAmount)
                cmdToExecute.Parameters.AddWithValue("@creditAmount", _creditAmount)
                cmdToExecute.Parameters.AddWithValue("@isSystemProcess", _isSystemProcess)
                cmdToExecute.Parameters.AddWithValue("@isDeleted", _isDeleted)
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
            cmdToExecute.CommandText = "UPDATE accJournalDt " + _
                                        "SET accountID=@accountID, " + _
                                        "journalRemarks=@journalRemarks, referenceNo=@referenceNo, " + _
                                        "debitAmount=@debitAmount, creditAmount=@creditAmount, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE journalDtID=@journalDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@journalDtID", _journalDtID)
                cmdToExecute.Parameters.AddWithValue("@accountID", _accountID)
                cmdToExecute.Parameters.AddWithValue("@journalRemarks", _journalRemarks)
                cmdToExecute.Parameters.AddWithValue("@referenceNo", _referenceNo)
                cmdToExecute.Parameters.AddWithValue("@debitAmount", _debitAmount)
                cmdToExecute.Parameters.AddWithValue("@creditAmount", _creditAmount)
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
            cmdToExecute.CommandText = "SELECT * FROM accJournalDt ORDER BY journalDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accJournalDt")
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
            cmdToExecute.CommandText = "SELECT * FROM accJournalDt WHERE journalDtID=@journalDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accJournalDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@journalDtID", _journalDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _journalDtID = CType(toReturn.Rows(0)("journalDtID"), String)
                    _journalID = CType(toReturn.Rows(0)("journalID"), String)
                    _accountID = CType(toReturn.Rows(0)("accountID"), String)
                    _journalRemarks = CType(toReturn.Rows(0)("journalRemarks"), String)
                    _referenceNo = CType(toReturn.Rows(0)("referenceNo"), String)
                    _debitAmount = CType(toReturn.Rows(0)("debitAmount"), Decimal)
                    _creditAmount = CType(toReturn.Rows(0)("creditAmount"), Decimal)
                    _isSystemProcess = CType(toReturn.Rows(0)("isSystemProcess"), Boolean)
                    _isDeleted = CType(toReturn.Rows(0)("isDeleted"), Boolean)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _userIDdeleted = CType(ProcessNull.GetString(toReturn.Rows(0)("userIDdeleted")), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    _deletedDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("deletedDate")), DateTime)
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
            cmdToExecute.CommandText = "UPDATE accJournalDt " + _
                                        "SET isDeleted=1, userIDdeleted=@userIDdeleted, deletedDate=GETDATE() " + _
                                        "WHERE journalDtID=@journalDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@journalDtID", _journalDtID)
                cmdToExecute.Parameters.AddWithValue("@userIDdeleted", _userIDdeleted)

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

        Public Function SelectByJournalID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT dt.*, ac.accountNo, ac.accountName, ac.normalBalance " + _
                                        "FROM accJournalDt dt " + _
                                        "INNER JOIN accAccount ac ON dt.accountID=ac.accountID " + _
                                        "WHERE journalID=@journalID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accJournalDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@journalID", _journalID)

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
        Public Property [journalDtID]() As String
            Get
                Return _journalDtID
            End Get
            Set(ByVal Value As String)
                _journalDtID = Value
            End Set
        End Property

        Public Property [journalID]() As String
            Get
                Return _journalID
            End Get
            Set(ByVal Value As String)
                _journalID = Value
            End Set
        End Property

        Public Property [accountID]() As String
            Get
                Return _accountID
            End Get
            Set(ByVal Value As String)
                _accountID = Value
            End Set
        End Property

        Public Property [journalRemarks]() As String
            Get
                Return _journalRemarks
            End Get
            Set(ByVal Value As String)
                _journalRemarks = Value
            End Set
        End Property

        Public Property [referenceNo]() As String
            Get
                Return _referenceNo
            End Get
            Set(ByVal Value As String)
                _referenceNo = Value
            End Set
        End Property

        Public Property [debitAmount]() As Decimal
            Get
                Return _debitAmount
            End Get
            Set(ByVal Value As Decimal)
                _debitAmount = Value
            End Set
        End Property

        Public Property [creditAmount]() As Decimal
            Get
                Return _creditAmount
            End Get
            Set(ByVal Value As Decimal)
                _creditAmount = Value
            End Set
        End Property

        Public Property [isSystemProcess]() As Boolean
            Get
                Return _isSystemProcess
            End Get
            Set(ByVal Value As Boolean)
                _isSystemProcess = Value
            End Set
        End Property

        Public Property [isDeleted]() As Boolean
            Get
                Return _isDeleted
            End Get
            Set(ByVal Value As Boolean)
                _isDeleted = Value
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

        Public Property [userIDdeleted]() As String
            Get
                Return _userIDdeleted
            End Get
            Set(ByVal Value As String)
                _userIDdeleted = Value
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

        Public Property [deletedDate]() As DateTime
            Get
                Return _deletedDate
            End Get
            Set(ByVal Value As DateTime)
                _deletedDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
