<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProjectMonitoring.aspx.vb" Inherits="Raven.Web.Secure.ProjectMonitoring" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Project Monitoring</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
    <style type="text/css">
        #ulRepProjectMonitoring
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepProjectMonitoring li
        {
            list-style-type: none;            
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
                                            Project Monitoring
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>                                    
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:Repeater ID="repLevel1_Inspectors" runat="server" OnItemDataBound="repLevel1_Inspectors_ItemDataBound">
                                                <headertemplate>
                                                    <ul id="ulRepProjectMonitoring">
                                                </headertemplate>
                                                <itemtemplate>
                                                    <li>
                                                        <table cellspacing="1" width="100%">
                                                            <tr>
                                                                <td class="gridHeaderStyle Heading3 center" style="width: 120; height: 30;">
                                                                    <%# DataBinder.Eval(Container.DataItem, "resourceCode") %>
                                                                </td>
                                                                <td>
                                                                    <asp:Panel id="pnlDetail" runat="server">
                                                                        <table cellspacing="1" width="100%">
                                                                            <tr>
                                                                                <td class="menu center" style="width: 100%;">
                                                                                    Current Project                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>          
                                                                                    <asp:Repeater ID="repCurrentProject" runat="server" OnItemDataBound="repLevel2_CurrentProject_ItemDataBound">
                                                                                        <headertemplate>
                                                                                            <ul id="ul1" class="ulRepProjectMonitoring">
                                                                                        </headertemplate>
                                                                                        <itemtemplate>
                                                                                            <li>
                                                                                                <table cellspacing="1" width="100%">
                                                                                                    <tr>
                                                                                                        <td style="width: 100;" class="gridHeaderStyle center">
                                                                                                            Helper
                                                                                                        </td>
                                                                                                        <td style="width: 200;" class="gridHeaderStyle center">
                                                                                                            Customer & Work Location
                                                                                                        </td>
                                                                                                        <td style="width: 350;" class="gridHeaderStyle center">
                                                                                                            Job Description Detail
                                                                                                        </td>
                                                                                                        <td style="width: 80;" class="gridHeaderStyle center">
                                                                                                            Start Date
                                                                                                        </td>
                                                                                                        <td style="width: 80;" class="gridHeaderStyle center">
                                                                                                            End Date
                                                                                                        </td>
                                                                                                        <td style="width: 100;" class="gridHeaderStyle center">
                                                                                                            WR#
                                                                                                        </td>
                                                                                                        <td style="width: 100;" class="gridHeaderStyle center">
                                                                                                            Order#
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 100;" valign="top">
                                                                                                            <asp:DataGrid ID="grdHelper" runat="server" BorderWidth="0" GridLines="None"
                                                                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                                                                                AutoGenerateColumns="false">
                                                                                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                                                                <itemstyle cssclass="gridItemStyle" />
                                                                                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                                                                <columns>
                                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Helper Name">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# DataBinder.Eval(Container.DataItem, "resourceName")%>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateColumn>
                                                                                                                </columns>
                                                                                                            </asp:DataGrid>
                                                                                                        </td>
                                                                                                        <td style="width: 200;" valign="top">
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "customerName")%><br />
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "workLocation")%>
                                                                                                        </td>
                                                                                                        <td valign="top">
                                                                                                            <asp:DataGrid ID="grdProjectDt" runat="server" BorderWidth="0" GridLines="None"
                                                                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                                                                AutoGenerateColumns="false">
                                                                                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                                                                <itemstyle cssclass="gridItemStyle" />
                                                                                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                                                                <columns>
                                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Description" HeaderStyle-HorizontalAlign="center">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# DataBinder.Eval(Container.DataItem, "description")%>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateColumn>
                                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="center">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "qty"),"#,##0") %>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateColumn>
                                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Unit" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# DataBinder.Eval(Container.DataItem, "unitOfMeasurement")%>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateColumn>
                                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Scope of Work" HeaderStyle-HorizontalAlign="center" ItemStyle-Width="100px">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# DataBinder.Eval(Container.DataItem, "descriptionDetail")%>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateColumn>
                                                                                                                </columns>
                                                                                                            </asp:DataGrid>
                                                                                                        </td>
                                                                                                        <td style="width: 80;" valign="top">
                                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "startDate"),"dd-MMM-yyyy") %>
                                                                                                        </td>
                                                                                                        <td style="width: 80;" valign="top">
                                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "endDate"),"dd-MMM-yyyy") %>
                                                                                                        </td>
                                                                                                        <td style="width: 100;" valign="top">
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "projectCode")%><br />                                                                                                            
                                                                                                        </td>
                                                                                                        <td style="width: 100;" valign="top">
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "workOrderNo")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="7" style="background-image: url('/pureravensLib/images/dot.png'); background-repeat: repeat-x; height: 10px;">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>                                                                                                            
                                                                                            </li>
                                                                                        </itemtemplate>
                                                                                        <footertemplate>
                                                                                            </ul>
                                                                                        </footertemplate>
                                                                                    </asp:Repeater>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                    <asp:Panel id="pnlNoActivity" runat="server">
                                                                        <table cellspacing="1" width="100%">
                                                                            <tr>
                                                                                <td class="center" style="font-size: 14pt; font-weight: bold; color: #cccccc;">
                                                                                    No Activity
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                </itemtemplate>
                                                <footertemplate>
                                                    </ul>
                                                </footertemplate>
                                            </asp:Repeater>
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
