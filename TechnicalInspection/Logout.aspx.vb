Option Strict On
Option Explicit On 

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Namespace Raven.Web

    Public Class Logout
        Inherits PageBase


#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            System.Web.Security.FormsAuthentication.SignOut()
            MyBase.PB_CacheLoggedOnUser = Nothing
            Session.Abandon()
            Session.Clear()
            Session.RemoveAll()
            HttpRuntime.Close()
            For Each de As DictionaryEntry In HttpContext.Current.Cache
                HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
            Next

            Dim myCookie As HttpCookie
            myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
            myCookie.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(myCookie)

            Response.Redirect(PageBase.UrlBase + "/Logon.aspx")
        End Sub

    End Class
End Namespace