<%@ LANGUAGE="VBSCRIPT" %>

<%
	%>
		<!-- #include file="../CONFIG_SubReport/connection.inc" -->
	<%

	set session("oRs") = Server.CreateObject("ADODB.Recordset")	' Main Report
	set session("oRsSubReport1") = Server.CreateObject("ADODB.Recordset") 'Sub Report 1
	set session("oRsSubReport2") = Server.CreateObject("ADODB.Recordset") 'Sub Report 2
	
	'
	' process form variable(s) in here...!!
	'
	RptName = Request.QueryString("RptName")
	SP = Request.QueryString("SP")
	parm = Request.QueryString("parm")
	moduleName = Request.QueryString("moduleName")
	
	if parm <> "" then
		parm = Replace(parm, "True", "1")
		parm = Replace(parm, "False", "0")
		parm = Replace(parm, "|", "','")
		strSQL = SP & " '" & parm & "'"		
	else
		strSQL = SP
	end if

	' SQL Statement for Sub Report 1..!!
	strsql2 = "spp_MPISubReportPicsL '" & parm & "'"
	
	' SQL Statement for Sub Report 2..!!
	strsql3 = "spp_MPISubReportPicsS '" & parm & "'"

	reportname = "../" + moduleName + "/" + RptName
	
	'
	' ----------------------------------------------------------------------
	'	Main Report, open recordset and close the connection
	' ----------------------------------------------------------------------
	'

	session("oRs").CursorLocation = 3 'adUseClient
	Session("oRs").Open strSQL, oConn, 3, 4, 1
	set Session("oRs").ActiveConnection = Nothing


	'
	'	recordset untuk parameter yg ditampilin di pageHeader,reportHeader..
	'
	%>
		<!-- #include file="../CONFIG_SubReport/company.inc" -->
	<%


	'
	'	crystalreport Object...
	'
	If Not IsObject (session("oApp")) Then
		Set session("oApp") = Server.CreateObject("CrystalRuntime.Application")
	End If

	Path = Request.ServerVariables("PATH_TRANSLATED")
	While (Right(Path, 1) <> "\" And Len(Path) <> 0)
		iLen = Len(Path) - 1
		Path = Left(Path, iLen)
	Wend

	If IsObject(session("oRpt")) then
		Set session("oRpt") = nothing
	End if

	On error resume next

	Set session("oRpt") = session("oApp").OpenReport(path & reportname, 1)

	If Err.Number <> 0 Then
	  Response.Write "Error Occurred creating Report Object: " & Err.Description
	  Set Session("oRpt") = nothing
	  Set Session("oApp") = nothing
	  Session.Abandon
	  Response.End
	End If

	session("oRpt").MorePrintEngineErrorMessages = False
	session("oRpt").EnableParameterPrompting = False
	session("oRpt").DiscardSavedData

	set Database = session("oRpt").Database
	set Tables = Database.Tables
	set Table1 = Tables.Item(1)
	set Table2 = Tables.Item(2)

	Table1.SetPrivateData 3, session("oRs")
	Table2.SetPrivateData 3, session("oRsCompany")


	' // Sub Report 1
	set Tables = nothing
	set Table1 = nothing
	'
	' ----------------------------------------------------------------------
	'	Sub Report 1, open recordset and close the connection
	' ----------------------------------------------------------------------
	'
	session("oRsSubReport1").CursorLocation = 3 'adUseClient
	Session("oRsSubReport1").Open strSQL2, oConn, 3, 4, 1
	set Session("oRsSubReport1").ActiveConnection = Nothing

	Set CRXSubreport = session("oRpt").OpenSubreport("MPIPicL")
	Set Tables = CRXSubreport.Database.Tables
	Set Table1 = Tables.Item(1)
	Table1.SetDataSource session("oRsSubReport1")
	
	' // Sub Report 2
	set Tables = nothing
	set Table2 = nothing
	'
	' ----------------------------------------------------------------------
	'	Sub Report 2, open recordset and close the connection
	' ----------------------------------------------------------------------
	'
	session("oRsSubReport2").CursorLocation = 3 'adUseClient
	Session("oRsSubReport2").Open strSQL3, oConn, 3, 4, 1
	set Session("oRsSubReport2").ActiveConnection = Nothing

	Set CRXSubreport = session("oRpt").OpenSubreport("MPIPicS")
	Set Tables = CRXSubreport.Database.Tables
	Set Table1 = Tables.Item(1)
	Table1.SetDataSource session("oRsSubReport2")
	
	
	On Error Resume Next
	session("oRpt").ReadRecords

	If Err.Number <> 0 Then
	  Response.Write "Error Occurred Reading Records: " & Err.Description
	  Set Session("oRpt") = nothing
	  Set Session("oApp") = nothing
	  Session.Abandon
	  Response.End
	Else
	  If IsObject(session("oPageEngine")) Then
	  	set session("oPageEngine") = nothing
	  End If
	  set session("oPageEngine") = session("oRpt").PageEngine
	End If

	%>
	<!-- #include file="SmartViewerActiveX.asp" -->
	<%

%>