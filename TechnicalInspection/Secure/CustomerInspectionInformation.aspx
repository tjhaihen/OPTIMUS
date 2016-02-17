﻿<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerInspectionInformation.aspx.vb"
    Inherits="Raven.Web.Secure.CustomerInspectionInformation" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Customer Inspection Information</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
    <script language="javascript" type="text/javascript" src="/PureravensLib/scripts/JScript.js"></script>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" style="height: 100%;">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
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
                                        <td class="rheader" colspan="2">
                                            Customer Inspection Information
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="middle" style="width: 50;">
                                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                        </td>
                                        <td valign="middle">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Customer Code
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtCustomerID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtCustomerCode" Width="266" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:Button ID="btnSearchCustomer" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                        <asp:RequiredFieldValidator ID="rfvCustomerCode" runat="server" ControlToValidate="txtCustomerCode"
                                                            ErrorMessage="Customer Code" Display="dynamic" Text="*">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Product Code
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProductID" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtProductCode" Width="266" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:Button ID="btnSearchProduct" runat="server" Text="..." Width="30" CausesValidation="false" />                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Customer Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCustomerName" Width="300" MaxLength="500" runat="server" ReadOnly="true"
                                                            CssClass="txtReadOnly" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProductName" Width="300" MaxLength="500" runat="server" ReadOnly="true"
                                                            CssClass="txtReadOnly" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top" colspan="2">
                                            <telerik:RadTabStrip ID="rtsInspectionInformation" runat="server" Skin="Windows7"
                                                MultiPageID="rmpInspectionInformation" SelectedIndex="0" CssClass="tabStrip">
                                                <Tabs>
                                                    <telerik:RadTab Text="Work Order">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Text="Summary of Inspection">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Text="History of Inspection by Serial No.">
                                                    </telerik:RadTab>
                                                </Tabs>
                                            </telerik:RadTabStrip>
                                            <telerik:RadMultiPage ID="rmpInspectionInformation" runat="server" SelectedIndex="0"
                                                CssClass="multiPage">
                                                <telerik:RadPageView ID="pvInspectionByWorkRequest" runat="server">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 150px;" class="right">
                                                                Information Type
                                                            </td>
                                                            <td style="width: 500px;">
                                                                <asp:DropDownList ID="ddlInformationType" runat="server" Width="300" AutoPostBack="true">
                                                                    <asp:ListItem Text="All Inspection" Value="History">
                                                                    </asp:ListItem>
                                                                    <asp:ListItem Text="Due to Expired Inspection" Value="Due">
                                                                    </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px;" class="right">
                                                                <asp:Panel ID="pnlHistoryCaption" runat="server">
                                                                    Show Last
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnlDueCaption" runat="server">
                                                                    Due In
                                                                </asp:Panel>
                                                            </td>
                                                            <td>
                                                                <asp:Panel ID="pnlHistory" runat="server">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLast" Width="98" MaxLength="5" runat="server" />
                                                                            </td>
                                                                            <td style="padding-left: 5px;">
                                                                                Inspection(s)
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnlDue" runat="server">
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtDueIn" Width="98" MaxLength="5" runat="server" />
                                                                            </td>
                                                                            <td style="padding-left: 5px;">
                                                                                Day(s) to Expired Date
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr class="rbody">
                                                            <td valign="top" colspan="4">
                                                                <asp:DataGrid ID="grdCustomerInspection" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Location" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "workLocation") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "projectName") %>
                                                                                            <asp:Label ID="_lblProjectID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectID") %>'
                                                                                                Visible="false"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="FR/WO/JO No." ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td class="Heading1" style="font-weight: bold;">                                                                                            
                                                                                            <asp:Label ID="_lblWorkOrderNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkOrderNo") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            WR#:
                                                                                            <asp:Label ID="_lblProjectCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectCode") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "WorkOrderDate"),"dd-MMM-yyyy") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Product Name" ItemStyle-Width="120"
                                                                            ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "productName")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Work Period" ItemStyle-Width="100"
                                                                            ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "StartDate"),"dd-MMM-yyyy") %>
                                                                                &nbsp;to&nbsp;
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "EndDate"),"dd-MMM-yyyy") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Expired Date" ItemStyle-Width="100"
                                                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# IIf(DataBinder.Eval(Container.DataItem, "isNoExpiredDate")=true,"No Exp. Date",Format(DataBinder.Eval(Container.DataItem, "ExpiredDate"),"dd-MMM-yyyy")) %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Overdue?" ItemStyle-Width="120" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# IIf(DataBinder.Eval(Container.DataItem, "isNoExpiredDate") = True, "", "Due in: " + Format(DataBinder.Eval(Container.DataItem, "DueInDay"),"#,##0") + " day(s)")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="font-weight: bold; color: Red;">
                                                                                            <%# IIf(DataBinder.Eval(Container.DataItem, "isNoExpiredDate")=true,"",DataBinder.Eval(Container.DataItem, "IsOverDue")) %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Inspector Name" ItemStyle-Width="120"
                                                                            ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "inspectorName")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Job Description" ItemStyle-Width="200"
                                                                            ItemStyle-CssClass="txtweak" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="_txtJobDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "jobDescription") %>'
                                                                                    TextMode="MultiLine" Height="50" Style="font-family: Segoe UI, Verdana, Arial"
                                                                                    Width="100%" BorderStyle="None" CssClass="txtweak"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Status" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "status")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-HorizontalAlign="Center"
                                                                            ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibtnWorkRequestDetail" runat="server" ImageUrl="/pureravensLib/images/tbother1.png"
                                                                                    ToolTip="View Work Request Detail" CommandName="Preview" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-HorizontalAlign="Center"
                                                                            ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibtnSOIDetail" runat="server" ImageUrl="/pureravensLib/images/right_green.png"
                                                                                    ToolTip="View Summary of Inspection for this Work Request" CommandName="PreviewByWR" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="pvInformationDashboard" runat="server">
                                                    <table cellspacing="5" cellpadding="2" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                                <table cellspacing="5" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td style="width: 40%;" valign="top">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 100px;" class="right">
                                                                                        Information Type
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlInformationTypeSOI" runat="server" Width="300" AutoPostBack="true">
                                                                                            <asp:ListItem Text="All Inspection" Value="History">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="Due to Expired Inspection" Value="Due">
                                                                                            </asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <asp:Panel ID="pnlPeriod" runat="server">
                                                                                    <tr>
                                                                                        <td style="width: 100px;" class="right">
                                                                                            <asp:CheckBox ID="chkPeriod" runat="server" Text="Period" AutoPostBack="true" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlPeriod" runat="server" Width="300" AutoPostBack="true">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <asp:Panel ID="pnlCustomPeriod" runat="server">
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
                                                                                                <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                                                                                &nbsp;to&nbsp;
                                                                                                <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </asp:Panel>
                                                                                </asp:Panel>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        FR/WO/JO No.
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtWorkOrderNo" runat="server" Width="150" AutoPostBack="true"></asp:TextBox>
                                                                                        <asp:TextBox ID="txtProjectCode" runat="server" Width="150" ReadOnly="true" CssClass="txtReadOnly"></asp:TextBox>
                                                                                        <asp:TextBox ID="txtProjectID" runat="server" Width="150" Visible="false"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 60%;" valign="top">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Panel ID="pnlInspectionTotalSummary" runat="server">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table class="projectbanner" cellspacing="1" cellpadding="2" width="150">
                                                                                                            <tr>
                                                                                                                <td class="center">
                                                                                                                    TOTAL WORK ORDER
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt;">
                                                                                                                    <asp:Label ID="lblTotalWorkOrder" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #058ACD;">
                                                                                                            <tr>
                                                                                                                <td class="center">
                                                                                                                    TOTAL INSPECTED
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt;">
                                                                                                                    <asp:Label ID="lblTotalItemIspected" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #66CC33;">
                                                                                                            <tr>
                                                                                                                <td class="center" colspan="2">
                                                                                                                    <asp:LinkButton ID="lbtnAccepted" runat="server" Text="TOTAL ACCEPTED">
                                                                                                                    </asp:LinkButton>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt; width: 50%;">
                                                                                                                    <asp:Label ID="lblTotalItemAccepted" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt; width: 50%;">
                                                                                                                    <asp:Label ID="lblTotalItemAcceptedPct" runat="server"></asp:Label>%
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #EF8E19;">
                                                                                                            <tr>
                                                                                                                <td class="center" colspan="2">
                                                                                                                    <asp:LinkButton ID="lbtnRepair" runat="server" Text="TOTAL NEED REPAIR">
                                                                                                                    </asp:LinkButton>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt; width: 50%;">
                                                                                                                    <asp:Label ID="lblTotalItemNeedRepair" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt; width: 50%;">
                                                                                                                    <asp:Label ID="lblTotalItemNeedRepairPct" runat="server"></asp:Label>%
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #FF6666;">
                                                                                                            <tr>
                                                                                                                <td class="center" colspan="2">
                                                                                                                    <asp:LinkButton ID="lbtnRejected" runat="server" Text="TOTAL REJECTED">
                                                                                                                    </asp:LinkButton>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt; width: 50%;">
                                                                                                                    <asp:Label ID="lblTotalItemRejected" runat="server"></asp:Label>
                                                                                                                </td>
                                                                                                                <td class="gridItemStyle center" style="height: 50; font-size: 16pt; width: 50%;">
                                                                                                                    <asp:Label ID="lblTotalItemRejectedPct" runat="server"></asp:Label>%
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table cellspacing="5" cellpadding="2" width="100%">
                                                                    <asp:Panel ID="pnlDueToExpired" runat="server">
                                                                        <tr>
                                                                            <td class="projectBanner">
                                                                                List of Item Due to Expired Inspection in &nbsp;
                                                                                <asp:TextBox ID="txtItemDueToExpiredInspectionInDay" runat="server" Width="50" CssClass="right"
                                                                                    Text="30">
                                                                                </asp:TextBox>
                                                                                &nbsp; day(s)
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DataGrid ID="grdItemDueToExpiredInspection" runat="server" BorderWidth="0" GridLines="None"
                                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                                AutoGenerateColumns="false">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                <Columns>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="FR/WO/JO No." ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="100">
                                                                                        <ItemTemplate>
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td class="Heading1" style="font-weight: bold;">
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "workOrderNo") %>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        WR#&nbsp;<%# DataBinder.Eval(Container.DataItem, "projectCode") %>
                                                                                                        <asp:Label ID="_lblProjectID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectID") %>'
                                                                                                            Visible="false"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "WorkOrderDate"),"dd-MMM-yyyy") %>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Description of Equipment" ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="200">
                                                                                        <ItemTemplate>
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "descriptionOfEquipment") %>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak">
                                                                                                        Report#&nbsp;<%# DataBinder.Eval(Container.DataItem, "reportNo") %>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Serial No." ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="140">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "serialIDNo") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Type of Inspection" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <div class="txtweak">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "typeOfInspectionDescription") %>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Exam Date" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center"
                                                                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "examDate"),"dd-MMM-yyyy") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Expired Date" ItemStyle-Width="100"
                                                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# IIf(DataBinder.Eval(Container.DataItem, "ExpireDate")=DataBinder.Eval(Container.DataItem, "examDate"),"No Exp. Date",Format(DataBinder.Eval(Container.DataItem, "ExpireDate"),"dd-MMM-yyyy")) %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Result" ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="80">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "result") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Defect Found" ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="200">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "defectFound") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Remarks" ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="250">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "remarks") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Due In [day]" ItemStyle-Width="100"
                                                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# IIf(DataBinder.Eval(Container.DataItem, "ExpireDate") = DataBinder.Eval(Container.DataItem, "examDate"), "-", DataBinder.Eval(Container.DataItem, "DueInDay"))%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-HorizontalAlign="Center"
                                                                                        ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="ibtnWorkRequestDetail" runat="server" ImageUrl="/pureravensLib/images/tbother1.png"
                                                                                                ToolTip="View Summary of Inspection Detail" CommandName="Preview" />
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
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="pvInspectionByItem" runat="server">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 150px;" class="right">
                                                                Serial No.
                                                            </td>
                                                            <td style="width: 80%;">
                                                                <asp:TextBox ID="txtSerialNo" runat="server" Width="300">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DataGrid ID="grdInspectionBySerialIDNo" runat="server" BorderWidth="0" GridLines="None"
                                                                                CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false"
                                                                                Width="100%">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                <Columns>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Work Order No." ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "projectCode") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Work Order Date" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "workOrderDate"), "dd-MMM-yyyy")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="FR/WR/JO No." ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "workOrderNo") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Description of Equipment" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "descriptionOfEquipment") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Exam Date" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center"
                                                                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "examDate"),"dd-MMM-yyyy") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Expired Date" ItemStyle-Width="100"
                                                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "ExpireDate"),"dd-MMM-yyyy") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Result" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "result") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Defect Found" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "defectFound") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Remarks" ItemStyle-VerticalAlign="Top"
                                                                                        ItemStyle-Width="200">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "remarks") %>
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
                                                </telerik:RadPageView>
                                            </telerik:RadMultiPage>
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
