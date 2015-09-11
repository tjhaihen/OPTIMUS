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
Imports System.IO
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports Raven.Common

Namespace Raven.Web.Secure

    Public Class WorkOrder
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.WorkRequest_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                btnSearchProject.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Project", txtProjectCode.ClientID))
                btnSearchCustomer.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Customer", txtCustomerCode.ClientID))
                btnSearchResource.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Resource", txtResourceCode.ClientID))
                btnSearchProduct.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("Product", txtProductCode.ClientID))

                prepareDDL()
                prepareScreen(True)
                SetDataGridProjectDetail()
                SetDataGridProjectReportType()
                SetDataGridProjectResource()
                SetDataGridProjectFile()
                DataBind()
            End If
        End Sub

        Private Sub txtProjectCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectCode.TextChanged
            _open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtWorkLocation.ClientID)
        End Sub

        Private Sub txtCustomerCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomerCode.TextChanged
            _openCustomer(Common.BussinessRules.ID.GetFieldValue("Customer", "CustomerCode", txtCustomerCode.Text.Trim, "CustomerID"))
        End Sub

        Private Sub txtProductCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtProductCode.TextChanged
            _openProduct(Common.BussinessRules.ID.GetFieldValue("Product", "ProductCode", txtProductCode.Text.Trim, "ProductID"))
        End Sub

        Private Sub txtResourceCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtResourceCode.TextChanged
            _openResource(Common.BussinessRules.ID.GetFieldValue("Resource", "ResourceCode", txtResourceCode.Text.Trim, "ResourceID"))
            commonFunction.Focus(Me, txtResourceName.ClientID)
        End Sub

        Private Sub btnAddResource_Click(sender As Object, e As System.EventArgs) Handles btnAddResource.Click
            _updateProjectResource()
        End Sub

        Private Sub btnAddDetail_Click(sender As Object, e As System.EventArgs) Handles btnAddDetail.Click            
            _updateProjectDetail()
        End Sub

        Private Sub btnAttachProjectFile_Click(sender As Object, e As System.EventArgs) Handles btnAttachProjectFile.Click
            _attachFile()
        End Sub

        Private Sub grdProjectDetail_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProjectDetail.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtProjectDtID.Text = CType(e.Item.FindControl("_lblProjectDtID"), Label).Text.Trim
                    _openProjectDetail(txtProjectDtID.Text.Trim)
                Case "Delete"
                    txtProjectDtID.Text = CType(e.Item.FindControl("_lblProjectDtID"), Label).Text.Trim
                    _deleteProjectDetail(txtProjectDtID.Text.Trim)
            End Select
        End Sub

        Private Sub grdProjectResource_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProjectResource.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblProjectResourceID As Label = CType(e.Item.FindControl("_lblProjectResourceID"), Label)
                    _deleteProjectResource(_lblProjectResourceID.Text.Trim)
            End Select
        End Sub

        Private Sub grdProjectFile_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProjectFile.ItemCommand
            Dim _lblProjectFileID As Label
            Select Case e.CommandName
                Case "Delete"
                    _lblProjectFileID = CType(e.Item.FindControl("_lblProjectFileID"), Label)
                    _deleteProjectFile(_lblProjectFileID.Text.Trim)
            End Select
        End Sub

#Region " Project Report Type "
        Private Sub btnProjectReportTypeAdd_Click(sender As Object, e As System.EventArgs) Handles btnProjectReportTypeAdd.Click
            _updateProjectReportType(False)
        End Sub

        Private Sub btnProductReportTypeAddAll_Click(sender As Object, e As System.EventArgs) Handles btnProjectReportTypeAddAll.Click
            _updateProjectReportType(True)
        End Sub

        Private Sub btnProductReportTypeRemove_Click(sender As Object, e As System.EventArgs) Handles btnProjectReportTypeRemove.Click
            _deleteProjectReportType(False)
        End Sub

        Private Sub btnProductReportTypeRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnProjectReportTypeRemoveAll.Click
            _deleteProjectReportType(True)
        End Sub
