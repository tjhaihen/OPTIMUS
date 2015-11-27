<%
	Set oConn = Server.CreateObject("ADODB.Connection")

	cst = "Provider=SQLOLEDB;Server=.\sqlsvr2012;User ID=sa;Password=p455w0rd.;Initial Catalog=OPTIMUS;"

	oConn.Mode = adModeRead
	oConn.Open cst
	oConn.CommandTimeout = 300	
%>

<%

Set Session("oRsCompany") = Server.CreateObject("ADODB.Recordset")
Session("oRsCompany").ActiveConnection = oConn
Session("oRsCompany").CursorLocation = 3

Session("oRsCompany").Open "spCompanyInfo"
Set Session("oRsCompany").ActiveConnection = Nothing


%>	

<%
set Session("oRs") = Server.CreateObject("ADODB.Recordset")
	  Session("oRs").ActiveConnection = oConn
	  session("oRs").CursorLocation = 3
%>	