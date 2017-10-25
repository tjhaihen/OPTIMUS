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
Imports Raven.Common.BussinessRules

Namespace CommonLibs
    Public Class Menu
        Inherits System.Web.UI.UserControl

        Protected WithEvents rptMenu As Repeater
        Protected WithEvents rptMenuLevel2 As Repeater
        Protected WithEvents rptMenuLevel3 As Repeater
        Protected WithEvents rptMenuLevel4 As Repeater

        Private _ProfileID As String = String.Empty
        Private _AppID As String = String.Empty

        Private Sub Page_DataBinding(sender As Object, e As System.EventArgs) Handles Me.DataBinding
            Dim dtMenu As DataTable
            Dim oUGM As New ProfileMenu
            oUGM.ProfileID = _ProfileID.Trim
            dtMenu = oUGM.SelectMenuByAppIDandParentID(_AppID.Trim, "NULL")
            rptMenu.DataSource = dtMenu
            rptMenu.DataBind()
            oUGM.Dispose()
            oUGM = Nothing
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
                'Dim dtMenu As DataTable
                'Dim oUGM As New ProfileMenu
                'oUGM.ProfileID = _ProfileID.Trim
                'dtMenu = oUGM.SelectMenuByAppIDandParentID(_AppID.Trim, "NULL")
                'rptMenu.DataSource = dtMenu
                'rptMenu.DataBind()
                'oUGM.Dispose()
                'oUGM = Nothing
            End If            
        End Sub

        Protected Sub rptMenu_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptMenu.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim rptMenuLevel2 As Repeater = CType(e.Item.FindControl("rptMenuLevel2"), Repeater)

                Dim dtMenuLevel2 As DataTable = Me.GetMenuChild(row("MenuID").ToString.Trim)
                If dtMenuLevel2.Rows.Count > 0 Then
                    rptMenuLevel2.DataSource = dtMenuLevel2
                    rptMenuLevel2.DataBind()
                End If
            End If
        End Sub

        Protected Sub rptMenuLevel2_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptMenuLevel2.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim rptMenuLevel3 As Repeater = CType(e.Item.FindControl("rptMenuLevel3"), Repeater)

                Dim dtMenuLevel3 As DataTable = Me.GetMenuChild(row("MenuID").ToString.Trim)
                If dtMenuLevel3.Rows.Count > 0 Then
                    rptMenuLevel3.DataSource = dtMenuLevel3
                    rptMenuLevel3.DataBind()
                End If
            End If
        End Sub

        Protected Sub rptMenuLevel3_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptMenuLevel3.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim rptMenuLevel4 As Repeater = CType(e.Item.FindControl("rptMenuLevel4"), Repeater)

                Dim dtMenuLevel4 As DataTable = Me.GetMenuChild(row("MenuID").ToString.Trim)
                If dtMenuLevel4.Rows.Count > 0 Then
                    rptMenuLevel4.DataSource = dtMenuLevel4
                    rptMenuLevel4.DataBind()
                End If
            End If
        End Sub

        Protected Function GetResolveUrl(ByVal Url As String) As String
            If Url = "#" Then
                Return "#"
            End If

            Return ResolveUrl("~/Secure/" + Url)
        End Function

        Private Function GetMenuChild(ByVal ParentID As String) As DataTable
            Dim dt As DataTable
            Dim oUGM As New ProfileMenu
            oUGM.ProfileID = _ProfileID.Trim
            dt = oUGM.SelectMenuByAppIDandParentID(_AppID.Trim, ParentID.Trim)
            oUGM.Dispose()
            oUGM = Nothing
            Return dt
        End Function

        Public Property [ProfileID]() As String
            Get
                Return _ProfileID
            End Get
            Set(ByVal Value As String)
                _ProfileID = Value
            End Set
        End Property

        Public Property [AppID]() As String
            Get
                Return _AppID
            End Get
            Set(ByVal Value As String)
                _AppID = Value
            End Set
        End Property
    End Class
End Namespace