#End Region
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidSave) = True
                .VisibleButton(CSSToolbarItem.tidDelete) = True
                .VisibleButton(CSSToolbarItem.tidPropose) = True
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidDelete
                    _delete()
                Case CSSToolbarItem.tidNew
                    prepareScreen(True)
                Case CSSToolbarItem.tidNext
                    _open(BussinessRules.RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _open(BussinessRules.RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _update()
                Case CSSToolbarItem.tidPropose
                    _updatePropose()
                Case CSSToolbarItem.tidVoid
                    _updatePropose()
                Case CSSToolbarItem.tidPrint
                    Dim br As New Common.BussinessRules.MyReport
                    Dim strUserID As String = MyBase.LoggedOnUserID.Trim
                    br.ReportCode = "1000000070"
                    br.AddParameters(txtProjectID.Text.Trim)
                    br.AddParameters(strUserID)
                    Response.Write(br.UrlPrintPreview(Context.Request.Url.Host))
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlSite, "Site", String.Empty)
            commonFunction.SetDDL_Table(ddlPriority, "CommonCode", Common.Constants.GroupCode.Priority_SCode)
            commonFunction.SetDDL_Table(ddlResourceRole, "CommonCode", Common.Constants.GroupCode.ResourceType_SCode)
            commonFunction.SetDDL_Table(ddlResourceSignature, "ResourceSignature", txtResourceID.Text.Trim)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtProjectID.Text = String.Empty
            If isNew Then
                txtProjectCode.Text = String.Empty
                commonFunction.Focus(Me, txtProjectCode.ClientID)                
            Else
                commonFunction.Focus(Me, txtProjectName.ClientID)
            End If
            txtRefWorkRequestNo.Text = String.Empty
            txtProjectName.Text = String.Empty
            calStartDate.selectedDate = Date.Now
            calEndDate.selectedDate = Date.Now
            calExpiredDate.selectedDate = Date.Now
            chkIsNoExpiredDate.Checked = False
            txtWorkOrderNo.Text = String.Empty
            calWorkOrderDate.selectedDate = Date.Today
            txtCustomerID.Text = String.Empty
            txtCustomerCode.Text = String.Empty
            txtCustomerName.Text = String.Empty
            txtProductID.Text = String.Empty
            txtProductCode.Text = String.Empty
            txtProductName.Text = String.Empty
            txtWorkLocation.Text = String.Empty
            calRequiredDate.selectedDate = Date.Today
            ddlPriority.SelectedIndex = 0
            txtJobDescription.Text = String.Empty
            txtServiceName.Text = String.Empty
            txtAssetNo.Text = String.Empty
            txtModel.Text = String.Empty
            txtSerialNo.Text = String.Empty
            txtManufacturer.Text = String.Empty
            txtWorkLocationDescription.Text = String.Empty
            txtTermsAndConditions.Text = String.Empty
            txtDescription.Text = String.Empty
            txtReferenceNo.Text = String.Empty
            txtQty.Text = "1"
            txtUOM.Text = String.Empty
            txtDescriptionDetail.Text = String.Empty            

            txtResourceID.Text = String.Empty
            txtResourceCode.Text = String.Empty
            txtResourceName.Text = String.Empty
            ddlResourceRole.SelectedIndex = 0
            commonFunction.SetDDL_Table(ddlResourceSignature, "ResourceSignature", txtResourceID.Text.Trim)

            txtToDepartment.Text = Common.Methods.GetSettingParameter("TODEPT").Trim
            txtWorkRequestReference.Text = Common.Methods.GetSettingParameter("WRREF").Trim
            txtNote.Text = String.Empty
            txtCustomerPIC.Text = String.Empty
            txtCompanyToProvide.Text = String.Empty
            txtCustomerToProvide.Text = String.Empty
            txtRequestedBy.Text = Common.Methods.GetUserFullName(MyBase.LoggedOnUserID.Trim)
            txtAcknowledgedBy.Text = Common.Methods.GetSettingParameter("MKTMGR").Trim
            txtPreparedBy.Text = String.Empty
            txtCheckedBy.Text = Common.Methods.GetSettingParameter("QAMGR").Trim
            txtApprovedBy.Text = Common.Methods.GetSettingParameter("OPSDIR").Trim
            txtWarehousePIC.Text = String.Empty

            pnlProposed.Visible = False
            lblProposedBy.Text = String.Empty
            lblProposedDate.Text = String.Empty

            pnlApproved.Visible = False
            lblApprovalBy.Text = String.Empty
            lblApprovalDate.Text = String.Empty

            _refreshStatus()
            SetDataGridProjectReportType()
            SetDataGridProjectDetail()
            SetDataGridProjectResource()
            SetDataGridProjectFile()
            setToolbarVisibleButton()
        End Sub

        Private Sub PrepareScreenProjectFile()
            txtProjectFileName.Text = String.Empty
            txtProjectFileNo.Text = String.Empty
            txtProjectFileDescription.Text = String.Empty
            chkIsShared.Checked = False

            commonFunction.Focus(Me, txtProjectFileName.ClientID)
        End Sub

        Private Sub SetDataGridProjectDetail()
            Dim oProjectDt As New Common.BussinessRules.ProjectDt
            oProjectDt.projectID = txtProjectID.Text.Trim
            grdProjectDetail.DataSource = oProjectDt.SelectByProjectID
            grdProjectDetail.DataBind()
            oProjectDt.Dispose()
            oProjectDt = Nothing
        End Sub

        Private Sub SetDataGridProjectReportType()
            Dim oPr As New Common.BussinessRules.ProjectReportType
            oPr.ProjectID = txtProjectID.Text.Trim
            grdReportType.DataSource = oPr.SelectReportTypeNotInProjectReportTypeByProjectID
            grdReportType.DataBind()
            grdProjectReportType.DataSource = oPr.GetReportTypeByProjectID
            grdProjectReportType.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub

        Private Sub SetDataGridProjectResource()
            Dim oProjectResource As New Common.BussinessRules.ProjectResource
            oProjectResource.ProjectID = txtProjectID.Text.Trim
            grdProjectResource.DataSource = oProjectResource.GetResourceByProjectID
            grdProjectResource.DataBind()
            oProjectResource.Dispose()
            oProjectResource = Nothing
        End Sub

        Private Sub SetDataGridProjectFile()
            Dim br As New Common.BussinessRules.ProjectFile
            Dim dt As New DataTable
            With br
                .projectID = txtProjectID.Text.Trim
                dt = .GetFileByProjectID(False)
            End With

            grdProjectFile.DataSource = dt.DefaultView
            grdProjectFile.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _refreshStatus()
            Dim br As New Common.BussinessRules.ProjectHd
            With br
                .projectID = txtProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    If .isProposed = True Then
                        pnlProposed.Visible = True
                        lblProposedBy.Text = _openUser(.proposedBy.Trim)
                        lblProposedDate.Text = .proposedDate.ToString.Trim                        
                    Else
                        pnlProposed.Visible = False
                        lblProposedBy.Text = String.Empty
                        lblProposedDate.Text = String.Empty
                    End If

                    If .isApproval = True Then
                        pnlApproved.Visible = True
                        lblApprovalBy.Text = _openUser(.approvalBy.Trim)
                        lblApprovalDate.Text = .approvalDate.ToString.Trim

                        pnlProposed.Visible = False
                        lblProposedBy.Text = String.Empty
                        lblProposedDate.Text = String.Empty
                    Else
                        pnlApproved.Visible = False
                        lblApprovalBy.Text = String.Empty
                        lblApprovalDate.Text = String.Empty
                    End If

                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = Not .isProposed And Not .isApproval
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = Not .isProposed And Not .isApproval
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = Not .isProposed
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = .isProposed And Not .isApproval
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = .isProposed

                    btnAddDetail.Enabled = Not .isProposed
                    btnAddResource.Enabled = Not .isProposed
                    btnProjectReportTypeAdd.Enabled = Not .isProposed
                    btnProjectReportTypeAddAll.Enabled = Not .isProposed
                    btnProjectReportTypeRemove.Enabled = Not .isProposed
                    btnProjectReportTypeRemoveAll.Enabled = Not .isProposed
                Else
                    pnlProposed.Visible = False
                    lblProposedBy.Text = String.Empty
                    lblProposedDate.Text = String.Empty

                    pnlApproved.Visible = False
                    lblApprovalBy.Text = String.Empty
                    lblApprovalDate.Text = String.Empty

                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = False

                    btnAddDetail.Enabled = True
                    btnAddResource.Enabled = True
                    btnProjectReportTypeAdd.Enabled = True
                    btnProjectReportTypeAddAll.Enabled = True
                    btnProjectReportTypeRemove.Enabled = True
                    btnProjectReportTypeRemoveAll.Enabled = True
                End If
            End With
            br.Dispose()
            br = Nothing
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
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oProjectHd As New Common.BussinessRules.ProjectHd
            With oProjectHd
                txtProjectID.Text = Common.BussinessRules.ID.GetFieldValue("ProjectHd", "ProjectCode", txtProjectCode.Text.Trim, "ProjectID")
                .projectID = txtProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtRefWorkRequestNo.Text = .refWorkRequestNo.Trim
                    txtProjectName.Text = .projectName.Trim
                    calStartDate.selectedDate = .startDate
                    calEndDate.selectedDate = .endDate
                    commonFunction.SelectListItem(ddlSite, .siteID.Trim)
                    txtWorkOrderNo.Text = .workOrderNo.Trim
                    calWorkOrderDate.selectedDate = .workOrderDate
                    calExpiredDate.selectedDate = .expiredDate
                    chkIsNoExpiredDate.Checked = .isNoExpiredDate
                    txtCustomerID.Text = .customerID.Trim
                    _openCustomer(.customerID.Trim)
                    txtProductID.Text = .productID.Trim
                    _openProduct(.productID.Trim)
                    txtWorkLocation.Text = .workLocation.Trim
                    calRequiredDate.selectedDate = .requiredDate
                    commonFunction.SelectListItem(ddlPriority, .prioritySCode.Trim)
                    txtJobDescription.Text = .jobDescription.Trim
                    txtServiceName.Text = .serviceName.Trim
                    txtAssetNo.Text = .assetNo.Trim
                    txtModel.Text = .model.Trim
                    txtSerialNo.Text = .serialNo.Trim
                    txtManufacturer.Text = .manufacturer.Trim
                    txtWorkLocationDescription.Text = .workLocationDescription.Trim
                    txtTermsAndConditions.Text = .termsAndConditions.Trim
                    txtToDepartment.Text = .toDepartment.Trim
                    txtWorkRequestReference.Text = .reference.Trim
                    txtNote.Text = .note.Trim
                    txtCustomerPIC.Text = .customerPIC.Trim
                    txtCompanyToProvide.Text = .companyToProvide.Trim
                    txtCustomerToProvide.Text = .customerToProvide.Trim
                    txtRequestedBy.Text = .requestedBy.Trim
                    txtAcknowledgedBy.Text = .ackBy.Trim
                    txtPreparedBy.Text = .preparedBy.Trim
                    txtCheckedBy.Text = .checkedBy.Trim
                    txtApprovedBy.Text = .approvedBy.Trim
                    txtWarehousePIC.Text = .warehousePIC.Trim
                Else
                    prepareScreen(False)
                End If
            End With
            oProjectHd.Dispose()
            oProjectHd = Nothing

            SetDataGridProjectDetail()
            SetDataGridProjectReportType()
            SetDataGridProjectResource()
            SetDataGridProjectFile()
            _refreshStatus()
        End Sub

        Private Sub _openCustomer(ByVal _customerID As String)
            Dim oCustomer As New Common.BussinessRules.Customer
            oCustomer.CustomerID = _customerID.Trim
            If oCustomer.SelectOne.Rows.Count > 0 Then
                txtCustomerID.Text = _customerID.Trim
                txtCustomerCode.Text = oCustomer.CustomerCode.Trim
                txtCustomerName.Text = oCustomer.CustomerName.Trim
            Else
                txtCustomerID.Text = String.Empty
                txtCustomerCode.Text = String.Empty
                txtCustomerName.Text = String.Empty
            End If
            oCustomer.Dispose()
            oCustomer = Nothing
        End Sub

        Private Sub _openProduct(ByVal _productID As String)
            Dim oProduct As New Common.BussinessRules.Product
            oProduct.productID = _productID.Trim
            If oProduct.SelectOne.Rows.Count > 0 Then
                txtProductID.Text = _productID.Trim
                txtProductCode.Text = oProduct.productCode.Trim
                txtProductName.Text = oProduct.productName.Trim
            Else
                txtProductID.Text = String.Empty
                txtProductCode.Text = String.Empty
                txtProductName.Text = String.Empty
            End If
            oProduct.Dispose()
            oProduct = Nothing
        End Sub

        Private Sub _openResource(ByVal _resourceID As String)
            Dim oResource As New Common.BussinessRules.Resource
            oResource.resourceID = _resourceID.Trim
            If oResource.SelectOne.Rows.Count > 0 Then
                txtResourceID.Text = _resourceID.Trim
                txtResourceCode.Text = oResource.resourceCode.Trim
                commonFunction.SelectListItem(ddlResourceRole, oResource.resourceTypeSCode.Trim)
                txtPersonID.Text = oResource.personID.Trim                
                _openPerson()
            Else
                txtResourceID.Text = String.Empty
                txtResourceCode.Text = String.Empty
                ddlResourceRole.SelectedIndex = 0
                txtPersonID.Text = String.Empty                
                _openPerson()
            End If
            oResource.Dispose()
            oResource = Nothing
            commonFunction.SetDDL_Table(ddlResourceSignature, "ResourceSignature", txtResourceID.Text.Trim)
        End Sub

        Private Sub _openProjectDetail(ByVal _projectDtID As String)
            Dim oProjectDt As New Common.BussinessRules.ProjectDt
            oProjectDt.projectDetailID = _projectDtID.Trim
            If oProjectDt.SelectOne.Rows.Count > 0 Then
                txtDescription.Text = oProjectDt.description.Trim
                txtReferenceNo.Text = oProjectDt.referenceNo.Trim
                txtQty.Text = oProjectDt.qty.ToString.Trim
                txtUOM.Text = oProjectDt.unitOfMeasurement.Trim
                txtDescriptionDetail.Text = oProjectDt.descriptionDetail.Trim                
            Else
                txtDescription.Text = String.Empty
                txtReferenceNo.Text = String.Empty
                txtQty.Text = "1"
                txtUOM.Text = String.Empty
                txtDescriptionDetail.Text = String.Empty
            End If
            oProjectDt.Dispose()
            oProjectDt = Nothing
        End Sub

        Private Sub _openPerson()
            Dim oPerson As New Common.BussinessRules.Person
            With oPerson
                .PersonID = txtPersonID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtResourceName.Text = Trim(.FirstName.Trim + " " + .MiddleName.Trim + " " + .LastName.Trim)                    
                Else
                    txtPersonID.Text = String.Empty
                    txtResourceName.Text = String.Empty
                End If
            End With
            oPerson.Dispose()
            oPerson = Nothing
        End Sub

        Private Sub _delete()
            Dim oProjectHd As New Common.BussinessRules.ProjectHd
            oProjectHd.projectID = txtProjectID.Text.Trim
            If oProjectHd.Delete() Then
                prepareScreen(True)
            End If
            oProjectHd.Dispose()
            oProjectHd = Nothing
            SetDataGridProjectDetail()
            SetDataGridProjectReportType()
            SetDataGridProjectResource()
            SetDataGridProjectFile()
        End Sub

        Private Sub _deleteProjectReportType(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProjectReportType
            With oPr
                For Each item As DataGridItem In grdProjectReportType.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProjectReportTypeID As Label = CType(item.FindControl("_lblProjectReportTypeID"), Label)
                    .ProjectReportTypeID = lblProjectReportTypeID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProjectReportType()
        End Sub

        Private Sub _deleteProjectResource(ByVal projectResourceID As String)
            Dim oPr As New Common.BussinessRules.ProjectResource
            With oPr
                .ProjectResourceID = projectResourceID.Trim
                .Delete()
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProjectResource()
            commonFunction.Focus(Me, txtResourceName.ClientID)
        End Sub

        Private Sub _deleteProjectDetail(ByVal projectDetailID As String)
            Dim oPr As New Common.BussinessRules.ProjectDt
            With oPr
                .projectDetailID = projectDetailID.Trim
                .Delete()
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProjectDetail()
            commonFunction.Focus(Me, txtDescription.ClientID)
        End Sub

        Private Sub _deleteProjectFile(ByVal _ProjectFileID As String)
            Dim br As New Common.BussinessRules.ProjectFile
            Dim strFileName As String = String.Empty
            Dim nmFile As String = String.Empty
            With br
                .projectFileID = _ProjectFileID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    strFileName = .fileName.Trim

                    Dim Pathdb As New Common.SystemParameter                    
                    nmFile = Pathdb.GetValue("AttachFileUrl").ToString + strFileName
                    If File.Exists(nmFile) Then
                        File.Delete(nmFile)
                        If .Delete() Then
                            SetDataGridProjectFile()
                        End If
                    End If
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oProjectHd As New Common.BussinessRules.ProjectHd
            With oProjectHd
                .projectID = txtProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .refWorkRequestNo = txtRefWorkRequestNo.Text.Trim
                .projectName = txtProjectName.Text.Trim
                .startDate = calStartDate.selectedDate
                .endDate = calEndDate.selectedDate
                .siteID = ddlSite.SelectedValue.Trim
                .customerID = txtCustomerID.Text.Trim
                .workOrderNo = txtWorkOrderNo.Text.Trim
                .workOrderDate = calWorkOrderDate.selectedDate
                .expiredDate = calExpiredDate.selectedDate
                .isNoExpiredDate = chkIsNoExpiredDate.Checked
                .workLocation = txtWorkLocation.Text.Trim
                .requiredDate = calRequiredDate.selectedDate
                .prioritySCode = ddlPriority.SelectedValue.Trim
                .productID = txtProductID.Text.Trim
                .serviceName = txtServiceName.Text.Trim
                .assetNo = txtAssetNo.Text.Trim
                .model = txtModel.Text.Trim
                .serialNo = txtSerialNo.Text.Trim
                .manufacturer = txtManufacturer.Text.Trim
                .workLocationDescription = txtWorkLocationDescription.Text.Trim
                .termsAndConditions = txtTermsAndConditions.Text.Trim
                .jobDescription = txtJobDescription.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                .toDepartment = txtToDepartment.Text.Trim
                .reference = txtWorkRequestReference.Text.Trim
                .note = txtNote.Text.Trim
                .customerPIC = txtCustomerPIC.Text.Trim
                .companyToProvide = txtCompanyToProvide.Text.Trim
                .customerToProvide = txtCustomerToProvide.Text.Trim
                .requestedBy = txtRequestedBy.Text.Trim
                .ackBy = txtAcknowledgedBy.Text.Trim
                .preparedBy = txtPreparedBy.Text.Trim
                .checkedBy = txtCheckedBy.Text.Trim
                .approvedBy = txtApprovedBy.Text.Trim
                .warehousePIC = txtWarehousePIC.Text.Trim
                If isNew Then
                    If .Insert() Then
                        txtProjectID.Text = .projectID.Trim
                        txtProjectCode.Text = .projectCode.Trim

                        'Dim oPrt As New Common.BussinessRules.ProductReportType
                        'Dim oPr As New Common.BussinessRules.ProjectReportType
                        'Dim strReportTypeID As String = String.Empty
                        'Dim dtPrtTemp As New DataTable
                        'Dim dtPrtMandatoryTemp As New DataTable
                        'oPrt.ProductID = txtProductID.Text.Trim
                        'dtPrtTemp = oPrt.SelectReportTypeByProductID
                        'dtPrtMandatoryTemp = oPrt.SelectReportTypeByIsMandatoryProductID
                        'Dim drPrtMandatoryTemp As DataRow() = dtPrtMandatoryTemp.Select()
                        'For i As Integer = 0 To drPrtMandatoryTemp.Length - 1
                        '    Dim rowMandatory As DataRow = drPrtMandatoryTemp(i)
                        '    strReportTypeID = ProcessNull.GetString(rowMandatory("ReportTypeID"))
                        '    oPr.ProjectID = txtProjectID.Text.Trim
                        '    oPr.ReportTypeID = strReportTypeID.Trim
                        '    oPr.UserIDInsert = MyBase.LoggedOnUserID
                        '    oPr.UserIDPrepare = MyBase.LoggedOnUserID
                        '    oPr.Insert()
                        'Next
                        'Dim drPrtTemp As DataRow() = dtPrtTemp.Select()
                        'For i As Integer = 0 To drPrtTemp.Length - 1
                        '    Dim row As DataRow = drPrtTemp(i)
                        '    strReportTypeID = ProcessNull.GetString(row("ReportTypeID"))
                        '    oPr.ProjectID = txtProjectID.Text.Trim
                        '    oPr.ReportTypeID = strReportTypeID.Trim
                        '    oPr.UserIDInsert = MyBase.LoggedOnUserID
                        '    oPr.UserIDPrepare = MyBase.LoggedOnUserID
                        '    oPr.Insert()
                        'Next                        
                        'oPrt.Dispose()
                        'oPrt = Nothing
                        'oPr.Dispose()
                        'oPr = Nothing

                        'SetDataGridProjectReportType()
                    End If                    
                Else
                    If .Update() Then
                        'Dim oPrt As New Common.BussinessRules.ProductReportType
                        'Dim oPr As New Common.BussinessRules.ProjectReportType
                        'Dim strReportTypeID As String = String.Empty
                        'Dim dtPrtTemp As New DataTable
                        'Dim dtPrtMandatoryTemp As New DataTable
                        'oPr.ProjectID = txtProjectID.Text.Trim
                        'oPr.DeleteByProjectID()
                        'oPrt.ProductID = txtProductID.Text.Trim
                        'dtPrtTemp = oPrt.SelectReportTypeByProductID
                        'dtPrtMandatoryTemp = oPrt.SelectReportTypeByIsMandatoryProductID
                        'Dim drPrtMandatoryTemp As DataRow() = dtPrtMandatoryTemp.Select()
                        'For i As Integer = 0 To drPrtMandatoryTemp.Length - 1
                        '    Dim rowMandatory As DataRow = drPrtMandatoryTemp(i)
                        '    strReportTypeID = ProcessNull.GetString(rowMandatory("ReportTypeID"))
                        '    oPr.ProjectID = txtProjectID.Text.Trim
                        '    oPr.ReportTypeID = strReportTypeID.Trim
                        '    oPr.UserIDInsert = MyBase.LoggedOnUserID
                        '    oPr.UserIDPrepare = MyBase.LoggedOnUserID
                        '    oPr.Insert()
                        'Next
                        'Dim drPrtTemp As DataRow() = dtPrtTemp.Select()
                        'For i As Integer = 0 To drPrtTemp.Length - 1
                        '    Dim row As DataRow = drPrtTemp(i)
                        '    strReportTypeID = ProcessNull.GetString(row("ReportTypeID"))
                        '    oPr.ProjectID = txtProjectID.Text.Trim
                        '    oPr.ReportTypeID = strReportTypeID.Trim
                        '    oPr.UserIDInsert = MyBase.LoggedOnUserID
                        '    oPr.UserIDPrepare = MyBase.LoggedOnUserID
                        '    oPr.Insert()
                        'Next
                        'oPrt.Dispose()
                        'oPrt = Nothing
                        'oPr.Dispose()
                        'oPr = Nothing

                        'SetDataGridProjectReportType()
                    End If
                End If
            End With
            oProjectHd.Dispose()
            oProjectHd = Nothing
        End Sub

        Private Sub _updatePropose()
            Dim oProjectHd As New Common.BussinessRules.ProjectHd
            With oProjectHd
                .projectID = txtProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    .isProposed = Not .isProposed
                    .proposedBy = MyBase.LoggedOnUserID.Trim
                    If .UpdateProposed() Then
                        _refreshStatus()
                    End If
                End If
            End With
            oProjectHd.Dispose()
            oProjectHd = Nothing
        End Sub

        Private Sub _updateProjectReportType(ByVal isAddAll As Boolean)
            If txtProjectCode.Text.Trim.Length = 0 Then
                commonFunction.MsgBox(Me, "Please save Work Request first.")
                Exit Sub
            End If

            Dim oPr As New Common.BussinessRules.ProjectReportType
            With oPr
                For Each item As DataGridItem In grdReportType.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblReportTypeID As Label = CType(item.FindControl("_lblReportTypeID"), Label)
                    .ProjectID = txtProjectID.Text.Trim
                    .ReportTypeID = lblReportTypeID.Text.Trim
                    .UserIDInsert = MyBase.LoggedOnUserID
                    .UserIDPrepare = MyBase.LoggedOnUserID
                    If isAddAll Then
                        .Insert()
                    Else
                        If chkSelect.Checked Then .Insert()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProjectReportType()
        End Sub

        Private Sub _updateProjectResource()
            If txtProjectCode.Text.Trim.Length = 0 Then
                commonFunction.MsgBox(Me, "Please save Work Request first.")
                Exit Sub
            End If

            Dim oPr As New Common.BussinessRules.ProjectResource
            With oPr
                .ProjectID = txtProjectID.Text.Trim
                .ResourceID = txtResourceID.Text.Trim
                .ResourceRoleSCode = ddlResourceRole.SelectedValue.Trim
                .ResourceSignatureID = ddlResourceSignature.SelectedValue.Trim
                .UserIDInsert = MyBase.LoggedOnUserID.Trim
                .UserIDUpdate = MyBase.LoggedOnUserID.Trim
                .Insert()
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProjectResource()
            commonFunction.Focus(Me, txtResourceName.ClientID)
        End Sub

        Private Sub _updateProjectDetail()
            If txtProjectCode.Text.Trim.Length = 0 Then
                commonFunction.MsgBox(Me, "Please save Work Request first.")
                Exit Sub
            End If

            Dim oPr As New Common.BussinessRules.ProjectDt
            With oPr
                .projectID = txtProjectID.Text.Trim
                .description = txtDescription.Text.Trim
                .referenceNo = txtReferenceNo.Text.Trim
                .qty = CDec(txtQty.Text.Trim)
                .unitOfMeasurement = txtUOM.Text.Trim
                .productID = txtProductID.Text.Trim
                .descriptionDetail = txtDescriptionDetail.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If .Insert() Then
                    Dim oPrt As New Common.BussinessRules.ProductReportType
                    Dim oPrty As New Common.BussinessRules.ProjectReportType
                    Dim strReportTypeID As String = String.Empty
                    Dim dtPrtTemp As New DataTable
                    Dim dtPrtMandatoryTemp As New DataTable
                    oPrt.ProductID = txtProductID.Text.Trim
                    dtPrtTemp = oPrt.SelectReportTypeByProductIDNotInProjectReportType(txtProjectID.Text.Trim)
                    dtPrtMandatoryTemp = oPrt.SelectReportTypeByIsMandatoryProductIDNotInProjectReportType(txtProjectID.Text.Trim)
                    Dim drPrtMandatoryTemp As DataRow() = dtPrtMandatoryTemp.Select()
                    For i As Integer = 0 To drPrtMandatoryTemp.Length - 1
                        Dim rowMandatory As DataRow = drPrtMandatoryTemp(i)
                        strReportTypeID = ProcessNull.GetString(rowMandatory("ReportTypeID"))
                        oPrty.ProjectID = txtProjectID.Text.Trim
                        oPrty.ReportTypeID = strReportTypeID.Trim
                        oPrty.UserIDInsert = MyBase.LoggedOnUserID
                        oPrty.UserIDPrepare = MyBase.LoggedOnUserID
                        oPrty.Insert()
                    Next
                    Dim drPrtTemp As DataRow() = dtPrtTemp.Select()
                    For i As Integer = 0 To drPrtTemp.Length - 1
                        Dim row As DataRow = drPrtTemp(i)
                        strReportTypeID = ProcessNull.GetString(row("ReportTypeID"))
                        oPrty.ProjectID = txtProjectID.Text.Trim
                        oPrty.ReportTypeID = strReportTypeID.Trim
                        oPrty.UserIDInsert = MyBase.LoggedOnUserID
                        oPrty.UserIDPrepare = MyBase.LoggedOnUserID
                        oPrty.Insert()
                    Next
                    oPrt.Dispose()
                    oPrt = Nothing
                    oPrty.Dispose()
                    oPrty = Nothing

                    SetDataGridProjectReportType()
                End If
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProjectDetail()
            commonFunction.Focus(Me, txtDescription.ClientID)
        End Sub

        Private Sub _attachFile()
            If txtProjectID.Text.Trim.Length = 0 Then Exit Sub

            If txtFileUrl.Value.Trim.Length > 0 Then
                Dim fileExt As String, fileName As String
                Dim br As New Common.BussinessRules.ProjectFile
                With br
                    fileExt = Path.GetExtension(txtFileUrl.Value.Trim)
                    fileName = txtProjectFileName.Text.Trim + fileExt.Trim
                    .projectFileID = txtProjectFileID.Text.Trim
                    Dim Pathdb As New Common.SystemParameter
                    Dim fNotNew As Boolean = False
                    Dim nmFile As String
                    Try
                        If .SelectOne.Rows.Count > 0 Then
                            fNotNew = True
                        Else
                            fNotNew = False
                        End If
                        .projectID = txtProjectID.Text.Trim
                        .fileName = fileName.Trim
                        .fileNo = txtProjectFileNo.Text.Trim
                        .fileExtension = fileExt.Trim                        
                        .isShared = chkIsShared.Checked
                        .description = txtProjectFileDescription.Text.Trim
                        .UserIDInsert = MyBase.LoggedOnUserID.Trim
                        .UserIDUpdate = MyBase.LoggedOnUserID.Trim

                        '// validate if the file exist
                        nmFile = Pathdb.GetValue("AttachFileUrl").ToString + fileName
                        If txtFileUrl.Value.Trim.Length > 0 Then
                            If File.Exists(nmFile) Then
                                File.Delete(nmFile)
                            End If
                            txtFileUrl.PostedFile.SaveAs(nmFile)
                            If fNotNew Then
                                If .Update() Then
                                    PrepareScreenProjectFile()
                                    SetDataGridProjectFile()
                                End If
                            Else
                                If .Insert() Then                                    
                                    PrepareScreenProjectFile()
                                    SetDataGridProjectFile()
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        commonFunction.MsgBox(Me, "Upload file failed.")
                        Exit Sub
                    End Try
                End With
            Else
                commonFunction.MsgBox(Me, "No file choosen.")
                Exit Sub
            End If
        End Sub
#End Region

    End Class

End Namespace