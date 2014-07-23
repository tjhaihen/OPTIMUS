Option Strict On
Option Explicit On 

Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Web

    Public Class Logon
        Inherits PageBase

        Protected WithEvents pnlLogin As Panel
        Protected WithEvents pnlChooseProfileAndSite As Panel
        Protected WithEvents txtUsername As TextBox
        Protected WithEvents rfvUsername As RequiredFieldValidator
        Protected WithEvents txtPassword As TextBox
        Protected WithEvents rfvPassword As RequiredFieldValidator        
        Protected WithEvents lblErrLogin As Label
        Protected WithEvents lblUserFullName As Label
        Protected WithEvents ddlUserProfile As DropDownList        
        Protected WithEvents btnLogin As Button
        Protected WithEvents btnLogout As Button
        Protected WithEvents btnContinue As Button
        Protected WithEvents lblCompanyName As Label
        Protected WithEvents lblCompanyAddress As Label
        Protected WithEvents lblCompanyPhone As Label
        Protected WithEvents lblCompanyCityPostalCode As Label

        Private logonUserData As DataSet

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
            logonUserData = CType(PB_CacheLoggedOnUser, DataSet)
            lblErrLogin.Visible = False

            If Me.IsPostBack Then
            Else
                loadCompanyInfo()

                pnlLogin.Visible = True
                pnlChooseProfileAndSite.Visible = False
                lblErrLogin.Visible = False
                ddlUserProfile.Enabled = True
            End If
        End Sub

        Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
            If Not Page.IsValid Then
                Return
            End If

            If Not MyBase.PB_CacheLoggedOnUser Is Nothing Then
                lblUserFullName.Text = MyBase.PB_UserFullName.Trim
                pnlLogin.Visible = False
                pnlChooseProfileAndSite.Visible = True                
                commonFunction.SetDDL_Table(ddlUserProfile, "UserProfile", MyBase.LoggedOnUserID)
                Me.ViewState("target") = "logon"
                Exit Sub
            End If

            pnlLogin.Visible = True

            Dim dtUser As New DataTable
            dtUser = commonFunction.tblUserLogin(txtUsername.Text.Trim)
            If dtUser.Rows.Count = 1 Then
                If CType(dtUser.Rows(0)("Password"), String).Trim = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim, "sha1") Then
                    Dim ds As New DataSet
                    Dim _strUserID As String = CType(dtUser.Rows(0)("UserID"), String).Trim
                    dtUser.TableName = "User"

                    commonFunction.SetDDL_Table(ddlUserProfile, "UserProfile", _strUserID.Trim)

                    ds.Tables.Add(dtUser)
                    MyBase.PB_CacheLoggedOnUser = ds
                    ds = Nothing
                    lblUserFullName.Text = MyBase.PB_UserFullName.Trim

                    If ddlUserProfile.Items.Count = 1 Then
                        ddlUserProfile.Enabled = False
                        Dim _strProfileID As String = ddlUserProfile.SelectedValue.Trim
                        Dim _strProfileName As String = String.Empty
                        Dim oProfile As New Common.BussinessRules.Profile
                        oProfile.ProfileID = _strProfileID.Trim
                        oProfile.SelectOne()
                        _strProfileName = oProfile.ProfileName.Trim
                        oProfile.Dispose()
                        oProfile = Nothing

                        MyBase.LoggedOnProfileID = _strProfileID
                        MyBase.LoggedOnProfileName = _strProfileName

                        FormsAuthentication.RedirectFromLoginPage("*", False)
                    Else
                        pnlLogin.Visible = False
                        pnlChooseProfileAndSite.Visible = True
                    End If                                                    
                Else
                    lblErrLogin.Visible = True
                End If
            Else
                lblErrLogin.Visible = True
            End If
            dtUser = Nothing
        End Sub

        Private Sub btnContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Click
            If Not Page.IsValid Then
                Return
            End If

            If MyBase.PB_CacheLoggedOnUser Is Nothing Then
                pnlLogin.Visible = True
                pnlChooseProfileAndSite.Visible = False                
                Exit Sub
            End If

            Dim _strProfileID As String = ddlUserProfile.SelectedValue.Trim
            
            If Len(_strProfileID.Trim) > 0 Then
                Dim _strProfileName As String = String.Empty                
                Dim oProfile As New Common.BussinessRules.Profile
                oProfile.ProfileID = _strProfileID.Trim
                oProfile.SelectOne()
                _strProfileName = oProfile.ProfileName.Trim
                oProfile.Dispose()
                oProfile = Nothing

                MyBase.LoggedOnProfileID = _strProfileID
                MyBase.LoggedOnProfileName = _strProfileName

                FormsAuthentication.RedirectFromLoginPage("*", False)
            End If
        End Sub

        Private Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
            'MyBase.PB_CacheLoggedOnUser = Nothing
            'logonUserData = Nothing
            'FormsAuthentication.SignOut()

            'Session.Abandon()
            'Session.Clear()
            'Session.RemoveAll()
            'HttpRuntime.Close()
            'For Each de As DictionaryEntry In HttpContext.Current.Cache
            '    HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
            'Next

            'Dim myCookie As HttpCookie
            'myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
            'myCookie.Expires = DateTime.Now.AddDays(-1D)
            'Response.Cookies.Add(myCookie)

            'commonFunction.ShowPanel(pnlLogin, True)
            'commonFunction.ShowPanel(pnlChooseProfileAndSite, False)

            Response.Redirect(PageBase.UrlBase + "/Logout.aspx")
        End Sub

        Private Sub loadCompanyInfo()
            Dim oCP As New Common.BussinessRules.Company
            With oCP
                If .SelectOne.Rows.Count > 0 Then
                    lblCompanyName.Text = .companyName.Trim
                    lblCompanyAddress.Text = .address1.Trim
                    lblCompanyPhone.Text = .phone.Trim
                    lblCompanyCityPostalCode.Text = (.city.Trim + " " + .postalCode.Trim).Trim
                End If
            End With
            oCP.Dispose()
            oCP = Nothing
        End Sub

    End Class

End Namespace