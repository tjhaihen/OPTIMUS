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

    Public Class InspectionSpec
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.InspectionSpec_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                prepareScreen(True)
                SetDataGridInspectionSpec()
                DataBind()
            End If
        End Sub

        Private Sub txtInspectionSpecificationCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInspectionSpecificationCode.TextChanged
            _open(BussinessRules.RavenRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtInspectionSpecificationName.ClientID)
        End Sub

        Private Sub grdInspectionSpec_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdInspectionSpec.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtInspectionSpecificationCode.Text = CType(e.Item.FindControl("_lblInspectionSpecCode"), Label).Text.Trim
                    _open(BussinessRules.RavenRecStatus.CurrentRecord)
            End Select
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

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtInspectionSpecificationID.Text = String.Empty
            txtInspectionSpecificationName.Text = String.Empty
            chkIsActive.Checked = True
            If isNew Then
                txtInspectionSpecificationCode.Text = String.Empty
                commonFunction.Focus(Me, txtInspectionSpecificationCode.ClientID)
            Else
                commonFunction.Focus(Me, txtInspectionSpecificationName.ClientID)
            End If
            txtSize.Text = String.Empty
            txtWeight.Text = String.Empty
            txtConnection.Text = String.Empty
            txtGrade.Text = String.Empty
            txtRange.Text = String.Empty
            txtNominalWidth.Text = String.Empty
            txtMinODPremium.Text = String.Empty
            txtMinShoulderPremium.Text = String.Empty
            txtMaxIDPremium.Text = String.Empty
            txtMinSealPremium.Text = String.Empty
            txtMinWallPremium.Text = String.Empty
            txtMinBevelDiaPremium.Text = String.Empty
            txtMinODClass2.Text = String.Empty
            txtMaxIDClass2.Text = String.Empty
            txtMinShoulderClass2.Text = String.Empty
            txtMinSealClass2.Text = String.Empty
            txtMinWallClass2.Text = String.Empty
            txtMinTongSpacePinClass2.Text = String.Empty
            txtMinTongSpaceBoxClass2.Text = String.Empty
            txtMaxLengthPinClass2.Text = String.Empty
            txtMinQCDepthClass2.Text = String.Empty
            txtMaxQCClass2.Text = String.Empty
            txtMaxPinNeckClass2.Text = String.Empty
            txtBevelDiaClass2.Text = String.Empty
            txtMaxBevelDiaClass2.Text = String.Empty
            txtMaxCBoreClass2.Text = String.Empty
        End Sub

        Private Sub SetDataGridInspectionSpec()
            Dim oIS As New Common.BussinessRules.InspectionSpec
            grdInspectionSpec.DataSource = oIS.SelectAll
            grdInspectionSpec.DataBind()
            oIS.Dispose()
            oIS = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.RavenRecStatus)
            Dim oIS As New Common.BussinessRules.InspectionSpec
            With oIS
                txtInspectionSpecificationID.Text = Common.BussinessRules.ID.GetFieldValue("InspectionSpec", "InspectionSpecCode", txtInspectionSpecificationCode.Text.Trim, "InspectionSpecID")
                .inspectionSpecID = txtInspectionSpecificationID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtInspectionSpecificationCode.Text = .inspectionSpecCode.Trim
                    txtInspectionSpecificationName.Text = .inspectionSpecName.Trim
                    txtMinODPremium.Text = .minODpremium.Trim
                    txtMinShoulderPremium.Text = .minShldrpremium.Trim
                    txtMaxIDPremium.Text = .maxIDpremium.Trim
                    txtMinSealPremium.Text = .minShldrpremium.Trim
                    txtMinWallPremium.Text = .minWallpremium.Trim
                    txtMinBevelDiaPremium.Text = .minBevelDiapremium.Trim
                    txtMinODClass2.Text = .minODclass2.Trim
                    txtMinShoulderClass2.Text = .minShldrclass2.Trim
                    txtMaxIDClass2.Text = .maxIDclass2.Trim
                    txtMinSealClass2.Text = .minShldrclass2.Trim
                    txtMinWallClass2.Text = .minWallclass2.Trim
                    txtMinTongSpacePinClass2.Text = .minTongSpacePinclass2.Trim
                    txtMinTongSpaceBoxClass2.Text = .minTongSpaceBoxclass2.Trim
                    txtMaxLengthPinClass2.Text = .maxLengthPinclass2.Trim
                    txtMinQCDepthClass2.Text = .minQCDepthclass2.Trim
                    txtMaxQCClass2.Text = .maxQCclass2.Trim
                    txtMaxPinNeckClass2.Text = .maxPinNeckclass2.Trim
                    txtBevelDiaClass2.Text = .minBevelDiaclass2.Trim
                    txtMaxBevelDiaClass2.Text = .maxBevelDiaclass2.Trim
                    txtMaxCBoreClass2.Text = .maxCBoreclass2.Trim
                    chkIsActive.Checked = .IsActive
                Else
                    prepareScreen(False)
                End If
            End With
            oIS.Dispose()
            oIS = Nothing
        End Sub

        Private Sub _delete()
            Dim oIS As New Common.BussinessRules.InspectionSpec
            oIS.inspectionSpecID = txtInspectionSpecificationID.Text.Trim
            If oIS.Delete() Then
                prepareScreen(True)
            End If
            oIS.Dispose()
            oIS = Nothing
            SetDataGridInspectionSpec()
        End Sub

        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oIS As New Common.BussinessRules.InspectionSpec
            With oIS
                .inspectionSpecID = txtInspectionSpecificationID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .inspectionSpecCode = txtInspectionSpecificationCode.Text.Trim
                .inspectionSpecName = txtInspectionSpecificationName.Text.Trim
                .size = txtSize.Text.Trim
                .weight = txtWeight.Text.Trim
                .connection = txtConnection.Text.Trim
                .grade = txtGrade.Text.Trim
                .range = txtRange.Text.Trim
                .nominalWT = txtNominalWidth.Text.Trim
                .minODpremium = txtMinODPremium.Text.Trim
                .minShldrpremium = txtMinShoulderPremium.Text.Trim
                .maxIDpremium = txtMaxIDPremium.Text.Trim
                .minShldrpremium = txtMinSealPremium.Text.Trim
                .minWallpremium = txtMinWallPremium.Text.Trim
                .minSealpremium = txtMinSealPremium.Text.Trim
                .minBevelDiapremium = txtMinBevelDiaPremium.Text.Trim
                .minODclass2 = txtMinODClass2.Text.Trim
                .maxIDclass2 = txtMaxIDClass2.Text.Trim
                .minShldrclass2 = txtMinShoulderClass2.Text.Trim
                .minSealclass2 = txtMinSealClass2.Text.Trim
                .minWallclass2 = txtMinWallClass2.Text.Trim
                .minTongSpacePinclass2 = txtMinTongSpacePinClass2.Text.Trim
                .minTongSpaceBoxclass2 = txtMinTongSpaceBoxClass2.Text.Trim
                .maxLengthPinclass2 = txtMaxLengthPinClass2.Text.Trim
                .maxPinNeckclass2 = txtMaxPinNeckClass2.Text.Trim
                .minQCDepthclass2 = txtMinQCDepthClass2.Text.Trim
                .maxQCclass2 = txtMaxQCClass2.Text.Trim
                .minBevelDiaclass2 = txtBevelDiaClass2.Text.Trim
                .maxBevelDiaclass2 = txtMaxBevelDiaClass2.Text.Trim
                .maxCBoreclass2 = txtMaxCBoreClass2.Text.Trim
                .IsActive = chkIsActive.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then txtInspectionSpecificationID.Text = .inspectionSpecID
                Else
                    .Update()
                End If
            End With
            oIS.Dispose()
            oIS = Nothing
            prepareScreen(True)
            SetDataGridInspectionSpec()
        End Sub
#End Region
    End Class

End Namespace