<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CommonCode.aspx.vb" Inherits="Raven.Web.Secure.CommonCode" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Common Code</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/PureravensLib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" style="height: 100%;">
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
                                            Common Code
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Group Code
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGroupCode" runat="server" width="300" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Image
                                                    </td>
                                                    <td>
                                                        <input id="ImagePicFile" type="file" runat="server" autopostback="True" name="ImagePicFile"
                                                            class="imguploader" style="width: 200;" />
                                                        <asp:Button ID="btnUploadPicFile" runat="server" Text="Upload" CssClass="sbttn" Width="100" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Code
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtCode" Width="300" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode"
                                                            ErrorMessage="Code" Display="dynamic" Text="*">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td rowspan="4">
                                                        <table width="300" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="gridAlternatingItemStyle">
                                                                    <asp:Image ID="imgFilePic" runat="server" Width="100" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Caption
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCaption" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Value
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtValue" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsDefault" runat="server" Text="Is Default?" Checked="False" />
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active?" Checked="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:DataGrid ID="grdCommonCode" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                <itemstyle cssclass="gridItemStyle" />
                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                <columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Code">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>'
                                                                ID="_lblCode" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Caption">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Caption")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Value">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Value")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Default?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsDefault" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsDefault") %>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Active?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </columns>
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
