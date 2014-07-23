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
Imports System.Data.SqlTypes
Imports Microsoft.VisualBasic

Imports Raven
Imports Raven.Web
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven
    Partial Public Class SearchList
        Inherits PageBase

#Region " Control Events "        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean

                fQueryStringExist = ReadQueryString()

                If fQueryStringExist Then
                    prepareScreen()
                End If
            End If
        End Sub

        Private Sub grdSearchList_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdSearchList.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim _drv As DataRowView = CType(e.Item.DataItem, DataRowView)
                    If _drv Is Nothing Then Exit Sub

                    Dim s1 As String = CType(_drv.Row.Item(0), String).Trim

                    Dim a As String = "'"

                    s1 = Replace(s1, "'", " ")
                    s1 = Replace(s1, """", " ")

                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='#00bcf2';this.style.color='#454545';this.focus;this.style.cursor='pointer';")
                    If e.Item.ItemType = ListItemType.Item Then
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#ffffff';this.style.color='#000000'")
                    Else
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#eeeeee';this.style.color='#000000'")
                    End If
                    e.Item.Attributes.Add("onclick", "closeWindowPostBackReturnValue('" + s1 + "', '" + Trim(Request.QueryString("ctrlID")) + "')")
            End Select
        End Sub

        Private Sub btnApplyFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyFilter.Click
            UpdateViewGrid(txtFilterValue.Text.Trim)
        End Sub

        Protected Sub linkApplyFilter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles linkApplyFilter.Click
            btnApplyFilter_Click(Nothing, Nothing)
        End Sub
#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            Dim b As Boolean = (Len(Trim(Request.QueryString("sID"))) > 0) And (Len(Trim(Request.QueryString("ctrlID"))) > 0)
            Return b
        End Function

        Private Sub prepareScreen()
            'txtFilterValue.Text = CType(IIf(Trim(Request.QueryString("fvalue")) = Nothing, "", Trim(Request.QueryString("fvalue"))), String)
            txtFilterValue.Text = String.Empty
            lblSearchCode.Text = Trim(Request.QueryString("sID"))
            _OpenSearch()
            UpdateViewGrid(Trim(Request.QueryString("filterValue").ToString))
        End Sub

        Private Sub UpdateViewGrid(Optional ByVal FilterValue As String = "")
            Dim br As New Common.BussinessRules.SearchList
            If IsNumeric(txtMaxRecord.Text.Trim) Then
                If CInt(txtMaxRecord.Text.Trim) <= 0 Then
                    txtMaxRecord.Text = "50"
                Else
                    txtMaxRecord.Text = CStr(CInt(txtMaxRecord.Text.Trim))
                End If
            Else
                txtMaxRecord.Text = "50"
            End If

            br.SearchID = CStr(Trim(Request.QueryString("sID")))
            br.SearchProcedure = lblSearchProcedure.Text.Trim
            grdSearchList.DataSource = br.SelectSearchList(CInt(txtMaxRecord.Text), FilterValue.Trim).DefaultView
            grdSearchList.DataBind()

            '// display record count
            lblSearchResults.Text = grdSearchList.Items.Count.ToString.Trim

            br = Nothing
        End Sub
#End Region

#Region " Main Function: Open, Save Delete Data "
        Private Sub _OpenSearch()
            If Len(Trim(Request.QueryString("sID"))) = 0 Then Exit Sub

            Dim br As New Common.BussinessRules.SearchList

            With br
                .SearchID = CStr(Trim(Request.QueryString("sID")))

                If (.SelectOne.Rows.Count > 0) Then
                    litSearchList.Text = .SearchCaption.Trim
                    lblSearchProcedure.Text = .SearchProcedure.Trim
                Else
                    litSearchList.Text = String.Empty
                    lblSearchProcedure.Text = String.Empty
                End If
            End With

            br = Nothing
        End Sub
#End Region

    End Class
End Namespace
