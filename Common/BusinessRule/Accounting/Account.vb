Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Account
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _accountID, _accountNo, _accountName, _parentAccountID, _normalBalance, _accountCategoryID As String
        Private _isHeader, _isActive, _isSystem As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO accAccount " + _
                                        "(accountID, accountNo, accountName, parentAccountID, normalBalance, accountCategoryID, " + _
                                        "isHeader, isActive, isSystem, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@accountID, @accountNo, @accountName, @parentAccountID, @normalBalance, @accountCategoryID, " + _
                                        "@isHeader, @isActive, @isSystem, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("accAccount", "accountID")

            Try
                cmdToExecute.Parameters.AddWithValue("@accountID", strID)
                cmdToExecute.Parameters.AddWithValue("@accountNo", _accountNo)
                cmdToExecute.Parameters.AddWithValue("@accountName", _accountName)
                cmdToExecute.Parameters.AddWithValue("@parentAccountID", _parentAccountID)
                cmdToExecute.Parameters.AddWithValue("@normalBalance", _normalBalance)
                cmdToExecute.Parameters.AddWithValue("@accountCategoryID", _accountCategoryID)
                cmdToExecute.Parameters.AddWithValue("@isHeader", _isHeader)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@isSystem", _isSystem)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _accountID = strID
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
            cmdToExecute.CommandText = "UPDATE accAccount " + _
                                        "SET accountNo=@accountNo, accountName=@accountName, parentAccountID=@parentAccountID, " + _
                                        "normalBalance = @normalBalance, accountCategoryID=@accountCategoryID, " + _
                                        "isHeader=@isHeader, isActive=@isActive, isSystem=@isSystem, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE accountID=@accountID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@accountID", _accountID)
                cmdToExecute.Parameters.AddWithValue("@accountNo", _accountNo)
                cmdToExecute.Parameters.AddWithValue("@accountName", _accountName)
                cmdToExecute.Parameters.AddWithValue("@parentAccountID", _parentAccountID)
                cmdToExecute.Parameters.AddWithValue("@normalBalance", _normalBalance)
                cmdToExecute.Parameters.AddWithValue("@accountCategoryID", _accountCategoryID)
                cmdToExecute.Parameters.AddWithValue("@isHeader", _isHeader)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@isSystem", _isSystem)
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
            cmdToExecute.CommandText = "SELECT * FROM accAccount ORDER BY accountNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accAccount")
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
            cmdToExecute.CommandText = "SELECT * FROM accAccount WHERE accountID=@accountID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("accAccount")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@accountID", _accountID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _accountID = CType(toReturn.Rows(0)("accountID"), String)
                    _accountNo = CType(toReturn.Rows(0)("accountNo"), String)
                    _accountName = CType(toReturn.Rows(0)("accountName"), String)
                    _parentAccountID = CType(toReturn.Rows(0)("parentAccountID"), String)
                    _normalBalance = CType(toReturn.Rows(0)("normalBalance"), String)
                    _accountCategoryID = CType(toReturn.Rows(0)("accountCategoryID"), String)
                    _isHeader = CType(toReturn.Rows(0)("isHeader"), Boolean)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
                    _isSystem = CType(toReturn.Rows(0)("isSystem"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM accAccount " + _
                                        "WHERE accountID=@accountID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@accountID", _accountID)

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
        Public Property [accountID]() As String
            Get
                Return _accountID
            End Get
            Set(ByVal Value As String)
                _accountID = Value
            End Set
        End Property

        Public Property [accountNo]() As String
            Get
                Return _accountNo
            End Get
            Set(ByVal Value As String)
                _accountNo = Value
            End Set
        End Property

        Public Property [accountName]() As String
            Get
                Return _accountName
            End Get
            Set(ByVal Value As String)
                _accountName = Value
            End Set
        End Property

        Public Property [parentAccountID]() As String
            Get
                Return _parentAccountID
            End Get
            Set(ByVal Value As String)
                _parentAccountID = Value
            End Set
        End Property

        Public Property [normalBalance]() As String
            Get
                Return _normalBalance
            End Get
            Set(ByVal Value As String)
                _normalBalance = Value
            End Set
        End Property

        Public Property [accountCategoryID]() As String
            Get
                Return _accountCategoryID
            End Get
            Set(ByVal Value As String)
                _accountCategoryID = Value
            End Set
        End Property

        Public Property [isHeader]() As Boolean
            Get
                Return _isHeader
            End Get
            Set(ByVal Value As Boolean)
                _isHeader = Value
            End Set
        End Property

        Public Property [isActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
            End Set
        End Property

        Public Property [isSystem]() As Boolean
            Get
                Return _isSystem
            End Get
            Set(ByVal Value As Boolean)
                _isSystem = Value
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
