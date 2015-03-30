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
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic


Imports System.Data.SqlTypes

Namespace Raven.Web
    Public Class Main
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

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Me.IsPostBack Then
                commonFunction.SetDDL_Table(ddlMySite, "UserSite", MyBase.LoggedOnUserID)
                btnSearchProject.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("SiteProject", txtProjectCode.ClientID, ddlMySite.SelectedValue.Trim))                

                SetToolbarVisibleButton()
                SetDropDownListItems()
                SetRadioButtonListItems()
                SetPanelVisibility("")

                ReadQueryString()

                If chkIsCustomer.Checked = False Then
                    If MyBase.LoggedOnProfileID.Trim <> Common.Methods.GetSettingParameter("INSPProfileID") Then
                        pnlAdministratorScreen.Visible = True
                        pnlInspectorScreen.Visible = False
                        SetDataGrid(pnlAdministratorScreen.ID)
                        commonFunction.Focus(Me, txtWorkRequestListFilter.ClientID)
                    Else
                        pnlAdministratorScreen.Visible = False
                        pnlInspectorScreen.Visible = True
                    End If
                Else
                    pnlAdministratorScreen.Visible = False
                    pnlInspectorScreen.Visible = True
                End If
            End If
        End Sub

        Private Sub ddlMySite_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMySite.SelectedIndexChanged
            btnSearchProject.Attributes.Remove("onClick")
            btnSearchProject.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("SiteProject", txtProjectCode.ClientID, ddlMySite.SelectedValue.Trim))
        End Sub

        Private Sub txtProjectCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtProjectCode.TextChanged            
            txtProjectName.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectCode", txtProjectCode.Text.Trim, "ProjectName")
            txtProjectID.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectCode", txtProjectCode.Text.Trim, "ProjectID")
            ddlMySite.SelectedValue = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "SiteID")
            ddlMySite_SelectedIndexChanged(Nothing, Nothing)
            ProjectBanner.ProjectID = txtProjectID.Text.Trim
            ProjectBanner.GetProjectInformation()
            SetDataGridReportTypeByProject()            
            lblReportTypeName.Text = String.Empty
            lblReportTypePanelID.Text = String.Empty
            SetPanelVisibility(lblReportTypePanelID.Text.Trim)
        End Sub

        Private Sub ddlWorkRequestListFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlWorkRequestListFilter.SelectedIndexChanged
            SetDataGrid(pnlAdministratorScreen.ID)
        End Sub

        Private Sub btnWorkRequestListFilter_Click(sender As Object, e As System.EventArgs) Handles btnWorkRequestListFilter.Click
            SetDataGrid(pnlAdministratorScreen.ID)
            commonFunction.Focus(Me, txtWorkRequestListFilter.ClientID)
        End Sub

        Private Sub grdReportTypeByProject_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdReportTypeByProject.ItemCommand
            Select Case e.CommandName
                Case "SelectReportType"
                    Dim _lblReportTypeID As Label = CType(e.Item.FindControl("_lblReportTypeID"), Label)
                    Dim _lbtnReportTypeID As LinkButton = CType(e.Item.FindControl("_lbtnReportTypeID"), LinkButton)
                    lblReportTypeCode.Text = _lblReportTypeID.ToolTip.Trim
                    lblReportTypeName.Text = _lbtnReportTypeID.Text.Trim
                    lblReportTypePanelID.Text = _lbtnReportTypeID.ToolTip.Trim
                    SetPanelVisibility(lblReportTypePanelID.Text.Trim)
                    PrepareScreen(lblReportTypePanelID.Text.Trim, False)
                    SetDataGrid(lblReportTypePanelID.Text.Trim)
            End Select
        End Sub

        Private Sub grdReportTypeByProject_ItemCreated(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdReportTypeByProject.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='#00bcf2';this.style.color='#ffffff';this.focus;this.style.cursor='pointer';")
                    e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#ffffff';this.style.color='#000000'")
            End Select
        End Sub

        Private Sub grdWorkRequest_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdWorkRequest.ItemCommand
            Select Case e.CommandName
                Case "Process"
                    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    pnlAdministratorScreen.Visible = False
                    pnlInspectorScreen.Visible = True                    
                    txtProjectID.Text = _lblProjectID.Text.Trim
                    txtProjectName.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "ProjectName")
                    txtProjectCode.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "ProjectCode")
                    ddlMySite.SelectedValue = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectID", txtProjectID.Text.Trim, "SiteID")
                    ddlMySite_SelectedIndexChanged(Nothing, Nothing)
                    ProjectBanner.ProjectID = txtProjectID.Text.Trim
                    ProjectBanner.GetProjectInformation()
                    SetDataGridReportTypeByProject()                    
                    lblReportTypeName.Text = String.Empty
                    lblReportTypePanelID.Text = String.Empty
                    SetPanelVisibility(lblReportTypePanelID.Text.Trim)

                Case "Done"
                    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    Dim oBR As New Common.BussinessRules.ProjectHd
                    oBR.projectID = _lblProjectID.Text.Trim
                    If oBR.SelectOne.Rows.Count > 0 Then
                        oBR.isDone = True
                        oBR.doneBy = MyBase.LoggedOnUserID.Trim
                        If oBR.UpdateDone() Then
                            SetDataGrid(pnlAdministratorScreen.ID)
                        End If
                    End If
                    oBR.Dispose()
                    oBR = Nothing
            End Select
        End Sub

        Private Sub grdWorkRequest_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdWorkRequest.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim _drv As DataRowView = CType(e.Item.DataItem, DataRowView)
                    If _drv Is Nothing Then Exit Sub

                    Dim projectID As String = CType(_drv.Row.Item("projectID"), String).Trim

                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='#00bcf2';this.style.color='#454545';this.focus;this.style.cursor='pointer';")
                    If e.Item.ItemType = ListItemType.Item Then
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#ffffff';this.style.color='#000000'")
                    Else
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#eeeeee';this.style.color='#000000'")
                    End If                
            End Select
        End Sub

#Region " Summary of Inspection Report "
        Private Sub SOI_grdSummaryOfInspection_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles SOI_grdSummaryOfInspection.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _SOI_lblSummaryOfInspectionID As Label = CType(e.Item.FindControl("SOI_lblSummaryOfInspectionID"), Label)
                    SOI_txtSummaryOfInspectionID.Text = _SOI_lblSummaryOfInspectionID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)

                Case "Delete"
                    Dim _SOI_lblSummaryOfInspectionID As Label = CType(e.Item.FindControl("SOI_lblSummaryOfInspectionID"), Label)
                    SOI_txtSummaryOfInspectionID.Text = _SOI_lblSummaryOfInspectionID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, SOI_txtSummaryOfInspectionID.Text.Trim)
                    PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                    SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
            End Select
        End Sub

        Private Sub SOI_rbtnlInputMethod_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles SOI_rbtnlInputMethod.SelectedIndexChanged
            SOI_pnlEntry.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Entry")
            SOI_pnlUpload.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Upload")
            SOI_txtSheetName.Text = "Sheet1"
        End Sub
#End Region

#Region " Check List Of Completion Report "
        Private Sub CCR_grdCheckListOfCompletionReport_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles CCR_grdCheckListOfCompletionReport.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _CCR_lblCCRID As Label = CType(e.Item.FindControl("CCR_lblCCRID"), Label)
                    CCR_txtCCRID.Text = _CCR_lblCCRID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Daily Progress Report "
        Private Sub DPR_txtDailyReportHdID_TextChanged(sender As Object, e As System.EventArgs) Handles DPR_txtDailyReportHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
            SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
        End Sub

        Private Sub DPR_grdDailyReportDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DPR_grdDailyReportDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _DPR_lblDailyReportDtID As Label = CType(e.Item.FindControl("DPR_lblDailyReportDtID"), Label)
                    DPR_txtDailyReportDtID.Text = _DPR_lblDailyReportDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
                Case "Delete"
                    Dim _DPR_lblDailyReportDtID As Label = CType(e.Item.FindControl("DPR_lblDailyReportDtID"), Label)
                    _delete(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID, _DPR_lblDailyReportDtID.Text.Trim)
                    PrepareScreen(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID, False, False)
                    SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Daily Inspection Report "
        Private Sub DIR_txtDailyReportHdID_TextChanged(sender As Object, e As System.EventArgs) Handles DIR_txtDailyReportHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID)
            SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID)
        End Sub

        Private Sub DIR_grdDailyReportDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DIR_grdDailyReportDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _DIR_lblDailyReportDtID As Label = CType(e.Item.FindControl("DIR_lblDailyReportDtID"), Label)
                    DIR_txtDailyReportDtID.Text = _DIR_lblDailyReportDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID)
            End Select
        End Sub
#End Region

#Region " Timesheet "
        Private Sub TS_ddlMonth_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TS_ddlMonth.SelectedIndexChanged
            PopulateDateInMonth(repDateInMonthHd, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue))
            SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
        End Sub

        Private Sub TS_ddlYear_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TS_ddlYear.SelectedIndexChanged
            PopulateDateInMonth(repDateInMonthHd, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue))
            SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
        End Sub

        Protected Sub lvwTimeSheet_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs)
            If e.Item.ItemType = ListViewItemType.DataItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim _repDateInMonthDt As Repeater = CType(e.Item.FindControl("repDateInMonthDt"), Repeater)
                Dim _projectResourceID As String = CType(row("projectResourceID"), String)
                PopulateDateInMonth(_repDateInMonthDt, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), _projectResourceID)
            End If
        End Sub

        Protected Sub repDateInMonthHd_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim TS_ddlWorkingTypeAll As DropDownList = CType(e.Item.FindControl("TS_ddlWorkingTypeAll"), DropDownList)
                commonFunction.SetDDL_Table(TS_ddlWorkingTypeAll, "CommonCode", Common.Constants.GroupCode.WorkingType_SCode, True, "")
            End If
        End Sub

        Protected Sub repDateInMonthDt_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim TS_lblDateInMonthDt As Label = CType(e.Item.FindControl("TS_lblDateInMonthDt"), Label)
                Dim TS_lblTimeSheetID As Label = CType(e.Item.FindControl("TS_lblTimeSheetID"), Label)
                Dim TS_lblProjectResourceID As Label = CType(e.Item.FindControl("TS_lblProjectResourceID"), Label)
                Dim TS_ddlWorkingType As DropDownList = CType(e.Item.FindControl("TS_ddlWorkingType"), DropDownList)
                Dim TS_chkIsNew As CheckBox = CType(e.Item.FindControl("TS_chkIsNew"), CheckBox)
                Dim _workingDate As Date = DateSerial(CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), CInt(TS_lblDateInMonthDt.Text.Trim))
                TS_lblProjectResourceID.Text = CType(row("KeyField"), String)
                commonFunction.SetDDL_Table(TS_ddlWorkingType, "CommonCode", Common.Constants.GroupCode.WorkingType_SCode, True, "")

                Dim oBR As New Common.BussinessRules.TimeSheet
                With oBR
                    .projectResourceID = TS_lblProjectResourceID.Text.Trim
                    .workingDate = _workingDate
                    If .SelectByProjectResourceIDWorkingDate.Rows.Count > 0 Then
                        TS_lblTimeSheetID.Text = .timeSheetID
                        commonFunction.SelectListItem(TS_ddlWorkingType, .workingTypeSCode)
                        TS_chkIsNew.Checked = False
                    Else
                        TS_lblTimeSheetID.Text = String.Empty
                        TS_ddlWorkingType.SelectedIndex = 0
                        TS_chkIsNew.Checked = True
                    End If
                End With
                oBR.Dispose()
                oBR = Nothing
            End If
        End Sub
#End Region

#Region " Drill Pipe Inspection Report "
        Private Sub DP_txtSpecificationCode_TextChanged(sender As Object, e As System.EventArgs) Handles DP_txtSpecificationCode.TextChanged
            DP_txtSpecificationID.Text = Common.BussinessRules.ID.GetFieldValue("InspectionSpec", "inspectionSpecCode", DP_txtSpecificationCode.Text.Trim, "inspectionSpecID")
            _openInspectionSpec()
        End Sub

        Private Sub DP_txtDrillPipeReportHdID_TextChanged(sender As Object, e As System.EventArgs) Handles DP_txtDrillPipeReportHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
            SetDataGrid(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
        End Sub

        Private Sub DP_ddlCaptionTemplate_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DP_ddlCaptionTemplate.SelectedIndexChanged
            _openCaptionTemplateDrillPipe()
        End Sub

        Private Sub DP_grdDrillPipeReportDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DP_grdDrillPipeReportDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _DP_lblDrillPipeReportDtID As Label = CType(e.Item.FindControl("DP_lblDrillPipeReportDtID"), Label)
                    DP_txtDrillPipeReportDtID.Text = _DP_lblDrillPipeReportDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
                Case "Delete"
                    Dim _DP_lblDrillPipeReportDtID As Label = CType(e.Item.FindControl("DP_lblDrillPipeReportDtID"), Label)                    
                    _delete(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID, _DP_lblDrillPipeReportDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Inspection Report "
        Private Sub INS_txtInspectionReportHdID_TextChanged(sender As Object, e As System.EventArgs) Handles INS_txtInspectionReportHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.InspectionReport_PanelID)
            SetDataGrid(Common.Constants.ReportTypePanelID.InspectionReport_PanelID)
        End Sub

        Private Sub INS_grdInspectionReportDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles INS_grdInspectionReportDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _INS_lblInspectionReportDtID As Label = CType(e.Item.FindControl("INS_lblInspectionReportDtID"), Label)
                    INS_txtInspectionReportDTID.Text = _INS_lblInspectionReportDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.InspectionReport_PanelID)
                Case "Delete"
                    Dim _INS_lblInspectionReportDtID As Label = CType(e.Item.FindControl("INS_lblInspectionReportDtID"), Label)
                    _delete(Common.Constants.ReportTypePanelID.InspectionReport_PanelID, _INS_lblInspectionReportDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.InspectionReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Service Report "
        Private Sub SR_ddlServiceReportFor_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles SR_ddlServiceReportFor.SelectedIndexChanged
            SetDataGrid(Common.Constants.ReportTypePanelID.ServiceReport_PanelID)
        End Sub

        Private Sub SR_grdServiceReport_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles SR_grdServiceReport.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _SR_lblServiceReportID As Label = CType(e.Item.FindControl("SR_lblServiceReportID"), Label)
                    SR_txtServiceReportID.Text = _SR_lblServiceReportID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.ServiceReport_PanelID)
            End Select
        End Sub
#End Region

#Region " Certificate of Inspection "
        Private Sub COI_grdCertificateInspection_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles COI_grdCertificateInspection.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _COI_lblCertificateOfInspectionID As Label = CType(e.Item.FindControl("COI_lblCertificateOfInspectionID"), Label)
                    COI_txtCertificateInspectionID.Text = _COI_lblCertificateOfInspectionID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)

                Case "Delete"
                    Dim _COI_lblCertificateOfInspectionID As Label = CType(e.Item.FindControl("COI_lblCertificateOfInspectionID"), Label)
                    COI_txtCertificateInspectionID.Text = _COI_lblCertificateOfInspectionID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID, COI_txtCertificateInspectionID.Text.Trim)
                    PrepareScreen(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID, False, True)
                    SetDataGrid(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
            End Select
        End Sub

        Private Sub COI_btnUploadPic1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles COI_btnUploadPic1.Click
            UploadPic_COI(1)
        End Sub

        Private Sub COI_btnUploadPic2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles COI_btnUploadPic2.Click
            UploadPic_COI(2)
        End Sub

        Private Sub COI_btnUploadPic3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles COI_btnUploadPic3.Click
            UploadPic_COI(3)
        End Sub
#End Region

#Region " MPI Report "
        Private Sub MPI_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles MPI_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.MPIReport_PanelID)
        End Sub

        Private Sub MPI_ddlMPIType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles MPI_ddlMPIType.SelectedIndexChanged
            MPI_btnReportNo.Attributes.Remove("onclick")
            MPI_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("MPIHd", MPI_txtReportNo.ClientID, txtProjectCode.Text.Trim + "|" + MPI_ddlMPIType.SelectedValue.Trim))
            PrepareScreen(Common.Constants.ReportTypePanelID.MPIReport_PanelID, False, True)
        End Sub

        Private Sub MPI_btnUploadImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MPI_btnUploadImage.Click
            Dim strFileName As String
            Dim strFileExtension As String
            Dim strFilePath As String
            Dim strFolder As String

            strFolder = Server.MapPath("ImgTmp") + "\"

            strFileName = MPI_ImageFile.PostedFile.FileName
            strFileName = Path.GetFileName(strFileName)
            strFileExtension = Path.GetExtension(strFileName)

            If (Not Directory.Exists(strFolder)) Then
                Directory.CreateDirectory(strFolder)
            End If

            'Save the uploaded file to the server.
            strFilePath = strFolder & MPI_txtMPIDtID.Text.Trim & strFileName
            If File.Exists(strFilePath) Then
                File.Delete(strFilePath)
            Else
                MPI_ImageFile.PostedFile.SaveAs(strFilePath)
            End If

            Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
            Dim b(CInt(fs.Length)) As Byte
            fs.Read(b, 0, CInt(fs.Length))
            fs.Close()

            Dim br As New Common.BussinessRules.MPIDt
            Dim fnotnew As Boolean = False

            With br
                .MPIDtID = MPI_txtMPIDtID.Text.Trim
                fnotnew = (.SelectOne.Rows.Count > 0)
                .MPIHdID = MPI_txtMPIHdID.Text.Trim
                .MPIpic = New SqlBinary(b)
                .MPIpicDescription = MPI_txtPicDescription.Text.Trim
                .MPIpicSize = MPI_ImageFile.PostedFile.ContentLength
                .MPIpicType = strFileExtension.Trim
                .MPIpicGroupSCode = MPI_ddlPicGroup.SelectedValue.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim

                If fnotnew Then
                    .Update()
                Else
                    .Insert()                    
                End If
                MPI_txtMPIDtID.Text = String.Empty
                SetDataGrid(Common.Constants.ReportTypePanelID.MPIReport_PanelID)
            End With
            br.Dispose()
            br = Nothing

            File.Delete(strFilePath)
        End Sub

        Private Sub MPI_repMPIimages_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles MPI_repMPIimages.ItemCommand
            Dim MPI_lblMPIDtIDonRep As Label = CType(e.Item.FindControl("MPI_lblMPIDtIDonRep"), Label)
            Dim oBr As New Common.BussinessRules.MPIDt
            oBr.MPIDtID = MPI_lblMPIDtIDonRep.Text.Trim

            Select Case e.CommandName
                Case "Edit"                    
                    If oBr.SelectOne.Rows.Count > 0 Then
                        MPI_txtMPIDtID.Text = MPI_lblMPIDtIDonRep.Text.Trim
                        MPI_txtPicDescription.Text = oBr.MPIpicDescription.Trim
                        MPI_ddlPicGroup.SelectedValue = oBr.MPIpicGroupSCode.Trim
                    End If

                Case "Delete"                    
                    If oBr.Delete() Then
                        SetDataGrid(Common.Constants.ReportTypePanelID.MPIReport_PanelID)
                    End If
            End Select

            oBr.Dispose()
            oBr = Nothing
        End Sub

        Private Sub MPI_repMPIimages_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles MPI_repMPIimages.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim MPI_img As Image = CType(e.Item.FindControl("MPI_img"), Image)                    
                    Dim MPI_lblMPIDtIDonRep As Label = CType(e.Item.FindControl("MPI_lblMPIDtIDonRep"), Label)

                    MPI_img.ImageUrl = UrlBase + "/secure/GetImage.aspx?imgType=MPI&cn=" + MPI_lblMPIDtIDonRep.Text.Trim                    
            End Select
        End Sub
#End Region

#Region " UT Spot Check Wall Thickness and Hardness Test "
        Private Sub UTSC_grdUTSpotCheckDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles UTSC_grdUTSpotCheckDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _UTSC_lblUTSpotCheckDtID As Label = CType(e.Item.FindControl("UTSC_lblUTSpotCheckDtID"), Label)
                    UTSC_txtUTSpotCheckDtID.Text = _UTSC_lblUTSpotCheckDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)

                Case "Delete"
                    Dim _UTSC_lblUTSpotCheckDtID As Label = CType(e.Item.FindControl("UTSC_lblUTSpotCheckDtID"), Label)
                    UTSC_txtUTSpotCheckDtID.Text = _UTSC_lblUTSpotCheckDtID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID, UTSC_txtUTSpotCheckDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
            End Select
        End Sub

        Private Sub UTSC_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles UTSC_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
        End Sub
#End Region

#Region " UT Spot Area "
        Private Sub UTSA_grdUTSpotAreaDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles UTSA_grdUTSpotAreaDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _UTSA_lblUTSpotAreaDtID As Label = CType(e.Item.FindControl("UTSA_lblUTSpotAreaDtID"), Label)
                    UTSA_txtUTSpotAreaDtID.Text = _UTSA_lblUTSpotAreaDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID)

                Case "Delete"
                    Dim _UTSA_lblUTSpotAreaDtID As Label = CType(e.Item.FindControl("UTSA_lblUTSpotAreaDtID"), Label)
                    UTSA_txtUTSpotAreaDtID.Text = _UTSA_lblUTSpotAreaDtID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID, UTSA_txtUTSpotAreaDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID)
            End Select
        End Sub

        Private Sub UTSA_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles UTSA_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID)
        End Sub
#End Region

#Region " Hardness Test Report "
        Private Sub HT_grdHardnessTestDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles HT_grdHardnessTestDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _HT_lblHardnessTestDtID As Label = CType(e.Item.FindControl("HT_lblHardnessTestDtID"), Label)
                    HT_txtHardnessTestDtID.Text = _HT_lblHardnessTestDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)

                Case "Delete"
                    Dim _HT_lblHardnessTestDtID As Label = CType(e.Item.FindControl("HT_lblHardnessTestDtID"), Label)
                    HT_txtHardnessTestDtID.Text = _HT_lblHardnessTestDtID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.HardnessTest_PanelID, HT_txtHardnessTestDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
            End Select
        End Sub

        Private Sub HT_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles HT_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
        End Sub
#End Region

