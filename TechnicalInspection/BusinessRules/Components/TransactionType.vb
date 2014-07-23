Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class TransactionType
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _transactionCode, _transactionName, _transactionInitial, _numberingMethod, _delimiter, _tableName, _fieldName1, _fieldName2, _lastUpdatedBy As SqlString
        Private _counterDigit As SqlInt16 
        Private _lastUpdatedDate As SqlDateTime
        Private _isNeedApproval As SqlBoolean

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub


        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub


        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[sprs_transactiontype_Insert]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionCode", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionCode))
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionName", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionName))
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionInitial", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionInitial))
                cmdToExecute.Parameters.Add(New SqlParameter("@IsNeedApproval", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _isNeedApproval))
                cmdToExecute.Parameters.Add(New SqlParameter("@Delimiter", SqlDbType.VarChar, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _delimiter))
                cmdToExecute.Parameters.Add(New SqlParameter("@NumberingMethod", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _numberingMethod))
                cmdToExecute.Parameters.Add(New SqlParameter("@CounterDigit", SqlDbType.SmallInt, 16, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _counterDigit))
                cmdToExecute.Parameters.Add(New SqlParameter("@TableName", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tableName))
                cmdToExecute.Parameters.Add(New SqlParameter("@FieldName1", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _fieldName1))
                cmdToExecute.Parameters.Add(New SqlParameter("@FieldName2", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _fieldName2))
                cmdToExecute.Parameters.Add(New SqlParameter("@LastUpdatedBy", SqlDbType.VarChar, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _lastUpdatedBy))
                cmdToExecute.Parameters.Add(New SqlParameter("@LastUpdatedDate", SqlDbType.DateTime, 20, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _lastUpdatedDate))

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


        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[sprs_transactiontype_Update]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionCode", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionCode))
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionName", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionName))
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionInitial", SqlDbType.VarChar, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionInitial))
                cmdToExecute.Parameters.Add(New SqlParameter("@IsNeedApproval", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _isNeedApproval))
                cmdToExecute.Parameters.Add(New SqlParameter("@Delimiter", SqlDbType.VarChar, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _delimiter))
                cmdToExecute.Parameters.Add(New SqlParameter("@NumberingMethod", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _numberingMethod))
                cmdToExecute.Parameters.Add(New SqlParameter("@CounterDigit", SqlDbType.SmallInt, 16, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _counterDigit))
                cmdToExecute.Parameters.Add(New SqlParameter("@TableName", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tableName))
                cmdToExecute.Parameters.Add(New SqlParameter("@FieldName1", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _fieldName1))
                cmdToExecute.Parameters.Add(New SqlParameter("@FieldName2", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _fieldName2))
                cmdToExecute.Parameters.Add(New SqlParameter("@LastUpdatedBy", SqlDbType.VarChar, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _lastUpdatedBy))
                cmdToExecute.Parameters.Add(New SqlParameter("@LastUpdatedDate", SqlDbType.DateTime, 20, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _lastUpdatedDate))

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


        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[sprs_transactiontype_Delete]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionCode", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionCode))

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
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "dbo.[sprs_transactiontype_SelectOne]"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "dbo.[sprs_transactiontype_SelectOneNext]"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "dbo.[sprs_transactiontype_SelectOnePrev]"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("TransactionType")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@TransactionCode", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transactionCode))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _transactionCode = New SqlString(CType(toReturn.Rows(0)("TransactionCode"), String))
                    _transactionName = New SqlString(CType(toReturn.Rows(0)("TransactionName"), String))
                    _transactionInitial = New SqlString(CType(toReturn.Rows(0)("TransactionInitial"), String))
                    _isNeedApproval = New SqlBoolean(CType(toReturn.Rows(0)("IsNeedApproval"), Boolean))
                    _delimiter = New SqlString(CType(toReturn.Rows(0)("Delimiter"), String))
                    _numberingMethod = New SqlString(CType(toReturn.Rows(0)("NumberingMethod"), String))
                    _counterDigit = New SqlInt16(CType(toReturn.Rows(0)("CounterDigit"), Int16))
                    _tableName = New SqlString(CType(toReturn.Rows(0)("TableName"), String))
                    _fieldName1 = New SqlString(CType(toReturn.Rows(0)("FieldName1"), String))
                    _fieldName2 = New SqlString(CType(toReturn.Rows(0)("FieldName2"), String))
                    _lastUpdatedBy = New SqlString(CType(toReturn.Rows(0)("LastUpdatedBy"), String))
                    _lastUpdatedDate = New SqlString(CType(toReturn.Rows(0)("LastUpdatedDate"), DateTime))
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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "dbo.[sprs_transactiontype_SelectAll]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("TransactionType")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
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


