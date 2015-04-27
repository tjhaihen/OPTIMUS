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

    Public Class Resource
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Resource_MenuID
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                btnSearchUser.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("User", txtUserName.ClientID))

                prepareDDL()
                prepareScreen(True)
                SetDataGridResource()
                DataBind()
            End If
        End Sub

        Private Sub txtResourceCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResourceCode.TextChanged
            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, ddlResourceType.ClientID)
        End Sub

        Private Sub txtUserName_TextChanged(sender As Object, e As System.EventArgs) Handles txtUserName.TextChanged
            txtUserID.Text = Common.BussinessRules.ID.GetFieldValue("Resource", "ResourceCode", txtResourceCode.Text.Trim, "ResourceID").Trim
        End Sub

        Private Sub btnUploadPicSignature_Click(sender As Object, e As System.EventArgs) Handles btnUploadPicSignature.Click
            UploadPic()
            SetDataGridResourceSignature()
        End Sub

        Private Sub grdResource_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdResource.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtResourceCode.Text = CType(e.Item.FindControl("_lblResourceCode"), Label).Text.Trim
                    _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            End Select
        End Sub

        Private Sub grdResourceSignature_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdResourceSignature.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtResourceSignatureID.Text = CType(e.Item.FindControl("_lblResourceSignatureID"), Label).Text.Trim
                    _openResourceSignature()
                    SetDataGridResourceSignature()
                Case "Delete"
                    txtResourceSignatureID.Text = CType(e.Item.FindControl("_lblResourceSignatureID"), Label).Text.Trim
                    _deleteResourceSignature()
            End Select
        End Sub

        Private Sub grdResourceSignature_ItemCreated(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdResourceSignature.ItemCreated
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim drv As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim _imgPicSignature As Image = CType(e.Item.FindControl("_imgPicSignature"), Image)
                If Not drv Is Nothing Then
                    _imgPicSignature.ImageUrl = GetPic(CType(drv("resourceSignatureID"), String))
                End If
            End If
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
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
                    _Open(BussinessRules.RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _Open(BussinessRules.RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _update()
            End Select
        End Sub
#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlResourceType, "CommonCode", Common.Constants.GroupCode.ResourceType_SCode)
            commonFunction.SetDDL_Table(ddlSex, "CommonCode", Common.Constants.GroupCode.Sex_SCode)
            commonFunction.SetDDL_Table(ddlGender, "CommonCode", Common.Constants.GroupCode.Sex_SCode)
            commonFunction.SetDDL_Table(ddlReligion, "CommonCode", Common.Constants.GroupCode.Religion_SCode)
            commonFunction.SetDDL_Table(ddlNationality, "CommonCode", Common.Constants.GroupCode.Nationality_SCode)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtResourceID.Text = String.Empty
            ddlResourceType.SelectedIndex = 0
            txtJobTitle.Text = String.Empty
            txtPersonID.Text = String.Empty
            txtUserID.Text = String.Empty
            txtUserName.Text = String.Empty
            calWorkingSDate.selectedDate = Nothing
            calWorkingEDate.selectedDate = Nothing
            chkIsActive.Checked = True
            If isNew Then
                txtResourceCode.Text = String.Empty
                commonFunction.Focus(Me, txtResourceCode.ClientID)
            Else
                commonFunction.Focus(Me, ddlResourceType.ClientID)
            End If

            prepareScreenPerson()
            prepareScreenResourceSinature()
            SetDataGridResourceSignature()
        End Sub

        Private Sub prepareScreenResourceSinature()
            txtResourceSignatureID.Text = String.Empty
            txtResourceSignatureDescription.Text = String.Empty
            imgPicSignature.ImageUrl = GetPic(txtResourceSignatureID.Text.Trim)
        End Sub

        Private Sub prepareScreenPerson()
            txtPersonID.Text = String.Empty
            txtSalutation.Text = String.Empty
            txtFirstName.Text = String.Empty
            txtMiddleName.Text = String.Empty
            txtLastName.Text = String.Empty
            txtAcademicTitle.Text = String.Empty
            ddlSex.SelectedIndex = 0
            ddlGender.SelectedIndex = 0
            ddlReligion.SelectedIndex = 0
            ddlNationality.SelectedIndex = 0
            txtAddress1.Text = String.Empty
            txtAddress2.Text = String.Empty
            txtAddress3.Text = String.Empty
            txtCity.Text = String.Empty
            txtPostalCode.Text = String.Empty
            txtPhone.Text = String.Empty
            txtMobile.Text = String.Empty
            txtFax.Text = String.Empty
            txtEmail.Text = String.Empty
            txtUrl.Text = String.Empty
        End Sub

        Private Sub SetDataGridResource()
            Dim oRsrc As New Common.BussinessRules.Resource
            grdResource.DataSource = oRsrc.SelectAll
            grdResource.DataBind()
            oRsrc.Dispose()
            oRsrc = Nothing
        End Sub

        Private Sub SetDataGridResourceSignature()
            Dim oRsrc As New Common.BussinessRules.ResourceSignature
            oRsrc.resourceID = txtResourceID.Text.Trim
            grdResourceSignature.DataSource = oRsrc.SelectByResourceID
            grdResourceSignature.DataBind()
            oRsrc.Dispose()
            oRsrc = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oRsrc As New Common.BussinessRules.Resource
            With oRsrc
                txtResourceID.Text = Common.BussinessRules.ID.GetFieldValue("Resource", "ResourceCode", txtResourceCode.Text.Trim, "ResourceID")
                .resourceID = txtResourceID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtResourceCode.Text = .resourceCode.Trim
                    ddlResourceType.SelectedValue = .resourceTypeSCode.Trim
                    txtJobTitle.Text = .resourceJobTitle.Trim
                    txtPersonID.Text = .personID.Trim
                    _openPerson()
                    txtUserID.Text = .userID.Trim
                    _openUser()
                    calWorkingSDate.selectedDate = .workingSDate
                    calWorkingEDate.selectedDate = .workingEDate
                    chkIsActive.Checked = .isActive
                    SetDataGridResourceSignature()
                Else
                    prepareScreen(False)
                End If
            End With
            oRsrc.Dispose()
            oRsrc = Nothing
        End Sub

        Private Sub _openPerson()
            Dim oPerson As New Common.BussinessRules.Person
            With oPerson
                .PersonID = txtPersonID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtSalutation.Text = .Salutation.Trim
                    txtFirstName.Text = .FirstName.Trim
                    txtMiddleName.Text = .MiddleName.Trim
                    txtLastName.Text = .LastName.Trim
                    txtAcademicTitle.Text = .AcademicTitle.Trim
                    ddlSex.SelectedValue = .SexSCode.Trim
                    ddlGender.SelectedValue = .GenderSCode.Trim
                    ddlReligion.SelectedValue = .ReligionSCode.Trim
                    ddlNationality.SelectedValue = .NationalitySCode.Trim
                    txtAddress1.Text = .Address1.Trim
                    txtAddress2.Text = .Address2.Trim
                    txtAddress3.Text = .Address3.Trim
                    txtCity.Text = .City.Trim
                    txtPostalCode.Text = .PostalCode.Trim
                    txtPhone.Text = .Phone.Trim
                    txtMobile.Text = .Mobile.Trim
                    txtFax.Text = .Fax.Trim
                    txtEmail.Text = .Email.Trim
                    txtUrl.Text = .Url.Trim                    
                Else
                    prepareScreenPerson()
                End If
            End With
            oPerson.Dispose()
            oPerson = Nothing
        End Sub

        Private Sub _openUser()
            Dim oUser As New Common.BussinessRules.User
            With oUser
                .UserID = txtUserID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtUserName.Text = .UserName.Trim
                Else
                    txtUserID.Text = String.Empty
                    txtUserName.Text = String.Empty
                End If
            End With
            oUser.Dispose()
            oUser = Nothing
        End Sub

        Private Sub _openResourceSignature()
            Dim oRS As New Common.BussinessRules.ResourceSignature
            With oRS
                .resourceSignatureID = txtResourceSignatureID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtResourceSignatureDescription.Text = .description.Trim
                    imgPicSignature.ImageUrl = GetPic(txtResourceSignatureID.Text.Trim)
                Else
                    prepareScreenResourceSinature()
                End If
            End With
            oRS.Dispose()
            oRS = Nothing
        End Sub

        Private Sub _delete()
            Dim oPerson As New Common.BussinessRules.Person
            oPerson.PersonID = txtPersonID.Text.Trim
            If oPerson.Delete() Then
                Dim oProd As New Common.BussinessRules.Resource
                oProd.resourceID = txtResourceID.Text.Trim
                If oProd.Delete() Then
                    prepareScreen(True)
                End If
                oProd.Dispose()
                oProd = Nothing
            End If
            oPerson.Dispose()
            oPerson = Nothing
            SetDataGridResource()
        End Sub

        Private Sub _deleteResourceSignature()
            Dim oRS As New Common.BussinessRules.ResourceSignature
            oRS.resourceSignatureID = txtResourceSignatureID.Text.Trim
            If oRS.Delete() Then
                SetDataGridResourceSignature()
            End If
            oRS.Dispose()
            oRS = Nothing            
        End Sub

        Private Sub _update()
            _updatePerson()
            Dim isNew As Boolean = True

            Dim oRsrc As New Common.BussinessRules.Resource
            With oRsrc
                .resourceID = txtResourceID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .resourceCode = txtResourceCode.Text.Trim
                .resourceTypeSCode = ddlResourceType.SelectedValue
                .resourceJobTitle = txtJobTitle.Text.Trim
                .personID = txtPersonID.Text.Trim
                .userID = txtUserID.Text.Trim
                .workingSDate = calWorkingSDate.selectedDate
                .workingEDate = calWorkingEDate.selectedDate
                .isActive = chkIsActive.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then
                        txtResourceID.Text = .resourceID
                        If ImageFilePicSignature.PostedFile.FileName.Trim.Length > 0 Then UploadPic()
                    End If
                Else
                    If .Update() Then
                        If txtResourceSignatureID.Text.Trim.Length > 0 Then UploadPic()
                    End If
                End If
            End With
            oRsrc.Dispose()
            oRsrc = Nothing
            prepareScreen(True)
            SetDataGridResource()
            SetDataGridResourceSignature()
        End Sub

        Private Sub _updatePerson()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Dim oPerson As New Common.BussinessRules.Person
            With oPerson
                .PersonID = txtPersonID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .Salutation = txtSalutation.Text.Trim
                .FirstName = txtFirstName.Text.Trim
                .MiddleName = txtMiddleName.Text.Trim
                .LastName = txtLastName.Text.Trim
                .AcademicTitle = txtAcademicTitle.Text.Trim
                .SexSCode = ddlSex.SelectedValue.Trim
                .GenderSCode = ddlGender.SelectedValue.Trim
                .ReligionSCode = ddlReligion.SelectedValue.Trim
                .NationalitySCode = ddlNationality.SelectedValue.Trim
                .Address1 = txtAddress1.Text.Trim
                .Address2 = txtAddress2.Text.Trim
                .Address3 = txtAddress3.Text.Trim
                .City = txtCity.Text.Trim
                .PostalCode = txtPostalCode.Text.Trim
                .Phone = txtPhone.Text.Trim
                .Mobile = txtMobile.Text.Trim
                .Fax = txtFax.Text.Trim
                .Email = txtEmail.Text.Trim
                .Url = txtUrl.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then txtPersonID.Text = .PersonID
                Else
                    .Update()
                End If
            End With
            oPerson.Dispose()
            oPerson = Nothing
        End Sub

        Private Sub UploadPic()
            Dim strFileName As String
            Dim strFileExtension As String
            Dim strFilePath As String
            Dim strFolder As String

            strFolder = Server.MapPath("ImgTmp") + "\"

            strFileName = ImageFilePicSignature.PostedFile.FileName
            strFileName = Path.GetFileName(strFileName)
            strFileExtension = Path.GetExtension(strFileName)

            If (Not Directory.Exists(strFolder)) Then
                Directory.CreateDirectory(strFolder)
            End If

            'Save the uploaded file to the server.
            strFilePath = strFolder & txtUserID.Text.Trim & strFileName
            If File.Exists(strFilePath) Then
                File.Delete(strFilePath)
            Else
                ImageFilePicSignature.PostedFile.SaveAs(strFilePath)
            End If

            Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
            Dim b(CInt(fs.Length)) As Byte
            fs.Read(b, 0, CInt(fs.Length))
            fs.Close()

            Dim br As New Common.BussinessRules.ResourceSignature
            Dim isNew As Boolean = False

            With br
                .resourceSignatureID = txtResourceSignatureID.Text.Trim
                isNew = (.SelectOne.Rows.Count = 0)
                .signaturePic = New SqlBinary(b)
                .resourceID = txtResourceID.Text.Trim
                .description = txtResourceSignatureDescription.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim

                If isNew Then
                    If .Insert() Then
                        txtResourceSignatureID.Text = .resourceSignatureID.Trim
                    End If                    
                Else
                    If .Update() Then
                        imgPicSignature.ImageUrl = GetPic(txtResourceSignatureID.Text.Trim)
                    End If                    
                End If
            End With
            br.Dispose()
            br = Nothing

            File.Delete(strFilePath)
        End Sub

        Private Function GetPic(ByVal ID As String) As String
            Dim strURL As String = String.Empty
            strURL = UrlBase + "/secure/GetImage.aspx?imgType=ResourceSignature&cn=" + ID.Trim
            Return strURL.Trim
        End Function
#End Region

    End Class

End Namespace