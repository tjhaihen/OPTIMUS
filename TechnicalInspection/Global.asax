<%@ Import Namespace="Raven.SystemFramework"%>
<%@ Import Namespace="System.Runtime.Remoting" %>
<%@ Import Namespace="System.IO" %>
<script language="VB" runat="server">
    Sub Application_OnStart()
        ApplicationConfiguration.OnApplicationStart(Context.Server.MapPath(HttpRuntime.AppDomainAppVirtualPath))
		
        Dim configPath As String = Path.Combine(Context.Server.MapPath(HttpRuntime.AppDomainAppVirtualPath), "remotingclient.cfg")
		
		If(File.Exists(configPath)) Then 
            System.Runtime.Remoting.RemotingConfiguration.Configure(configPath, False)
		End If

    End Sub
</script>