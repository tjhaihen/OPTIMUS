<%
'This file contains the HTML code to instantiate the Smart Viewer ActiveX.      
'                                                                     
'You will notice that the Report Name parameter references the rptserver.asp file.
'This is because the report pages are actually created by rptserver.asp.
'Rptserver.asp accesses session("oApp"), session("oRpt") and session("oPageEngine")
'to create the report pages that will be rendered by the ActiveX Smart Viewer.
'
%>
<HTML>
<HEAD>
<TITLE>Crystal Reports ActiveX Viewer</TITLE>
</HEAD>
<BODY BGCOLOR="C6C6C6" ONUNLOAD="CallDestroy();" leftmargin=0 topmargin=0 rightmargin=0 bottommargin=0>

<OBJECT ID="CRViewer"
	CLASSID="CLSID:2DEF4530-8CE6-41c9-84B6-A54536C90213"
	WIDTH=100% HEIGHT=100%
	CODEBASE="/viewer9/activeXViewer/activexviewer.cab#Version=9,2,0,442" VIEWASTEXT>
<PARAM NAME="EnableRefreshButton" VALUE=1>
<PARAM NAME="EnableGroupTree" VALUE=1>
<PARAM NAME="DisplayGroupTree" VALUE=0>
<PARAM NAME="EnablePrintButton" VALUE=1>
<PARAM NAME="EnableExportButton" VALUE=1>
<PARAM NAME="EnableDrillDown" VALUE=1>
<PARAM NAME="EnableSearchControl" VALUE=1>
<PARAM NAME="EnableAnimationControl" VALUE=1>
<PARAM NAME="EnableZoomControl" VALUE=1>
</OBJECT>

<SCRIPT LANGUAGE="VBScript">
<!--
Sub Window_Onload
	On Error Resume Next
	Dim webBroker
	Set webBroker = CreateObject("WebReportBroker9.WebReportBroker")
	if ScriptEngineMajorVersion < 2 then
		window.alert "IE 3.02 users on NT4 need to get the latest version of VBScript or install IE 4.01 SP1. IE 3.02 users on Win95 need DCOM95 and latest version of VBScript, or install IE 4.01 SP1. These files are available at Microsoft's web site."
	else
		Dim webSource
		Set webSource = CreateObject("WebReportSource9.WebReportSource")
		webSource.ReportSource = webBroker
		webSource.URL = "rptserver.asp"
		webSource.PromptOnRefresh = True
		CRViewer.ReportSource = webSource
	end if
	CRViewer.ViewReport
End Sub
-->
</SCRIPT>

<script language="javascript">
function CallDestroy()
{
	window.open("Cleanup.asp");
}
</script>

</BODY>
</HTML>
