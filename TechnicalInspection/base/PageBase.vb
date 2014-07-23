
Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.ComponentModel
Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic

Imports Raven.Common

Imports Raven.SystemFramework

Namespace Raven.Web

    Public Class PageBase
        Inherits System.Web.UI.Page

        Private Const UNHANDLED_EXCEPTION As String = "Unhandled Exception:"

        Private Shared pageSecureUrlBase As String
        Private Shared pageUrlBase As String
        Private Shared pageUrlDokuwiki As String
        Private Shared urlSuffix As String

        Private _strProfileID, _strProfileName As String
        Private _strSiteID, _strSiteName As String

        Public Sub New()
            MyBase.New()
            Try
                urlSuffix = Context.Request.Url.Host
                pageUrlDokuwiki = "http://" & urlSuffix

                urlSuffix = Context.Request.Url.Host & Context.Request.ApplicationPath
                pageUrlBase = "http://" & urlSuffix
            Catch
            End Try
        End Sub

        Public Sub Logout()
            System.Web.Security.FormsAuthentication.SignOut()
            Session.Abandon()
            Session.Clear()
            Session.RemoveAll()
            Session.Remove(commonFunction.Key_CacheLoggedOnUser)
            Cache.Remove(commonFunction.Key_CacheLoggedOnUser)
            Cache.Remove(commonFunction.Key_CacheErrorMessage)
            Session.Abandon()
            For Each de As DictionaryEntry In HttpContext.Current.Cache
                HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
            Next
            HttpRuntime.Close()
        End Sub

        Public Shared ReadOnly Property SecureUrlBase() As String
            Get
                If SecureUrlBase Is Nothing Then
                    If SysConfig.EnableSsl Then
                        pageSecureUrlBase = "https://"
                    Else
                        pageSecureUrlBase = "http://"
                    End If
                    pageSecureUrlBase = pageSecureUrlBase & urlSuffix
                End If
                SecureUrlBase = pageSecureUrlBase
            End Get
        End Property

        Public Shared ReadOnly Property UrlBase() As String
            Get
                UrlBase = pageUrlBase
            End Get
        End Property

        Public Property PB_CacheLoggedOnUser() As DataSet
            Get
                Try
                    Dim str As String = Request.Cookies(commonFunction.Key_CacheLoggedOnUser).Value
                    Dim arrstr() As String = str.Split(CChar("|"))
                    Dim dt As New DataSet
                    Dim dttable As New DataTable
                    dttable.TableName = "User"
                    dttable.Columns.Add("UserID")
                    dttable.Columns.Add("Password")
                    dttable.Columns.Add("UserName")
                    dttable.Columns.Add("FirstName")
                    dttable.Columns.Add("MiddleName")
                    dttable.Columns.Add("LastName")
                    dttable.Columns.Add("ProfileID")
                    dttable.Columns.Add("SiteID")

                    Dim dtrow As DataRow = dttable.NewRow()
                    For i As Integer = 0 To arrstr.Length - 1
                        dtrow.Item(i) = arrstr(i)
                    Next
                    dttable.Rows.Add(dtrow)
                    dt.Tables.Add(dttable)

                    'Dim dtProfileMenu As New DataTable
                    'dtProfileMenu = commonFunction.tblProfileMenu(CType(dttable.Rows(0)("ProfileID"), String).Trim, "%")
                    'dtProfileMenu.TableName = "ProfileMenu"
                    'dt.Tables.Add(dtProfileMenu)

                    Return dt
                Catch
                    Return Nothing
                End Try
            End Get
            Set(ByVal Value As DataSet)
                If Value Is Nothing Then
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                Else
                    Dim str As String = ""
                    str += CType(Value.Tables("User").Rows(0)("UserID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("Password"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("UserName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("FirstName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("MiddleName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("LastName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("ProfileID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("SiteID"), String)

                    Dim cookie As HttpCookie
                    cookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
                    cookie.Value = str
                    Response.SetCookie(cookie)
                End If
            End Set
        End Property

        Public Property LoggedOnProfileID() As String
            Get
                Try
                    Dim str As String = Request.Cookies(commonFunction.Key_CacheLoggedOnProfileID).Value
                    Return str.Trim
                Catch
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                If value Is Nothing Then
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnProfileID)
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                Else
                    _strProfileID = value
                    Dim cookie As HttpCookie
                    cookie = New HttpCookie(commonFunction.Key_CacheLoggedOnProfileID)
                    cookie.Value = _strProfileID
                    Response.SetCookie(cookie)
                End If
            End Set
        End Property

        Public Property LoggedOnProfileName() As String
            Get
                Try
                    Dim str As String = Request.Cookies(commonFunction.Key_CacheLoggedOnProfileName).Value
                    Return str.Trim
                Catch
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                If value Is Nothing Then
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnProfileName)
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                Else
                    _strProfileName = value
                    Dim cookie As HttpCookie
                    cookie = New HttpCookie(commonFunction.Key_CacheLoggedOnProfileName)
                    cookie.Value = _strProfileName
                    Response.SetCookie(cookie)
                End If
            End Set
        End Property

        Public Property LoggedOnSiteID() As String
            Get
                Try
                    Dim str As String = Request.Cookies(commonFunction.Key_CacheLoggedOnSiteID).Value
                    Return str.Trim
                Catch
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                If value Is Nothing Then
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnSiteID)
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                Else
                    _strSiteID = value
                    Dim cookie As HttpCookie
                    cookie = New HttpCookie(commonFunction.Key_CacheLoggedOnSiteID)
                    cookie.Value = _strSiteID
                    Response.SetCookie(cookie)
                End If
            End Set
        End Property

        Public Property LoggedOnSiteName() As String
            Get
                Try
                    Dim str As String = Request.Cookies(commonFunction.Key_CacheLoggedOnSiteName).Value
                    Return str.Trim
                Catch
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                If value Is Nothing Then
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnSiteName)
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                Else
                    _strSiteName = value
                    Dim cookie As HttpCookie
                    cookie = New HttpCookie(commonFunction.Key_CacheLoggedOnSiteName)
                    cookie.Value = _strSiteName
                    Response.SetCookie(cookie)
                End If
            End Set
        End Property

        Public ReadOnly Property LoggedOnUserID() As String
            Get
                Dim moduleSet As DataSet
                Dim moduleTable As DataTable
                Dim UID As String = String.Empty

                moduleSet = PB_CacheLoggedOnUser
                If moduleSet Is Nothing Then
                    UID = String.Empty
                Else
                    moduleTable = moduleSet.Tables("User")
                    If (moduleTable.Rows.Count = 1) Then
                        UID = CType(moduleTable.Rows(0)("UserID"), String)
                    End If
                End If

                Return UID.Trim
            End Get
        End Property

        Public ReadOnly Property PB_UserID() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("UserID"), String)
            End Get
        End Property

        Public ReadOnly Property PB_Password() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("Password"), String)
            End Get
        End Property

        Public ReadOnly Property PB_UserFullName() As String
            Get
                Dim _strFullName As String = String.Empty
                Dim _strFirstName, _strMiddleName, _strLastName As String
                _strFirstName = CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("FirstName"), String)
                _strMiddleName = CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("MiddleName"), String)
                _strLastName = CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("LastName"), String)

                If _strLastName.Length > 0 Then _strFullName += _strLastName.ToUpper.Trim
                If _strFirstName.Length > 0 Then _strFullName += ", " + _strFirstName.Trim
                If _strMiddleName.Length > 0 Then _strFullName += " " + _strMiddleName.Trim

                Return _strFullName.Trim
            End Get
        End Property

        Public ReadOnly Property AllowCreate(ByVal MenuID As String) As Boolean
            Get
                Dim moduleSet As DataSet
                Dim moduleView As DataView

                moduleSet = PB_CacheLoggedOnUser
                If Not moduleSet Is Nothing Then
                    moduleView = moduleSet.Tables("ProfileMenu").DefaultView
                    moduleView.RowFilter = "MenuID = '" & MenuID.Trim & "'"

                    If CType(moduleView(0)("IsAllowCreate"), Boolean) = True Then
                        Return True
                    End If
                Else
                    Server.Transfer(Context.Request.ApplicationPath + "/Logon.aspx")
                End If
            End Get
        End Property
        Public ReadOnly Property AllowRead(ByVal MenuID As String) As Boolean
            Get
                Dim moduleSet As DataSet
                Dim moduleView As DataView

                moduleSet = PB_CacheLoggedOnUser
                If Not moduleSet Is Nothing Then
                    moduleView = moduleSet.Tables("ProfileMenu").DefaultView
                    moduleView.RowFilter = "MenuID = '" & MenuID.Trim & "'"

                    If CType(moduleView(0)("IsAllowRead"), Boolean) = True Then
                        Return True
                    End If
                Else
                    Server.Transfer(Context.Request.ApplicationPath + "/Logon.aspx")
                End If
                
            End Get
        End Property        
        Public ReadOnly Property AllowUpdate(ByVal MenuID As String) As Boolean
            Get
                Dim moduleSet As DataSet
                Dim moduleView As DataView

                moduleSet = PB_CacheLoggedOnUser
                If Not moduleSet Is Nothing Then
                    moduleView = moduleSet.Tables("ProfileMenu").DefaultView
                    moduleView.RowFilter = "MenuID = '" & MenuID.Trim & "'"

                    If CType(moduleView(0)("IsAllowUpdate"), Boolean) = True Then
                        Return True
                    End If
                Else
                    Server.Transfer(Context.Request.ApplicationPath + "/Logon.aspx")
                End If
            End Get
        End Property
        Public ReadOnly Property AllowDelete(ByVal MenuID As String) As Boolean
            Get
                Dim moduleSet As DataSet
                Dim moduleView As DataView

                moduleSet = PB_CacheLoggedOnUser
                If Not moduleSet Is Nothing Then
                    moduleView = moduleSet.Tables("ProfileMenu").DefaultView
                    moduleView.RowFilter = "MenuID  = '" & MenuID.Trim & "'"

                    If CType(moduleView(0)("IsAllowDelete"), Boolean) = True Then
                        Return True
                    End If
                Else
                    Server.Transfer(Context.Request.ApplicationPath + "/Logon.aspx")
                End If
            End Get
        End Property

        Protected Overrides Sub OnError(ByVal e As EventArgs)
            ApplicationLog.WriteError(ApplicationLog.FormatException(Server.GetLastError(), UNHANDLED_EXCEPTION))
            Session("Cached:Error:") = Server.GetLastError
            Server.Transfer(Context.Request.ApplicationPath + "/errMsg.aspx")
            MyBase.OnError(e)
        End Sub

    End Class

End Namespace