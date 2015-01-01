<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportType.aspx.vb" Inherits="Raven.Web.Secure.ReportType" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Report Type</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" height="100%" cellspacing="2" cellpadding="1">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
                <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr>
                                        <td class="rheader">
                                            Report Type
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%">
                                                <!-- PAGE CONTENT BEGIN HERE -->
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Report Type Code
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtReportTypeID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtReportTypeCode" Width="300" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvReportTypeCode" runat="server" ControlToValidate="txtReportTypeCode"
                                                            ErrorMessage="Report Type Code" Display="dynamic" Text="*">																
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Document No.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDocumentNo" Width="300" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Report Type Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtReportTypeName" Width="300" MaxLength="500" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rfvReportTypeName" runat="server" ControlToValidate="txtReportTypeName"
                                                            ErrorMessage="Report Type Name" Display="dynamic" Text="*">																
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Revision No.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRevisionNo" Width="300" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Sequence
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSequence" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Effective Date
                                                    </td>
                                                    <td>
                                                        <Module:Calendar ID="calEffectiveDate" runat="server" />
                                                        <asp:CheckBox ID="chkIsNoEffectiveDate" runat="server" Text="No Effective Date" Checked="True" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Panel ID
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPanelID" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsMandatory" runat="server" Text="Is Mandatory?" Checked="False" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active?" Checked="False" />
                                                    </td>
                                                </tr>
                                                <!-- PAGE CONTENT END HERE -->
                                            </table>
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:DataGrid ID="grdReportType" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridItemStyle" />
                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                <Columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Code">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportTypeCode") %>'
                                                                ID="_lblReportTypeCode" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ReportTypeName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Sequence">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Sequence") %>'
                                                                ID="_lblSequence" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Panel ID">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "PanelID")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Active?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                </table>
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
</body>
</html>
