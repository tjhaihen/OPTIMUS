<%

	Set oConn = Server.CreateObject("ADODB.Connection")

	cst = "Provider=SQLOLEDB;Server=.\SQLSVR2012;User ID=sa;" & _
          		";Password=p455w0rd.;Initial Catalog=OPTIMUS_2012;"

	oConn.Mode = adModeRead
	oConn.Open cst
	oConn.CommandTimeout = 300


%>