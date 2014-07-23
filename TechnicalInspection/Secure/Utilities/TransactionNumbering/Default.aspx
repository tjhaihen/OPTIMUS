<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Raven.Web.Secure.Utilities.TransactionNumbering"
    EnableSessionState="true" EnableViewState="true" %>

<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyright.ascx" %>
<%@ Import Namespace="Raven.Web" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Transaction Numbering</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/PureravensLib/css/styles_blue.css" type="text/css" rel="Stylesheet">

    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>
    <script language="javascript" type="text/javascript" src="/PureravensLib/scripts/JScript.js"></script>
    <script language="javascript" src="/PureravensLib/scripts/rs_/rs___Dlg_Rs-v2.js"></script>

</head>
<body ms_positioning="GridLayout">
    <form runat="server" id="frmMasterBank">
    <table border="0" width="100%" height="100%" cellspacing="0" cellpadding="2">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
            </td>
        </tr>
        <tr>
            <td valign="top" width="100%" height="100%">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="0" cellpadding="10" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <!--BEGIN DATA PANEL-->
                                <asp:Panel ID="DataPanel" runat="server">
                                    <table cellspacing="0" cellpadding="5" width="100%">
                                        <tr class="rheader">
                                            <td class="rheadercol" align="left" height="25">
                                                Transaction Numbering
                                            </td>
                                        </tr>
                                        <tr class="rbody">
                                            <td class="rbodycol" align="middle" height="25">
                                                <!--BEGIN TABLE INPUT DATA-->
                                                <table width="100%">
                                                    <tr>
                                                        <td width="20%">
                                                            <asp:LinkButton ID="lBtnTransactionCode" runat="server" Text="Transaction Code" CausesValidation="False"
                                                                onmouseover="window.status='Click here to select from existing data.';return true"
                                                                onmouseout="window.status='';return true;" title="Click here to select from existing data."></asp:LinkButton>
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtTransactionCode" runat="server" MaxLength="3" Width="100%" AutoPostBack="True" />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTransactionCode" runat="server" ControlToValidate="txtTransactionCode"
                                                                ErrorMessage="Transaction Code" Display="dynamic">**</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Transaction Name
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtTransactionName" runat="server" MaxLength="100" Width="100%" />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTransactionName" runat="server" ControlToValidate="txtTransactionName"
                                                                ErrorMessage="Transaction Name" Display="dynamic">**</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Transaction Initial
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtTransactionInitial" runat="server" MaxLength="3" Width="100%" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none">
                                                        <td width="20%">
                                                        </td>
                                                        <td width="40%">
                                                            <asp:CheckBox ID="chkIsNeedApproval" runat="server" Text="Is Need Approval"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Numbering Method
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlNumberingMethod" runat="server" Width="100%">
                                                                <asp:ListItem Text="Daily" Value="01" />
                                                                <asp:ListItem Text="Monthly" Value="02" />
                                                                <asp:ListItem Text="Yearly" Value="03" />
                                                                <asp:ListItem Text="Continously" Value="04" />
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Delimiter
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtDelimiter" runat="server" MaxLength="1" Width="100%" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Counter Digit
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtCounterDigit" runat="server" MaxLength="2" Width="100%" />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCounterDigit" runat="server" ControlToValidate="txtCounterDigit"
                                                                ErrorMessage="Counter Digit" Display="dynamic">**</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Table Name
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtTableName" runat="server" MaxLength="50" Width="100%" />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTableName" runat="server" ControlToValidate="txtTableName"
                                                                ErrorMessage="Table Name" Display="dynamic">**</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Field Name 1
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtFieldName1" runat="server" MaxLength="50" Width="100%" />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFieldName1" runat="server" ControlToValidate="txtFieldName1"
                                                                ErrorMessage="Field Name 1" Display="dynamic">**</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Field Name 2
                                                        </td>
                                                        <td width="40%">
                                                            <asp:TextBox ID="txtFieldName2" runat="server" MaxLength="50" Width="100%" />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFieldName2" runat="server" ControlToValidate="txtFieldName2"
                                                                ErrorMessage="Field Name 2" Display="dynamic">**</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <!--END TABLE INPUT DATA-->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <p>
                                                    <asp:ValidationSummary ID="ValidationSummaryBank" runat="server" HeaderText="Field(s) berikut harus diisi.">
                                                    </asp:ValidationSummary>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <!--END DATA PANEL-->
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="bottom" style="padding-left: 20px">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>

    <script language="javascript" src="/PureravensLib/scripts/common/common.js"></script>

    <script language="vbscript" src="/PureravensLib/scripts/common/common.vbs"></script>

</body>
</html>