#Region " Service Acceptance "
        Private Sub SetDataGridProjectDetail(ByVal _VisiblePanelID As String)
            Dim oProjectDt As New Common.BussinessRules.ProjectDt
            oProjectDt.projectID = txtProjectID.Text.Trim

            Select _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.ServiceAcceptance_PanelID
                    SA_grdProjectDt.DataSource = oProjectDt.SelectByProjectID
                    SA_grdProjectDt.DataBind()
                Case Common.Constants.ReportTypePanelID.OfficialReport_PanelID
                    BA_grdBeritaAcaraAkhir.DataSource = oProjectDt.SelectByProjectID
                    BA_grdBeritaAcaraAkhir.DataBind()
            End Select

            oProjectDt.Dispose()
            oProjectDt = Nothing
        End Sub

        Private Sub SA_grdProjectDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles SA_grdProjectDt.ItemCommand
            Select Case e.CommandName
                Case "Print"
                    Dim br As New Common.BussinessRules.MyReport
                    Dim strUserID As String = MyBase.LoggedOnUserID.Trim
                    Dim SA_lblProjectDtID As Label = CType(e.Item.FindControl("SA_lblProjectDtID"), Label)

                    br.ReportCode = "1000000099"
                    br.AddParameters(SA_lblProjectDtID.Text.Trim)
                    br.AddParameters(strUserID)
                    Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
            End Select
        End Sub
#End Region

#Region " Thorough Visual Inspection Report "
        Private Sub TVI_txtReportNo_TextChanged(sender As Object, e As System.EventArgs) Handles TVI_txtReportNo.TextChanged
            _open(Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID)
        End Sub

        Private Sub TVI_ddlTVIType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TVI_ddlTVIType.SelectedIndexChanged
            PrepareScreen(Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID, False, True)
        End Sub
#End Region

#Region " Inspection Tally Report "
        Private Sub IT_grdInspectionTally_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles IT_grdInspectionTally.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _IT_lblInspectionTallyDtID As Label = CType(e.Item.FindControl("IT_lblInspectionTallyDtID"), Label)
                    IT_txtInspectionTallyDtID.Text = _IT_lblInspectionTallyDtID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID)

                Case "Delete"
                    Dim _IT_lblInspectionTallyDtID As Label = CType(e.Item.FindControl("IT_lblInspectionTallyDtID"), Label)
                    IT_txtInspectionTallyDtID.Text = _IT_lblInspectionTallyDtID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID, IT_txtInspectionTallyDtID.Text.Trim)
                    SetDataGrid(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID)
            End Select
        End Sub

        Private Sub IT_txtInspectionTallyHdID_TextChanged(sender As Object, e As System.EventArgs) Handles IT_txtInspectionTallyHdID.TextChanged
            _open(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID)
        End Sub
#End Region

#Region " Official Report (Berita Acara) "
        Private Sub BA_grdBeritaAcara_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles BA_grdBeritaAcara.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _BA_lblOfficialReportID As Label = CType(e.Item.FindControl("BA_lblOfficialReportID"), Label)
                    BA_txtOfficialReportID.Text = _BA_lblOfficialReportID.Text.Trim
                    _open(Common.Constants.ReportTypePanelID.OfficialReport_PanelID)
                    SetDataGrid(Common.Constants.ReportTypePanelID.OfficialReport_PanelID)

                Case "Delete"
                    Dim _BA_lblOfficialReportID As Label = CType(e.Item.FindControl("BA_lblOfficialReportID"), Label)
                    BA_txtOfficialReportID.Text = _BA_lblOfficialReportID.Text.Trim
                    _delete(Common.Constants.ReportTypePanelID.OfficialReport_PanelID, BA_txtOfficialReportID.Text.Trim)
                    PrepareScreen(Common.Constants.ReportTypePanelID.OfficialReport_PanelID, False, True)
                    SetDataGrid(Common.Constants.ReportTypePanelID.OfficialReport_PanelID)

                Case "Print"
                    Dim br As New Common.BussinessRules.MyReport
                    Dim strUserID As String = MyBase.LoggedOnUserID.Trim
                    Dim _BA_lblOfficialReportID As Label = CType(e.Item.FindControl("BA_lblOfficialReportID"), Label)

                    br.ReportCode = "1000000098"
                    br.AddParameters(_BA_lblOfficialReportID.Text.Trim)
                    br.AddParameters(strUserID)
                    Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
            End Select
        End Sub

        Private Sub BA_ddlOfficialReportType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles BA_ddlOfficialReportType.SelectedIndexChanged
            Select Case BA_ddlOfficialReportType.SelectedValue.Trim
                Case Common.Constants.OfficialReportType.OfficialReportStart
                    BA_pnlBeritaAcaraAkhir.Visible = False
                Case Else
                    BA_pnlBeritaAcaraAkhir.Visible = True
                    SetDataGridProjectDetail(Common.Constants.ReportTypePanelID.OfficialReport_PanelID)
            End Select
        End Sub
#End Region

