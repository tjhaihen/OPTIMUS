<%

	'	crystalreport Object...
	'
	if Not IsObject (Session("oApp")) Then                              
		Set Session("oApp") = Server.CreateObject("CrystalRuntime.Application")
	End If                                                                

	Path = Request.ServerVariables("PATH_TRANSLATED")                     
	While (Right(Path, 1) <> "\" And Len(Path) <> 0)                      
	   iLen = Len(Path) - 1                                                  
	   Path = Left(Path, iLen)                                               
	Wend                                                                  
	                                                                      
	If IsObject(Session("oRpt")) then
		Set Session("oRpt") = nothing
	End if

	On Error Resume Next

	Set Session("oRpt") = Session("oApp").OpenReport(Path & reportname, 1)

	If Err.Number <> 0 Then
	  Response.Write "Error Occurred creating Report Object: " & Err.Description
	  Set Session("oRpt") = nothing
	  Set Session("oApp") = nothing
	  Session.Abandon
	  Response.End
	End If

	Session("oRpt").MorePrintEngineErrorMessages = False
	Session("oRpt").EnableParameterPrompting = False
	Session("oRpt").DiscardSavedData

	Set Database = Session("oRpt").Database
	Set Tables = Database.Tables
	Set Table1 = Tables.Item(1)
	Set Table2 = Tables.Item(2)
	

	Table1.SetPrivateData 3, Session("oRs") 
	Table2.SetPrivateData 3, Session("oRsCompany") 

	On Error Resume Next
	Session("oRpt").ReadRecords

	If Err.Number <> 0 Then                                               
	  Response.Write "Error Occurred Reading Records: " & Err.Description
	  Set Session("oRpt") = nothing
	  Set Session("oApp") = nothing
	  Session.Abandon
	  Response.End
	Else
	  If IsObject(Session("oPageEngine")) Then                              
	  	Set Session("oPageEngine") = nothing
	  End If
	  Set Session("oPageEngine") = Session("oRpt").PageEngine
	End If

%>


