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
                                        <td class="rheader">
                                            Customer Inspection Information
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
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
                                                    </td>
                                                    <td>
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
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top" class="">
                                            <telerik:RadTabStrip ID="rtsInspectionInformation" runat="server" Skin="Windows7"
                                                MultiPageID="rmpInspectionInformation" SelectedIndex="0" CssClass="tabStrip">
                                                <Tabs>
                                                    <telerik:RadTab Text="Information Dashboard">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Text="Inspection by Item">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Text="Inspection by Work Request">
                                                    </telerik:RadTab>
                                                </Tabs>
                                            </telerik:RadTabStrip>
                                            <telerik:RadMultiPage ID="rmpInspectionInformation" runat="server" SelectedIndex="0"
                                                CssClass="multiPage">
                                                <telerik:RadPageView ID="pvInformationDashboard" runat="server">
                                                    <table cellspacing="5" cellpadding="2">
                                                        <tr>
                                                            <td valign="top" style="width: 50%;">
                                                                <table cellspacing="5" cellpadding="2">
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
                                                                            <table class="projectbanner" cellspacing="1" cellpadding="2" width="150">
                                                                                <tr>
                                                                                    <td class="center">
                                                                                        TOTAL ITEM INSPECTED
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
                                                                            <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #009900;">
                                                                                <tr>
                                                                                    <td class="center">
                                                                                        TOTAL ITEM ACCEPTED
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridItemStyle center" style="height: 50; font-size: 16pt;">
                                                                                        <asp:Label ID="lblTotalItemAccepted" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #FF0000;">
                                                                                <tr>
                                                                                    <td class="center">
                                                                                        TOTAL ITEM REJECTED
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridItemStyle center" style="height: 50; font-size: 16pt;">
                                                                                        <asp:Label ID="lblTotalItemRejected" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table cellspacing="5" cellpadding="2">
                                                                    <tr>
                                                                        <td class="projectBanner" style="width: 624;">
                                                                            List of Item Due to Expired Inspection in &nbsp;
                                                                            <asp:TextBox ID="txtItemDueToExpiredInspectionInDay" runat="server" Width="50" CssClass="right"
                                                                                Text="30">
                                                                            </asp:TextBox>
                                                                            &nbsp; day(s)
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 624;">
                                                                            <asp:DataGrid ID="grdItemDueToExpiredInspection" runat="server" BorderWidth="0" GridLines="None"
                                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                                AutoGenerateColumns="false">
                                                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                                <itemstyle cssclass="gridItemStyle" />
                                                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                                <columns>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Description of Equipment" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "descriptionOfEquipment") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Serial No." ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "serialIDNo") %>
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
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Due In [day]" ItemStyle-Width="100"
                                                                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "DueInDay")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Result" ItemStyle-VerticalAlign="Top">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "result") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </columns>
                                                                            </asp:DataGrid>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" style="width: 50%;">
                                                                <table cellspacing="1" cellpadding="2">
                                                                    <tr>
                                                                        <td valign="top">
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
                                                            <td style="width: 500px;">
                                                                <asp:TextBox ID="txtSerialNo" runat="server" Width="300">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:DataGrid ID="grdInspectionBySerialIDNo" runat="server" BorderWidth="0" GridLines="None"
                                                                    CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Description of Equipment" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "descriptionOfEquipment") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Serial No." ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "serialIDNo") %>
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
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="pvInspectionByWorkRequest" runat="server">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 150px;" class="right">
                                                                Information Type
                                                            </td>
                                                            <td style="width: 500px;">
                                                                <asp:DropDownList ID="ddlInformationType" runat="server" Width="300" AutoPostBack="true">
                                                                    <asp:ListItem Text="Due to Expired Inspection" Value="Due">
                                                                    </asp:ListItem>
                                                                    <asp:ListItem Text="History Inspection" Value="History">
                                                                    </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 150px;" class="right">
                                                                <asp:Panel ID="pnlDueCaption" runat="server">
                                                                    Due In
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnlHistoryCaption" runat="server">
                                                                    Show Last
                                                                </asp:Panel>
                                                            </td>
                                                            <td>
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
                                                            </td>
                                                        </tr>
                                                        <tr class="rbody">
                                                            <td valign="top" colspan="4">
                                                                <asp:DataGrid ID="grdCustomerInspection" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Work Order" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "WorkOrderNo") %>
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
                                                                                            <asp:Label ID="_lblProjectCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectCode") %>'></asp:Label>
                                                                                            &nbsp;&nbsp;
                                                                                            <%# DataBinder.Eval(Container.DataItem, "projectName") %>
                                                                                            <asp:Label ID="_lblProjectID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectID") %>'
                                                                                                Visible="false"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Work Period" ItemStyle-Width="200"
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
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "ExpiredDate"),"dd-MMM-yyyy") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Overdue?" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center"
                                                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "IsOverDue")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Due In [day]" ItemStyle-Width="100"
                                                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "DueInDay")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Job Description" ItemStyle-Width="250"
                                                                            ItemStyle-CssClass="txtweak" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="_txtJobDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "jobDescription") %>'
                                                                                    TextMode="MultiLine" Style="font-family: Segoe UI, Verdana, Arial" Width="100%"
                                                                                    BorderStyle="None" CssClass="txtweak"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-HorizontalAlign="Center"
                                                                            ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ibtnWorkRequestDetail" runat="server" ImageUrl="/pureravensLib/images/right_green.png"
                                                                                    ToolTip="Process this Work Request" CommandName="Process" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
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