#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub SetToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = True
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = True
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidSave
                    If pnlSummaryOfInspection.Visible Then
                        _update(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If
                    If pnlCheckListCompletionReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID)
                    End If
                    If pnlTimeSheet.Visible Then
                        _update(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
                    End If
                    If pnlDailyProgressReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
                    End If
                    If pnlDailyProgressReportMPI.Visible Then
                        _update(Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID)
                    End If
                    If pnlDrillPipeInspectionReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
                    End If
                    If pnlInspectionReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.InspectionReport_PanelID)
                    End If
                    If pnlServiceReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.ServiceReport_PanelID)
                    End If
                    If pnlCertificateInspection.Visible Then
                        _update(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
                    End If
                    If pnlMPIReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.MPIReport_PanelID)
                    End If
                    If pnlUTSpotCheck.Visible Then
                        _update(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
                    End If
                    If pnlUTSpotArea.Visible Then
                        _update(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID)
                    End If
                    If pnlHardnessTestReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
                    End If
                    If pnlThoroughVisualInspectionReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID)
                    End If
                    If pnlInspectionTallyReport.Visible Then
                        _update(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID)
                    End If
                    If pnlBeritaAcara.Visible Then
                        _update(Common.Constants.ReportTypePanelID.OfficialReport_PanelID)
                    End If

                Case CSSToolbarItem.tidNew
                    If pnlSummaryOfInspection.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If
                    If pnlCheckListCompletionReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID)
                    End If
                    If pnlTimeSheet.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.TimeSheet_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)
                    End If
                    If pnlDailyProgressReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)
                    End If
                    If pnlDailyProgressReportMPI.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID)
                    End If
                    If pnlDrillPipeInspectionReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)
                    End If
                    If pnlInspectionReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.InspectionReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.InspectionReport_PanelID)
                    End If
                    If pnlServiceReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.ServiceReport_PanelID)
                    End If
                    If pnlCertificateInspection.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID)
                    End If
                    If pnlMPIReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.MPIReport_PanelID, False, True)                        
                    End If
                    If pnlUTSpotCheck.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)
                    End If
                    If pnlUTSpotArea.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID)
                    End If
                    If pnlHardnessTestReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.HardnessTest_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)
                    End If
                    If pnlThoroughVisualInspectionReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID, False, True)
                    End If
                    If pnlInspectionTallyReport.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID)
                    End If
                    If pnlBeritaAcara.Visible Then
                        PrepareScreen(Common.Constants.ReportTypePanelID.OfficialReport_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.OfficialReport_PanelID)
                    End If

                Case CSSToolbarItem.tidPrint
                    Dim br As New Common.BussinessRules.MyReport
                    Dim strUserID As String = MyBase.LoggedOnUserID.Trim

                    If pnlSummaryOfInspection.Visible Then
                        br.ReportCode = "1000000071"
                        br.AddParameters(txtProjectID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlCheckListCompletionReport.Visible Then
                        br.ReportCode = "1000000001"
                        br.AddParameters(txtProjectID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlTimeSheet.Visible Then
                        br.ReportCode = "1000000002"
                        br.AddParameters(txtProjectID.Text.Trim)
                        br.AddParameters(TS_ddlMonth.SelectedValue.Trim)
                        br.AddParameters(TS_ddlYear.SelectedValue.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlDailyProgressReport.Visible Then
                        br.ReportCode = "1000000003"
                        br.AddParameters(DPR_txtDailyReportHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlDailyProgressReportMPI.Visible Then
                        br.ReportCode = "1000000004"
                        br.AddParameters(DIR_txtDailyReportHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlDrillPipeInspectionReport.Visible Then
                        br.ReportCode = "1000000005"
                        br.AddParameters(DP_txtDrillPipeReportHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlInspectionReport.Visible Then
                        Select Case lblReportTypeCode.Text.Trim
                            Case Common.Constants.ReportTypeCode.SlickDrillCollarInspectionReport
                                br.ReportCode = "1000000030"
                            Case Common.Constants.ReportTypeCode.SpiralDrillCollarInspectionReport
                                br.ReportCode = "1000000031"
                            Case Common.Constants.ReportTypeCode.HeavyWeightDrillPipeInspectionReport
                                br.ReportCode = "1000000032"
                            Case Common.Constants.ReportTypeCode.RotaryShoulderConnectionReport
                                br.ReportCode = "1000000033"
                        End Select
                        br.AddParameters(INS_txtInspectionReportHdID.Text.Trim)
                        br.AddParameters(INS_ddlInspectionReportType.SelectedValue.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlServiceReport.Visible Then
                        br.ReportCode = "1000000025"
                        br.AddParameters(SR_txtServiceReportID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlCertificateInspection.Visible Then
                        br.ReportCode = "1000000100"
                        br.AddParameters(COI_txtCertificateInspectionID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlMPIReport.Visible Then
                        br.ReportCode = "1000000008"
                        br.AddParameters(MPI_txtMPIHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlUTSpotCheck.Visible Then
                        br.ReportCode = "1000000009"
                        br.AddParameters(UTSC_txtUTSpotCheckHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlUTSpotArea.Visible Then
                        br.ReportCode = "1000000015"
                        br.AddParameters(UTSA_txtUTSpotCheckHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlHardnessTestReport.Visible Then
                        br.ReportCode = "1000000011"
                        br.AddParameters(HT_txtHardnessTestHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlThoroughVisualInspectionReport.Visible Then
                        br.ReportCode = "1000000013"
                        br.AddParameters(TVI_txtTVIHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlInspectionTallyReport.Visible Then
                        br.ReportCode = "1000000017"
                        br.AddParameters(IT_txtInspectionTallyHdID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    If pnlBeritaAcara.Visible Then
                        br.ReportCode = "1000000098"
                        br.AddParameters(BA_txtOfficialReportID.Text.Trim)
                        br.AddParameters(strUserID)
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
                    End If

                    br.Dispose()
                    br = Nothing

                Case CSSToolbarItem.tidApprove
                    If pnlSummaryOfInspection.Visible Then
                        UpdateApproval(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, True)
                        PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If

                Case CSSToolbarItem.tidVoid
                    If pnlSummaryOfInspection.Visible Then
                        UpdateApproval(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False)
                        PrepareScreen(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID, False, True)
                        SetDataGrid(Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID)
                    End If
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean
            Dim b As Boolean = False
            chkIsCustomer.Checked = False
            ddlMySite.Enabled = True
            btnSearchProject.Enabled = True

            If Not Request.QueryString("isc") = Nothing Then
                If Request.QueryString("isc").Trim = "True" Then
                    chkIsCustomer.Checked = True
                    ddlMySite.Enabled = False
                    btnSearchProject.Enabled = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidNew) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = False
                End If
            End If

            If Not Request.QueryString("pid") = Nothing Then
                txtProjectCode.Text = Request.QueryString("pid").Trim
                txtProjectCode_TextChanged(Nothing, Nothing)
            End If

            Return b
        End Function

        Private Sub SetDataGridReportTypeByProject()
            Dim oPRT As New Common.BussinessRules.ProjectReportType
            oPRT.ProjectID = txtProjectID.Text.Trim
            grdReportTypeByProject.DataSource = oPRT.GetReportTypeByProjectID
            grdReportTypeByProject.DataBind()
            oPRT.Dispose()
            oPRT = Nothing
        End Sub

        Private Sub SetDataGrid(ByVal _VisiblePanelID As String)
            Select Case _VisiblePanelID
                Case pnlAdministratorScreen.ID
                    Dim oBR As New Common.BussinessRules.ProjectHd
                    grdWorkRequest.DataSource = oBR.GetWorkRequestListByStatus(ddlWorkRequestListFilter.SelectedValue.Trim, _
                        txtWorkRequestListFilter.Text.Trim, _
                        CInt(IIf(IsNumeric(txtWorkRequestListDisplayFilter.Text.Trim) = True, CInt(txtWorkRequestListDisplayFilter.Text.Trim), 50).ToString.Trim))
                    grdWorkRequest.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    oBR.projectID = txtProjectID.Text.Trim
                    SOI_grdSummaryOfInspection.DataSource = oBR.SelectByProjectID
                    SOI_grdSummaryOfInspection.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                    _refreshStatus(_VisiblePanelID)
                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    Dim oBR As New Common.BussinessRules.CheckListOfCompletionReport
                    oBR.projectID = txtProjectID.Text.Trim
                    CCR_grdCheckListOfCompletionReport.DataSource = oBR.SelectByProjectID
                    CCR_grdCheckListOfCompletionReport.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.TimeSheet_PanelID
                    Dim oBR As New Common.BussinessRules.ProjectResource
                    oBR.ProjectID = txtProjectID.Text.Trim
                    lvwTimeSheet.DataSource = oBR.GetResourceByProjectID
                    lvwTimeSheet.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    Dim oBR As New Common.BussinessRules.DailyReportDt
                    oBR.dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                    DPR_grdDailyReportDt.DataSource = oBR.SelectByDailyReportHdID
                    DPR_grdDailyReportDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID
                    Dim oBR As New Common.BussinessRules.DailyReportDt
                    oBR.dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                    DIR_grdDailyReportDt.DataSource = oBR.SelectByDailyReportHdID
                    DIR_grdDailyReportDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.InspectionReport_PanelID
                    Dim oBR As New Common.BussinessRules.InspectionReportDt
                    oBR.inspectionReportHdID = INS_txtInspectionReportHdID.Text.Trim
                    INS_grdInspectionReportDt.DataSource = oBR.SelectByHdID
                    INS_grdInspectionReportDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.MPIReport_PanelID
                    Dim oBR As New Common.BussinessRules.MPIDt
                    oBR.MPIHdID = MPI_txtMPIHdID.Text.Trim
                    MPI_repMPIimages.DataSource = oBR.SelectByMPIHdID
                    MPI_repMPIimages.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    Dim oBR As New Common.BussinessRules.DrillPipeReportDt
                    oBR.drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                    DP_grdDrillPipeReportDt.DataSource = oBR.SelectByDrillPipeReportHdID
                    DP_grdDrillPipeReportDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    Dim oBR As New Common.BussinessRules.ServiceReport
                    oBR.projectID = txtProjectID.Text.Trim
                    oBR.serviceReportForSCode = SR_ddlServiceReportFor.SelectedValue.Trim
                    SR_grdServiceReport.DataSource = oBR.SelectByProjectIDForSCode
                    SR_grdServiceReport.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.CertificateInspection
                    oBR.projectID = txtProjectID.Text.Trim
                    COI_grdCertificateInspection.DataSource = oBR.SelectByProjectID
                    COI_grdCertificateInspection.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    Dim oBR As New Common.BussinessRules.UTSpotCheckDt
                    oBR.UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                    UTSC_grdUTSpotCheckDt.DataSource = oBR.SelectByUTSpotCheckHdID
                    UTSC_grdUTSpotCheckDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.UTSpotArea_PanelID
                    Dim oBR As New Common.BussinessRules.UTSpotAreaDt
                    oBR.UTSpotCheckHdID = UTSA_txtUTSpotCheckHdID.Text.Trim
                    UTSA_grdUTSpotAreaDt.DataSource = oBR.SelectByHdID
                    UTSA_grdUTSpotAreaDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    Dim oBR As New Common.BussinessRules.HardnessTestDt
                    oBR.hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                    HT_grdHardnessTestDt.DataSource = oBR.SelectByHardnessTestHdID
                    HT_grdHardnessTestDt.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID
                    Dim oBR As New Common.BussinessRules.InspectionTallyReportDt
                    oBR.InspectionTallyHdID = IT_txtInspectionTallyHdID.Text.Trim
                    IT_grdInspectionTally.DataSource = oBR.SelectByHdID
                    IT_grdInspectionTally.DataBind()
                    oBR.Dispose()
                    oBR = Nothing
                Case Common.Constants.ReportTypePanelID.OfficialReport_PanelID
                    Dim oBR As New Common.BussinessRules.OfficialReport
                    oBR.projectID = txtProjectID.Text.Trim
                    BA_grdBeritaAcara.DataSource = oBR.SelectByProjectID
                    BA_grdBeritaAcara.DataBind()
                    oBR.Dispose()
                    oBR = Nothing

                    If BA_pnlBeritaAcaraAkhir.Visible Then
                        Dim oPDT As New Common.BussinessRules.ProjectDt
                        oPDT.projectID = txtProjectID.Text.Trim
                        BA_grdBeritaAcaraAkhir.DataSource = oPDT.SelectByProjectID
                        BA_grdBeritaAcaraAkhir.DataBind()
                        oPDT.Dispose()
                        oPDT = Nothing
                    End If
            End Select
        End Sub

        Private Function GetReportTypeByProductID(ByVal _productID As String) As DataTable
            Dim dt As New DataTable
            Dim br As New Common.BussinessRules.ProductReportType
            br.ProductID = _productID.Trim
            dt = br.SelectReportTypeByProductIDWithNoProductID(txtProjectID.Text.Trim)
            br.Dispose()
            br = Nothing
            Return dt
        End Function

        Private Sub GetReportTypeName(ByVal _ReportTypeID As String)
            lblReportTypeName.Text = Common.BussinessRules.ID.GetFieldValue("ReportType", "ReportTypeID", _ReportTypeID.Trim, "ReportTypeName")
        End Sub

        Private Sub SetPanelVisibility(ByVal _VisiblePanelID As String)
            pnlCheckListCompletionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlCheckListCompletionReport.ID, True, False))
            pnlServiceAcceptance.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlServiceAcceptance.ID, True, False))
            pnlSummaryOfInspection.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlSummaryOfInspection.ID, True, False))

            pnlTimeSheet.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlTimeSheet.ID, True, False))
            pnlDailyProgressReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlDailyProgressReport.ID, True, False))
            pnlDailyProgressReportMPI.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlDailyProgressReportMPI.ID, True, False))

            pnlServiceReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlServiceReport.ID, True, False))
            pnlMPIReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlMPIReport.ID, True, False))
            pnlDrillPipeInspectionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlDrillPipeInspectionReport.ID, True, False))

            pnlThoroughVisualInspectionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlThoroughVisualInspectionReport.ID, True, False))
            pnlInspectionTallyReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlInspectionTallyReport.ID, True, False))
            pnlUTSpotCheck.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlUTSpotCheck.ID, True, False))

            pnlInspectionReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlInspectionReport.ID, True, False))
            pnlUTSpotArea.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlUTSpotArea.ID, True, False))
            pnlCertificateInspection.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlCertificateInspection.ID, True, False))

            pnlHardnessTestReport.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlHardnessTestReport.ID, True, False))
            pnlBeritaAcara.Visible = CBool(IIf(_VisiblePanelID.Trim = pnlBeritaAcara.ID, True, False))
        End Sub

        Private Sub SetDropDownListItems()
            commonFunction.SetDDL_Table(CCR_ddlTypeOfReport, "CommonCode", Common.Constants.GroupCode.TypeOfReport_SCode)
            commonFunction.SetDDL_Table(DP_ddlCaptionTemplate, "CaptionTemplate", String.Empty)
            commonFunction.SetDDL_Table(DPR_ddlWeatherCondition, "CommonCode", Common.Constants.GroupCode.Weather_SCode)
            commonFunction.SetDDL_Table(DIR_ddlWeatherCondition, "CommonCode", Common.Constants.GroupCode.Weather_SCode)
            commonFunction.SetDDL_Table(SR_ddlServiceReportFor, "CommonCode", Common.Constants.GroupCode.ServiceReportFor_SCode)
            commonFunction.SetDDL_Table(DP_ddlRemarks, "CommonCode", Common.Constants.GroupCode.DrillPipeRemarks_SCode)
            commonFunction.SetDDL_Table(MPI_ddlMPIType, "CommonCode", Common.Constants.GroupCode.MPIType_SCode)
            commonFunction.SetDDL_Table(MPI_ddlPicGroup, "CommonCode", Common.Constants.GroupCode.MPIPicGroup_SCode)
            commonFunction.SetDDL_Table(HT_ddlLocation, "CommonCode", Common.Constants.GroupCode.HardnessTestLocation_SCode)
            commonFunction.SetDDL_Table(UTSC_ddlUTSpotType, "CommonCode", Common.Constants.GroupCode.UTSpotType_SCode)
            commonFunction.SetDDL_Table(UTSA_ddlUTSpotType, "CommonCode", Common.Constants.GroupCode.UTSpotAreaType_SCode)
            commonFunction.SetDDL_Table(INS_ddlInspectionReportType, "CommonCode", Common.Constants.GroupCode.InspectionReportType_SCode)
            commonFunction.SetDDL_Table(TVI_ddlTVIType, "CommonCode", Common.Constants.GroupCode.ThoroughVisualType_SCode)
            commonFunction.SetDDL_Table(IT_ddlTallyType, "CommonCode", Common.Constants.GroupCode.InspectionTallyType_SCode)
            commonFunction.SetDDL_Table(BA_ddlOfficialReportType, "CommonCode", Common.Constants.GroupCode.OfficialReportType_SCode)
        End Sub

        Private Sub SetRadioButtonListItems()
            commonFunction.SetRBTNL_Table(MPI_rbtnlYoke, "CommonCode", Common.Constants.GroupCode.MPIYoke_SCode)
            commonFunction.SetRBTNL_Table(MPI_rbtnlCoil, "CommonCode", Common.Constants.GroupCode.MPICoil_SCode)
            commonFunction.SetRBTNL_Table(MPI_rbtnlFluorescent, "CommonCode", Common.Constants.GroupCode.MPIFluorescent_SCode)
            commonFunction.SetRBTNL_Table(MPI_rbtnlContrastBW, "CommonCode", Common.Constants.GroupCode.MPIContrastBW_SCode)
        End Sub

        Private Sub PrepareScreen(ByVal _VisiblePanelID As String, ByVal _isAfterInsert As Boolean, Optional ByVal _isNew As Boolean = True)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    If _isAfterInsert Then
                        If IsNumeric(SOI_txtSequenceNo.Text.Trim) Then
                            SOI_txtSequenceNo.Text = CStr(CDec(SOI_txtSequenceNo.Text.Trim) + 1)
                        Else
                            SOI_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, SOI_txtDescOfEquip.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("SummaryOfInspection", "SequenceNo", _
                                                    "projectID", txtProjectID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            SOI_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            SOI_txtSequenceNo.Text = strMaxSequenceNo
                        End If

                        If Len(SOI_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, SOI_txtDescOfEquip.ClientID)
                        Else
                            commonFunction.Focus(Me, SOI_txtSequenceNo.ClientID)
                        End If
                    End If
                    SOI_txtSummaryOfInspectionID.Text = String.Empty
                    SOI_pnlEntry.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Entry")
                    SOI_pnlUpload.Visible = (SOI_rbtnlInputMethod.SelectedValue.Trim = "Upload")
                    SOI_txtSheetName.Text = "Sheet1"

                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    If _isAfterInsert Then
                        If IsNumeric(CCR_txtSequenceNo.Text.Trim) Then
                            CCR_txtSequenceNo.Text = CStr(CDec(CCR_txtSequenceNo.Text.Trim) + 1)
                        Else
                            CCR_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, CCR_txtDescription.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("CheckListOfCompletionReport", "SequenceNo", _
                                                    "ProjectID", txtProjectID.Text.Trim)
                        CCR_txtSequenceNo.Text = IIf(IsNumeric(strMaxSequenceNo) = True, CInt(strMaxSequenceNo) + 1, strMaxSequenceNo).ToString.Trim
                        CCR_txtPreparedByName.Text = String.Empty
                        If Len(CCR_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, CCR_txtDescription.ClientID)
                        Else
                            commonFunction.Focus(Me, CCR_txtSequenceNo.ClientID)
                        End If
                    End If
                    CCR_txtCCRID.Text = String.Empty
                    CCR_txtDescription.Text = String.Empty
                    CCR_ddlTypeOfReport.SelectedIndex = 0
                    CCR_txtReportNo.Text = String.Empty
                    CCR_txtRemarks.Text = String.Empty

                Case Common.Constants.ReportTypePanelID.TimeSheet_PanelID
                    Dim oBR As New Common.BussinessRules.ProjectHd
                    oBR.projectID = txtProjectID.Text.Trim
                    oBR.SelectOne()
                    commonFunction.SetDDL_Table(TS_ddlMonth, "MonthInYear", String.Empty)
                    commonFunction.SetDDL_YearPeriod(TS_ddlYear, Year(oBR.startDate), Year(Date.Today))
                    TS_ddlMonth.SelectedValue = Month(Date.Today).ToString.Trim
                    TS_ddlYear.SelectedValue = Year(Date.Today).ToString.Trim
                    PopulateDateInMonth(repDateInMonthHd, CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue))
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    DPR_btnSearchDailyReportHd.Attributes.Remove("onclick")
                    DPR_btnSearchDailyReportHd.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("DailyReportHd", DPR_txtDailyReportHdID.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        DPR_txtDailyReportHdID.Text = String.Empty
                        DPR_calReportDate.selectedDate = Date.Today
                        DPR_txtMaterialDetail.Text = String.Empty
                    End If

                    If _isAfterInsert Then
                        If IsNumeric(DPR_txtSequenceNo.Text.Trim) Then
                            DPR_txtSequenceNo.Text = CStr(CDec(DPR_txtSequenceNo.Text.Trim) + 1)
                        Else
                            DPR_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, DPR_ddlWeatherCondition.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("DailyReportDt", "SequenceNo", _
                                                    "DailyReportHdID", DPR_txtDailyReportHdID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            DPR_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            DPR_txtSequenceNo.Text = strMaxSequenceNo
                        End If

                        If Len(DPR_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, DPR_ddlWeatherCondition.ClientID)
                        Else
                            commonFunction.Focus(Me, DPR_txtSequenceNo.ClientID)
                        End If
                    End If

                    DPR_txtDailyReportDtID.Text = String.Empty
                    DPR_txtDescription.Text = String.Empty
                    DPR_ddlWeatherCondition.SelectedIndex = 0
                    DPR_txtQtyCurrent.Text = "0"
                    DPR_txtQtyPrevious.Text = "0"
                    DPR_txtQtyCumulative.Text = "0"
                    DPR_txtUOMCurrent.Text = Common.Constants.UOM.DailyProgressReportDefaultUOM.Trim
                    DPR_txtUOMPrevious.Text = Common.Constants.UOM.DailyProgressReportDefaultUOM.Trim
                    DPR_txtUOMCumulative.Text = Common.Constants.UOM.DailyProgressReportDefaultUOM.Trim                    

                Case Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID
                    DIR_btnSearchDailyReportHd.Attributes.Remove("onclick")
                    DIR_btnSearchDailyReportHd.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("DailyReportHd", DIR_txtDailyReportHdID.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        DIR_txtDailyReportHdID.Text = String.Empty
                        DIR_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        If IsNumeric(DIR_txtSequenceNo.Text.Trim) Then
                            DIR_txtSequenceNo.Text = CStr(CDec(DIR_txtSequenceNo.Text.Trim) + 1)
                        Else
                            DIR_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, DIR_ddlWeatherCondition.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("DailyReportDt", "SequenceNo", _
                                                    "DailyReportHdID", DIR_txtDailyReportHdID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            DIR_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            DIR_txtSequenceNo.Text = strMaxSequenceNo
                        End If

                        If Len(DIR_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, DIR_ddlWeatherCondition.ClientID)
                        Else
                            commonFunction.Focus(Me, DIR_txtSequenceNo.ClientID)
                        End If
                    End If

                    DIR_txtDailyReportDtID.Text = String.Empty
                    DIR_txtDescription.Text = String.Empty
                    DIR_ddlWeatherCondition.SelectedIndex = 0
                    DIR_txtQty.Text = "0"
                    DIR_txtResult.Text = String.Empty

                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    DP_btnSearchDrillPipeReport.Attributes.Remove("onclick")
                    DP_btnSearchDrillPipeReport.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("DPRHd", DP_txtDrillPipeReportHdID.ClientID, txtProjectCode.Text.Trim))
                    DP_btnSearchSpecification.Attributes.Remove("onclick")
                    DP_btnSearchSpecification.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("InspectionSpec", DP_txtSpecificationCode.ClientID))

                    If _isNew = True Then
                        DP_txtDrillPipeReportHdID.Text = String.Empty
                        DP_txtReportNo.Text = String.Empty
                        DP_calReportDate.selectedDate = Date.Today
                        DP_txtSize.Text = String.Empty
                        DP_txtWeight.Text = String.Empty
                        DP_txtGrade.Text = String.Empty
                        DP_txtConnection.Text = String.Empty
                        DP_txtRange.Text = String.Empty
                        DP_txtNominalWT.Text = String.Empty
                        DP_txtSpecificationID.Text = String.Empty
                        DP_txtSpecificationName.Text = String.Empty
                        DP_Premium_txtMinOD.Text = String.Empty
                        DP_Premium_txtMaxID.Text = String.Empty
                        DP_Premium_txtMinWall.Text = String.Empty
                        DP_Premium_txtMinShoulder.Text = String.Empty
                        DP_Premium_txtMinSeal.Text = String.Empty
                        DP_Class2_txtMinOD.Text = String.Empty
                        DP_Class2_txtMaxID.Text = String.Empty
                        DP_Class2_txtMinWall.Text = String.Empty
                        DP_Class2_txtMinShoulder.Text = String.Empty
                        DP_Class2_txtMinSeal.Text = String.Empty
                        DP_Class2_txtMinTongSpacePB.Text = String.Empty
                        DP_Class2_txtMaxQC.Text = String.Empty
                        DP_Class2_txtBevelDia.Text = String.Empty
                        DP_Class2_txtMinQCDepth.Text = String.Empty
                        DP_Class2_txtMaxLengthPin.Text = String.Empty
                        DP_Class2_txtMaxPinNeck.Text = String.Empty
                    End If

                    If _isAfterInsert Then
                        If IsNumeric(DP_txtSequenceNo.Text.Trim) Then
                            DP_txtSequenceNo.Text = CStr(CDec(DP_txtSequenceNo.Text.Trim) + 1)
                        Else
                            DP_txtSequenceNo.Text = String.Empty
                        End If
                        commonFunction.Focus(Me, DP_txtSerialNo.ClientID)
                    Else
                        Dim strMaxSequenceNo As String = String.Empty
                        strMaxSequenceNo = Common.BussinessRules.ID.GetMaxSequenceNo("DrillPipeReportDt", "SequenceNo", _
                                                    "DrillPipeReportHdID", DP_txtDrillPipeReportHdID.Text.Trim)
                        If IsNumeric(strMaxSequenceNo) = True Then
                            DP_txtSequenceNo.Text = CStr(CInt(strMaxSequenceNo) + 1)
                        Else
                            DP_txtSequenceNo.Text = strMaxSequenceNo
                        End If
                        If Len(DP_txtSequenceNo.Text.Trim) > 0 Then
                            commonFunction.Focus(Me, DP_txtSerialNo.ClientID)
                        Else
                            commonFunction.Focus(Me, DP_txtSequenceNo.ClientID)
                        End If
                    End If

                    DP_txtDrillPipeReportDtID.Text = String.Empty
                    DP_txtSerialNo.Text = String.Empty

                    _openCaptionTemplateDrillPipe()

                    If _isNew = True Then
                        DP_txtBod001Value.Text = String.Empty
                        DP_txtBod002Value.Text = String.Empty
                        DP_txtBod003Value.Text = String.Empty
                        DP_txtBod004Value.Text = String.Empty
                        DP_txtBod005Value.Text = String.Empty
                        DP_txtBod006Value.Text = String.Empty
                        DP_txtBod007Value.Text = String.Empty
                        DP_txtBod008Value.Text = String.Empty
                        DP_txtBod009Value.Text = String.Empty
                        DP_txtPin001Value.Text = String.Empty
                        DP_txtPin002Value.Text = String.Empty
                        DP_txtPin003Value.Text = String.Empty
                        DP_txtPin004Value.Text = String.Empty
                        DP_txtPin005Value.Text = String.Empty
                        DP_txtPin006Value.Text = String.Empty
                        DP_txtPin007Value.Text = String.Empty
                        DP_txtPin008Value.Text = String.Empty
                        DP_txtPin009Value.Text = String.Empty
                        DP_txtPin010Value.Text = String.Empty
                        DP_txtPin011Value.Text = String.Empty
                        DP_txtBox001Value.Text = String.Empty
                        DP_txtBox002Value.Text = String.Empty
                        DP_txtBox003Value.Text = String.Empty
                        DP_txtBox004Value.Text = String.Empty
                        DP_txtBox005Value.Text = String.Empty
                        DP_txtBox006Value.Text = String.Empty
                        DP_txtBox007Value.Text = String.Empty
                        DP_txtBox008Value.Text = String.Empty
                        DP_txtBox009Value.Text = String.Empty
                        DP_txtBox010Value.Text = String.Empty
                        DP_txtBox011Value.Text = String.Empty
                        DP_txtRemarks.Text = String.Empty
                        DP_chkIsPinHB.Checked = False
                        DP_chkIsBoxHB.Checked = False
                        commonFunction.Focus(Me, DP_txtReportNo.ClientID)
                    End If

                Case Common.Constants.ReportTypePanelID.InspectionReport_PanelID
                    If _isNew = True Then
                        INS_txtInspectionReportHdID.Text = String.Empty
                        INS_txtReportNo.Text = String.Empty
                        INS_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        commonFunction.Focus(Me, INS_txtDescription.ClientID)                    
                    End If

                    INS_txtInspectionReportDTID.Text = String.Empty
                    INS_txtSerialNo.Text = String.Empty

                    If _isNew = True Then
                        INS_txtDescription.Text = String.Empty
                        INS_txtSerialNo.Text = String.Empty
                        INS_txtTotalLength.Text = String.Empty
                        INS_txtIDDescription.Text = String.Empty
                        INS_txtConnectionSizePin.Text = String.Empty
                        INS_txtConnectionODPin.Text = String.Empty
                        INS_txtConnectionSizeBox.Text = String.Empty
                        INS_txtConnectionODBox.Text = String.Empty
                        INS_txtElevatorGrooveDiaPin.Text = String.Empty
                        INS_txtElevatorGrooveDepthPin.Text = String.Empty
                        INS_txtElevatorGrooveDiaBox.Text = String.Empty
                        INS_txtElevatorGrooveDepthBox.Text = String.Empty
                        INS_txtBBackRGrooveDiaPin.Text = String.Empty
                        INS_txtBBackRGrooveLengthPin.Text = String.Empty
                        INS_txtBBackRGrooveDiaBox.Text = String.Empty
                        INS_txtBBackRGrooveLengthBox.Text = String.Empty
                        INS_txtBevelDiameterPin.Text = String.Empty
                        INS_txtBevelDiameterBox.Text = String.Empty
                        INS_txtThreadLengthPin.Text = String.Empty
                        INS_txtThreadLengthBox.Text = String.Empty
                        INS_txtCounterBoreDiaPin.Text = String.Empty
                        INS_txtCounterBoreDepthPin.Text = String.Empty
                        INS_txtCounterBoreDiaBox.Text = String.Empty
                        INS_txtCounterBoreDepthBox.Text = String.Empty
                        INS_txtCenterPadDiaPin.Text = String.Empty
                        INS_txtCenterPadDepthPin.Text = String.Empty
                        INS_txtCenterPadDiaBox.Text = String.Empty
                        INS_txtCenterPadDepthBox.Text = String.Empty
                        INS_txtTongSpacePin.Text = String.Empty
                        INS_txtTongSpaceBox.Text = String.Empty
                        INS_txtConditionPin.Text = String.Empty
                        INS_txtConditionBox.Text = String.Empty
                        INS_txtBSR.Text = String.Empty
                        INS_txtRemarksPin.Text = String.Empty
                        INS_txtRemarksBox.Text = String.Empty
                        INS_txtHBPin.Text = String.Empty
                        INS_txtHBBox.Text = String.Empty
                        INS_txtHBCenterPad.Text = String.Empty
                        commonFunction.Focus(Me, INS_txtReportNo.ClientID)
                    End If
                    commonFunction.SetDDL_Table(INS_ddlInspectionReportType, "CommonCode", Common.Constants.GroupCode.InspectionReportType_SCode)

                    Select Case lblReportTypeCode.Text.Trim
                        Case Common.Constants.ReportTypeCode.SpiralDrillCollarInspectionReport
                            INS_pnlElevatorGroove.Visible = True
                            INS_pnlCenterPad.Visible = False
                            INS_pnlHBCenterPad.Visible = False

                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.HWDP).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.RotaryShoulder).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.DrillCollar).Enabled = False
                            INS_ddlInspectionReportType.SelectedValue = Common.Constants.ReportTypeCodeInspectionReport.SpiralDrillCollar
                        Case Common.Constants.ReportTypeCode.SlickDrillCollarInspectionReport
                            INS_pnlElevatorGroove.Visible = False
                            INS_pnlCenterPad.Visible = False
                            INS_pnlHBCenterPad.Visible = False

                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.HWDP).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.RotaryShoulder).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.SpiralDrillCollar).Enabled = False
                            INS_ddlInspectionReportType.SelectedValue = Common.Constants.ReportTypeCodeInspectionReport.DrillCollar
                        Case Common.Constants.ReportTypeCode.RotaryShoulderConnectionReport
                            INS_pnlElevatorGroove.Visible = False
                            INS_pnlCenterPad.Visible = True
                            INS_pnlHBCenterPad.Visible = True

                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.HWDP).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.DrillCollar).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.SpiralDrillCollar).Enabled = False
                            INS_ddlInspectionReportType.SelectedValue = Common.Constants.ReportTypeCodeInspectionReport.RotaryShoulder
                        Case Else
                            INS_pnlElevatorGroove.Visible = False
                            INS_pnlCenterPad.Visible = True
                            INS_pnlHBCenterPad.Visible = True

                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.RotaryShoulder).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.DrillCollar).Enabled = False
                            INS_ddlInspectionReportType.Items.FindByValue(Common.Constants.ReportTypeCodeInspectionReport.SpiralDrillCollar).Enabled = False
                            INS_ddlInspectionReportType.SelectedValue = Common.Constants.ReportTypeCodeInspectionReport.HWDP
                    End Select
                    INS_btnSearchInspectionReport.Attributes.Remove("onclick")
                    INS_btnSearchInspectionReport.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("INSHd", INS_txtInspectionReportHdID.ClientID, txtProjectCode.Text.Trim + "|" + INS_ddlInspectionReportType.SelectedValue.Trim))

                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    SR_txtServiceReportID.Text = String.Empty
                    SR_ddlServiceReportFor.SelectedIndex = 0
                    SR_calServiceReportDate.selectedDate = Date.Today
                    SR_txtTypeOfInspection.Text = String.Empty
                    SR_txtManufacturer.Text = String.Empty
                    SR_txtTypeOfPipe.Text = String.Empty
                    SR_txtPipeOD.Text = String.Empty
                    SR_txtPipeGrade.Text = String.Empty
                    SR_txtPipeWeight.Text = String.Empty
                    SR_txtThreadConnection.Text = String.Empty
                    SR_txtRange.Text = String.Empty
                    SR_txtTotalInspected.Text = String.Empty
                    SR_txtTotalAccepted.Text = String.Empty
                    SR_txtMaterialDescription.Text = String.Empty
                    SR_txtResult.Text = String.Empty

                    commonFunction.SetDDL_Table(SR_ddlServiceReportFor, "CommonCode", Common.Constants.GroupCode.ServiceReportFor_SCode)

                    Select Case lblReportTypeCode.Text.Trim
                        Case Common.Constants.ReportTypeCode.ServiceReportMPIDPI
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIBeforeLoadTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIAfterLoadTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIBeforePullTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIAfterPullTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.Tubular).Enabled = False
                            SR_ddlServiceReportFor.SelectedValue = Common.Constants.ReportTypeCodeServiceReportFor.MPIDPI
                            SR_pnlTubular.Visible = False
                            SR_pnlNotTubular.Visible = True
                        Case Common.Constants.ReportTypeCode.ServiceReportMPILoadPullTest
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIDPI).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.Tubular).Enabled = False
                            SR_ddlServiceReportFor.SelectedValue = Common.Constants.ReportTypeCodeServiceReportFor.MPIBeforeLoadTest
                            SR_pnlTubular.Visible = False
                            SR_pnlNotTubular.Visible = True
                        Case Common.Constants.ReportTypeCode.ServiceReportTubular
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIDPI).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIBeforeLoadTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIAfterLoadTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIBeforePullTest).Enabled = False
                            SR_ddlServiceReportFor.Items.FindByValue(Common.Constants.ReportTypeCodeServiceReportFor.MPIAfterPullTest).Enabled = False
                            SR_ddlServiceReportFor.SelectedValue = Common.Constants.ReportTypeCodeServiceReportFor.Tubular
                            SR_pnlTubular.Visible = True
                            SR_pnlNotTubular.Visible = False
                    End Select

                    commonFunction.Focus(Me, SR_ddlServiceReportFor.ClientID)

                Case Common.Constants.ReportTypePanelID.ServiceAcceptance_PanelID
                    SetDataGridProjectDetail(Common.Constants.ReportTypePanelID.ServiceAcceptance_PanelID)

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    COI_txtCertificateInspectionID.Text = String.Empty
                    COI_calCertificateDate.selectedDate = Date.Today
                    COI_caInspectionDate.selectedDate = Date.Today
                    COI_calExpiredDate.selectedDate = Date.Today
                    COI_txtCertificateNo.Text = String.Empty
                    COI_txtOwner.Text = String.Empty
                    COI_txtUser.Text = String.Empty
                    COI_txtLocation.Text = String.Empty
                    COI_txtDescription.Text = String.Empty
                    COI_txtSerialNo.Text = String.Empty
                    COI_txtMaxGossWeightR.Text = String.Empty
                    COI_txtLoadTest.Text = String.Empty
                    COI_txtDuration.Text = String.Empty
                    COI_txtSpecification.Text = String.Empty
                    COI_txtExamination.Text = String.Empty
                    COI_txtResult.Text = String.Empty
                    COI_txtNotes.Text = String.Empty
                    COI_imgPic1.ImageUrl = UrlBase + "/secure/GetImage.aspx?imgType=COI-1&cn=" + COI_txtCertificateInspectionID.Text.Trim
                    COI_imgPic2.ImageUrl = UrlBase + "/secure/GetImage.aspx?imgType=COI-2&cn=" + COI_txtCertificateInspectionID.Text.Trim
                    COI_imgPic3.ImageUrl = UrlBase + "/secure/GetImage.aspx?imgType=COI-3&cn=" + COI_txtCertificateInspectionID.Text.Trim

                Case Common.Constants.ReportTypePanelID.MPIReport_PanelID
                    If _isAfterInsert = False Then
                        MPI_btnReportNo.Attributes.Remove("onclick")
                        MPI_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("MPIHd", MPI_txtReportNo.ClientID, txtProjectCode.Text.Trim + "|" + MPI_ddlMPIType.SelectedValue.Trim))
                        If _isNew = True Then
                            MPI_txtMPIHdID.Text = String.Empty
                            MPI_txtReportNo.Text = String.Empty
                            MPI_calReportDate.selectedDate = Date.Today
                            MPI_txtSerialNo.Text = String.Empty
                            MPI_calExpiredDate.selectedDate = Date.Today

                            MPI_txtMPIDtID.Text = String.Empty
                            MPI_ddlPicGroup.SelectedIndex = 0
                            MPI_txtPicDescription.Text = String.Empty
                            MPI_btnUploadImage.Enabled = False
                        End If
                        MPI_txtDescription.Text = String.Empty
                        MPI_chkACIsASME.Checked = False
                        MPI_chkACIsAPISpec.Checked = False
                        MPI_chkIsACDS1.Checked = False
                        MPI_chkIsACOther.Checked = False
                        MPI_txtACASMEDescription.Text = "ASME"
                        MPI_txtACAPISpecDescription.Text = "API Spec."
                        MPI_txtACDS1Description.Text = "DS-1"
                        MPI_txtACOtherDescription.Text = "Other"
                        MPI_txtQty.Text = String.Empty
                        MPI_txtDimension.Text = String.Empty
                        MPI_txtAreaInspection.Text = String.Empty
                        MPI_txtMaterial.Text = String.Empty
                        MPI_txtApplication.Text = String.Empty
                        MPI_txtSurfaceCondition.Text = String.Empty
                        MPI_txtContrast.Text = String.Empty
                        MPI_txtMetalSurfaceTemp.Text = String.Empty
                        MPI_txtMagneticParticle.Text = String.Empty
                        MPI_txtMaterialThickness.Text = String.Empty
                        MPI_txtCleaner.Text = String.Empty
                        MPI_txtSetCalibration.Text = String.Empty
                        MPI_txtPenetrant.Text = String.Empty
                        MPI_txtPoleSpacing.Text = String.Empty
                        MPI_txtDeveloper.Text = String.Empty
                        MPI_rbtnlYoke.SelectedIndex = 0
                        MPI_rbtnlCoil.SelectedIndex = 0
                        MPI_rbtnlRods.SelectedValue = "No"
                        MPI_rbtnlBlacklight.SelectedValue = "No"
                        MPI_rbtnlFluorescent.SelectedIndex = 0
                        MPI_rbtnlContrastBW.SelectedIndex = 0
                        MPI_rbtnlDyePenetrant.SelectedValue = "No"
                        MPI_rbtnlWireBrush.SelectedValue = "No"
                        MPI_rbtnlBlastCleaning.SelectedValue = "No"
                        MPI_rbtnlGrinding.SelectedValue = "No"
                        MPI_rbtnlMachining.SelectedValue = "No"
                        MPI_txtInspectionResult.Text = String.Empty
                        MPI_txtNotes.Text = String.Empty
                        MPI_txtYokeSerialNo.Text = String.Empty
                        MPI_txtCoilSerialNo.Text = String.Empty
                        MPI_txtRodsSerialNo.Text = String.Empty
                        MPI_txtBlacklightSerialNo.Text = String.Empty

                        commonFunction.Focus(Me, MPI_ddlMPIType.ClientID)
                    Else
                        MPI_btnUploadImage.Enabled = False
                        commonFunction.Focus(Me, MPI_txtReportNo.ClientID)
                    End If

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    UTSC_btnReportNo.Attributes.Remove("onclick")
                    UTSC_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("UTSpotCheckHd", UTSC_txtReportNo.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        UTSC_txtUTSpotCheckHdID.Text = String.Empty
                        UTSC_calReportDate.selectedDate = Date.Today
                        UTSC_chkIsAreaSpotCylinder.Checked = False
                        UTSC_chkIsAreaSpotSquare.Checked = False
                    End If

                    If _isAfterInsert Then
                        UTSC_txtUTSpotCheckDtID.Text = String.Empty
                        commonFunction.Focus(Me, UTSC_txtStructureTallyNo.ClientID)
                    Else
                        If _isNew Then
                            If Len(UTSC_txtStructureTallyNo.Text.Trim) > 0 Then
                                commonFunction.Focus(Me, UTSC_txtSize.ClientID)
                            Else
                                commonFunction.Focus(Me, UTSC_txtStructureTallyNo.ClientID)
                            End If

                            UTSC_txtDescription.Text = String.Empty
                            UTSC_txtSerialNo.Text = String.Empty
                            UTSC_txtMaterial.Text = String.Empty
                            UTSC_txtEquipment.Text = String.Empty
                            UTSC_txtCouplant.Text = String.Empty
                            UTSC_txtProbeType.Text = String.Empty
                            UTSC_txtImpactDevice.Text = String.Empty
                            UTSC_txtReferenceLevel.Text = String.Empty
                            UTSC_txtFrequency.Text = String.Empty
                            UTSC_txtCalReference.Text = String.Empty
                            UTSC_txtWallThickness1.Text = "0"
                            UTSC_txtWallThickness2.Text = "0"
                            UTSC_txtWallThickness3.Text = "0"
                            UTSC_txtWallThickness4.Text = "0"
                            UTSC_txtHardnessTest1.Text = "0"
                            UTSC_txtHardnessTest2.Text = "0"
                            UTSC_txtHardnessTest3.Text = "0"
                            UTSC_txtHardnessTest4.Text = "0"
                            UTSC_txtRemark.Text = String.Empty                            
                        End If
                    End If

                Case Common.Constants.ReportTypePanelID.UTSpotArea_PanelID
                    UTSA_btnReportNo.Attributes.Remove("onclick")
                    UTSA_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("UTSpotAreaHd", UTSA_txtReportNo.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        UTSA_txtUTSpotCheckHdID.Text = String.Empty
                        UTSA_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        UTSA_txtUTSpotAreaDtID.Text = String.Empty
                        commonFunction.Focus(Me, UTSA_txtPipeNo.ClientID)
                    Else
                        If _isNew Then
                            If Len(UTSA_txtPipeNo.Text.Trim) > 0 Then
                                commonFunction.Focus(Me, UTSA_txtConditionResultPin.ClientID)
                            Else
                                commonFunction.Focus(Me, UTSA_txtPipeNo.ClientID)
                            End If

                            UTSA_txtDescription.Text = String.Empty
                            UTSA_txtEquipment.Text = String.Empty
                            UTSA_txtCouplant.Text = String.Empty
                            UTSA_txtProbe.Text = String.Empty
                            UTSA_txtReferenceLevel.Text = String.Empty
                            UTSA_txtCalReference.Text = String.Empty
                            UTSA_txtFrequency.Text = String.Empty
                            UTSA_txtConditionResultPin.Text = String.Empty
                            UTSA_txtConditionResultBox.Text = String.Empty
                            UTSA_txtRemarkPin.Text = String.Empty
                            UTSA_txtRemarkBox.Text = String.Empty
                        End If
                    End If

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    HT_btnReportNo.Attributes.Remove("onclick")
                    HT_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("HardnessTestHd", HT_txtReportNo.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        HT_txtHardnessTestHdID.Text = String.Empty
                        HT_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        HT_txtHardnessTestDtID.Text = String.Empty
                        commonFunction.Focus(Me, HT_txtPipeNo.ClientID)
                    Else
                        If _isNew Then
                            If Len(HT_txtPipeNo.Text.Trim) > 0 Then
                                commonFunction.Focus(Me, HT_ddlLocation.ClientID)
                            Else
                                commonFunction.Focus(Me, HT_txtPipeNo.ClientID)
                            End If

                            HT_ddlLocation.SelectedIndex = 0
                            HT_txtHRB1.Text = "0"
                            HT_txtHRB2.Text = "0"
                            HT_txtHRB3.Text = "0"
                            HT_txtHRB4.Text = "0"
                            HT_txtHRBAvg.Text = "0"
                            HT_txtHB1.Text = "0"
                            HT_txtHB2.Text = "0"
                            HT_txtHB3.Text = "0"
                            HT_txtHB4.Text = "0"
                            HT_txtHBAvg.Text = "0"
                        End If
                    End If

                Case Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID
                    TVI_btnReportNo.Attributes.Remove("onclick")
                    TVI_btnReportNo.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("TVIHd", TVI_txtReportNo.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        TVI_txtTVIHdID.Text = String.Empty
                        TVI_calReportDate.selectedDate = Date.Today
                    End If

                    If _isAfterInsert Then
                        TVI_txtTVIHdID.Text = String.Empty
                        commonFunction.Focus(Me, TVI_txtReportNo.ClientID)
                    Else
                        If _isNew Then
                            TVI_txtReportNo.Text = String.Empty
                            TVI_txtDescription.Text = String.Empty
                            TVI_txtSerialNo.Text = String.Empty
                            TVI_txtWLLSWL.Text = String.Empty
                            TVI_txtDimensionDiameter.Text = String.Empty
                            TVI_txtLength.Text = String.Empty
                            TVI_txtManufacturer.Text = String.Empty
                            TVI_txtDefectFound.Text = String.Empty
                            TVI_txtExamineWith.Text = String.Empty
                            TVI_txtResult.Text = String.Empty
                            TVI_txtNote.Text = String.Empty
                            TVI_calNextInspectionDate.selectedDate = Date.Today

                            Select Case TVI_ddlTVIType.SelectedValue.Trim
                                Case Common.Constants.ReportTypeCodeThoroughVisualType.Sling
                                    TVI_lblWLLSWLCaption.Text = "SWL"
                                    TVI_lblDimensionDiameterCaption.Text = "Dimension"
                                    TVI_pnlLength.Visible = True
                                Case Common.Constants.ReportTypeCodeThoroughVisualType.Shackle
                                    TVI_lblWLLSWLCaption.Text = "WLL"
                                    TVI_lblDimensionDiameterCaption.Text = "Diameter"
                                    TVI_pnlLength.Visible = False
                            End Select
                        End If
                    End If

                Case Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID
                    IT_btnInspectionTallyHdID.Attributes.Remove("onclick")
                    IT_btnInspectionTallyHdID.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("ITHd", IT_txtInspectionTallyHdID.ClientID, txtProjectCode.Text.Trim))

                    If _isNew = True Then
                        IT_txtInspectionTallyHdID.Text = String.Empty
                        IT_txtReportNo.Text = String.Empty
                        IT_calReportDate.selectedDate = Date.Today
                        IT_txtSize.Text = String.Empty
                        IT_txtGrade.Text = String.Empty
                        IT_txtWeight.Text = String.Empty
                        IT_txtConnection.Text = String.Empty
                        IT_txtRange.Text = String.Empty
                        IT_txtNominalWT.Text = String.Empty
                    End If

                    If _isAfterInsert Then
                        IT_txtInspectionTallyDtID.Text = String.Empty
                        commonFunction.Focus(Me, IT_txtPipeNo.ClientID)
                    Else
                        If _isNew Then
                            IT_txtPipeNo.Text = String.Empty
                            IT_txtPipeLength.Text = String.Empty
                            IT_txtVBI.Text = String.Empty
                            IT_txtRWT.Text = String.Empty
                            IT_txtVTIPin.Text = String.Empty
                            IT_txtVTIBox.Text = String.Empty
                            IT_txtFLD.Text = String.Empty
                            IT_txtFinalClass.Text = String.Empty
                            IT_txtInternalExternalCleaning.Text = String.Empty
                            IT_txtInternalExternalCoating.Text = String.Empty
                            IT_txtRemark.Text = String.Empty                            
                            commonFunction.Focus(Me, IT_txtPipeNo.ClientID)
                        Else
                            If Len(IT_txtPipeNo.Text.Trim) > 0 Then
                                commonFunction.Focus(Me, IT_txtPipeLength.ClientID)
                            Else
                                commonFunction.Focus(Me, IT_txtPipeNo.ClientID)
                            End If
                        End If
                    End If

                Case Common.Constants.ReportTypePanelID.OfficialReport_PanelID
                    BA_txtOfficialReportID.Text = String.Empty
                    BA_txtReportNo.Text = String.Empty
                    BA_ddlOfficialReportType.SelectedIndex = 0
                    BA_calReportDate.selectedDate = Date.Today
                    BA_pnlBeritaAcaraAkhir.Visible = False
            End Select
        End Sub

        Private Sub PopulateDateInMonth(ByVal _Repeater As Repeater, ByVal _Year As Integer, ByVal _Month As Integer, Optional ByVal _KeyFieldValue As String = "")
            Dim tblDateInMonth As New DataTable
            With tblDateInMonth
                .Columns.Add("DateNo", System.Type.GetType("System.String"))
                .Columns.Add("KeyField", System.Type.GetType("System.String"))
            End With
            For i As Integer = 1 To Date.DaysInMonth(_Year, _Month)
                Dim newRow As DataRow = tblDateInMonth.NewRow
                newRow("DateNo") = CStr(i)
                newRow("KeyField") = _KeyFieldValue
                tblDateInMonth.Rows.Add(newRow)
            Next
            _Repeater.DataSource = tblDateInMonth
            _Repeater.DataBind()
        End Sub

        Private Sub UpdateApproval(ByVal _VisiblePanelID As String, ByVal _isApproval As Boolean)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    oBR.projectID = txtProjectID.Text.Trim
                    If oBR.SelectByProjectID.Rows.Count > 0 Then
                        oBR.isApproval = _isApproval
                        oBR.approvalBy = MyBase.LoggedOnUserID.Trim
                        If oBR.UpdateApproval() Then
                            _refreshStatus(_VisiblePanelID.Trim)
                        End If
                    End If
                    oBR.Dispose()
                    oBR = Nothing
            End Select
        End Sub

        Private Sub _refreshStatus(ByVal _VisiblePanelID As String)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBr As New Common.BussinessRules.SummaryOfInspection
                    With oBr
                        .projectID = txtProjectID.Text.Trim
                        If .SelectByProjectID.Rows.Count > 0 Then
                            If .isApproval = True Then
                                SOI_pnlApproved.Visible = True
                                SOI_lblApprovalBy.Text = _openUser(.approvalBy.Trim)
                                SOI_lblApprovalDate.Text = .approvalDate.ToString.Trim
                            Else
                                SOI_pnlApproved.Visible = False
                                SOI_lblApprovalBy.Text = String.Empty
                                SOI_lblApprovalDate.Text = String.Empty
                            End If

                            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = Not .isApproval And Not chkIsCustomer.Checked
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = Not .isApproval And Not chkIsCustomer.Checked
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = .isApproval And Not chkIsCustomer.Checked
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = .isApproval 'And Not chkIsCustomer.Checked
                        Else
                            SOI_pnlApproved.Visible = False
                            SOI_lblApprovalBy.Text = String.Empty
                            SOI_lblApprovalDate.Text = String.Empty

                            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = False
                            CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = False
                        End If
                    End With
                    oBr.Dispose()
                    oBr = Nothing
                Case Else
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = True
            End Select
        End Sub

#End Region

#Region " C,R,U,D "
        Private Sub _open(ByVal _VisiblePanelID As String)
            Dim isNew As Boolean = True
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    With oBR
                        .summaryOfInspectionID = SOI_txtSummaryOfInspectionID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            SOI_txtSequenceNo.Text = .sequenceNo.Trim
                            SOI_txtDescOfEquip.Text = .descriptionOfEquipment.Trim
                            SOI_txtSerialNo.Text = .serialIDNo.Trim
                            SOI_txtLocation.Text = .location.Trim
                            SOI_txtManufacture.Text = .manufacture.Trim
                            SOI_txtSWLWWLMGW.Text = .SWL_WWL_MGW.Trim
                            SOI_txtDimensional.Text = .dimensional.Trim
                            SOI_txtDefectFound.Text = .defectFound.Trim
                            SOI_txtResult.Text = .result.Trim
                            SOI_calExamDate.selectedDate = .examDate
                            SOI_calExpiredDate.selectedDate = .expireDate
                            SOI_txtReportNumber.Text = .reportNo.Trim
                            SOI_chkIsV.Checked = .isToiV
                            SOI_chkIsN.Checked = .isToiN
                            SOI_chkIsT.Checked = .isToiT
                            SOI_txtInterval.Text = .interval.Trim
                            SOI_txtRemarks.Text = .remarks.Trim
                        Else
                            PrepareScreen(_VisiblePanelID, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    Dim oBR As New Common.BussinessRules.CheckListOfCompletionReport
                    With oBR
                        .CCRID = CCR_txtCCRID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            CCR_txtSequenceNo.Text = .sequenceNo.Trim
                            CCR_txtDescription.Text = .description.Trim
                            commonFunction.SelectListItem(CCR_ddlTypeOfReport, .typeOfReportSCode.Trim)
                            CCR_txtPreparedByName.Text = .preparedBy.Trim
                            CCR_calPreparedDate.selectedDate = .preparedDate
                            CCR_txtReportNo.Text = .reportNo.Trim
                            CCR_txtRemarks.Text = .remarks.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DPR_calReportDate.selectedDate = .reportDate
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DPR_txtDailyReportDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DPR_txtSequenceNo.Text = .sequenceNo.Trim
                            DPR_txtDescription.Text = .description.Trim
                            commonFunction.SelectListItem(DPR_ddlWeatherCondition, .weatherConditionSCode.Trim)
                            DPR_txtQtyCurrent.Text = CStr(.currentQty)
                            DPR_txtQtyPrevious.Text = CStr(.beginningQty)
                            DPR_txtQtyCumulative.Text = CStr(.endingQty)
                            DPR_txtUOMCurrent.Text = .currentUOM.Trim
                            DPR_txtUOMPrevious.Text = .beginningUOM.Trim
                            DPR_txtUOMCumulative.Text = .endingUOM.Trim
                            DPR_txtMaterialDetail.Text = .materialDetail.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID)

                Case Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DIR_calReportDate.selectedDate = .reportDate
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DIR_txtDailyReportDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DIR_txtSequenceNo.Text = .sequenceNo.Trim
                            DIR_txtDescription.Text = .description.Trim
                            commonFunction.SelectListItem(DIR_ddlWeatherCondition, .weatherConditionSCode.Trim)
                            DIR_txtQty.Text = CStr(.currentQty)
                            DIR_txtResult.Text = .result.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID)

                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.DrillPipeReportHd
                    With oHd
                        .drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            DP_calReportDate.selectedDate = .reportDate
                            DP_txtReportNo.Text = .reportNo.Trim
                            DP_txtRemarks.Text = .remarks.Trim
                            DP_txtSize.Text = .size.Trim
                            DP_txtWeight.Text = .weight.Trim
                            DP_txtGrade.Text = .grade.Trim
                            DP_txtConnection.Text = .connection.Trim
                            DP_txtRange.Text = .range.Trim
                            DP_txtNominalWT.Text = .nominalWT.Trim
                            DP_ddlCaptionTemplate.SelectedValue = .captionTemplateHdID.Trim
                            _openCaptionTemplateDrillPipe()
                            DP_txtSpecificationID.Text = .inspectionSpecID.Trim
                            _openInspectionSpec()
                            isNew = False
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DrillPipeReportDt
                    With oDt
                        .drillPipeReportDtID = DP_txtDrillPipeReportDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            Dim remarksArr As String() = .remarks.Split(New [Char]() {CChar("^")})
                            Dim remarksSCode As String = String.Empty
                            Dim remarksText As String = String.Empty
                            remarksSCode = remarksArr(0)
                            remarksText = remarksArr(1)
                            DP_txtSequenceNo.Text = .sequenceNo.Trim
                            DP_txtSerialNo.Text = .serialNo.Trim
                            DP_ddlRemarks.SelectedValue = remarksSCode.Trim
                            DP_txtRemarks.Text = remarksText.Trim
                            DP_txtBod001Value.Text = .bod001Value.Trim
                            DP_txtBod002Value.Text = .bod002Value.Trim
                            DP_txtBod003Value.Text = .bod003Value.Trim
                            DP_txtBod004Value.Text = .bod004Value.Trim
                            DP_txtBod005Value.Text = .bod005Value.Trim
                            DP_txtBod006Value.Text = .bod006Value.Trim
                            DP_txtBod007Value.Text = .bod007Value.Trim
                            DP_txtBod008Value.Text = .bod008Value.Trim
                            DP_txtBod009Value.Text = .bod009Value.Trim
                            DP_txtPin001Value.Text = .pin001Value.Trim
                            DP_txtPin002Value.Text = .pin002Value.Trim
                            DP_txtPin003Value.Text = .pin003Value.Trim
                            DP_txtPin004Value.Text = .pin004Value.Trim
                            DP_txtPin005Value.Text = .pin005Value.Trim
                            DP_txtPin006Value.Text = .pin006Value.Trim
                            DP_txtPin007Value.Text = .pin007Value.Trim
                            DP_txtPin008Value.Text = .pin008Value.Trim
                            DP_txtPin009Value.Text = .pin009Value.Trim
                            DP_txtPin010Value.Text = .pin010Value.Trim
                            DP_txtPin011Value.Text = .pin011Value.Trim
                            DP_txtBox001Value.Text = .box001Value.Trim
                            DP_txtBox002Value.Text = .box002Value.Trim
                            DP_txtBox003Value.Text = .box003Value.Trim
                            DP_txtBox004Value.Text = .box004Value.Trim
                            DP_txtBox005Value.Text = .box005Value.Trim
                            DP_txtBox006Value.Text = .box006Value.Trim
                            DP_txtBox007Value.Text = .box007Value.Trim
                            DP_txtBox008Value.Text = .box008Value.Trim
                            DP_txtBox009Value.Text = .box009Value.Trim
                            DP_txtBox010Value.Text = .box010Value.Trim
                            DP_txtBox011Value.Text = .box011Value.Trim
                            DP_chkIsPinHB.Checked = .isPinHB
                            DP_chkIsBoxHB.Checked = .isBoxHB
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID)

                Case Common.Constants.ReportTypePanelID.InspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.InspectionReportHd
                    With oHd
                        .inspectionReportHdID = INS_txtInspectionReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            INS_calReportDate.selectedDate = .reportDate
                            INS_txtReportNo.Text = .reportNo.Trim
                            INS_ddlInspectionReportType.SelectedValue = .inspectionReportTypeSCode.Trim
                            INS_chkMPI.Checked = .isMPI
                            INS_chkVTI.Checked = .isVisualThread
                            INS_chkDIM.Checked = .isDimensional
                            INS_chkBLC.Checked = .isBlacklightConnection
                            INS_chkVBI.Checked = .isVisualBodyInspection
                            isNew = False
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.InspectionReport_PanelID, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.InspectionReportDt
                    With oDt
                        .inspectionReportDtID = INS_txtInspectionReportDTID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            INS_txtDescription.Text = .description.Trim
                            INS_txtSerialNo.Text = .serialNo.Trim
                            INS_txtTotalLength.Text = .totalLength.Trim
                            INS_txtIDDescription.Text = .IDdescription.Trim
                            INS_txtConnectionSizePin.Text = .connectionSizePin.Trim
                            INS_txtConnectionODPin.Text = .connectionODPin.Trim
                            INS_txtConnectionSizeBox.Text = .connectionSizeBox.Trim
                            INS_txtConnectionODBox.Text = .connectionODBox.Trim
                            INS_txtElevatorGrooveDiaPin.Text = .elevatorGrooveDiaPin.Trim
                            INS_txtElevatorGrooveDepthPin.Text = .elevatorGrooveDepthPin.Trim
                            INS_txtElevatorGrooveDiaBox.Text = .elevatorGrooveDiaBox.Trim
                            INS_txtElevatorGrooveDepthBox.Text = .elevatorGrooveDepthBox.Trim
                            INS_txtBBackRGrooveDiaPin.Text = .BBackRGrooveDiaPin.Trim
                            INS_txtBBackRGrooveLengthPin.Text = .BBackRGrooveLengthPin.Trim
                            INS_txtBBackRGrooveDiaBox.Text = .BBackRGrooveDiaBox.Trim
                            INS_txtBBackRGrooveLengthBox.Text = .BBackRGrooveLengthBox.Trim
                            INS_txtBevelDiameterPin.Text = .bevelDiaPin.Trim
                            INS_txtBevelDiameterBox.Text = .bevelDiaBox.Trim
                            INS_txtThreadLengthPin.Text = .threadLengthPin.Trim
                            INS_txtThreadLengthBox.Text = .threadLengthBox.Trim
                            INS_txtCounterBoreDiaPin.Text = .counterBoreDiaPin.Trim
                            INS_txtCounterBoreDepthPin.Text = .counterBoreDepthPin.Trim
                            INS_txtCounterBoreDiaBox.Text = .counterBoreDiaBox.Trim
                            INS_txtCounterBoreDepthBox.Text = .counterBoreDepthBox.Trim
                            INS_txtCenterPadDiaPin.Text = .centerPadDiaPin.Trim
                            INS_txtCenterPadDepthPin.Text = .centerPadDepthPin.Trim
                            INS_txtCenterPadDiaBox.Text = .centerPadDiaBox.Trim
                            INS_txtCenterPadDepthBox.Text = .centerPadDepthBox.Trim
                            INS_txtTongSpacePin.Text = .tongSpacePin.Trim
                            INS_txtTongSpaceBox.Text = .tongSpaceBox.Trim
                            INS_txtConditionPin.Text = .conditionPin.Trim
                            INS_txtConditionBox.Text = .conditionBox.Trim
                            INS_txtBSR.Text = .BSR.Trim
                            INS_txtRemarksPin.Text = .remarksPin.Trim
                            INS_txtRemarksBox.Text = .remarksBox.Trim
                            INS_txtHBPin.Text = .HBPin.Trim
                            INS_txtHBBox.Text = .HBBox.Trim
                            INS_txtHBCenterPad.Text = .HBCenterPad.Trim
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.InspectionReport_PanelID, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.InspectionReport_PanelID)

                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    Dim oSR As New Common.BussinessRules.ServiceReport
                    With oSR
                        .serviceReportID = SR_txtServiceReportID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            commonFunction.SelectListItem(SR_ddlServiceReportFor, .serviceReportForSCode.Trim)
                            SR_calServiceReportDate.selectedDate = .serviceReportDate
                            txtProjectID.Text = .projectID.Trim
                            SR_txtTypeOfInspection.Text = .typeOfInspection.Trim
                            SR_txtManufacturer.Text = .mdManufacturer.Trim
                            SR_txtTypeOfPipe.Text = .mdTypeOfPipe.Trim
                            SR_txtPipeOD.Text = .mdPipeOD.Trim
                            SR_txtPipeGrade.Text = .mdPipeGrade.Trim
                            SR_txtPipeWeight.Text = .mdPipeWeight.Trim
                            SR_txtThreadConnection.Text = .mdThreadConnection.Trim
                            SR_txtRange.Text = .mdRange.Trim
                            SR_txtTotalInspected.Text = .mdTotalInspected.Trim
                            SR_txtTotalAccepted.Text = .mdTotalAccepted.Trim
                            SR_txtMaterialDescription.Text = .mdNotes.Trim
                            SR_txtResult.Text = .result.Trim
                            commonFunction.Focus(Me, SR_ddlServiceReportFor.ClientID)
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, False)
                        End If
                    End With
                    oSR.Dispose()
                    oSR = Nothing

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.CertificateInspection
                    With oBR
                        .certificateInspectionID = COI_txtCertificateInspectionID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            COI_txtCertificateNo.Text = .certificateNo.Trim
                            COI_calCertificateDate.selectedDate = .certificateDate
                            COI_txtOwner.Text = .owner.Trim
                            COI_txtUser.Text = .userLabel.Trim
                            COI_txtLocation.Text = .location.Trim
                            COI_txtDescription.Text = .description.Trim
                            COI_txtSerialNo.Text = .serialNo.Trim
                            COI_txtMaxGossWeightR.Text = .maxGrossWeightR.Trim
                            COI_txtLoadTest.Text = .loadTest.Trim
                            COI_txtDuration.Text = .duration.Trim
                            COI_txtSpecification.Text = .specification.Trim
                            COI_txtExamination.Text = .examination.Trim
                            COI_txtResult.Text = .result.Trim
                            COI_txtNotes.Text = .notes.Trim
                            COI_caInspectionDate.selectedDate = .inspectionDate
                            COI_calExpiredDate.selectedDate = .expiredDate
                            COI_imgPic1.ImageUrl = GetPic_COI(1, COI_txtCertificateInspectionID.Text.Trim)
                            COI_imgPic2.ImageUrl = GetPic_COI(2, COI_txtCertificateInspectionID.Text.Trim)
                            COI_imgPic3.ImageUrl = GetPic_COI(3, COI_txtCertificateInspectionID.Text.Trim)
                        Else
                            PrepareScreen(_VisiblePanelID, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.MPIReport_PanelID
                    MPI_txtMPIHdID.Text = Common.BussinessRules.ID.GetFieldValue("MPIHd", "reportNo", MPI_txtReportNo.Text.Trim, "MPIHdID")
                    Dim oBR As New Common.BussinessRules.MPIHd
                    With oBR
                        .MPIHdID = MPI_txtMPIHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            MPI_ddlMPIType.SelectedValue = .MPITypeSCode.Trim
                            MPI_calReportDate.selectedDate = .reportDate
                            MPI_txtReportNo.Text = .reportNo.Trim
                            MPI_txtSerialNo.Text = .serialNo.Trim
                            MPI_calExpiredDate.selectedDate = .expiredDate
                            MPI_txtDescription.Text = .description.Trim
                            MPI_chkACIsASME.Checked = .ACIsASME
                            MPI_chkACIsAPISpec.Checked = .ACIsAPISpec
                            MPI_chkIsACDS1.Checked = .ACIsDS1
                            MPI_chkIsACOther.Checked = .ACIsOther
                            MPI_txtACASMEDescription.Text = .ACASMEDescription.Trim
                            MPI_txtACAPISpecDescription.Text = .ACAPISpecDescription.Trim
                            MPI_txtACDS1Description.Text = .ACDS1Description.Trim
                            MPI_txtACOtherDescription.Text = .ACOtherDescription.Trim
                            MPI_txtQty.Text = .qty.Trim
                            MPI_txtDimension.Text = .dimension.Trim
                            MPI_txtAreaInspection.Text = .areaInspection.Trim
                            MPI_txtMaterial.Text = .material.Trim
                            MPI_txtApplication.Text = .application.Trim
                            MPI_txtSurfaceCondition.Text = .surfaceCondition.Trim
                            MPI_txtContrast.Text = .contrast.Trim
                            MPI_txtMetalSurfaceTemp.Text = .metalSurfaceTemp.Trim
                            MPI_txtMagneticParticle.Text = .magneticParticle.Trim
                            MPI_txtMaterialThickness.Text = .materialThickness.Trim
                            MPI_txtCleaner.Text = .cleaner.Trim
                            MPI_txtSetCalibration.Text = .setCalibration.Trim
                            MPI_txtPenetrant.Text = .penetrant.Trim
                            MPI_txtPoleSpacing.Text = .poleSpacing.Trim
                            MPI_txtDeveloper.Text = .developer.Trim
                            MPI_rbtnlYoke.SelectedValue = .yokeSCode.Trim
                            MPI_rbtnlCoil.SelectedValue = .coilSCode.Trim
                            If .isRods Then
                                MPI_rbtnlRods.SelectedValue = "Yes"
                            Else
                                MPI_rbtnlRods.SelectedValue = "No"
                            End If
                            If .isBlacklight Then
                                MPI_rbtnlBlacklight.SelectedValue = "Yes"
                            Else
                                MPI_rbtnlBlacklight.SelectedValue = "No"
                            End If                                                        
                            MPI_rbtnlFluorescent.SelectedValue = .fluorescentSCode.Trim
                            MPI_rbtnlContrastBW.SelectedValue = .contrastBWSCode.Trim
                            If .isDyePenetrant Then
                                MPI_rbtnlDyePenetrant.SelectedValue = "Yes"
                            Else
                                MPI_rbtnlDyePenetrant.SelectedValue = "No"
                            End If
                            If .isWireBrush Then
                                MPI_rbtnlWireBrush.SelectedValue = "Yes"
                            Else
                                MPI_rbtnlWireBrush.SelectedValue = "No"
                            End If
                            If .isBlastCleaning Then
                                MPI_rbtnlBlastCleaning.SelectedValue = "Yes"
                            Else
                                MPI_rbtnlBlastCleaning.SelectedValue = "No"
                            End If
                            If .isGrinding Then
                                MPI_rbtnlGrinding.SelectedValue = "Yes"
                            Else
                                MPI_rbtnlGrinding.SelectedValue = "No"
                            End If
                            If .isMachining Then
                                MPI_rbtnlMachining.SelectedValue = "Yes"
                            Else
                                MPI_rbtnlMachining.SelectedValue = "No"
                            End If
                            MPI_txtYokeSerialNo.Text = .yokeSerialNo.Trim
                            MPI_txtCoilSerialNo.Text = .coilSerialNo.Trim
                            MPI_txtRodsSerialNo.Text = .rodsSerialNo.Trim
                            MPI_txtBlacklightSerialNo.Text = .blacklightSerialNo.Trim
                            MPI_txtInspectionResult.Text = .inspectionResult.Trim
                            MPI_txtNotes.Text = .notes.Trim
                            MPI_btnUploadImage.Enabled = True
                        Else
                            PrepareScreen(_VisiblePanelID, False, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(_VisiblePanelID)

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    UTSC_txtUTSpotCheckHdID.Text = Common.BussinessRules.ID.GetFieldValue("UTSpotCheckHd", "reportNo", UTSC_txtReportNo.Text.Trim, "UTSpotCheckHdID")
                    Dim oHd As New Common.BussinessRules.UTSpotCheckHd
                    With oHd
                        .UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            UTSC_ddlUTSpotType.SelectedValue = .UTSpotTypeSCode.Trim
                            UTSC_calReportDate.selectedDate = .reportDate
                            UTSC_txtSerialNo.Text = .SerialNo.Trim
                            UTSC_txtDescription.Text = .Description.Trim
                            UTSC_txtMaterial.Text = .Material.Trim
                            UTSC_txtEquipment.Text = .Equipment.Trim
                            UTSC_txtCouplant.Text = .Couplant.Trim
                            UTSC_txtProbeType.Text = .ProbeType.Trim
                            UTSC_txtImpactDevice.Text = .ImpactDevice.Trim
                            UTSC_txtReferenceLevel.Text = .ReferenceLevel.Trim
                            UTSC_txtFrequency.Text = .Frequency.Trim
                            UTSC_txtCalReference.Text = .CalReference.Trim
                            UTSC_chkIsAreaSpotCylinder.Checked = .isAreaSpotCylinder
                            UTSC_chkIsAreaSpotSquare.Checked = .isAreaSpotSquare
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.UTSpotCheckDt
                    With oDt
                        .UTSpotCheckDtID = UTSC_txtUTSpotCheckDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            UTSC_txtStructureTallyNo.Text = .structureTallyNo.Trim
                            UTSC_txtSize.Text = .size.Trim
                            UTSC_txtLength.Text = .length.Trim
                            UTSC_txtWallThickness1.Text = .wallThickness1.ToString.Trim
                            UTSC_txtWallThickness2.Text = .wallThickness2.ToString.Trim
                            UTSC_txtWallThickness3.Text = .wallThickness3.ToString.Trim
                            UTSC_txtWallThickness4.Text = .wallThickness4.ToString.Trim
                            UTSC_txtHardnessTest1.Text = .hardnessTest1.ToString.Trim
                            UTSC_txtHardnessTest2.Text = .hardnessTest2.ToString.Trim
                            UTSC_txtHardnessTest3.Text = .hardnessTest3.ToString.Trim
                            UTSC_txtHardnessTest4.Text = .hardnessTest4.ToString.Trim
                            UTSC_txtRemark.Text = .remark.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID)

                Case Common.Constants.ReportTypePanelID.UTSpotArea_PanelID
                    UTSA_txtUTSpotCheckHdID.Text = Common.BussinessRules.ID.GetFieldValue("UTSpotCheckHd", "reportNo", UTSA_txtReportNo.Text.Trim, "UTSpotCheckHdID")
                    Dim oHd As New Common.BussinessRules.UTSpotCheckHd
                    With oHd
                        .UTSpotCheckHdID = UTSA_txtUTSpotCheckHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            UTSA_ddlUTSpotType.SelectedValue = .UTSpotTypeSCode.Trim
                            UTSA_calReportDate.selectedDate = .reportDate
                            UTSA_txtDescription.Text = .Description.Trim
                            UTSA_txtEquipment.Text = .Equipment.Trim
                            UTSA_txtCouplant.Text = .Couplant.Trim
                            UTSA_txtProbe.Text = .ProbeType.Trim
                            UTSA_txtReferenceLevel.Text = .ReferenceLevel.Trim
                            UTSA_txtFrequency.Text = .Frequency.Trim
                            UTSA_txtCalReference.Text = .CalReference.Trim
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.UTSpotAreaDt
                    With oDt
                        .UTSpotAreaDtID = UTSA_txtUTSpotAreaDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            UTSA_txtPipeNo.Text = .pipeNo.Trim
                            UTSA_txtConditionResultPin.Text = .conditionResultPin.Trim
                            UTSA_txtConditionResultBox.Text = .conditionResultBox.Trim
                            UTSA_txtRemarkPin.Text = .remarkPin.Trim
                            UTSA_txtRemarkBox.Text = .remarkBox.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.UTSpotArea_PanelID)

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    HT_txtHardnessTestHdID.Text = Common.BussinessRules.ID.GetFieldValue("HardnessTestHd", "reportNo", HT_txtReportNo.Text.Trim, "HardnessTestHdID")
                    Dim oHd As New Common.BussinessRules.HardnessTestHd
                    With oHd
                        .hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            HT_calReportDate.selectedDate = .reportDate
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.HardnessTestDt
                    With oDt
                        .hardnessTestDtID = HT_txtHardnessTestDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            HT_txtPipeNo.Text = .pipeNo.Trim
                            HT_ddlLocation.SelectedValue = .locationSCode.Trim
                            HT_txtHRB1.Text = .HRB1.ToString.Trim
                            HT_txtHRB2.Text = .HRB2.ToString.Trim
                            HT_txtHRB3.Text = .HRB3.ToString.Trim
                            HT_txtHRB4.Text = .HRB4.ToString.Trim
                            HT_txtHRBAvg.Text = .HRBAvg.ToString.Trim
                            HT_txtHB1.Text = .HB1.ToString.Trim
                            HT_txtHB2.Text = .HB2.ToString.Trim
                            HT_txtHB3.Text = .HB3.ToString.Trim
                            HT_txtHB4.Text = .HB4.ToString.Trim
                            HT_txtHBAvg.Text = .HBAvg.ToString.Trim
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.HardnessTest_PanelID)

                Case Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID
                    TVI_txtTVIHdID.Text = Common.BussinessRules.ID.GetFieldValue("ThoroughVisualReportHd", "reportNo", TVI_txtReportNo.Text.Trim, "tviHdID")
                    Dim oTVI As New Common.BussinessRules.ThoroughVisualReportHd
                    With oTVI
                        .tviHdID = TVI_txtTVIHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            TVI_txtTVIHdID.Text = .tviHdID.Trim
                            TVI_txtReportNo.Text = .reportNo.Trim
                            commonFunction.SelectListItem(TVI_ddlTVIType, .tviTypeSCode.Trim)
                            TVI_calReportDate.selectedDate = .reportDate
                            txtProjectID.Text = .projectID.Trim
                            TVI_txtDescription.Text = .Description.Trim
                            TVI_txtSerialNo.Text = .SerialNo.Trim
                            TVI_txtWLLSWL.Text = .WLLSWL.Trim
                            TVI_txtDimensionDiameter.Text = .Dimension.Trim
                            TVI_txtLength.Text = .Length.Trim
                            TVI_txtManufacturer.Text = .Manufacture.Trim
                            TVI_txtDefectFound.Text = .DefectFound.Trim
                            TVI_txtExamineWith.Text = .ExamineWith.Trim
                            TVI_txtResult.Text = .Result.Trim
                            TVI_txtNote.Text = .Note.Trim
                            TVI_calNextInspectionDate.selectedDate = .NextInspectionDate
                            commonFunction.Focus(Me, TVI_txtDescription.ClientID)
                        Else
                            PrepareScreen(Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID, False)
                        End If
                    End With
                    oTVI.Dispose()
                    oTVI = Nothing

                Case Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID
                    Dim oHd As New Common.BussinessRules.InspectionTallyReportHd
                    With oHd
                        .InspectionTallyHdID = IT_txtInspectionTallyHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            IT_txtReportNo.Text = .reportNo.Trim
                            IT_calReportDate.selectedDate = .reportDate
                            IT_txtSize.Text = .size.Trim
                            IT_txtGrade.Text = .grade.Trim
                            IT_txtWeight.Text = .weight.Trim
                            IT_txtConnection.Text = .connection.Trim
                            IT_txtRange.Text = .range.Trim
                            IT_txtNominalWT.Text = .nominalWT.Trim
                            IT_txtAC1.Text = .ACcaption1.Trim
                            IT_txtAC2.Text = .ACcaption2.Trim
                            IT_txtAC3.Text = .ACcaption3.Trim
                            IT_txtAC4.Text = .ACcaption4.Trim
                            IT_chkIsAC1.Checked = .isAC1
                            IT_chkIsAC2.Checked = .isAC2
                            IT_chkIsAC3.Checked = .isAC3
                            IT_chkIsAC4.Checked = .isAC4
                            isNew = False
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                            isNew = True
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.InspectionTallyReportDt
                    With oDt
                        .inspectionTallyDtID = IT_txtInspectionTallyDtID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            IT_txtPipeNo.Text = .pipeNo.Trim
                            IT_txtPipeLength.Text = .pipeLength.Trim
                            IT_txtVBI.Text = .VBI.Trim
                            IT_txtRWT.Text = .RWT.Trim
                            IT_txtVTIPin.Text = .VTIPin.Trim
                            IT_txtVTIBox.Text = .VTIBox.Trim
                            IT_txtFLD.Text = .FLD.Trim
                            IT_txtFinalClass.Text = .finalClass.Trim
                            IT_txtInternalExternalCleaning.Text = .intExtCleaning.Trim
                            IT_txtInternalExternalCoating.Text = .intExtCoating.Trim
                            If .isCCUYellow Then
                                IT_rdblCCU.SelectedValue = "Y"
                            End If
                            If .isCCUBlue Then
                                IT_rdblCCU.SelectedValue = "B"
                            End If
                            If .isCCUGreen Then
                                IT_rdblCCU.SelectedValue = "G"
                            End If
                            If .isCCURed Then
                                IT_rdblCCU.SelectedValue = "R"
                            End If
                            If .isCCNWhite Then
                                IT_rdblCCN.SelectedValue = "W"
                            End If
                            If .isCCNYellow Then
                                IT_rdblCCN.SelectedValue = "Y"
                            End If
                            If .isCCNRed Then
                                IT_rdblCCN.SelectedValue = "R"
                            End If
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False, isNew)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID)

                Case Common.Constants.ReportTypePanelID.OfficialReport_PanelID
                    Dim oBR As New Common.BussinessRules.OfficialReport
                    With oBR
                        .officialReportID = BA_txtOfficialReportID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            BA_txtReportNo.Text = .reportNo.Trim
                            BA_calReportDate.selectedDate = .reportDate
                            commonFunction.SelectListItem(BA_ddlOfficialReportType, .officialReportTypeSCode.Trim)
                            BA_ddlOfficialReportType_SelectedIndexChanged(Nothing, Nothing)
                        Else
                            PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing
            End Select
        End Sub

        Private Function _openUser(ByVal strUserID As String) As String
            Dim strToReturn As String = String.Empty
            Dim oUser As New Common.BussinessRules.User
            With oUser
                .UserID = strUserID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    strToReturn = .UserName.Trim
                Else
                    strToReturn = String.Empty
                End If
            End With
            oUser.Dispose()
            oUser = Nothing
            Return strToReturn.Trim
        End Function

        Private Sub _update(ByVal _VisiblePanelID As String)
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.SummaryOfInspection
                    If SOI_rbtnlInputMethod.SelectedValue.Trim = "Entry" Then
                        With oBR
                            .projectID = txtProjectID.Text.Trim
                            .summaryOfInspectionID = SOI_txtSummaryOfInspectionID.Text.Trim
                            If .SelectOne.Rows.Count > 0 Then
                                isNew = False
                            Else
                                isNew = True
                            End If
                            .projectID = txtProjectID.Text.Trim
                            .sequenceNo = SOI_txtSequenceNo.Text.Trim
                            .descriptionOfEquipment = SOI_txtDescOfEquip.Text.Trim
                            .serialIDNo = SOI_txtSerialNo.Text.Trim
                            .location = SOI_txtLocation.Text.Trim
                            .manufacture = SOI_txtManufacture.Text.Trim
                            .SWL_WWL_MGW = SOI_txtSWLWWLMGW.Text.Trim
                            .dimensional = SOI_txtDimensional.Text.Trim
                            .defectFound = SOI_txtDefectFound.Text.Trim
                            .result = SOI_txtResult.Text.Trim
                            .reportNo = SOI_txtReportNumber.Text.Trim
                            .typeOfInspectionSCode = ""
                            .isToiV = SOI_chkIsV.Checked
                            .isToiN = SOI_chkIsN.Checked
                            .isToiT = SOI_chkIsT.Checked
                            .interval = SOI_txtInterval.Text.Trim
                            .remarks = SOI_txtRemarks.Text.Trim
                            .detailReportSection = ""
                            .examDate = SOI_calExamDate.selectedDate
                            .expireDate = SOI_calExpiredDate.selectedDate
                            .userIDinsert = MyBase.LoggedOnUserID
                            .userIDupdate = MyBase.LoggedOnUserID

                            If txtFileUrl.Value.Trim.Length > 0 Then
                                Dim fileExt As String, fileName As String
                                fileExt = Path.GetExtension(txtFileUrl.Value.Trim)
                                If SOI_txtSummaryOfInspectionID.Text.Trim.Length = 0 Then
                                    fileName = Common.BussinessRules.ID.GenerateIDNumber("SummaryOfInspection", "summaryOfInspectionID") + fileExt.Trim
                                Else
                                    fileName = SOI_txtSummaryOfInspectionID.Text.Trim + fileExt.Trim
                                End If
                                .summaryOfInspectionID = SOI_txtSummaryOfInspectionID.Text.Trim
                                Dim Pathdb As String = Common.Methods.GetCommonCode("SOIDIR", "FILEDIR").Trim
                                Dim fNotNew As Boolean = False
                                Dim nmFile As String
                                Try
                                    .fileName = fileName.Trim
                                    .fileExtension = fileExt.Trim

                                    '// validate if the file exist
                                    nmFile = Pathdb + fileName
                                    If txtFileUrl.Value.Trim.Length > 0 Then
                                        If File.Exists(nmFile) Then
                                            File.Delete(nmFile)
                                        End If
                                        txtFileUrl.PostedFile.SaveAs(nmFile)
                                    End If
                                Catch ex As Exception
                                    commonFunction.MsgBox(Me, "Upload File tidak berhasil.")
                                    Exit Sub
                                End Try
                            Else
                                .fileName = String.Empty
                                .fileExtension = String.Empty
                            End If

                            If isNew Then
                                If .Insert() Then SOI_txtSummaryOfInspectionID.Text = .summaryOfInspectionID.Trim
                                PrepareScreen(_VisiblePanelID.Trim, True)
                            Else
                                .Update()
                                PrepareScreen(_VisiblePanelID.Trim, False)
                            End If
                        End With
                    Else
                        '// Upload
                        Dim MyConnection As System.Data.OleDb.OleDbConnection

                        If Len(SOI_txtSheetName.Text.Trim) = 0 Then
                            commonFunction.MsgBox(Me, "Sheet Name harus diisi.")
                            Exit Sub
                        End If

                        Dim strFileFolder As String = Common.Methods.GetCommonCode("SOIUPLDIR", "FILEDIR").Trim
                        Dim strFileName As String = Path.GetFileName(SOI_File.Value.Trim).Trim
                        Dim strFilePath As String = String.Empty

                        strFilePath = strFileFolder + strFileName

                        If (Not File.Exists(strFilePath)) Then
                            commonFunction.MsgBox(Me, "Upload Failed. File " + strFileName.Trim + " doesn't exist.")
                            Exit Sub
                        End If

                        Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
                        Dim b(CInt(fs.Length)) As Byte
                        fs.Read(b, 0, CInt(fs.Length))
                        fs.Close()

                        Try
                            '// Fetch Data from Excel
                            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                            Dim DtSet As System.Data.DataSet

                            'MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & strFilePath & " '; " & "Extended Properties=Excel 12.0;")
                            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & strFilePath & " '; " & "Extended Properties=Excel 8.0;")
                            MyCommand = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + SOI_txtSheetName.Text.Trim + "$]", MyConnection)

                            DtSet = New System.Data.DataSet

                            MyCommand.Fill(DtSet, "[" + SOI_txtSheetName.Text.Trim + "$]")

                            '// -------------------------------------------------------------------------------
                            Dim iRecCount As Integer = 0
                            While DtSet.Tables(0).Rows.Count > iRecCount
                                With oBR
                                    .projectID = txtProjectID.Text.Trim
                                    If (DtSet.Tables(0).Rows(iRecCount)(0)) Is System.DBNull.Value Then
                                        .sequenceNo = "0"
                                    Else
                                        .sequenceNo = CType(DtSet.Tables(0).Rows(iRecCount)(0), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(1)) Is System.DBNull.Value Then
                                        .descriptionOfEquipment = String.Empty
                                    Else
                                        .descriptionOfEquipment = CType(DtSet.Tables(0).Rows(iRecCount)(1), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(2)) Is System.DBNull.Value Then
                                        .serialIDNo = String.Empty
                                    Else
                                        .serialIDNo = CType(DtSet.Tables(0).Rows(iRecCount)(2), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(3)) Is System.DBNull.Value Then
                                        .location = String.Empty
                                    Else
                                        .location = CType(DtSet.Tables(0).Rows(iRecCount)(3), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(4)) Is System.DBNull.Value Then
                                        .manufacture = String.Empty
                                    Else
                                        .manufacture = CType(DtSet.Tables(0).Rows(iRecCount)(4), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(5)) Is System.DBNull.Value Then
                                        .SWL_WWL_MGW = String.Empty
                                    Else
                                        .SWL_WWL_MGW = CType(DtSet.Tables(0).Rows(iRecCount)(5), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(6)) Is System.DBNull.Value Then
                                        .dimensional = String.Empty
                                    Else
                                        .dimensional = CType(DtSet.Tables(0).Rows(iRecCount)(6), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(7)) Is System.DBNull.Value Then
                                        .defectFound = String.Empty
                                    Else
                                        .defectFound = CType(DtSet.Tables(0).Rows(iRecCount)(7), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(8)) Is System.DBNull.Value Then
                                        .result = String.Empty
                                    Else
                                        .result = CType(DtSet.Tables(0).Rows(iRecCount)(8), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(9)) Is System.DBNull.Value Then
                                        Throw New Exception("Kolom Exam_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                    Else
                                        Dim strDate As String
                                        strDate = CType(DtSet.Tables(0).Rows(iRecCount)(9), String)

                                        Try
                                            .examDate = DateSerial(Convert.ToInt32(strDate.Substring(6, 4)), Convert.ToInt32(strDate.Substring(3, 2)), Convert.ToInt32(strDate.Substring(0, 2)))
                                        Catch
                                            Throw New Exception("Kolom Exam_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                        End Try
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(10)) Is System.DBNull.Value Then
                                        Throw New Exception("Kolom Expire_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                    Else
                                        Dim strDate As String
                                        strDate = CType(DtSet.Tables(0).Rows(iRecCount)(10), String)

                                        Try
                                            .expireDate = DateSerial(Convert.ToInt32(strDate.Substring(6, 4)), Convert.ToInt32(strDate.Substring(3, 2)), Convert.ToInt32(strDate.Substring(0, 2)))
                                        Catch
                                            Throw New Exception("Kolom Expire_Date untuk Description of Equipment " + .descriptionOfEquipment.Trim + " belum terisi dengan benar. Format yang digunakan adalah: dd-MM-yyyy.")
                                        End Try
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(11)) Is System.DBNull.Value Then
                                        .reportNo = String.Empty
                                    Else
                                        .reportNo = CType(DtSet.Tables(0).Rows(iRecCount)(11), String)
                                    End If

                                    .typeOfInspectionSCode = String.Empty

                                    If (DtSet.Tables(0).Rows(iRecCount)(12)) Is System.DBNull.Value Then
                                        .isToiV = False
                                    Else
                                        If CType(DtSet.Tables(0).Rows(iRecCount)(12), String) = "Yes" Then
                                            .isToiV = True
                                        Else
                                            .isToiV = False
                                        End If
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(13)) Is System.DBNull.Value Then
                                        .isToiN = False
                                    Else
                                        If CType(DtSet.Tables(0).Rows(iRecCount)(13), String) = "Yes" Then
                                            .isToiN = True
                                        Else
                                            .isToiN = False
                                        End If
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(14)) Is System.DBNull.Value Then
                                        .isToiT = False
                                    Else
                                        If CType(DtSet.Tables(0).Rows(iRecCount)(14), String) = "Yes" Then
                                            .isToiT = True
                                        Else
                                            .isToiT = False
                                        End If
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(15)) Is System.DBNull.Value Then
                                        .interval = String.Empty
                                    Else
                                        .interval = CType(DtSet.Tables(0).Rows(iRecCount)(15), String)
                                    End If

                                    If (DtSet.Tables(0).Rows(iRecCount)(16)) Is System.DBNull.Value Then
                                        .remarks = String.Empty
                                    Else
                                        .remarks = CType(DtSet.Tables(0).Rows(iRecCount)(16), String)
                                    End If

                                    .detailReportSection = ""
                                    .userIDinsert = MyBase.LoggedOnUserID
                                    .userIDupdate = MyBase.LoggedOnUserID

                                    If (DtSet.Tables(0).Rows(iRecCount)(17)) Is System.DBNull.Value Then
                                        .fileName = String.Empty
                                        .fileExtension = String.Empty
                                    Else
                                        Dim strFileURL As String = (DtSet.Tables(0).Rows(iRecCount)(17)).ToString.Trim
                                        If strFileURL.Trim.Length > 0 Then
                                            Dim fileExt As String, fileName As String
                                            SOI_FileDetail.Value = strFileURL.Trim
                                            fileExt = Path.GetExtension(SOI_FileDetail.Value.Trim)
                                            fileName = Common.BussinessRules.ID.GenerateIDNumber("SummaryOfInspection", "summaryOfInspectionID") + fileExt.Trim
                                            Dim Pathdb As String = Common.Methods.GetCommonCode("SOIDIR", "FILEDIR").Trim
                                            Dim fNotNew As Boolean = False
                                            Dim nmFile As String
                                            Try
                                                .fileName = fileName.Trim
                                                .fileExtension = fileExt.Trim

                                                '// validate if the file exist
                                                nmFile = Pathdb + fileName
                                                If txtFileUrl.Value.Trim.Length > 0 Then
                                                    If File.Exists(nmFile) Then
                                                        File.Delete(nmFile)
                                                    End If
                                                    SOI_FileDetail.PostedFile.SaveAs(nmFile)
                                                End If
                                            Catch ex As Exception
                                                commonFunction.MsgBox(Me, "Upload File tidak berhasil.")
                                                Exit Sub
                                            End Try
                                        Else
                                            .fileName = String.Empty
                                            .fileExtension = String.Empty
                                        End If
                                    End If

                                    .Insert()
                                    iRecCount = iRecCount + 1
                                End With
                            End While
                        Catch ex As Exception
                            MyConnection.Close()
                            Throw ex
                        End Try

                        PrepareScreen(_VisiblePanelID.Trim, True)
                    End If
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.CheckListCompletionReport_PanelID
                    Dim oBR As New Common.BussinessRules.CheckListOfCompletionReport
                    With oBR
                        .CCRID = CCR_txtCCRID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .sequenceNo = CCR_txtSequenceNo.Text.Trim
                        .description = CCR_txtDescription.Text.Trim
                        .typeOfReportSCode = CCR_ddlTypeOfReport.SelectedValue.Trim
                        .preparedBy = CCR_txtPreparedByName.Text.Trim
                        .preparedDate = CCR_calPreparedDate.selectedDate
                        .reportNo = CCR_txtReportNo.Text.Trim
                        .remarks = CCR_txtRemarks.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then CCR_txtCCRID.Text = .CCRID
                            PrepareScreen(_VisiblePanelID.Trim, True)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.TimeSheet_PanelID
                    Dim oBR As New Common.BussinessRules.TimeSheet
                    With oBR
                        If TS_chkIsAll.Checked Then
                            For Each repItemHd As RepeaterItem In repDateInMonthHd.Items
                                Dim TS_lblDateInMonthHd As Label = CType(repItemHd.FindControl("TS_lblDateInMonthHd"), Label)
                                Dim TS_ddlWorkingTypeAll As DropDownList = CType(repItemHd.FindControl("TS_ddlWorkingTypeAll"), DropDownList)

                                For Each lvwItem As ListViewItem In lvwTimeSheet.Items
                                    Dim _repDateInMonthDt As Repeater = CType(lvwItem.FindControl("repDateInMonthDt"), Repeater)

                                    For Each repItem As RepeaterItem In _repDateInMonthDt.Items
                                        Dim TS_lblDateInMonthDt As Label = CType(repItem.FindControl("TS_lblDateInMonthDt"), Label)
                                        Dim TS_lblTimeSheetID As Label = CType(repItem.FindControl("TS_lblTimeSheetID"), Label)
                                        Dim TS_lblProjectResourceID As Label = CType(repItem.FindControl("TS_lblProjectResourceID"), Label)
                                        Dim TS_chkIsNew As CheckBox = CType(repItem.FindControl("TS_chkIsNew"), CheckBox)

                                        If TS_lblDateInMonthDt.Text.Trim = TS_lblDateInMonthHd.Text.Trim Then
                                            .timeSheetID = TS_lblTimeSheetID.Text.Trim
                                            .projectResourceID = TS_lblProjectResourceID.Text.Trim
                                            .workingDate = DateSerial(CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), CInt(TS_lblDateInMonthDt.Text))
                                            .workingTypeSCode = TS_ddlWorkingTypeAll.SelectedValue
                                            .remarks = ""
                                            .userIDinsert = MyBase.LoggedOnUserID.Trim
                                            .userIDupdate = MyBase.LoggedOnUserID.Trim

                                            If TS_chkIsNew.Checked = False Then
                                                If .workingTypeSCode <> "" Then
                                                    .Update()
                                                End If
                                            Else
                                                If .workingTypeSCode <> "" Then
                                                    .Insert()
                                                End If
                                            End If
                                        End If
                                    Next
                                Next
                            Next
                        Else
                            For Each lvwItem As ListViewItem In lvwTimeSheet.Items
                                Dim _repDateInMonthDt As Repeater = CType(lvwItem.FindControl("repDateInMonthDt"), Repeater)

                                For Each repItem As RepeaterItem In _repDateInMonthDt.Items
                                    Dim TS_lblDateInMonthDt As Label = CType(repItem.FindControl("TS_lblDateInMonthDt"), Label)
                                    Dim TS_lblTimeSheetID As Label = CType(repItem.FindControl("TS_lblTimeSheetID"), Label)
                                    Dim TS_lblProjectResourceID As Label = CType(repItem.FindControl("TS_lblProjectResourceID"), Label)
                                    Dim TS_ddlWorkingType As DropDownList = CType(repItem.FindControl("TS_ddlWorkingType"), DropDownList)
                                    Dim TS_chkIsNew As CheckBox = CType(repItem.FindControl("TS_chkIsNew"), CheckBox)

                                    .timeSheetID = TS_lblTimeSheetID.Text.Trim
                                    .projectResourceID = TS_lblProjectResourceID.Text.Trim
                                    .workingDate = DateSerial(CInt(TS_ddlYear.SelectedValue), CInt(TS_ddlMonth.SelectedValue), CInt(TS_lblDateInMonthDt.Text))
                                    .workingTypeSCode = TS_ddlWorkingType.SelectedValue
                                    .remarks = ""
                                    .userIDinsert = MyBase.LoggedOnUserID.Trim
                                    .userIDupdate = MyBase.LoggedOnUserID.Trim

                                    If TS_chkIsNew.Checked = False Then
                                        .Update()
                                    Else
                                        If .workingTypeSCode <> "" Then
                                            .Insert()
                                        End If
                                    End If
                                Next
                            Next
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(Common.Constants.ReportTypePanelID.TimeSheet_PanelID)

                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = ""
                        .remarks = DPR_txtDescription.Text.Trim
                        .reportDate = DPR_calReportDate.selectedDate
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DPR_txtDailyReportHdID.Text = .dailyReportHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DPR_txtDailyReportDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .dailyReportHdID = DPR_txtDailyReportHdID.Text.Trim
                        .sequenceNo = DPR_txtSequenceNo.Text.Trim
                        .weatherConditionSCode = DPR_ddlWeatherCondition.SelectedValue
                        .description = DPR_txtDescription.Text.Trim
                        .currentQty = CDec(DPR_txtQtyCurrent.Text.Trim)
                        .beginningQty = CDec(DPR_txtQtyPrevious.Text.Trim)
                        .endingQty = .beginningQty + .currentQty
                        .currentUOM = DPR_txtUOMCurrent.Text.Trim
                        .beginningUOM = DPR_txtUOMPrevious.Text.Trim
                        .endingUOM = DPR_txtUOMCumulative.Text.Trim
                        .materialDetail = DPR_txtMaterialDetail.Text.Trim
                        .result = ""
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DPR_txtDailyReportDtID.Text = .dailyReportDtID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.DailyProgressReportMPI_PanelID
                    Dim oHd As New Common.BussinessRules.DailyReportHd
                    With oHd
                        .dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = ""
                        .remarks = DIR_txtDescription.Text.Trim
                        .reportDate = DIR_calReportDate.selectedDate
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DIR_txtDailyReportHdID.Text = .dailyReportHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DailyReportDt
                    With oDt
                        .dailyReportDtID = DIR_txtDailyReportDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .dailyReportHdID = DIR_txtDailyReportHdID.Text.Trim
                        .sequenceNo = DIR_txtSequenceNo.Text.Trim
                        .weatherConditionSCode = DIR_ddlWeatherCondition.SelectedValue
                        .description = DIR_txtDescription.Text.Trim
                        .currentQty = CDec(DIR_txtQty.Text.Trim)
                        .beginningQty = 0D
                        .endingQty = 0D + .currentQty
                        .result = DIR_txtResult.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DIR_txtDailyReportDtID.Text = .dailyReportDtID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.DrillPipeReportHd
                    With oHd
                        .drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .inspectionSpecID = DP_txtSpecificationID.Text.Trim
                        .reportNo = DP_txtReportNo.Text.Trim
                        .reportDate = DP_calReportDate.selectedDate
                        .remarks = ""
                        .size = DP_txtSize.Text.Trim
                        .weight = DP_txtWeight.Text.Trim
                        .grade = DP_txtGrade.Text.Trim
                        .connection = DP_txtConnection.Text.Trim
                        .range = DP_txtRange.Text.Trim
                        .nominalWT = DP_txtNominalWT.Text.Trim
                        .captionTemplateHdID = DP_ddlCaptionTemplate.SelectedValue.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then DP_txtDrillPipeReportHdID.Text = .drillPipeReportHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.DrillPipeReportDt
                    With oDt
                        .drillPipeReportDtID = DP_txtDrillPipeReportDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .drillPipeReportHdID = DP_txtDrillPipeReportHdID.Text.Trim
                        .sequenceNo = DP_txtSequenceNo.Text.Trim
                        .serialNo = DP_txtSerialNo.Text.Trim
                        .remarks = DP_ddlRemarks.SelectedValue.Trim + "^" + DP_txtRemarks.Text.Trim
                        .bod001CaptionID = DP_lblBod001Caption.ToolTip.Trim
                        .bod002CaptionID = DP_lblBod002Caption.ToolTip.Trim
                        .bod003CaptionID = DP_lblBod003Caption.ToolTip.Trim
                        .bod004CaptionID = DP_lblBod004Caption.ToolTip.Trim
                        .bod005CaptionID = DP_lblBod005Caption.ToolTip.Trim
                        .bod006CaptionID = DP_lblBod006Caption.ToolTip.Trim
                        .bod007CaptionID = DP_lblBod007Caption.ToolTip.Trim
                        .bod008CaptionID = DP_lblBod008Caption.ToolTip.Trim
                        .bod009CaptionID = DP_lblBod009Caption.ToolTip.Trim
                        .bod001Value = DP_txtBod001Value.Text.Trim
                        .bod002Value = DP_txtBod002Value.Text.Trim
                        .bod003Value = DP_txtBod003Value.Text.Trim
                        .bod004Value = DP_txtBod004Value.Text.Trim
                        .bod005Value = DP_txtBod005Value.Text.Trim
                        .bod006Value = DP_txtBod006Value.Text.Trim
                        .bod007Value = DP_txtBod007Value.Text.Trim
                        .bod008Value = DP_txtBod008Value.Text.Trim
                        .bod009Value = DP_txtBod009Value.Text.Trim
                        .pin001CaptionID = DP_lblPin001Caption.ToolTip.Trim
                        .pin002CaptionID = DP_lblPin002Caption.ToolTip.Trim
                        .pin003CaptionID = DP_lblPin003Caption.ToolTip.Trim
                        .pin004CaptionID = DP_lblPin004Caption.ToolTip.Trim
                        .pin005CaptionID = DP_lblPin005Caption.ToolTip.Trim
                        .pin006CaptionID = DP_lblPin006Caption.ToolTip.Trim
                        .pin007CaptionID = DP_lblPin007Caption.ToolTip.Trim
                        .pin008CaptionID = DP_lblPin008Caption.ToolTip.Trim
                        .pin009CaptionID = DP_lblPin009Caption.ToolTip.Trim
                        .pin010CaptionID = DP_lblPin010Caption.ToolTip.Trim
                        .pin011CaptionID = DP_lblPin011Caption.ToolTip.Trim
                        .pin001Value = DP_txtPin001Value.Text.Trim
                        .pin002Value = DP_txtPin002Value.Text.Trim
                        .pin003Value = DP_txtPin003Value.Text.Trim
                        .pin004Value = DP_txtPin004Value.Text.Trim
                        .pin005Value = DP_txtPin005Value.Text.Trim
                        .pin006Value = DP_txtPin006Value.Text.Trim
                        .pin007Value = DP_txtPin007Value.Text.Trim
                        .pin008Value = DP_txtPin008Value.Text.Trim
                        .pin009Value = DP_txtPin009Value.Text.Trim
                        .pin010Value = DP_txtPin010Value.Text.Trim
                        .pin011Value = DP_txtPin011Value.Text.Trim
                        .box001CaptionID = DP_lblBox001Caption.ToolTip.Trim
                        .box002CaptionID = DP_lblBox002Caption.ToolTip.Trim
                        .box003CaptionID = DP_lblBox003Caption.ToolTip.Trim
                        .box004CaptionID = DP_lblBox004Caption.ToolTip.Trim
                        .box005CaptionID = DP_lblBox005Caption.ToolTip.Trim
                        .box006CaptionID = DP_lblBox006Caption.ToolTip.Trim
                        .box007CaptionID = DP_lblBox007Caption.ToolTip.Trim
                        .box008CaptionID = DP_lblBox008Caption.ToolTip.Trim
                        .box009CaptionID = DP_lblBox009Caption.ToolTip.Trim
                        .box010CaptionID = DP_lblBox010Caption.ToolTip.Trim
                        .box011CaptionID = DP_lblBox011Caption.ToolTip.Trim
                        .box001Value = DP_txtBox001Value.Text.Trim
                        .box002Value = DP_txtBox002Value.Text.Trim
                        .box003Value = DP_txtBox003Value.Text.Trim
                        .box004Value = DP_txtBox004Value.Text.Trim
                        .box005Value = DP_txtBox005Value.Text.Trim
                        .box006Value = DP_txtBox006Value.Text.Trim
                        .box007Value = DP_txtBox007Value.Text.Trim
                        .box008Value = DP_txtBox008Value.Text.Trim
                        .box009Value = DP_txtBox009Value.Text.Trim
                        .box010Value = DP_txtBox010Value.Text.Trim
                        .box011Value = DP_txtBox011Value.Text.Trim
                        .isPinHB = DP_chkIsPinHB.Checked
                        .isBoxHB = DP_chkIsBoxHB.Checked
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If Len(DP_txtSerialNo.Text.Trim) > 0 Then
                                If .Insert() Then DP_txtDrillPipeReportDtID.Text = .drillPipeReportDtID
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            End If
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.InspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.InspectionReportHd
                    With oHd
                        .inspectionReportHdID = INS_txtInspectionReportHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = INS_txtReportNo.Text.Trim
                        .reportDate = INS_calReportDate.selectedDate
                        .inspectionReportTypeSCode = INS_ddlInspectionReportType.SelectedValue.Trim
                        .isMPI = INS_chkMPI.Checked
                        .isVisualThread = INS_chkVTI.Checked
                        .isDimensional = INS_chkDIM.Checked
                        .isBlacklightConnection = INS_chkBLC.Checked
                        .isVisualBodyInspection = INS_chkVBI.Checked
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then INS_txtInspectionReportHdID.Text = .inspectionReportHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    If INS_txtDescription.Text.Trim.Length > 0 Then
                        Dim oDt As New Common.BussinessRules.InspectionReportDt
                        With oDt
                            .inspectionReportDtID = INS_txtInspectionReportDTID.Text
                            If .SelectOne.Rows.Count > 0 Then
                                isNew = False
                            Else
                                isNew = True
                            End If
                            .inspectionReportHdID = INS_txtInspectionReportHdID.Text.Trim
                            .description = INS_txtDescription.Text.Trim
                            .serialNo = INS_txtSerialNo.Text.Trim
                            .totalLength = INS_txtTotalLength.Text.Trim
                            .IDdescription = INS_txtIDDescription.Text.Trim
                            .connectionSizePin = INS_txtConnectionSizePin.Text.Trim
                            .connectionODPin = INS_txtConnectionODPin.Text.Trim
                            .connectionSizeBox = INS_txtConnectionSizeBox.Text.Trim
                            .connectionODBox = INS_txtConnectionODBox.Text.Trim
                            .elevatorGrooveDiaPin = INS_txtElevatorGrooveDiaPin.Text.Trim
                            .elevatorGrooveDepthPin = INS_txtElevatorGrooveDepthPin.Text.Trim
                            .elevatorGrooveDiaBox = INS_txtElevatorGrooveDiaBox.Text.Trim
                            .elevatorGrooveDepthBox = INS_txtElevatorGrooveDepthBox.Text.Trim
                            .BBackRGrooveDiaPin = INS_txtBBackRGrooveDiaPin.Text.Trim
                            .BBackRGrooveLengthPin = INS_txtBBackRGrooveLengthPin.Text.Trim
                            .BBackRGrooveDiaBox = INS_txtBBackRGrooveDiaBox.Text.Trim
                            .BBackRGrooveLengthBox = INS_txtBBackRGrooveLengthBox.Text.Trim
                            .bevelDiaPin = INS_txtBevelDiameterPin.Text.Trim
                            .bevelDiaBox = INS_txtBevelDiameterBox.Text.Trim
                            .threadLengthPin = INS_txtThreadLengthPin.Text.Trim
                            .threadLengthBox = INS_txtThreadLengthBox.Text.Trim
                            .counterBoreDiaPin = INS_txtCounterBoreDiaPin.Text.Trim
                            .counterBoreDepthPin = INS_txtCounterBoreDepthPin.Text.Trim
                            .counterBoreDiaBox = INS_txtCounterBoreDiaBox.Text.Trim
                            .counterBoreDepthBox = INS_txtCounterBoreDepthBox.Text.Trim
                            .centerPadDiaPin = INS_txtCenterPadDiaPin.Text.Trim
                            .centerPadDepthPin = INS_txtCenterPadDepthPin.Text.Trim
                            .centerPadDiaBox = INS_txtCenterPadDiaBox.Text.Trim
                            .centerPadDepthBox = INS_txtCenterPadDepthBox.Text.Trim
                            .tongSpacePin = INS_txtTongSpacePin.Text.Trim
                            .tongSpaceBox = INS_txtTongSpaceBox.Text.Trim
                            .conditionPin = INS_txtConditionPin.Text.Trim
                            .conditionBox = INS_txtConditionBox.Text.Trim
                            .BSR = INS_txtBSR.Text.Trim
                            .remarksPin = INS_txtRemarksPin.Text.Trim
                            .remarksBox = INS_txtRemarksBox.Text.Trim
                            .HBPin = INS_txtHBPin.Text.Trim
                            .HBBox = INS_txtHBBox.Text.Trim
                            .HBCenterPad = INS_txtHBCenterPad.Text.Trim
                            .userIDinsert = MyBase.LoggedOnUserID
                            .userIDupdate = MyBase.LoggedOnUserID
                            If isNew Then
                                If .Insert() Then INS_txtInspectionReportDTID.Text = .inspectionReportDtID.Trim
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            Else
                                .Update()
                                PrepareScreen(_VisiblePanelID.Trim, False, False)
                            End If
                        End With
                        oDt.Dispose()
                        oDt = Nothing
                    End If                    
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.ServiceReport_PanelID
                    Dim oBR As New Common.BussinessRules.ServiceReport
                    With oBR
                        .serviceReportID = SR_txtServiceReportID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .serviceReportForSCode = SR_ddlServiceReportFor.SelectedValue.Trim
                        .serviceReportDate = SR_calServiceReportDate.selectedDate
                        .projectID = txtProjectID.Text.Trim
                        .typeOfInspection = SR_txtTypeOfInspection.Text.Trim
                        .mdManufacturer = SR_txtManufacturer.Text.Trim
                        .mdTypeOfPipe = SR_txtTypeOfPipe.Text.Trim
                        .mdPipeOD = SR_txtPipeOD.Text.Trim
                        .mdPipeGrade = SR_txtPipeGrade.Text.Trim
                        .mdPipeWeight = SR_txtPipeWeight.Text.Trim
                        .mdThreadConnection = SR_txtThreadConnection.Text.Trim
                        .mdRange = SR_txtRange.Text.Trim
                        .mdTotalInspected = SR_txtTotalInspected.Text.Trim
                        .mdTotalAccepted = SR_txtTotalAccepted.Text.Trim
                        .mdNotes = SR_txtMaterialDescription.Text.Trim
                        .result = SR_txtResult.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID

                        If isNew Then
                            If .Insert() Then SR_txtServiceReportID.Text = .serviceReportID.Trim
                            PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, True)
                        Else
                            .Update()
                            PrepareScreen(Common.Constants.ReportTypePanelID.ServiceReport_PanelID, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBR As New Common.BussinessRules.CertificateInspection
                    With oBR
                        .certificateInspectionID = COI_txtCertificateInspectionID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .certificateNo = COI_txtCertificateNo.Text.Trim
                        .certificateDate = COI_calCertificateDate.selectedDate
                        .owner = COI_txtOwner.Text.Trim
                        .userLabel = COI_txtUser.Text.Trim
                        .location = COI_txtLocation.Text.Trim
                        .description = COI_txtDescription.Text.Trim
                        .serialNo = COI_txtSerialNo.Text.Trim
                        .maxGrossWeightR = COI_txtMaxGossWeightR.Text.Trim
                        .loadTest = COI_txtLoadTest.Text.Trim
                        .duration = COI_txtDuration.Text.Trim
                        .specification = COI_txtSpecification.Text.Trim
                        .examination = COI_txtExamination.Text.Trim
                        .result = COI_txtResult.Text.Trim
                        .inspectionDate = COI_caInspectionDate.selectedDate
                        .expiredDate = COI_calExpiredDate.selectedDate
                        .notes = COI_txtNotes.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then COI_txtCertificateInspectionID.Text = .certificateInspectionID
                            UploadPic_COI(1)
                            UploadPic_COI(2)
                            UploadPic_COI(3)
                            PrepareScreen(_VisiblePanelID.Trim, True)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.MPIReport_PanelID
                    Dim oBR As New Common.BussinessRules.MPIHd
                    With oBR
                        .MPIHdID = MPI_txtMPIHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .MPITypeSCode = MPI_ddlMPIType.SelectedValue.Trim
                        .reportDate = MPI_calReportDate.selectedDate
                        .reportNo = MPI_txtReportNo.Text.Trim
                        .serialNo = MPI_txtSerialNo.Text.Trim
                        .expiredDate = MPI_calExpiredDate.selectedDate
                        .description = MPI_txtDescription.Text.Trim
                        .ACIsASME = MPI_chkACIsASME.Checked
                        .ACIsAPISpec = MPI_chkACIsAPISpec.Checked
                        .ACIsDS1 = MPI_chkIsACDS1.Checked
                        .ACIsOther = MPI_chkIsACOther.Checked
                        .ACASMEDescription = MPI_txtACASMEDescription.Text.Trim
                        .ACAPISpecDescription = MPI_txtACAPISpecDescription.Text.Trim
                        .ACDS1Description = MPI_txtACDS1Description.Text.Trim
                        .ACOtherDescription = MPI_txtACOtherDescription.Text.Trim
                        .qty = MPI_txtQty.Text.Trim
                        .dimension = MPI_txtDimension.Text.Trim
                        .areaInspection = MPI_txtAreaInspection.Text.Trim
                        .material = MPI_txtMaterial.Text.Trim
                        .application = MPI_txtApplication.Text.Trim
                        .surfaceCondition = MPI_txtSurfaceCondition.Text.Trim
                        .contrast = MPI_txtContrast.Text.Trim
                        .metalSurfaceTemp = MPI_txtMetalSurfaceTemp.Text.Trim
                        .magneticParticle = MPI_txtMagneticParticle.Text.Trim
                        .materialThickness = MPI_txtMaterialThickness.Text.Trim
                        .cleaner = MPI_txtCleaner.Text.Trim
                        .setCalibration = MPI_txtSetCalibration.Text.Trim
                        .penetrant = MPI_txtPenetrant.Text.Trim
                        .poleSpacing = MPI_txtPoleSpacing.Text.Trim
                        .developer = MPI_txtDeveloper.Text.Trim
                        .yokeSCode = MPI_rbtnlYoke.SelectedValue.Trim
                        .coilSCode = MPI_rbtnlCoil.SelectedValue.Trim
                        .isBlacklight = (MPI_rbtnlBlacklight.SelectedValue = "Yes")
                        .isRods = (MPI_rbtnlRods.SelectedValue = "Yes")
                        .fluorescentSCode = MPI_rbtnlFluorescent.SelectedValue.Trim
                        .contrastBWSCode = MPI_rbtnlContrastBW.SelectedValue.Trim
                        .isDyePenetrant = (MPI_rbtnlDyePenetrant.SelectedValue = "Yes")
                        .isWireBrush = (MPI_rbtnlWireBrush.SelectedValue = "Yes")
                        .isBlastCleaning = (MPI_rbtnlBlastCleaning.SelectedValue = "Yes")
                        .isGrinding = (MPI_rbtnlGrinding.SelectedValue = "Yes")
                        .isMachining = (MPI_rbtnlMachining.SelectedValue = "Yes")
                        .inspectionResult = MPI_txtInspectionResult.Text.Trim
                        .notes = MPI_txtNotes.Text.Trim
                        .yokeSerialNo = MPI_txtYokeSerialNo.Text.Trim
                        .coilSerialNo = MPI_txtCoilSerialNo.Text.Trim
                        .rodsSerialNo = MPI_txtRodsSerialNo.Text.Trim
                        .blacklightSerialNo = MPI_txtBlacklightSerialNo.Text.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then MPI_txtMPIHdID.Text = .MPIHdID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    Dim oHd As New Common.BussinessRules.UTSpotCheckHd
                    With oHd
                        .UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = UTSC_txtReportNo.Text.Trim
                        .reportDate = UTSC_calReportDate.selectedDate
                        .nominalWT = String.Empty
                        .minimalWT = String.Empty
                        .UTSpotTypeSCode = UTSC_ddlUTSpotType.SelectedValue.Trim
                        .Description = UTSC_txtDescription.Text.Trim
                        .SerialNo = UTSC_txtSerialNo.Text.Trim
                        .Material = UTSC_txtMaterial.Text.Trim
                        .Equipment = UTSC_txtEquipment.Text.Trim
                        .Couplant = UTSC_txtCouplant.Text.Trim
                        .ProbeType = UTSC_txtProbeType.Text.Trim
                        .ImpactDevice = UTSC_txtImpactDevice.Text.Trim
                        .ReferenceLevel = UTSC_txtReferenceLevel.Text.Trim
                        .Frequency = UTSC_txtFrequency.Text.Trim
                        .CalReference = UTSC_txtCalReference.Text.Trim
                        .isAreaSpotCylinder = UTSC_chkIsAreaSpotCylinder.Checked
                        .isAreaSpotSquare = UTSC_chkIsAreaSpotSquare.Checked
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        .isUTSpotArea = False
                        If isNew Then
                            If .Insert() Then UTSC_txtUTSpotCheckHdID.Text = .UTSpotCheckHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    If UTSC_txtStructureTallyNo.Text.Trim.Length > 0 Then
                        Dim oDt As New Common.BussinessRules.UTSpotCheckDt
                        With oDt
                            .UTSpotCheckDtID = UTSC_txtUTSpotCheckDtID.Text
                            If .SelectOne.Rows.Count > 0 Then
                                isNew = False
                            Else
                                isNew = True
                            End If
                            .UTSpotCheckHdID = UTSC_txtUTSpotCheckHdID.Text.Trim
                            .structureTallyNo = UTSC_txtStructureTallyNo.Text.Trim
                            .location = String.Empty
                            .size = UTSC_txtSize.Text.Trim
                            .length = UTSC_txtLength.Text.Trim
                            .wallThickness1 = UTSC_txtWallThickness1.Text.Trim
                            .wallThickness2 = UTSC_txtWallThickness2.Text.Trim
                            .wallThickness3 = UTSC_txtWallThickness3.Text.Trim
                            .wallThickness4 = UTSC_txtWallThickness4.Text.Trim
                            .hardnessTest1 = UTSC_txtHardnessTest1.Text.Trim
                            .hardnessTest2 = UTSC_txtHardnessTest2.Text.Trim
                            .hardnessTest3 = UTSC_txtHardnessTest3.Text.Trim
                            .hardnessTest4 = UTSC_txtHardnessTest4.Text.Trim
                            .remark = UTSC_txtRemark.Text.Trim
                            .userIDinsert = MyBase.LoggedOnUserID
                            .userIDupdate = MyBase.LoggedOnUserID
                            If isNew Then
                                If .Insert() Then UTSC_txtUTSpotCheckDtID.Text = .UTSpotCheckDtID
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            Else
                                .Update()
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            End If
                        End With
                        oDt.Dispose()
                        oDt = Nothing
                    End If                    
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.UTSpotArea_PanelID
                    Dim oHd As New Common.BussinessRules.UTSpotCheckHd
                    With oHd
                        .UTSpotCheckHdID = UTSA_txtUTSpotCheckHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = UTSA_txtReportNo.Text.Trim
                        .reportDate = UTSA_calReportDate.selectedDate
                        .nominalWT = String.Empty
                        .minimalWT = String.Empty
                        .UTSpotTypeSCode = UTSA_ddlUTSpotType.SelectedValue.Trim
                        .Description = UTSA_txtDescription.Text.Trim
                        .SerialNo = String.Empty
                        .Material = String.Empty
                        .Equipment = UTSA_txtEquipment.Text.Trim
                        .Couplant = UTSA_txtCouplant.Text.Trim
                        .ProbeType = UTSA_txtProbe.Text.Trim
                        .ImpactDevice = String.Empty
                        .ReferenceLevel = UTSA_txtReferenceLevel.Text.Trim
                        .Frequency = UTSA_txtFrequency.Text.Trim
                        .CalReference = UTSA_txtCalReference.Text.Trim
                        .isAreaSpotCylinder = False
                        .isAreaSpotSquare = False
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        .isUTSpotArea = True
                        If isNew Then
                            If .Insert() Then UTSA_txtUTSpotCheckHdID.Text = .UTSpotCheckHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    If UTSA_txtPipeNo.Text.Trim.Length > 0 Then
                        Dim oDt As New Common.BussinessRules.UTSpotAreaDt
                        With oDt
                            .UTSpotAreaDtID = UTSA_txtUTSpotAreaDtID.Text
                            If .SelectOne.Rows.Count > 0 Then
                                isNew = False
                            Else
                                isNew = True
                            End If
                            .UTSpotCheckHdID = UTSA_txtUTSpotCheckHdID.Text.Trim
                            .pipeNo = UTSA_txtPipeNo.Text.Trim
                            .conditionResultPin = UTSA_txtConditionResultPin.Text.Trim
                            .conditionResultBox = UTSA_txtConditionResultBox.Text.Trim
                            .remarkPin = UTSA_txtRemarkPin.Text.Trim
                            .remarkBox = UTSA_txtRemarkBox.Text.Trim
                            .userIDinsert = MyBase.LoggedOnUserID
                            .userIDupdate = MyBase.LoggedOnUserID
                            If isNew Then
                                If .Insert() Then UTSA_txtUTSpotAreaDtID.Text = .UTSpotAreaDtID
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            Else
                                .Update()
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            End If
                        End With
                        oDt.Dispose()
                        oDt = Nothing
                    End If                    
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    Dim oHd As New Common.BussinessRules.HardnessTestHd
                    With oHd
                        .hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = HT_txtReportNo.Text.Trim
                        .reportDate = HT_calReportDate.selectedDate
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then HT_txtHardnessTestHdID.Text = .hardnessTestHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    Dim oDt As New Common.BussinessRules.HardnessTestDt
                    With oDt
                        .hardnessTestDtID = HT_txtHardnessTestDtID.Text
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .hardnessTestHdID = HT_txtHardnessTestHdID.Text.Trim
                        .pipeNo = HT_txtPipeNo.Text.Trim
                        .locationSCode = HT_ddlLocation.SelectedValue.Trim
                        .HRB1 = CDec(IIf(IsNumeric(HT_txtHRB1.Text.Trim), HT_txtHRB1.Text.Trim, 0))
                        .HRB2 = CDec(IIf(IsNumeric(HT_txtHRB2.Text.Trim), HT_txtHRB2.Text.Trim, 0))
                        .HRB3 = CDec(IIf(IsNumeric(HT_txtHRB3.Text.Trim), HT_txtHRB3.Text.Trim, 0))
                        .HRB4 = CDec(IIf(IsNumeric(HT_txtHRB4.Text.Trim), HT_txtHRB4.Text.Trim, 0))
                        .HRBAvg = (CDec(IIf(IsNumeric(HT_txtHRB1.Text.Trim), HT_txtHRB1.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHRB2.Text.Trim), HT_txtHRB2.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHRB3.Text.Trim), HT_txtHRB3.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHRB4.Text.Trim), HT_txtHRB4.Text.Trim, 0))) / 4
                        .HB1 = CDec(IIf(IsNumeric(HT_txtHB1.Text.Trim), HT_txtHB1.Text.Trim, 0))
                        .HB2 = CDec(IIf(IsNumeric(HT_txtHB2.Text.Trim), HT_txtHB2.Text.Trim, 0))
                        .HB3 = CDec(IIf(IsNumeric(HT_txtHB3.Text.Trim), HT_txtHB3.Text.Trim, 0))
                        .HB4 = CDec(IIf(IsNumeric(HT_txtHB4.Text.Trim), HT_txtHB4.Text.Trim, 0))
                        .HBAvg = (CDec(IIf(IsNumeric(HT_txtHB1.Text.Trim), HT_txtHB1.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHB2.Text.Trim), HT_txtHB2.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHB3.Text.Trim), HT_txtHB3.Text.Trim, 0)) + _
                                CDec(IIf(IsNumeric(HT_txtHB4.Text.Trim), HT_txtHB4.Text.Trim, 0))) / 4
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then HT_txtHardnessTestDtID.Text = .hardnessTestDtID
                            PrepareScreen(_VisiblePanelID.Trim, True, False)
                        Else
                            .Update()
                            PrepareScreen(_VisiblePanelID.Trim, False, False)
                        End If
                    End With
                    oDt.Dispose()
                    oDt = Nothing
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID
                    Dim oHd As New Common.BussinessRules.ThoroughVisualReportHd
                    With oHd
                        .tviHdID = TVI_txtTVIHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = TVI_txtReportNo.Text.Trim
                        .reportDate = TVI_calReportDate.selectedDate
                        .tviTypeSCode = TVI_ddlTVIType.SelectedValue.Trim
                        .Description = TVI_txtDescription.Text.Trim
                        .SerialNo = TVI_txtSerialNo.Text.Trim
                        .WLLSWL = TVI_txtWLLSWL.Text.Trim
                        .Dimension = TVI_txtDimensionDiameter.Text.Trim
                        .Length = TVI_txtLength.Text.Trim
                        .Manufacture = TVI_txtManufacturer.Text.Trim
                        .DefectFound = TVI_txtDefectFound.Text.Trim
                        .ExamineWith = TVI_txtExamineWith.Text.Trim
                        .Result = TVI_txtResult.Text.Trim
                        .Note = TVI_txtNote.Text.Trim
                        .NextInspectionDate = TVI_calNextInspectionDate.selectedDate
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then TVI_txtTVIHdID.Text = .tviHdID.Trim
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                Case Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID
                    Dim oHd As New Common.BussinessRules.InspectionTallyReportHd
                    With oHd
                        .InspectionTallyHdID = IT_txtInspectionTallyHdID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = IT_txtReportNo.Text.Trim
                        .reportDate = IT_calReportDate.selectedDate
                        .inspectionTallyTypeSCode = IT_ddlTallyType.SelectedValue.Trim
                        .driftSizeLength = String.Empty
                        .driftSizeOD = String.Empty
                        .size = IT_txtSize.Text.Trim
                        .grade = IT_txtGrade.Text.Trim
                        .weight = IT_txtWeight.Text.Trim
                        .connection = IT_txtConnection.Text.Trim
                        .range = IT_txtRange.Text.Trim
                        .nominalWT = IT_txtNominalWT.Text.Trim
                        .ACcaption1 = IT_txtAC1.Text.Trim
                        .ACcaption2 = IT_txtAC2.Text.Trim
                        .ACcaption3 = IT_txtAC3.Text.Trim
                        .ACcaption4 = IT_txtAC4.Text.Trim
                        .isAC1 = IT_chkIsAC1.Checked
                        .isAC2 = IT_chkIsAC2.Checked
                        .isAC3 = IT_chkIsAC3.Checked
                        .isAC4 = IT_chkIsAC4.Checked
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID                        
                        If isNew Then
                            If .Insert() Then IT_txtInspectionTallyHdID.Text = .InspectionTallyHdID
                        Else
                            .Update()
                        End If
                    End With
                    oHd.Dispose()
                    oHd = Nothing

                    If IT_txtPipeNo.Text.Trim.Length > 0 Then
                        Dim oDt As New Common.BussinessRules.InspectionTallyReportDt
                        With oDt
                            .inspectionTallyDtID = IT_txtInspectionTallyDtID.Text.Trim
                            If .SelectOne.Rows.Count > 0 Then
                                isNew = False
                            Else
                                isNew = True
                            End If
                            .InspectionTallyHdID = IT_txtInspectionTallyHdID.Text.Trim
                            .pipeNo = IT_txtPipeNo.Text.Trim
                            .pipeLength = IT_txtPipeLength.Text.Trim
                            .VBI = IT_txtVBI.Text.Trim
                            .RWT = IT_txtRWT.Text.Trim
                            .isCCUYellow = (IT_rdblCCU.SelectedValue = "Y")
                            .isCCUBlue = (IT_rdblCCU.SelectedValue = "B")
                            .isCCUGreen = (IT_rdblCCU.SelectedValue = "G")
                            .isCCURed = (IT_rdblCCU.SelectedValue = "R")
                            .isCCNWhite = (IT_rdblCCN.SelectedValue = "W")
                            .isCCNYellow = (IT_rdblCCN.SelectedValue = "Y")
                            .isCCNRed = (IT_rdblCCN.SelectedValue = "R")
                            .VTIPin = IT_txtVTIPin.Text.Trim
                            .VTIBox = IT_txtVTIBox.Text.Trim
                            .FLD = IT_txtFLD.Text.Trim
                            .finalClass = IT_txtFinalClass.Text.Trim
                            .intExtCleaning = IT_txtInternalExternalCleaning.Text.Trim
                            .intExtCoating = IT_txtInternalExternalCoating.Text.Trim
                            .remarks = IT_txtRemark.Text.Trim
                            .userIDinsert = MyBase.LoggedOnUserID
                            .userIDupdate = MyBase.LoggedOnUserID
                            If isNew Then
                                If .Insert() Then IT_txtInspectionTallyDtID.Text = .inspectionTallyDtID
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            Else
                                .Update()
                                PrepareScreen(_VisiblePanelID.Trim, True, False)
                            End If
                        End With
                        oDt.Dispose()
                        oDt = Nothing
                    End If
                    SetDataGrid(_VisiblePanelID.Trim)

                Case Common.Constants.ReportTypePanelID.OfficialReport_PanelID
                    Dim oBR As New Common.BussinessRules.OfficialReport
                    With oBR
                        .officialReportID = BA_txtOfficialReportID.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .reportNo = BA_txtReportNo.Text.Trim
                        .reportDate = BA_calReportDate.selectedDate
                        .officialReportTypeSCode = BA_ddlOfficialReportType.SelectedValue.Trim
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        If isNew Then
                            If .Insert() Then BA_txtOfficialReportID.Text = .officialReportID
                            If BA_pnlBeritaAcaraAkhir.Visible = False Then PrepareScreen(_VisiblePanelID.Trim, True)
                        Else
                            .Update()
                            If BA_pnlBeritaAcaraAkhir.Visible = False Then PrepareScreen(_VisiblePanelID.Trim, False)
                        End If
                    End With
                    oBR.Dispose()
                    oBR = Nothing

                    If BA_pnlBeritaAcaraAkhir.Visible Then
                        Dim oPDT As New Common.BussinessRules.ProjectDt
                        Dim _item As DataGridItem
                        For Each _item In BA_grdBeritaAcaraAkhir.Items
                            Dim BA_lblProjectDtID As Label = CType(_item.FindControl("BA_lblProjectDtID"), Label)
                            Dim BA_txtQtyActual As TextBox = CType(_item.FindControl("BA_txtQtyActual"), TextBox)
                            oPDT.projectDetailID = BA_lblProjectDtID.Text.Trim
                            oPDT.qtyActual = CDec(IIf(IsNumeric(BA_txtQtyActual.Text.Trim) = True, BA_txtQtyActual.Text.Trim, 0))
                            oPDT.userIDupdate = MyBase.LoggedOnUserID
                            oPDT.UpdateQtyActual()
                        Next
                        oPDT.Dispose()
                        oPDT = Nothing
                    End If

                    SetDataGrid(_VisiblePanelID.Trim)
            End Select
        End Sub

        Private Sub _delete(ByVal _VisiblePanelID As String, ByVal _IDtoDelete As String)
            Select Case _VisiblePanelID
                Case Common.Constants.ReportTypePanelID.SummaryOfInspection_PanelID
                    Dim oBr As New Common.BussinessRules.SummaryOfInspection
                    With oBr
                        .summaryOfInspectionID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.DailyProgressReport_PanelID
                    Dim oBr As New Common.BussinessRules.DailyReportDt
                    With oBr
                        .dailyReportDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.CertificateOfInspection_PanelID
                    Dim oBr As New Common.BussinessRules.CertificateInspection
                    With oBr
                        .certificateInspectionID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.UTSpotCheck_PanelID
                    Dim oBr As New Common.BussinessRules.UTSpotCheckDt
                    With oBr
                        .UTSpotCheckDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.UTSpotArea_PanelID
                    Dim oBr As New Common.BussinessRules.UTSpotAreaDt
                    With oBr
                        .UTSpotAreaDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.HardnessTest_PanelID
                    Dim oBr As New Common.BussinessRules.HardnessTestDt
                    With oBr
                        .hardnessTestDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.DrillPipeInspectionReport_PanelID
                    Dim oBr As New Common.BussinessRules.DrillPipeReportDt
                    With oBr
                        .drillPipeReportDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.InspectionReport_PanelID
                    Dim oBr As New Common.BussinessRules.InspectionReportDt
                    With oBr
                        .inspectionReportDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.ThoroughVisualInspectionReport_PanelID
                    Dim oBr As New Common.BussinessRules.ThoroughVisualReportHd
                    With oBr
                        .tviHdID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.InspectionTallyReport_PanelID
                    Dim oBr As New Common.BussinessRules.InspectionTallyReportDt
                    With oBr
                        .inspectionTallyDtID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing

                Case Common.Constants.ReportTypePanelID.OfficialReport_PanelID
                    Dim oBr As New Common.BussinessRules.OfficialReport
                    With oBr
                        .officialReportID = _IDtoDelete.Trim
                        .Delete()
                    End With
                    oBr.Dispose()
                    oBr = Nothing
            End Select
        End Sub