#Region " Class Property Declarations "

        Public Property [TransactionCode]() As SqlString
            Get
                Return _transactionCode
            End Get
            Set(ByVal Value As SqlString)
                Dim transactionCodeTmp As SqlString = Value
                If transactionCodeTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TransactionCode", "Transaction Code can't be NULL")
                End If
                _transactionCode = Value
            End Set
        End Property

        Public Property [TransactionName]() As SqlString
            Get
                Return _transactionName
            End Get
            Set(ByVal Value As SqlString)
                Dim transactionNameTmp As SqlString = Value
                If transactionNameTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TransactionName", "Transaction Name can't be NULL")
                End If
                _transactionName = Value
            End Set
        End Property

        Public Property [TransactionInitial]() As SqlString
            Get
                Return _transactionInitial
            End Get
            Set(ByVal Value As SqlString)
                'Dim Tmp As SqlString = Value
                'If Tmp.IsNull Then
                '    Throw New ArgumentOutOfRangeException("TransactionInitial", "Transaction Initial can't be NULL")
                'End If
                _transactionInitial = Value
            End Set
        End Property

        Public Property [IsNeedApproval]() As SqlBoolean
            Get
                Return _isNeedApproval
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim Tmp As SqlBoolean = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("IsNeedApproval", "Is Need Approval can't be NULL")
                End If
                _isNeedApproval = Value
            End Set
        End Property

        Public Property [NumberingMethod]() As SqlString
            Get
                Return _numberingMethod
            End Get
            Set(ByVal Value As SqlString)
                Dim Tmp As SqlString = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NumberingMethod", "Numbering Method can't be NULL")
                End If
                _numberingMethod = Value
            End Set
        End Property

        Public Property [CounterDigit]() As SqlInt16
            Get
                Return _counterDigit
            End Get
            Set(ByVal Value As SqlInt16)
                Dim Tmp As SqlInt16 = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("CounterDigit", "Counter Digit can't be NULL")
                End If
                _counterDigit = Value
            End Set
        End Property

        Public Property [TableName]() As SqlString
            Get
                Return _tableName
            End Get
            Set(ByVal Value As SqlString)
                Dim Tmp As SqlString = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TableName", "Table Name can't be NULL")
                End If
                _tableName = Value
            End Set
        End Property

        Public Property [FieldName1]() As SqlString
            Get
                Return _fieldName1
            End Get
            Set(ByVal Value As SqlString)
                Dim Tmp As SqlString = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("FieldName1", "Field Name 1 can't be NULL")
                End If
                _fieldName1 = Value
            End Set
        End Property

        Public Property [FieldName2]() As SqlString
            Get
                Return _fieldName2
            End Get
            Set(ByVal Value As SqlString)
                Dim Tmp As SqlString = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("FieldName2", "Field Name 2 can't be NULL")
                End If
                _fieldName2 = Value
            End Set
        End Property

        Public Property [Delimiter]() As SqlString
            Get
                Return _delimiter
            End Get
            Set(ByVal Value As SqlString)
                _delimiter = Value
            End Set
        End Property

        Public Property [LastUpdatedBy]() As SqlString
            Get
                Return _lastUpdatedBy
            End Get
            Set(ByVal Value As SqlString)
                Dim Tmp As SqlString = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("LastUpdatedBy", "Last Updated By can't be NULL")
                End If
                _lastUpdatedBy = Value
            End Set
        End Property

        Public Property [LastUpdatedDate]() As SqlDateTime
            Get
                Return _lastUpdatedDate
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim Tmp As SqlDateTime = Value
                If Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("LastUpdatedDate", "Last Updated Date can't be NULL")
                End If
                _lastUpdatedDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
