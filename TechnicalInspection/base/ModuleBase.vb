
Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Web

    Public Class ModuleBase
        Inherits UserControl

        Private Const UNHANDLED_EXCEPTION As String = "Unhandled Exception:"

        Private basePathPrefix As String
        Private _strProfileID, _strProfileName As String
        Private _strSiteID, _strSiteName As String

        Public Property PathPrefix() As String
            Get
                If basePathPrefix Is Nothing Then
                    basePathPrefix = PageBase.UrlBase
                End If

                PathPrefix = basePathPrefix
            End Get
            Set(ByVal Value As String)
                basePathPrefix = Value
            End Set
        End Property

        Public Property MB_CacheLoggedOnUser() As DataSet
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

        Public ReadOnly Property MB_UserFullName() As String
            Get
                Dim _strFullName As String = String.Empty
                Dim _strFirstName, _strMiddleName, _strLastName As String
                _strFirstName = CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("FirstName"), String)
                _strMiddleName = CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("MiddleName"), String)
                _strLastName = CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("LastName"), String)

                If _strLastName.Length > 0 Then _strFullName += _strLastName.ToUpper.Trim
                If _strFirstName.Length > 0 Then _strFullName += ", " + _strFirstName.Trim
                If _strMiddleName.Length > 0 Then _strFullName += " " + _strMiddleName.Trim

                Return _strFullName.Trim
            End Get
        End Property

        Public ReadOnly Property MB_UserGroupMenu() As DataTable
            Get
                Dim dtUserGroupMenu As New DataTable
                dtUserGroupMenu = commonFunction.tblProfileMenu(CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("UserGroupID"), String).Trim, "%")
                Return dtUserGroupMenu
            End Get
        End Property

    End Class

End Namespace