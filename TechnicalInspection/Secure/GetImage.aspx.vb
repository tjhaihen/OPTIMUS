Option Strict On
Option Explicit On

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Text
Imports System.Collections
Imports System.ComponentModel
Imports System.IO
Imports System.Data.SqlTypes

Imports Microsoft.VisualBasic

Imports Raven
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Web
    Public Class GetImage
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strType As String = String.Empty
            Dim strID As String = String.Empty
            strType = Trim(Request.QueryString("imgType"))
            strID = Trim(Request.QueryString("cn"))
            If (Len(strType) > 0) And (Len(strID) > 0) Then
                Select Case strType
                    Case "MPI"
                        Dim br As New Common.BussinessRules.MPIDt
                        br.MPIDtID = strID.Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.MPIpic.Value)
                        End If
                    Case "COI-1"
                        Dim br As New Common.BussinessRules.CertificateInspection
                        br.certificateInspectionID = strID.Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.Pic1.Value)
                        End If
                    Case "COI-2"
                        Dim br As New Common.BussinessRules.CertificateInspection
                        br.certificateInspectionID = strID.Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.Pic2.Value)
                        End If
                    Case "COI-3"
                        Dim br As New Common.BussinessRules.CertificateInspection
                        br.certificateInspectionID = strID.Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.Pic3.Value)
                        End If
                    Case "PersonSignature"
                        Dim br As New Common.BussinessRules.Person
                        br.PersonID = strID.Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.SignaturePic.Value)
                        End If
                    Case "ResourceSignature"
                        Dim br As New Common.BussinessRules.ResourceSignature
                        br.resourceSignatureID = strID.Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.SignaturePic.Value)
                        End If
                    Case "CommonCodeFilePic"
                        Dim arrID() As String = strID.Split(CChar("|"))
                        Dim br As New Common.BussinessRules.CommonCode
                        br.GroupCode = arrID(0).Trim
                        br.Code = arrID(1).Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.picFile.Value)
                        End If
                    Case "ReportImage"
                        Dim br As New Common.BussinessRules.ReportImage
                        br.ReportImageID = strID.Trim
                        If br.SelectOne.Rows.Count > 0 Then
                            Response.BinaryWrite(br.reportpic.Value)
                        End If
                End Select
            End If
        End Sub

    End Class
End Namespace

