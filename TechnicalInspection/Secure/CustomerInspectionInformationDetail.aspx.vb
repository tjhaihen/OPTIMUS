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

Imports System.Data.SqlTypes

Imports Raven.Common

Namespace Raven.Web.Secure

    Public Class CustomerInspectionInformationDetail
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.CustomerInspectionInformation_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                If ReadQueryString() Then
                    _openProject(lblProjectID.Text.Trim)
                    SetDataGridCustomerInspectionInformation()
                End If
                DataBind()
            End If
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            lblProjectID.Text = ProcessNull.GetString(Request.QueryString("pid"))
            Return (lblProjectID.Text.Trim.Length > 0)
        End Function

        Private Sub SetDataGridCustomerInspectionInformation()
            Dim oSOI As New Common.BussinessRules.SummaryOfInspection
            oSOI.projectID = lblProjectID.Text.Trim
            grdSummaryOfInspection.DataSource = oSOI.SelectByProjectID
            grdSummaryOfInspection.DataBind()
            oSOI.Dispose()
            oSOI = Nothing
        End Sub

        Private Sub _openProject(ByVal _projectID As String)
            Dim oPr As New Common.BussinessRules.ProjectHd
            oPr.projectID = _projectID.Trim
            If oPr.SelectOne.Rows.Count > 0 Then
                lblProjectCode.Text = oPr.projectCode.Trim
                lblProjectID.Text = oPr.projectID.Trim
            Else
                lblProjectCode.Text = String.Empty
                lblProjectID.Text = String.Empty
            End If
            oPr.Dispose()
            oPr = Nothing
        End Sub
#End Region


#Region " C,R,U,D "

#End Region

    End Class

End Namespace