Option Strict On
Option Explicit On

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Raven.Web
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven
    Public MustInherit Class RadMenu
        Inherits ModuleBase

#Region "  Private Variables  "        

#End Region

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "  Control Events  "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load            
            initCompanyInfo()
            initUserInfo()
        End Sub

        Private Sub btnLogout_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnLogout.Click
            Response.Redirect(PageBase.UrlBase + "/Logout.aspx")
        End Sub
#End Region

#Region "  Private Functions  "
        Private Sub CreateMenu()
            Menu.ProfileID = MyBase.LoggedOnProfileID
            Menu.AppID = App.App_TechnicalInspection.Trim
        End Sub

        Private Sub initCompanyInfo()
            Dim br As New Common.BussinessRules.Company
            With br
                If .SelectOne.Rows.Count > 0 Then
                    lblCompanyName.Text = .companyName.Trim
                    'lblSiteName.Text = MyBase.LoggedOnSiteName
                Else
                    lblCompanyName.Text = "[Company]"
                    'lblSiteName.Text = "[Site]"
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub initUserInfo()
            If MyBase.MB_CacheLoggedOnUser Is Nothing Then
                System.Web.Security.FormsAuthentication.SignOut()
                lblUserFullName.Text = "You are Logged Out. Please Log In again to continue using the system."
                lblProfileName.Text = String.Empty
            Else
                lblUserFullName.Text = MyBase.MB_UserFullName
                lblProfileName.Text = MyBase.LoggedOnProfileName
                CreateMenu()
            End If
        End Sub
#End Region

#Region " Public Property "
        Public Property Menu_CompanyName() As String
            Get
                Return lblCompanyName.Text.Trim
            End Get
            Set(ByVal Value As String)
                lblCompanyName.Text = Value
            End Set
        End Property
#End Region

    End Class
End Namespace


