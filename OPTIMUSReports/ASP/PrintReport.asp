<%@ LANGUAGE="VBSCRIPT" %>
<%
	%>
	<!-- #include file="../CONFIG/header.inc" -->
	<%

	RptName = Request.QueryString("RptName")
	SP = Request.QueryString("SP")
	parm = Request.QueryString("parm")
	moduleName = Request.QueryString("moduleName")
		
	if parm <> "" then
		parm = Replace(parm, "|", "','")
		strSQL = SP & " '" & parm & "'"
	else
		strSQL = SP
	end if
	
	Session("oRs").Open strSQL
	session("oRs").ActiveConnection = nothing
	
	'response.Write(strsql)
	
	reportname = "../" + moduleName + "/" + RptName


	%>
	<!-- #include file="../CONFIG/footer.inc" -->
	<!-- #include file="SmartViewerActiveX.asp" -->
	<%

%>
