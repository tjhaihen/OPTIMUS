<%

Set Session("oRsCompany") = Server.CreateObject("ADODB.Recordset")
Session("oRsCompany").ActiveConnection = oConn
Session("oRsCompany").CursorLocation = 3

Session("oRsCompany").Open "spCompanyInfo"
Set Session("oRsCompany").ActiveConnection = Nothing


%>	