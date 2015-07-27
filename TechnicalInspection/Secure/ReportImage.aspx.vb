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

    Public Class ReportImage
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "        
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                If ReadQueryString() Then                    
                    SetDataGridReportImage()
                End If
                DataBind()
            End If
        End Sub

        Private Sub btnUploadImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadImage.Click
            Dim strFileName As String
            Dim strFileExtension As String
            Dim strFilePath As String
            Dim strFolder As String

            strFolder = Server.MapPath("ImgTmp") + "\"

            strFileName = ImageFile.PostedFile.FileName
            strFileName = Path.GetFileName(strFileName)
            strFileExtension = Path.GetExtension(strFileName)

            If (Not Directory.Exists(strFolder)) Then
                Directory.CreateDirectory(strFolder)
            End If

            'Save the uploaded file to the server.
            strFilePath = strFolder & txtReportImageID.Text.Trim & strFileName
            If File.Exists(strFilePath) Then
                File.Delete(strFilePath)
            Else
                ImageFile.PostedFile.SaveAs(strFilePath)
            End If

            Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
            Dim b(CInt(fs.Length)) As Byte
            fs.Read(b, 0, CInt(fs.Length))
            fs.Close()

            Dim br As New Common.BussinessRules.ReportImage
            Dim fnotnew As Boolean = False

            With br
                .ReportImageID = txtReportImageID.Text.Trim
                fnotnew = (.SelectOne.Rows.Count > 0)
                .reportTypeID = lblReportTypeID.Text.Trim
                .reportHdID = lblReportHdID.Text.Trim
                .reportpic = New SqlBinary(b)
                .picDescription = txtPicDescription.Text.Trim
                .picSize = ImageFile.PostedFile.ContentLength
                .picType = strFileExtension.Trim
                .isShowOnMainReport = chkShowOnMainReport.Checked
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim

                If fnotnew Then
                    .Update()
                Else
                    .Insert()
                End If
                txtReportImageID.Text = String.Empty
                SetDataGridReportImage()
            End With
            br.Dispose()
            br = Nothing

            File.Delete(strFilePath)
        End Sub

        Private Sub repImages_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles repImages.ItemCommand
            Dim _lblReportImageIDonRep As Label = CType(e.Item.FindControl("_lblReportImageIDonRep"), Label)
            Dim oBr As New Common.BussinessRules.ReportImage
            oBr.ReportImageID = _lblReportImageIDonRep.Text.Trim

            Select Case e.CommandName
                Case "Edit"
                    If oBr.SelectOne.Rows.Count > 0 Then
                        txtReportImageID.Text = _lblReportImageIDonRep.Text.Trim
                        txtPicDescription.Text = oBr.picDescription.Trim
                        chkShowOnMainReport.Checked = oBr.isShowOnMainReport
                    End If

                Case "Delete"
                    If oBr.Delete() Then
                        SetDataGridReportImage()
                    End If
            End Select

            oBr.Dispose()
            oBr = Nothing
        End Sub

        Private Sub repImages_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repImages.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim _imgReportPic As Image = CType(e.Item.FindControl("_imgReportPic"), Image)
                    Dim _lblReportImageIDonRep As Label = CType(e.Item.FindControl("_lblReportImageIDonRep"), Label)

                    _imgReportPic.ImageUrl = UrlBase + "/secure/GetImage.aspx?imgType=ReportImage&cn=" + _lblReportImageIDonRep.Text.Trim
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "

#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            lblReportTypeID.Text = ProcessNull.GetString(Request.QueryString("reportTypeID"))
            lblReportHdID.Text = ProcessNull.GetString(Request.QueryString("reportHdID"))
            lblReportNo.Text = ProcessNull.GetString(Request.QueryString("reportNo"))
            Return (lblReportHdID.Text.Trim.Length > 0)
        End Function

        Private Sub SetDataGridReportImage()
            Dim oBR As New Common.BussinessRules.ReportImage
            oBR.reportTypeID = lblReportTypeID.Text.Trim
            oBR.reportHdID = lblReportHdID.Text.Trim
            repImages.DataSource = oBR.SelectByReportTypeIDReportHdID
            repImages.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region


#Region " C,R,U,D "

#End Region

    End Class

End Namespace