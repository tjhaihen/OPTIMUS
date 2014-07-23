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
Imports System.Data.SqlTypes
Imports System.Data.SqlDbType

Imports Microsoft.VisualBasic

Imports Raven
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Web.Secure.Utilities

    Public Class TransactionNumbering
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Protected WithEvents LogonValidationSummary As System.Web.UI.WebControls.ValidationSummary
        Protected WithEvents DataPanel As System.Web.UI.WebControls.Panel
        Protected WithEvents RequiredFieldValidatorKodePos As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents btnSave As System.Web.UI.WebControls.Button
        Protected WithEvents btnOpen As System.Web.UI.WebControls.Button
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button

        Protected WithEvents txtTransactionCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidatorTransactionCode As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents lBtnTransactionCode As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtTransactionName As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidatorTransactionName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtTransactionInitial As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCounterDigit As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDelimiter As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidatorCounterDigit As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtTableName As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidatorTableName As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtFieldName1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidatorFieldName1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents txtFieldName2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents RequiredFieldValidatorFieldName2 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents chkIsNeedApproval As System.Web.UI.WebControls.CheckBox

        Protected WithEvents ddlNumberingMethod As System.Web.UI.WebControls.DropDownList

        Protected WithEvents listNavigasi As System.Web.UI.WebControls.DataList
        Protected WithEvents lblRecordCount As System.Web.UI.WebControls.Label
        Protected WithEvents RequiredFieldValidatorKelurahan As System.Web.UI.WebControls.RequiredFieldValidator

        Protected WithEvents CSSToolbar As Global.Raven.CSSToolbar
        Private ModuleId As String = "12510"

#End Region

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer

            InitializeComponent()
        End Sub

#End Region

#Region " Control Events... "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = ModuleId.Trim()
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                PrepareScreen()                

                lBtnTransactionCode.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("transtype", txtTransactionCode.ClientID))
                txtTransactionCode.Attributes.Add("onKeyDown", commonFunction.JSOpenSearchListWind("transtype", txtTransactionCode.ClientID))

                commonFunction.Focus(Me, txtTransactionCode.ClientID)

                DataBind()
            End If

        End Sub

        Private Sub txtTransactionCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransactionCode.TextChanged
            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
            'commonFunction.Focus(Me, txtTransactionName.ClientID)
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
                    _Delete()
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidNext
                    _Open(BussinessRules.RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _Open(BussinessRules.RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _Save()
            End Select
        End Sub

#End Region

#Region " Additional: Private Function "

        Private Sub PrepareScreen()
            txtTransactionCode.Text = String.Empty
            txtTransactionName.Text = String.Empty
            txtTransactionInitial.Text = String.Empty
            txtCounterDigit.Text = String.Empty
            txtDelimiter.Text = String.Empty
            txtTableName.Text = String.Empty
            txtFieldName1.Text = String.Empty
            txtFieldName2.Text = String.Empty
            chkIsNeedApproval.Checked = True
            ddlNumberingMethod.SelectedIndex = 0
        End Sub

        Private Function ReadQueryString() As Boolean
        End Function

#End Region

#Region " Main Function: Open, Save Delete Data "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            Dim obj As BussinessRules.TransactionType = New BussinessRules.TransactionType

            With obj
                .TransactionCode = New SqlString(Trim(txtTransactionCode.Text))
                If .SelectOne(recStatus).Rows.Count = 1 Then
                    txtTransactionCode.Text = Trim(.TransactionCode.Value)
                    txtTransactionName.Text = Trim(.TransactionName.Value)
                    txtTransactionInitial.Text = Trim(.TransactionInitial.Value)
                    txtCounterDigit.Text = Trim(.CounterDigit.Value.ToString)
                    txtDelimiter.Text = Trim(.Delimiter.Value)
                    txtTableName.Text = Trim(.TableName.Value)
                    txtFieldName1.Text = Trim(.FieldName1.Value)
                    txtFieldName2.Text = Trim(.FieldName2.Value)
                    chkIsNeedApproval.Checked = .IsNeedApproval.Value
                    ddlNumberingMethod.SelectedValue = .NumberingMethod.Value
                Else
                    'txtTransactionCode.Text = String.Empty
                    txtTransactionName.Text = String.Empty
                    txtTransactionInitial.Text = String.Empty
                    txtCounterDigit.Text = String.Empty
                    txtDelimiter.Text = String.Empty
                    txtTableName.Text = String.Empty
                    txtFieldName1.Text = String.Empty
                    txtFieldName2.Text = String.Empty
                    chkIsNeedApproval.Checked = True
                    ddlNumberingMethod.SelectedIndex = 0
                End If

            End With

            obj.Dispose()
            obj = Nothing
        End Sub

        Private Sub _Save()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            If Len(txtTransactionCode.Text.Trim) = 0 Then Exit Sub

            Dim fNotNew As Boolean = False

            Dim obj As BussinessRules.TransactionType = New BussinessRules.TransactionType
            With obj
                .TransactionCode = New SqlString(Trim(txtTransactionCode.Text))
                fNotNew = (.SelectOne.Rows.Count > 0)

                .TransactionCode = New SqlString(UCase(Trim(txtTransactionCode.Text)))
                .TransactionName = New SqlString(Trim(txtTransactionName.Text))
                .TransactionInitial = New SqlString(Trim(txtTransactionInitial.Text))
                If IsNumeric(txtCounterDigit.Text.Trim) Then
                    .CounterDigit = New SqlInt16(CShort(IIf(txtCounterDigit.Text = String.Empty, 0, txtCounterDigit.Text)))
                Else
                    Throw New Exception("Harus Angka Yang Dimasukkan")
                End If
                .Delimiter = New SqlString(Trim(txtDelimiter.Text))
                .TableName = New SqlString(Trim(txtTableName.Text))
                .FieldName1 = New SqlString(Trim(txtFieldName1.Text))
                .FieldName2 = New SqlString(Trim(txtFieldName2.Text))
                .IsNeedApproval = New SqlBoolean(chkIsNeedApproval.Checked)
                .NumberingMethod = New SqlString(ddlNumberingMethod.SelectedValue)
                .LastUpdatedBy = MyBase.LoggedOnUserID
                .LastUpdatedDate = Date.Now
                If fNotNew Then
                    .Update()
                Else '// data baru, insert 
                    .Insert()
                End If
            End With

            obj.Dispose()
            obj = Nothing

            _Open(BussinessRules.RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub _Delete()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            If Len(txtTransactionCode.Text.Trim) = 0 Then Exit Sub

            Dim obj As BussinessRules.TransactionType = New BussinessRules.TransactionType
            With obj
                .TransactionCode = New SqlString(Trim(txtTransactionCode.Text))
                If .Delete Then
                    PrepareScreen()
                End If
            End With

            obj.Dispose()
            obj = Nothing
        End Sub

#End Region

    End Class

End Namespace