#Region " C,R,U,D for Drill Pipe Inspection Report "
        Private Sub _openInspectionSpec()
            Dim oIS As New Common.BussinessRules.InspectionSpec
            With oIS
                .inspectionSpecID = DP_txtSpecificationID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    DP_txtSpecificationCode.Text = .inspectionSpecCode.Trim
                    DP_txtSpecificationName.Text = .inspectionSpecName.Trim
                    DP_Premium_txtMinOD.Text = .minODpremium.Trim
                    DP_Premium_txtMaxID.Text = .maxIDpremium.Trim
                    DP_Premium_txtMinWall.Text = .minWallpremium.Trim
                    DP_Premium_txtMinShoulder.Text = .minShldrpremium.Trim
                    DP_Premium_txtMinSeal.Text = .minSealpremium.Trim
                    DP_Class2_txtMinOD.Text = .minODclass2.Trim
                    DP_Class2_txtMaxID.Text = .maxIDclass2.Trim
                    DP_Class2_txtMinWall.Text = .minWallclass2.Trim
                    DP_Class2_txtMinShoulder.Text = .minShldrclass2.Trim
                    DP_Class2_txtMinSeal.Text = .minSealclass2.Trim
                    DP_Class2_txtMinTongSpacePB.Text = .minTongSpacePinclass2.Trim
                    DP_Class2_txtMaxQC.Text = .maxQCclass2.Trim
                    DP_Class2_txtBevelDia.Text = .minBevelDiaclass2.Trim
                    DP_Class2_txtMinQCDepth.Text = .minQCDepthclass2.Trim
                    DP_Class2_txtMaxLengthPin.Text = .maxLengthPinclass2.Trim
                    DP_Class2_txtMaxPinNeck.Text = .maxPinNeckclass2.Trim
                Else
                    DP_txtSpecificationID.Text = String.Empty
                    DP_txtSpecificationCode.Text = String.Empty
                    DP_txtSpecificationName.Text = String.Empty
                    DP_txtSize.Text = String.Empty
                    DP_txtWeight.Text = String.Empty
                    DP_txtGrade.Text = String.Empty
                    DP_txtConnection.Text = String.Empty
                    DP_txtRange.Text = String.Empty
                    DP_txtNominalWT.Text = String.Empty
                    DP_Premium_txtMinOD.Text = String.Empty
                    DP_Premium_txtMaxID.Text = String.Empty
                    DP_Premium_txtMinWall.Text = String.Empty
                    DP_Premium_txtMinShoulder.Text = String.Empty
                    DP_Premium_txtMinSeal.Text = String.Empty
                    DP_Class2_txtMinOD.Text = String.Empty
                    DP_Class2_txtMaxID.Text = String.Empty
                    DP_Class2_txtMinWall.Text = String.Empty
                    DP_Class2_txtMinShoulder.Text = String.Empty
                    DP_Class2_txtMinSeal.Text = String.Empty
                    DP_Class2_txtMinTongSpacePB.Text = String.Empty
                    DP_Class2_txtMaxQC.Text = String.Empty
                    DP_Class2_txtBevelDia.Text = String.Empty
                    DP_Class2_txtMinQCDepth.Text = String.Empty
                    DP_Class2_txtMaxLengthPin.Text = String.Empty
                    DP_Class2_txtMaxPinNeck.Text = String.Empty
                End If
            End With
            oIS.Dispose()
            oIS = Nothing
        End Sub

        Private Sub _openCaptionTemplateDrillPipe()
            Dim oCap As New Common.BussinessRules.CaptionTemplateDt
            With oCap
                .captionTemplateHdID = DP_ddlCaptionTemplate.SelectedValue.Trim
                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "001"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod001Caption.Text = .captionName
                    DP_lblBod001Caption.ToolTip = .captionID
                Else
                    DP_lblBod001Caption.Text = String.Empty
                    DP_lblBod001Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "002"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod002Caption.Text = .captionName
                    DP_lblBod002Caption.ToolTip = .captionID
                Else
                    DP_lblBod002Caption.Text = String.Empty
                    DP_lblBod002Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "003"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod003Caption.Text = .captionName
                    DP_lblBod003Caption.ToolTip = .captionID
                Else
                    DP_lblBod003Caption.Text = String.Empty
                    DP_lblBod003Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "004"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod004Caption.Text = .captionName
                    DP_lblBod004Caption.ToolTip = .captionID
                Else
                    DP_lblBod004Caption.Text = String.Empty
                    DP_lblBod004Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "005"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod005Caption.Text = .captionName
                    DP_lblBod005Caption.ToolTip = .captionID
                Else
                    DP_lblBod005Caption.Text = String.Empty
                    DP_lblBod005Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "006"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod006Caption.Text = .captionName
                    DP_lblBod006Caption.ToolTip = .captionID
                Else
                    DP_lblBod006Caption.Text = String.Empty
                    DP_lblBod006Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "007"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod007Caption.Text = .captionName
                    DP_lblBod007Caption.ToolTip = .captionID
                Else
                    DP_lblBod007Caption.Text = String.Empty
                    DP_lblBod007Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "008"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod008Caption.Text = .captionName
                    DP_lblBod008Caption.ToolTip = .captionID
                Else
                    DP_lblBod008Caption.Text = String.Empty
                    DP_lblBod008Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_Body
                .sequenceNo = "009"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBod009Caption.Text = .captionName
                    DP_lblBod009Caption.ToolTip = .captionID
                Else
                    DP_lblBod009Caption.Text = String.Empty
                    DP_lblBod009Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "001"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin001Caption.Text = .captionName
                    DP_lblPin001Caption.ToolTip = .captionID
                Else
                    DP_lblPin001Caption.Text = String.Empty
                    DP_lblPin001Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "002"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin002Caption.Text = .captionName
                    DP_lblPin002Caption.ToolTip = .captionID
                Else
                    DP_lblPin002Caption.Text = String.Empty
                    DP_lblPin002Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "003"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin003Caption.Text = .captionName
                    DP_lblPin003Caption.ToolTip = .captionID
                Else
                    DP_lblPin003Caption.Text = String.Empty
                    DP_lblPin003Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "004"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin004Caption.Text = .captionName
                    DP_lblPin004Caption.ToolTip = .captionID
                Else
                    DP_lblPin004Caption.Text = String.Empty
                    DP_lblPin004Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "005"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin005Caption.Text = .captionName
                    DP_lblPin005Caption.ToolTip = .captionID
                Else
                    DP_lblPin005Caption.Text = String.Empty
                    DP_lblPin005Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "006"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin006Caption.Text = .captionName
                    DP_lblPin006Caption.ToolTip = .captionID
                Else
                    DP_lblPin006Caption.Text = String.Empty
                    DP_lblPin006Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "007"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin007Caption.Text = .captionName
                    DP_lblPin007Caption.ToolTip = .captionID
                Else
                    DP_lblPin007Caption.Text = String.Empty
                    DP_lblPin007Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "008"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin008Caption.Text = .captionName
                    DP_lblPin008Caption.ToolTip = .captionID
                Else
                    DP_lblPin008Caption.Text = String.Empty
                    DP_lblPin008Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "009"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin009Caption.Text = .captionName
                    DP_lblPin009Caption.ToolTip = .captionID
                Else
                    DP_lblPin009Caption.Text = String.Empty
                    DP_lblPin009Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "010"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin010Caption.Text = .captionName
                    DP_lblPin010Caption.ToolTip = .captionID
                Else
                    DP_lblPin010Caption.Text = String.Empty
                    DP_lblPin010Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_PinConn
                .sequenceNo = "011"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblPin011Caption.Text = .captionName
                    DP_lblPin011Caption.ToolTip = .captionID
                Else
                    DP_lblPin011Caption.Text = String.Empty
                    DP_lblPin011Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "001"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox001Caption.Text = .captionName
                    DP_lblBox001Caption.ToolTip = .captionID
                Else
                    DP_lblBox001Caption.Text = String.Empty
                    DP_lblBox001Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "002"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox002Caption.Text = .captionName
                    DP_lblBox002Caption.ToolTip = .captionID
                Else
                    DP_lblBox002Caption.Text = String.Empty
                    DP_lblBox002Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "003"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox003Caption.Text = .captionName
                    DP_lblBox003Caption.ToolTip = .captionID
                Else
                    DP_lblBox003Caption.Text = String.Empty
                    DP_lblBox003Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "004"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox004Caption.Text = .captionName
                    DP_lblBox004Caption.ToolTip = .captionID
                Else
                    DP_lblBox004Caption.Text = String.Empty
                    DP_lblBox004Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "005"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox005Caption.Text = .captionName
                    DP_lblBox005Caption.ToolTip = .captionID
                Else
                    DP_lblBox005Caption.Text = String.Empty
                    DP_lblBox005Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "006"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox006Caption.Text = .captionName
                    DP_lblBox006Caption.ToolTip = .captionID
                Else
                    DP_lblBox006Caption.Text = String.Empty
                    DP_lblBox006Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "007"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox007Caption.Text = .captionName
                    DP_lblBox007Caption.ToolTip = .captionID
                Else
                    DP_lblBox007Caption.Text = String.Empty
                    DP_lblBox007Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "008"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox008Caption.Text = .captionName
                    DP_lblBox008Caption.ToolTip = .captionID
                Else
                    DP_lblBox008Caption.Text = String.Empty
                    DP_lblBox008Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "009"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox009Caption.Text = .captionName
                    DP_lblBox009Caption.ToolTip = .captionID
                Else
                    DP_lblBox009Caption.Text = String.Empty
                    DP_lblBox009Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "010"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox010Caption.Text = .captionName
                    DP_lblBox010Caption.ToolTip = .captionID
                Else
                    DP_lblBox010Caption.Text = String.Empty
                    DP_lblBox010Caption.ToolTip = String.Empty
                End If

                .captionGroupSCode = Common.Constants.CaptionTemplateGroup.DP_BoxConn
                .sequenceNo = "011"
                If .SelectForCaptionLabel.Rows.Count > 0 Then
                    DP_lblBox011Caption.Text = .captionName
                    DP_lblBox011Caption.ToolTip = .captionID
                Else
                    DP_lblBox011Caption.Text = String.Empty
                    DP_lblBox011Caption.ToolTip = String.Empty
                End If
            End With
            oCap.Dispose()
            oCap = Nothing
        End Sub
