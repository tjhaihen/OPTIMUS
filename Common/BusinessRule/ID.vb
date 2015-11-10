Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class ID
        Inherits BRInteractionBase


#Region " Class Member Declarations "
        
#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Shared Function GenerateIDNumber(ByVal TableName As String, ByVal ColumnName As String, Optional ByVal Prefix As String = "", Optional ByVal TextFilterForIDMax As String = "", Optional ByVal IDType As String = "D", Optional ByVal DateField As String = "", Optional ByVal DateFieldValue As String = "") As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)
            Dim strNewID As String = String.Empty
            Dim strAutoDate As String = String.Empty
            Dim strIDMax As String = String.Empty

            Select Case IDType
                Case "D"
                    strAutoDate = IIf(DateField.Trim.Length = 0, " convert(varchar(8),getdate(),112) ", " convert(varchar(8),CAST('" + DateFieldValue.Trim + "' AS DATE),112) ")
                    strIDMax = " LEFT(@IDMax,8) "
                    TextFilterForIDMax = IIf(DateField.Trim.Length = 0, "", " WHERE convert(varchar(8),workOrderDate,112) = convert(varchar(8),CAST('" + DateFieldValue.Trim + "' AS DATE),112) ")
                Case "M"
                    strAutoDate = IIf(DateField.Trim.Length = 0, " convert(varchar(6),getdate(),112) ", " convert(varchar(6),CAST('" + DateFieldValue.Trim + "' AS DATE),112) ")
                    strIDMax = " LEFT(@IDMax,6) "
                    TextFilterForIDMax = IIf(DateField.Trim.Length = 0, "", " WHERE convert(varchar(6),workOrderDate,112) = convert(varchar(6),CAST('" + DateFieldValue.Trim + "' AS DATE),112) ")
                Case Else
                    '// Means Yearly
                    strAutoDate = IIf(DateField.Trim.Length = 0, " left((convert(varchar(8),getdate(),112)),4) ", " left((convert(varchar(8),CAST('" + DateFieldValue.Trim + "' AS DATE),112)),4) ")
                    strIDMax = " LEFT(@IDMax,4) "
                    TextFilterForIDMax = IIf(DateField.Trim.Length = 0, "", " WHERE convert(varchar(4),workOrderDate,112) = convert(varchar(4),CAST('" + DateFieldValue.Trim + "' AS DATE),112) ")
            End Select

            cmdToExecute.CommandText = _
            "declare @IDMax VARCHAR(15), " & _
            "@prefix varchar(4), " & _
            "@PrefixLength int, " & _
            "@IDLength int, " & _
            "@ColumnMaxLength int, " & _
            "@Zero varchar(50) " & _
            "SET @prefix = '" + Prefix.Trim + "' " & _
            "SET @Zero = '' " & _
            "SET @PrefixLength = len(ltrim(rtrim(@prefix))) " & _
            "SET @ColumnMaxLength = (SELECT Character_Maximum_Length FROM INFORMATION_SCHEMA.Columns WHERE table_name = '" + Replace(Replace(TableName.Trim, "[", ""), "]", "") + "' AND column_name = '" + ColumnName.Trim + "') " & _
            "SET @IDLength = @ColumnMaxLength - @PrefixLength - 8 " & _
            "WHILE LEN(@Zero) < @IDLength " & _
            "BEGIN " & _
             "SET @Zero = @Zero + '0' " & _
            "End " & _
            "SELECT @IDMax= ISNULL(MAX(" + ColumnName.Trim + "),'0') FROM " + TableName.Trim + " " + IIf(TextFilterForIDMax.Trim = "", "", TextFilterForIDMax.Trim).ToString.Trim & _
            " IF @PrefixLength = 0 " & _
            "BEGIN " & _
                "IF ISNUMERIC(LEFT(@IDMax,@PrefixLength)) = 0 " & _
                    "set @IDMax = right(@IDMax,(@ColumnMaxLength - @PrefixLength)) " & _
                "SELECT " & _
                "(CASE " & _
                    "WHEN " + strAutoDate + " = " + strIDMax + " THEN " & _
                        "(" + strAutoDate + " + right((@Zero + cast((cast(right(@IDMax,@IDLength) as int) + 1)as varchar)),@IDLength)) " & _
                    "ELSE " & _
                        "(" + strAutoDate + " + right(@Zero+'1',@IDLength)) " & _
                "END) as ID " & _
            "END " & _
            "ELSE " & _
            "BEGIN " & _
                "if @IDMax <> '0' " & _
                "begin " & _
                    "set @IDMax = right(@IDMax,((len(@IDMax)) - @PrefixLength)) " & _
                "end " & _
                "SELECT " & _
                "(CASE " & _
                    "WHEN " + strAutoDate + " = " + strIDMax + " THEN " & _
                        "@prefix + (" + strAutoDate + " + right((@Zero + cast((cast(right(@IDMax,@IDLength) as int) + 1)as varchar)),@IDLength)) " & _
                    "ELSE " & _
                        "@prefix + (" + strAutoDate + " + right(@Zero+'1',@IDLength)) " & _
                "END) as ID " & _
            "END "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GenerateIDNumber")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                strNewID = CType(Common.ProcessNull.GetString(toReturn.Rows(0)("ID")), String)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return strNewID
        End Function

        Public Shared Function GetFieldValue_BAK(ByVal TableName As String, ByVal ParamField As String, ByVal ParamValue As String, ByVal ValueField As String) As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)

            cmdToExecute.CommandText = _
            "SELECT TOP 1 [" + ValueField + "] FROM [" + TableName + "] WHERE [" + ParamField + "]='" + ParamValue + "'"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetFieldValue")
            Dim strToReturn As String = String.Empty
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    strToReturn = CType(Common.ProcessNull.GetString(toReturn.Rows(0)(ValueField)), String)
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

            Return strToReturn
        End Function

        Public Shared Function GetFieldValue(ByVal TableName As String, ByVal ParamField As String, ByVal ParamValue As String, ByVal ValueField As String) As String
            Dim strCommand As String = String.Empty
            Dim strArrSeparator As String = Constants.ArrSeparator.DefaultArrSeparator
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)

            If ParamField.Contains(strArrSeparator) And ParamValue.Contains(strArrSeparator) Then
                Dim arrParamField() As String = ParamField.Split(strArrSeparator)
                Dim arrParamValue() As String = ParamValue.Split(strArrSeparator)
                Dim strCommandParam As String = String.Empty
                For i As Integer = 0 To arrParamField.Length - 1
                    If i = 0 Then
                        strCommandParam += " WHERE "
                    Else
                        strCommandParam += " AND "
                    End If
                    strCommandParam += "[" + arrParamField(i) + "] = '" + arrParamValue(i) + "'"
                Next
                strCommand = "SELECT TOP 1 [" + ValueField + "] FROM [" + TableName + "]" + strCommandParam
            Else
                strCommand = "SELECT TOP 1 [" + ValueField + "] FROM [" + TableName + "] WHERE [" + ParamField + "]='" + ParamValue + "'"
            End If

            cmdToExecute.CommandText = strCommand.Trim
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetFieldValue")
            Dim strToReturn As String = String.Empty
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    strToReturn = CType(Common.ProcessNull.GetString(toReturn.Rows(0)(ValueField)), String)
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

            Return strToReturn
        End Function

        Public Shared Function GetMaxSequenceNo(ByVal TableName As String, ByVal SequenceField As String, ByVal ParamField As String, ByVal ParamValue As String, _
                Optional ByVal DtParamField As String = "", Optional ByVal DtParamValue As String = "") As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(SysConfig.ConnectionString)
            Dim strDtFilterCondition As String = String.Empty
            Dim strDtFilterOrder As String = String.Empty

            If Len(DtParamField.Trim) > 0 And Len(DtParamValue.Trim) > 0 Then
                strDtFilterCondition = " AND [" + DtParamField + "]='" + DtParamValue + "'"
                strDtFilterOrder = "," + DtParamField
            End If

            cmdToExecute.CommandText = _
            "SELECT TOP 1 [" + SequenceField + "] FROM [" + TableName + "] WHERE [" + ParamField + "]='" + ParamValue + "'" + _
                strDtFilterCondition + " ORDER BY " + ParamField + strDtFilterOrder + "," + SequenceField + " DESC"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetMaxSequenceNo")
            Dim strToReturn As String = String.Empty
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    strToReturn = CType(Common.ProcessNull.GetString(toReturn.Rows(0)(SequenceField)), String)
                Else
                    strToReturn = "0"
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

            Return strToReturn
        End Function

#Region " Class Property Declarations "

#End Region

    End Class
End Namespace
