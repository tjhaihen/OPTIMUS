<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reports.aspx.vb" Inherits="Raven.Web.Secure.Reports" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Reports</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
    <script type="text/javascript">
        $(function () {
            $('.treenode').hover(function () {
                $('.treenode').css("font-underline", "false");
            });
        });
    </script>
    <style type="text/css">
        .treenode
        {
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" height="100%" cellspacing="2" cellpadding="1">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <table cellspacing="10" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="left">
                            <table cellspacing="0" cellpadding="5" width="100%">
                                <tr>
                                    <td colspan="3" class="rheader">
                                        Reports
                                    </td>
                                </tr>
                                <tr>
                                    <td class="hseparator" style="width: 100%;" colspan="3">
                                    </td>
                                </tr>
                                <tr class="rbody">
                                    <td valign="top">
                                        <table width="100%" cellpadding="3">
                                            <tr>
                                                <td class="rheaderexpable">
                                                    Report Explorer
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TreeView runat="server" ID="trvReport" Width="100%" Height="100%" ExpandDepth="-1"
                                                        ShowLines="true" ShowExpandCollapse="true">
                                                        <NodeStyle ForeColor="Black" CssClass="treenode" />
                                                    </asp:TreeView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" class="vseparator" style="height: 100%;">
                                    </td>
                                    <td valign="top" width="75%" style="height: 100%;">
                                        <table width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td valign="middle" style="width: 50px;">
                                                        <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                                    </td>
                                                    <td valign="middle" class="rheader" style="width: 70%;">
                                                        <asp:Label ID="lblReportCaption" runat="server"></asp:Label>                                                        
                                                    </td>
                                                    <td valign="middle" class="rheader right" style="width: 20%;">
                                                        # <asp:Label ID="lblReportID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" style="width: 100%;" colspan="3">
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel ID="pdPeriod" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Period
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPeriod" runat="server" Width="250" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <asp:Panel ID="pnlCustomPeriod" runat="server">
                                                        <tr>
                                                            <td>
                                                                <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                                                &nbsp;to&nbsp;
                                                                <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                </table>
                                            </asp:Panel>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
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
