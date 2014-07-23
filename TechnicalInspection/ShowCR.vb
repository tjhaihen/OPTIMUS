Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web.Design
Imports System.IO
Imports Raven.Common
Imports Raven.BussinessRules
Imports Raven.Web


Public Class ShowCR
    Inherits PageBase

    Public Sub CreateReport(ByVal reportID As String, ByRef rptViewer As CrystalDecisions.Web.CrystalReportViewer, ByVal parametersValue As String)
        Dim oRpt As New ReportDocument
        Dim oSubRpt As New ReportDocument
        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As CrystalDecisions.CrystalReports.Engine.Table
        Dim crLogOnInfos As New TableLogOnInfos
        Dim crLogOnInfo As New TableLogOnInfo
        Dim crConnInfo As New ConnectionInfo
        Dim configurationAppSettings As  _
            System.Configuration.AppSettingsReader = _
            New System.Configuration.AppSettingsReader


        '---------------------------------------------------------------------------------
        'Load MyReport Business Object
        Dim brReport As New MyReport
        brReport.ReportCode = reportID.Trim
        Dim dtTable As DataTable = brReport.GetReportDataByReportCode()
        If dtTable.Rows.Count > 0 Then
            '------------------------------------------------------------------------------
            'LoadReportPhysically
            Dim sReportPath As String
            Dim sConnectionString As String
            Dim sReportFormat As String = "PDF"

            sReportPath = SysConfig.PhysicalReportsFolder + brReport.ReportFileName
            sConnectionString = SysConfig.ConnectionString
            sReportFormat = brReport.ReportFormat

            oRpt.Load(sReportPath)

            '------------------------------------------------------------------------------------
            'log on to SQL server
            'Report code starts here
            'Set the database and the tables objects to the main report 'oRpt'
            crDatabase = oRpt.Database
            crTables = crDatabase.Tables
            'Loop through each table and set the connection info 
            'Pass the connection info to the logoninfo object then apply the 
            'logoninfo to the main report
            With crConnInfo
                Dim _splitConStr As New SplitConnStr
                _splitConStr.SplitStr(sConnectionString)
                .ServerName = _splitConStr.DBServer
                .DatabaseName = _splitConStr.Database
                .UserID = _splitConStr.UserID
                .Password = _splitConStr.Password
            End With

            For Each crTable In crTables
                crLogOnInfo = crTable.LogOnInfo
                crLogOnInfo.ConnectionInfo = crConnInfo
                'a.) apply Logon Info to the report viewer, to solve the 'Incorrect Logon Info' issue.
                crLogOnInfos.Add(crLogOnInfo)
                crTable.ApplyLogOnInfo(crLogOnInfo)
            Next

            '-----------------------------------------------------------------------
            'Load Parameter Field
            Dim parametersField As String = brReport.ReportParameter

            '------------------------------------------------------------------------------------
            'Fill Parameter Field
            Dim paramFields As New ParameterFields()
            Dim paramField As New ParameterField()
            Dim discreteValue As New ParameterDiscreteValue()
            Dim rangeVal As New ParameterRangeValue()

            If parametersField <> String.Empty Then
                Dim arrParamField() As String = parametersField.Split("|")
                Dim arrParamValue() As String = parametersValue.Split("|")

                Dim temp As ParameterFields = oRpt.ParameterFields

                For i As Integer = 0 To arrParamField.Length - 1
                    Try
                        oRpt.SetParameterValue(arrParamField(i), "'" + arrParamValue(i) + "'")

                        'b.) apply Parameter Values for each Parameter Fields, to solve the 'Missing Parameter Values' issue
                        paramField = New ParameterField
                        discreteValue = New ParameterDiscreteValue
                        paramField.ParameterFieldName = arrParamField(i)
                        discreteValue.Value = "'" + arrParamValue(i) + "'"
                        paramField.CurrentValues.Add(discreteValue)
                        paramFields.Add(paramField)
                    Catch
                    End Try
                Next
            End If

            '------------------------------------------------------------------------------------
            'Set report to reportviewer
            Select Case sReportFormat
                Case "PDF"
                    Dim s As System.IO.MemoryStream = oRpt.ExportToStream(ExportFormatType.PortableDocFormat)
                    ' the code below will create pdfs
                    ' in memory and stream them to the browser
                    ' instead of creating files on disk.
                    With HttpContext.Current.Response
                        .ClearContent()
                        .ClearHeaders()
                        .ContentType = "application/pdf"
                        .AddHeader("Content-Disposition", "inline; filename=Report.pdf")
                        .BinaryWrite(s.ToArray)
                        .End()
                    End With

                Case "XLS"
                    Dim s As System.IO.MemoryStream = oRpt.ExportToStream(ExportFormatType.Excel)
                    With HttpContext.Current.Response
                        .ClearContent()
                        .ClearHeaders()
                        .ContentType = "application/vnd.ms-excel"
                        .BinaryWrite(s.ToArray)
                        .End()
                    End With

                Case "DOC"
                    Dim s As System.IO.MemoryStream = oRpt.ExportToStream(ExportFormatType.Excel)
                    With HttpContext.Current.Response
                        .ClearContent()
                        .ClearHeaders()
                        .ContentType = "application/vnd.ms-word"
                        .BinaryWrite(s.ToArray)
                        .End()
                    End With

                Case "RPT"
                    '// CR default format        
                    rptViewer.HasCrystalLogo = False
                    rptViewer.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX
                    'a.) apply Logon Info to the report viewer, to solve the 'Incorrect Logon Info' issue.
                    rptViewer.LogOnInfo = crLogOnInfos
                    'b.) apply Parameter Values for each Parameter Fields, to solve the 'Missing Parameter Values' issue
                    rptViewer.ParameterFieldInfo = paramFields
                    rptViewer.ReportSource = oRpt

                Case Else
                    'Unknown format
                    commonFunction.MsgBox(Me, "Unknown Report Format: " + sReportFormat + " for ReportID: " + reportID.Trim)
            End Select
        End If
    End Sub

End Class

Public Class SplitConnStr
    Public Database As String
    Public UserID As String
    Public Password As String
    Public DBServer As String

    Public Sub SplitStr(ByVal connstr As String)
        Dim split As String() = connstr.Split(New [Char]() {";"})
        Dim s, sName As String
        For Each s In split
            If s.Trim() <> "" Then
                Dim s1 As String() = s.Split(New [Char]() {"="})
                sName = UCase(s1(0))
                If sName = "SERVER" Then DBServer = s1(1)
                If sName = "DATABASE" Then Database = s1(1)
                If sName = "USER ID" Then UserID = s1(1)
                If sName = "PASSWORD" Then Password = s1(1)
            End If
        Next s
    End Sub
End Class