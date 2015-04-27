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

    Public Class CommonCode
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.CommonCode_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                prepareDDL()
                prepareScreen(True)                
                DataBind()
            End If
        End Sub

        Private Sub txtCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
            _open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtCaption.ClientID)
        End Sub

        Private Sub ddlGroupCode_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGroupCode.SelectedIndexChanged
            _open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtCode.ClientID)
        End Sub

        Private Sub grdCommonCode_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCommonCode.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtCode.Text = CType(e.Item.FindControl("_lblCode"), Label).Text.Trim
                    _open(BussinessRules.RavenRecStatus.CurrentRecord)
            End Select
        End Sub

        Private Sub btnUploadPicFile_Click(sender As Object, e As System.EventArgs) Handles btnUploadPicFile.Click
            UploadPic()
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
                    _open(BussinessRules.RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _open(BussinessRules.RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _update()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlGroupCode, "CommonCodeGroup", String.Empty)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            chkIsActive.Checked = True
            If isNew Then
                txtCode.Text = String.Empty
                commonFunction.Focus(Me, txtCode.ClientID)
            Else
                commonFunction.Focus(Me, txtCaption.ClientID)
            End If
            txtValue.Text = String.Empty
            chkIsDefault.Checked = False
            chkIsActive.Checked = True
            imgFilePic.ImageUrl = GetPic(ddlGroupCode.SelectedValue.Trim + "|" + txtCode.Text.Trim)
            SetDataGrid()
        End Sub

        Private Sub SetDataGrid()
            Dim oCommonCode As New Common.BussinessRules.CommonCode
            oCommonCode.GroupCode = ddlGroupCode.SelectedValue.Trim
            grdCommonCode.DataSource = oCommonCode.SelectByGroupCode
            grdCommonCode.DataBind()
            oCommonCode.Dispose()
            oCommonCode = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oCommonCode As New Common.BussinessRules.CommonCode
            With oCommonCode
                .GroupCode = ddlGroupCode.SelectedValue.Trim
                .Code = txtCode.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtCaption.Text = .Caption.Trim
                    txtValue.Text = .Value.Trim
                    chkIsDefault.Checked = .IsDefault
                    chkIsActive.Checked = .IsActive
                    imgFilePic.ImageUrl = GetPic(ddlGroupCode.SelectedValue.Trim + "|" + txtCode.Text.Trim)
                Else
                    prepareScreen(False)
                End If
            End With
            oCommonCode.Dispose()
            oCommonCode = Nothing
        End Sub

        Private Sub _delete()
            Dim oCommonCode As New Common.BussinessRules.CommonCode
            oCommonCode.GroupCode = ddlGroupCode.SelectedValue.Trim
            oCommonCode.Code = txtCode.Text.Trim
            If oCommonCode.Delete() Then
                prepareScreen(True)
            End If
            oCommonCode.Dispose()
            oCommonCode = Nothing            
        End Sub

        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oCommonCode As New Common.BussinessRules.CommonCode
            With oCommonCode
                .GroupCode = ddlGroupCode.SelectedValue.Trim
                .Code = txtCode.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .Caption = txtCaption.Text.Trim
                .Value = txtValue.Text.Trim
                .IsDefault = chkIsDefault.Checked
                .IsActive = chkIsActive.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then UploadPic()
                Else
                    If .Update() Then UploadPic()
                End If
            End With
            oCommonCode.Dispose()
            oCommonCode = Nothing
            prepareScreen(True)            
        End Sub

        Private Sub UploadPic()
            Dim strFileName As String
            Dim strFileExtension As String
            Dim strFilePath As String
            Dim strFolder As String

            strFolder = Server.MapPath("ImgTmp") + "\"

            strFileName = ImagePicFile.PostedFile.FileName
            strFileName = Path.GetFileName(strFileName)
            strFileExtension = Path.GetExtension(strFileName)

            If (Not Directory.Exists(strFolder)) Then
                Directory.CreateDirectory(strFolder)
            End If

            'Save the uploaded file to the server.
            strFilePath = strFolder & ddlGroupCode.SelectedValue.Trim & txtCode.Text.Trim & strFileName
            If File.Exists(strFilePath) Then
                File.Delete(strFilePath)
            Else
                ImagePicFile.PostedFile.SaveAs(strFilePath)
            End If

            Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
            Dim b(CInt(fs.Length)) As Byte
            fs.Read(b, 0, CInt(fs.Length))
            fs.Close()

            Dim br As New Common.BussinessRules.CommonCode
            Dim fnotnew As Boolean = False

            With br
                .GroupCode = ddlGroupCode.SelectedValue.Trim
                .Code = txtCode.Text.Trim
                fnotnew = (.SelectOne.Rows.Count > 0)
                .picFile = New SqlBinary(b)
                .userIDupdate = MyBase.LoggedOnUserID.Trim

                If fnotnew Then
                    .UpdatePic()
                    imgFilePic.ImageUrl = GetPic(ddlGroupCode.SelectedValue.Trim + "|" + txtCode.Text.Trim)
                End If
            End With
            br.Dispose()
            br = Nothing

            File.Delete(strFilePath)
        End Sub

        Private Function GetPic(ByVal ID As String) As String
            Dim strURL As String = String.Empty
            strURL = UrlBase + "/secure/GetImage.aspx?imgType=CommonCodeFilePic&cn=" + ID.Trim
            Return strURL.Trim
        End Function
#End Region

    End Class

End Namespace