#End Region

#Region " C,R,U,D for Certificate of Inspection "
        Private Sub UploadPic_COI(ByVal PicNo As Integer)
            Dim strFileName As String
            Dim strFileExtension As String
            Dim strFilePath As String
            Dim strFolder As String

            strFolder = Server.MapPath("ImgTmp") + "\"

            Select Case PicNo
                Case 1
                    strFileName = COI_ImageFilePic1.PostedFile.FileName
                Case 2
                    strFileName = COI_ImageFilePic2.PostedFile.FileName
                Case Else
                    strFileName = COI_ImageFilePic3.PostedFile.FileName
            End Select
            strFileName = Path.GetFileName(strFileName)
            strFileExtension = Path.GetExtension(strFileName)

            If (Not Directory.Exists(strFolder)) Then
                Directory.CreateDirectory(strFolder)
            End If

            'Save the uploaded file to the server.
            strFilePath = strFolder & COI_txtCertificateInspectionID.Text.Trim & strFileName
            If File.Exists(strFilePath) Then
                File.Delete(strFilePath)
            Else
                Select Case PicNo
                    Case 1
                        COI_ImageFilePic1.PostedFile.SaveAs(strFilePath)
                    Case 2
                        COI_ImageFilePic2.PostedFile.SaveAs(strFilePath)
                    Case Else
                        COI_ImageFilePic3.PostedFile.SaveAs(strFilePath)
                End Select
            End If

            Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
            Dim b(CInt(fs.Length)) As Byte
            fs.Read(b, 0, CInt(fs.Length))
            fs.Close()

            Dim br As New Common.BussinessRules.CertificateInspection
            Dim fnotnew As Boolean = False

            With br
                .certificateInspectionID = COI_txtCertificateInspectionID.Text.Trim
                fnotnew = (.SelectOne.Rows.Count > 0)
                Select Case PicNo
                    Case 1
                        .Pic1 = New SqlBinary(b)
                    Case 2
                        .Pic2 = New SqlBinary(b)
                    Case Else
                        .Pic3 = New SqlBinary(b)
                End Select
                .userIDupdate = MyBase.LoggedOnUserID.Trim

                If fnotnew Then
                    .UpdatePic(PicNo)
                    Select Case PicNo
                        Case 1
                            COI_imgPic1.ImageUrl = GetPic_COI(1, COI_txtCertificateInspectionID.Text.Trim)
                        Case 2
                            COI_imgPic2.ImageUrl = GetPic_COI(2, COI_txtCertificateInspectionID.Text.Trim)
                        Case Else
                            COI_imgPic3.ImageUrl = GetPic_COI(3, COI_txtCertificateInspectionID.Text.Trim)
                    End Select
                End If
            End With
            br.Dispose()
            br = Nothing

            File.Delete(strFilePath)
        End Sub

        Private Function GetPic_COI(ByVal PicNo As Integer, ByVal ID As String) As String
            Dim strURL As String = String.Empty
            Select Case PicNo
                Case 1
                    strURL = UrlBase + "/secure/GetImage.aspx?imgType=COI-1&cn=" + ID.Trim
                Case 2
                    strURL = UrlBase + "/secure/GetImage.aspx?imgType=COI-2&cn=" + ID.Trim
                Case Else
                    strURL = UrlBase + "/secure/GetImage.aspx?imgType=COI-3&cn=" + ID.Trim
            End Select
            Return strURL.Trim
        End Function
#End Region
#End Region

    End Class

End Namespace