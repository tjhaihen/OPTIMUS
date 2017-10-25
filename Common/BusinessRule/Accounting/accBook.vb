Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Book
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _bookID, _bookDescription, _bookStatusSCode As String
        Private _year, _month As Integer
        Private _beginBalanceAmount, _debitBalanceAmount, _creditBalanceAmount, _endingBalanceAmount As Decimal
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
            cmdToExecute.CommandText = "INSERT INTO accBook " + _
                                        "(bookID, bookDescription, bookStatusSCode, year, month, " + _
                                        "beginBalanceAmount, debitBalanceAmount, creditBalanceAmount, endingBalanceAmount, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@bookID, @bookDescription, @bookStatusSCode, @year, @month, " + _
                                        "@beginBalanceAmount, @debitBalanceAmount, @creditBalanceAmount, @endingBalanceAmount, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("accBook", "bookID")

            Try
                cmdToExecute.Parameters.AddWithValue("@bookID", strID)
                cmdToExecute.Parameters.AddWithValue("@bookDescription", _bookDescription)
                cmdToExecute.Parameters.AddWithValue("@bookStatusSCode", _bookStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@year", _year)
                cmdToExecute.Parameters.AddWithValue("@month", _month)
                cmdToExecute.Parameters.AddWithValue("@beginBalanceAmount", _beginBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@debitBalanceAmount", _debitBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@creditBalanceAmount", _creditBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@endingBalanceAmount", _endingBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _bookID = strID
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
            cmdToExecute.CommandText = "UPDATE accBook " + _
                                        "SET bookDescription=@bookDescription, " + _
                                        "bookStatusSCode=@bookStatusSCode, year=@year, month=@month, " + _
                                        "beginBalanceAmount=@beginBalanceAmount, debitBalanceAmount=@debitBalanceAmount, " + _
                                        "creditBalanceAmount=@creditBalanceAmount, endingBalanceAmount=@endingBalanceAmount, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE bookID=@bookID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@bookID", _bookID)
                cmdToExecute.Parameters.AddWithValue("@bookDescription", _bookDescription)
                cmdToExecute.Parameters.AddWithValue("@bookStatusSCode", _bookStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@year", _year)
                cmdToExecute.Parameters.AddWithValue("@month", _month)
                cmdToExecute.Parameters.AddWithValue("@beginBalanceAmount", _beginBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@debitBalanceAmount", _debitBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@creditBalanceAmount", _creditBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@endingBalanceAmount", _endingBalanceAmount)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
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
            cmdToExecute.CommandText = "SELECT * FROM accBook ORDER BY year, month"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accBook")
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
            cmdToExecute.CommandText = "SELECT * FROM accBook WHERE bookID=@bookID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accBook")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@bookID", _bookID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _bookID = CType(toReturn.Rows(0)("bookID"), String)
                    _bookDescription = CType(toReturn.Rows(0)("bookDescription"), String)
                    _bookStatusSCode = CType(toReturn.Rows(0)("bookStatusSCode"), String)
                    _year = CType(toReturn.Rows(0)("year"), Integer)
                    _month = CType(toReturn.Rows(0)("month"), Integer)
                    _beginBalanceAmount = CType(toReturn.Rows(0)("beginBalanceAmount"), Decimal)
                    _debitBalanceAmount = CType(toReturn.Rows(0)("debitBalanceAmount"), Decimal)
                    _creditBalanceAmount = CType(toReturn.Rows(0)("creditBalanceAmount"), Decimal)
                    _endingBalanceAmount = CType(toReturn.Rows(0)("endingBalanceAmount"), Decimal)
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
            cmdToExecute.CommandText = "DELETE FROM accBook " + _
                                        "WHERE bookID=@bookID"
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
        Public Property [bookID]() As String
            Get
                Return _bookID
            End Get
            Set(ByVal Value As String)
                _bookID = Value
            End Set
        End Property

        Public Property [year]() As Integer
            Get
                Return _year
            End Get
            Set(ByVal Value As Integer)
                _year = Value
            End Set
        End Property

        Public Property [month]() As Integer
            Get
                Return _month
            End Get
            Set(ByVal Value As Integer)
                _month = Value
            End Set
        End Property

        Public Property [bookDescription]() As String
            Get
                Return _bookDescription
            End Get
            Set(ByVal Value As String)
                _bookDescription = Value
            End Set
        End Property

        Public Property [bookStatusSCode]() As String
            Get
                Return _bookStatusSCode
            End Get
            Set(ByVal Value As String)
                _bookStatusSCode = Value
            End Set
        End Property

        Public Property [beginBalanceAmount]() As Decimal
            Get
                Return _beginBalanceAmount
            End Get
            Set(ByVal Value As Decimal)
                _beginBalanceAmount = Value
            End Set
        End Property

        Public Property [debitBalanceAmount]() As Decimal
            Get
                Return _debitBalanceAmount
            End Get
            Set(ByVal Value As Decimal)
                _debitBalanceAmount = Value
            End Set
        End Property

        Public Property [creditBalanceAmount]() As Decimal
            Get
                Return _creditBalanceAmount
            End Get
            Set(ByVal Value As Decimal)
                _creditBalanceAmount = Value
            End Set
        End Property

        Public Property [endingBalanceAmount]() As Decimal
            Get
                Return _endingBalanceAmount
            End Get
            Set(ByVal Value As Decimal)
                _endingBalanceAmount = Value
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
