<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../incl/projectBanner.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Main.aspx.vb" Inherits="Raven.Web.Main" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>OPTIMUS - Home</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/PureravensLib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/PureravensLib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepDate
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDate li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            width: 35px;
            height: auto;
            margin: 0px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0" style="height: 100%;">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%;">
                <asp:CheckBox ID="chkIsCustomer" runat="server" Visible="False" />
                <asp:Panel ID="pnlAdministratorScreen" runat="server">
                    <table width="100%">
                        <tr>
                            <td class="Title" style="width: 50%;">
                                Work Request List
                            </td>
                            <td class="right" style="width: 50%;">
                                <table cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td class="gridHeaderStyle">
                                            Search Text
                                        </td>
                                        <td class="gridHeaderStyle">
                                            Status
                                        </td>
                                        <td class="gridHeaderStyle">
                                            Displaying
                                        </td>
                                        <td class="gridHeaderStyle">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtWorkRequestListFilter" runat="server" Width="200"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlWorkRequestListFilter" runat="server" Width="130" AutoPostBack="true">
                                                <asp:ListItem Text="In Progress" Value="InProgress"></asp:ListItem>
                                                <asp:ListItem Text="Done" Value="Done"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWorkRequestListDisplayFilter" runat="server" Width="80" ToolTip="Display top N records"
                                                CssClass="right" Text="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnWorkRequestListFilter" runat="server" Width="50" Text="Apply"
                                                CssClass="sbttn" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="hseparator" style="width: 100%;" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" colspan="2">
                                <asp:DataGrid ID="grdWorkRequest" runat="server" BorderWidth="0" GridLines="None"
                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                    AutoGenerateColumns="false">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                    <ItemStyle CssClass="gridItemStyle" />
                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                    <Columns>
                                        <asp:TemplateColumn runat="server" HeaderText="Work Request" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td class="Heading1" style="color: #ff3300">
                                                            <asp:Label ID="_lblProjectID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectID") %>'
                                                                Visible="false"></asp:Label>
                                                            <%# DataBinder.Eval(Container.DataItem, "projectCode")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%# DataBinder.Eval(Container.DataItem, "customerName")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            FR/WR/JO No.:
                                                            <%# DataBinder.Eval(Container.DataItem, "workOrderNo")%>
                                                            &nbsp;
                                                            <%# Format(DataBinder.Eval(Container.DataItem, "workOrderDate"),"dd-MMM-yyyy") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Description" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <%# DataBinder.Eval(Container.DataItem, "projectName") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%# DataBinder.Eval(Container.DataItem, "workLocation") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Acknowledgement" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Requested By:&nbsp;<%# DataBinder.Eval(Container.DataItem, "requestedBy") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Ack. By:&nbsp;<%# DataBinder.Eval(Container.DataItem, "ackBy") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Approval" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Proposed By:&nbsp;<%# DataBinder.Eval(Container.DataItem, "userProposeFullName") %>
                                                            &nbsp;On:&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "proposedDate"),"dd-MMM-yyyy") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Approved By:&nbsp;<%# DataBinder.Eval(Container.DataItem, "userApprovalFullName") %>
                                                            &nbsp;On:&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "approvalDate"),"dd-MMM-yyyy") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnWorkRequestDone" runat="server" ImageUrl="/pureravensLib/images/nurse_done.png"
                                                    ToolTip="Done" CommandName="Done" Visible='<%# Not (DataBinder.Eval(Container.DataItem, "isDone")) %>' />
                                                <asp:Label ID="lblWorkRequestDone" runat="server" Text="Done" CssClass="heading1"
                                                    ForeColor="#ff3300" Visible='<%# DataBinder.Eval(Container.DataItem, "isDone") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnWorkRequestDetail" runat="server" ImageUrl="/pureravensLib/images/right_green.png"
                                                    ToolTip="Process this Work Request" CommandName="Process" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlInspectorScreen" runat="server">
                    <table style="height: 100%;">
                        <tr>
                            <td style="width: 200px;" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td class="Heading2">
                                            My Site
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlMySite" runat="server" Width="180" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading2">
                                            My Project
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtProjectID" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtProjectCode" runat="server" Width="146" AutoPostBack="true"></asp:TextBox>
                                            <asp:Button ID="btnSearchProject" runat="server" Text="..." Width="30" />
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td>
                                            <asp:TextBox ID="txtProjectName" runat="server" ReadOnly="true" CssClass="txtreadonly"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataGrid ID="grdReportTypeByProject" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridMedHeightItemStyle" />
                                                <AlternatingItemStyle CssClass="gridMedHeightItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                <Columns>
                                                    <asp:TemplateColumn runat="server">
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportTypeID") %>'
                                                                            ToolTip='<%# DataBinder.Eval(Container.DataItem, "ReportTypeCode") %>' ID="_lblReportTypeID"
                                                                            Visible="false" />
                                                                        <asp:LinkButton ID="_lbtnReportTypeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportTypeName")%>'
                                                                            Width="100%" CommandName="SelectReportType" CssClass="txtnormallink" ToolTip='<%# DataBinder.Eval(Container.DataItem, "PanelID")%>' />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="hseparator" style="width: 100%;">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" class="vseparator" style="height: 100%;">
                            </td>
                            <td valign="top" style="width: 100%;">
                                <div style="overflow: auto;">
                                    <table width="100%">
                                        <tr>
                                            <td class="Heading1" style="width: 100%;">
                                                <Module:ProjectBanner ID="ProjectBanner" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Title">
                                                <asp:Label ID="lblReportTypeCode" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblReportTypeName" runat="server"></asp:Label>
                                                <asp:Label ID="lblReportTypePanelID" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="hseparator" style="width: 100%;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlCheckListCompletionReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td style="width: 50px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                No
                                                            </td>
                                                            <td style="width: auto;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                Description
                                                            </td>
                                                            <td style="width: 100px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                Type of Report
                                                            </td>
                                                            <td style="width: 200px;" class="gridAlternatingItemStyle center" colspan="2">
                                                                Prepared By
                                                            </td>
                                                            <td style="width: 150px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                Report Number
                                                            </td>
                                                            <td style="width: 100px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                Remarks
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px;" class="gridAlternatingItemStyle center">
                                                                Name
                                                            </td>
                                                            <td style="width: 100px;" class="gridAlternatingItemStyle center">
                                                                Date
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50px;">
                                                                <asp:TextBox ID="CCR_txtCCRID" runat="server" Visible="false"></asp:TextBox>
                                                                <asp:TextBox ID="CCR_txtSequenceNo" runat="server" Width="50"></asp:TextBox>
                                                            </td>
                                                            <td style="width: auto;">
                                                                <asp:TextBox ID="CCR_txtDescription" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:DropDownList ID="CCR_ddlTypeOfReport" runat="server" Width="100">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:TextBox ID="CCR_txtPreparedByName" runat="server" Width="100"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <Module:Calendar ID="CCR_calPreparedDate" runat="server" DontResetDate="true" />
                                                            </td>
                                                            <td style="width: 150px;">
                                                                <asp:TextBox ID="CCR_txtReportNo" runat="server" Width="150"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:TextBox ID="CCR_txtRemarks" runat="server" Width="100"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:DataGrid ID="CCR_grdCheckListOfCompletionReport" runat="server" BorderWidth="0"
                                                                    GridLines="None" Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true"
                                                                    ShowFooter="false" AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="CCR_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Sequence No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="CCR_lblCCRID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CCRID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Type of Report">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "typeOfReportName") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Prepared by">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "preparedBy") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="PreparedDate">
                                                                            <ItemTemplate>
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "preparedDate"), "dd-MMM-yyyy") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Report No.">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "reportNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remarks">
                                                                            <ItemTemplate>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlServiceAcceptance" runat="server">
                                                    This is Service Acceptance Panel
                                                </asp:Panel>
                                                <asp:Panel ID="pnlSummaryOfInspection" runat="server">
                                                    <asp:Panel ID="SOI_pnlApproved" Visible="false" runat="server">
                                                        <div class="transparent" id="Div1" style="width: 50%">
                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                                                                <tr>
                                                                    <td class="center" style="background-color: Red; color: #ffffff; font-size: 20pt;">
                                                                        APPROVED
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="center" style="background-color: #ffffff; color: Red;">
                                                                        by:&nbsp;<asp:Label ID="SOI_lblApprovalBy" runat="server"></asp:Label>&nbsp;on:&nbsp;<asp:Label
                                                                            ID="SOI_lblApprovalDate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:Panel>
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td class="Menu">
                                                                <asp:RadioButtonList ID="SOI_rbtnlInputMethod" runat="server" RepeatDirection="Horizontal"
                                                                    CssClass="Menu" AutoPostBack="true">
                                                                    <asp:ListItem Value="Entry" Text="Entry" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Value="Upload" Text="Upload"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel ID="SOI_pnlEntry" runat="server">
                                                        <table cellpadding="2" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td style="width: 50px;" class="gridAlternatingItemStyle center">
                                                                    No
                                                                </td>
                                                                <td class="gridAlternatingItemStyle center">
                                                                    Description of Equipment
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Serial/ID No.
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Location
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Manufacture
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    SWL/WWL/MGW
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Dimensional
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtSummaryOfInspectionID" runat="server" Width="50" Visible="false"></asp:TextBox>
                                                                    <asp:TextBox ID="SOI_txtSequenceNo" runat="server" Width="100%" CssClass="right"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtDescOfEquip" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtSerialNo" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtLocation" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtManufacture" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtSWLWWLMGW" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtDimensional" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table cellpadding="2" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Defect Found
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Result
                                                                </td>
                                                                <td style="width: 100px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Exam Date
                                                                </td>
                                                                <td style="width: 100px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Expired Date
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Report Number
                                                                </td>
                                                                <td style="width: 90px;" class="gridAlternatingItemStyle center" colspan="3">
                                                                    Type of Inspect
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Interval
                                                                </td>
                                                                <td class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Remarks
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 30px;" class="gridAlternatingItemStyle center">
                                                                    V
                                                                </td>
                                                                <td style="width: 30px;" class="gridAlternatingItemStyle center">
                                                                    N
                                                                </td>
                                                                <td style="width: 30px;" class="gridAlternatingItemStyle center">
                                                                    T
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtDefectFound" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtResult" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <Module:Calendar ID="SOI_calExamDate" runat="server" DontResetDate="true" />
                                                                </td>
                                                                <td>
                                                                    <Module:Calendar ID="SOI_calExpiredDate" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtReportNumber" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsV" runat="server"></asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsN" runat="server"></asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsT" runat="server"></asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtInterval" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtRemarks" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" class="gridAlternatingItemStyle center">
                                                                    Upload File
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <input id="txtFileUrl" type="file" name="txtFileUrl" runat="server" class="imguploader"
                                                                        style="width: 297px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="SOI_pnlUpload" runat="server">
                                                        <table cellpadding="2" cellspacing="1">
                                                            <tr>
                                                                <td class="gridHeaderStyle center">
                                                                    Spreadsheet File
                                                                </td>
                                                                <td class="gridHeaderStyle center">
                                                                    Sheet Name
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input id="SOI_File" type="file" runat="server" autopostback="True" name="SOI_File"
                                                                        size="85" class="imguploader" style="width: 404;">
                                                                    <input id="SOI_FileDetail" type="file" runat="server" autopostback="True" name="SOI_FileDetail"
                                                                        size="85" class="imguploader" style="width: 404; display: none;">
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtSheetName" runat="server" Width="200" Text="Sheet1"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:DataGrid ID="SOI_grdSummaryOfInspection" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="SOI_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" Visible='<%# Not (DataBinder.Eval(Container.DataItem, "isApproval")) %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="SOI_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" Visible='<%# Not (DataBinder.Eval(Container.DataItem, "isApproval")) %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="SOI_lblSummaryOfInspectionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "summaryOfInspectionID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Description Of Equipment">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "descriptionOfEquipment") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Serial/ID No.">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "serialIDNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Location">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "location")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Defect Found">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "defectFound")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Result">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "result")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Report No.">
                                                                            <ItemTemplate>
                                                                                <a href='<%# DataBinder.Eval(Container.DataItem, "fileUrl") %>' target="_blank" class="txtbluelink">
                                                                                    <asp:Image ID="imgView" runat="server" ImageUrl="/pureravensLib/images/QuickSearchIcon.png"
                                                                                        Visible='<%# DataBinder.Eval(Container.DataItem, "fileUrl") <> "#" %>' ImageAlign="AbsMiddle" />
                                                                                </a>
                                                                                <%# DataBinder.Eval(Container.DataItem, "reportNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remarks">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "remarks")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlTimeSheet" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Month - Year
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="TS_ddlMonth" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:DropDownList ID="TS_ddlYear" runat="server" Width="100" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td align="right">
                                                                            Note: [S] Standby [O] Operation [T] Traveling
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table class="lvwView" cellspacing="1" border="0" style="border-style: solid; border-width: 1px;
                                                                    border-color: #999999;">
                                                                    <tr class="gridHeaderStyle">
                                                                        <td style="width: 100px">
                                                                            Resource<br />
                                                                            <asp:CheckBox ID="TS_chkIsAll" runat="server" Text="All" Checked="true" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Repeater ID="repDateInMonthHd" runat="server" OnItemDataBound="repDateInMonthHd_ItemDataBound">
                                                                                <HeaderTemplate>
                                                                                    <ul id="ulRepDate">
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <li>
                                                                                        <table cellspacing="0" cellpadding="0" style="border-style: solid; border-width: 1px;
                                                                                            border-color: #ffffff;">
                                                                                            <tr>
                                                                                                <td class="center" style="width: 35px;">
                                                                                                    <asp:Label ID="TS_lblDateInMonthHd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateNo") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="center" style="width: 35px;">
                                                                                                    <asp:DropDownList ID="TS_ddlWorkingTypeAll" runat="server" Width="33">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </li>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    </ul>
                                                                                </FooterTemplate>
                                                                            </asp:Repeater>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <asp:ListView ID="lvwTimeSheet" runat="server" OnItemDataBound="lvwTimeSheet_ItemDataBound">
                                                                    <LayoutTemplate>
                                                                        <table id="tblView" runat="server" class="lvwView" cellspacing="1" border="0" style="border-style: solid;
                                                                            border-width: 1px; border-color: #999999;">
                                                                            <tr runat="server" id="itemPlaceholder">
                                                                            </tr>
                                                                        </table>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <tr class="gridAlternatingItemStyle">
                                                                            <td style="width: 100px">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%#Eval("resourceName")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txtweak">
                                                                                            <%#Eval("resourceRoleName")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Repeater ID="repDateInMonthDt" runat="server" OnItemDataBound="repDateInMonthDt_ItemDataBound">
                                                                                    <HeaderTemplate>
                                                                                        <ul id="ulRepDate">
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <li>
                                                                                            <table cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td class="center" style="width: 35px;">
                                                                                                        <asp:CheckBox ID="TS_chkIsNew" runat="server" Visible="false" />
                                                                                                        <asp:Label ID="TS_lblDateInMonthDt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateNo") %>'
                                                                                                            Visible="false"></asp:Label>
                                                                                                        <asp:Label ID="TS_lblTimeSheetID" runat="server" Visible="false"></asp:Label>
                                                                                                        <asp:Label ID="TS_lblProjectResourceID" runat="server" Visible="false"></asp:Label>
                                                                                                        <asp:DropDownList ID="TS_ddlWorkingType" runat="server" Width="35">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </li>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        </ul>
                                                                                    </FooterTemplate>
                                                                                </asp:Repeater>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlDailyProgressReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="6">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report ID
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DPR_txtDailyReportHdID" runat="server" Width="200" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:Button ID="DPR_btnSearchDailyReportHd" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="DPR_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                No
                                                            </td>
                                                            <td style="width: 100px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                Weather
                                                            </td>
                                                            <td style="width: auto;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                Description
                                                            </td>
                                                            <td style="width: 240px;" class="gridAlternatingItemStyle center" colspan="3">
                                                                Quantity
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                Current
                                                            </td>
                                                            <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                Previous
                                                            </td>
                                                            <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                Cumulative
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50px;">
                                                                <asp:TextBox ID="DPR_txtDailyReportDtID" runat="server" Width="50" Visible="false"></asp:TextBox>
                                                                <asp:TextBox ID="DPR_txtSequenceNo" runat="server" Width="50"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:DropDownList ID="DPR_ddlWeatherCondition" runat="server" Width="100">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: auto;">
                                                                <asp:TextBox ID="DPR_txtDescription" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 80px;">
                                                                <asp:TextBox ID="DPR_txtQtyCurrent" runat="server" Width="80"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 80px;">
                                                                <asp:TextBox ID="DPR_txtQtyPrevious" runat="server" Width="80"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 80px;">
                                                                <asp:TextBox ID="DPR_txtQtyCumulative" runat="server" Width="80"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:DataGrid ID="DPR_grdDailyReportDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="DPR_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Sequence No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="DPR_lblDailyReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DailyReportDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Weather">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "weatherConditionName") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Current Qty">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "currentQty") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Previous Qty">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "beginningQty") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Cumulative">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "endingQty") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlDailyInspectionReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="5">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report ID
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DIR_txtDailyReportHdID" runat="server" Width="200" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:Button ID="DIR_btnSearchDailyReportHd" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="DIR_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="gridAlternatingItemStyle center" style="width: 50px;">
                                                                No
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 100px;">
                                                                Weather
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 45%;">
                                                                Description
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 100px;">
                                                                Quantity
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 30%;">
                                                                Result
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtDailyReportDtID" runat="server" Visible="false"></asp:TextBox>
                                                                <asp:TextBox ID="DIR_txtSequenceNo" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DIR_ddlWeatherCondition" runat="server" Width="100%">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtDescription" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtQty" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtResult" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <asp:DataGrid ID="DIR_grdDailyReportDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="DIR_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Sequence No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="DIR_lblDailyReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DailyReportDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Weather">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "weatherConditionName") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Qty">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "currentQty") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Result">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "result")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlServiceReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Service Report for
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="SR_ddlServiceReportFor" runat="server" Width="300">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="SR_txtServiceReportID" runat="server" Width="266" Visible="false"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Service Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="SR_calServiceReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="Heading1">
                                                                            Type of Inspection/Service
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="SR_txtTypeOfInspection" runat="server" Width="100%" TextMode="MultiLine"
                                                                                Height="100" Style="font-family: Segoe UI, Arial, tahoma"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="Heading1">
                                                                            Material Description
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <asp:Panel ID="SR_pnlTubular" runat="server">
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Manufacturer
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtManufacturer" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Type of Pipe
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtTypeOfPipe" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Pipe Wt. Lbs/ft
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtPipeWeight" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Pipe O.D.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtPipeOD" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Thread Connection
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtThreadConnection" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Pipe Grade
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtPipeGrade" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Range
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtRange" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Total Inspected
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtTotalInspected" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Total Accepted
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtTotalAccepted" runat="server" Width="300"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="SR_pnlNotTubular" runat="server">
                                                                        <tr>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="SR_txtMaterialDescription" runat="server" Width="100%" TextMode="MultiLine"
                                                                                    Height="100" Style="font-family: Segoe UI, Arial, tahoma"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                    <tr>
                                                                        <td colspan="4" class="Heading1">
                                                                            Result
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="SR_txtResult" runat="server" Width="100%" TextMode="MultiLine" Height="100"
                                                                                Style="font-family: Segoe UI, Arial, tahoma"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataGrid ID="SR_grdServiceReport" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="SR_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "serviceReportDate"), "dd-MMM-yyyy") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="For">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "serviceReportFor") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Service Report ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="SR_lblServiceReportID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "serviceReportID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlMPIReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="5">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="right">
                                                                            MPI Report Type
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="MPI_ddlMPIType" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Report No
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtMPIHdID" runat="server" Width="200" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="MPI_txtReportNo" runat="server" Width="200" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:Button ID="MPI_btnReportNo" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="MPI_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Serial No
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtSerialNo" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Expired Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="MPI_calExpiredDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtDescription" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right" colspan="2" rowspan="4" valign="top">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" colspan="2">
                                                                                        Acceptance Criteria
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="MPI_chkACIsASME" runat="server" Text="ASME" />
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="MPI_chkACIsAPISpec" runat="server" Text="API Spec." />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="MPI_chkIsACDS1" runat="server" Text="DS-1" />
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="MPI_chkIsACOther" runat="server" Text="Other" /><br />
                                                                                        <asp:TextBox ID="MPI_txtACOtherDescription" runat="server" Width="100"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Quantity
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtQty" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Dimension
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtDimension" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Area Inspection
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtAreaInspection" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Material
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtMaterial" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Application
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtApplication" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Surface Condition
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtSurfaceCondition" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Contrast
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtContrast" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Metal Surface Temp.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtMetalSurfaceTemp" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Magnetic Particle
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtMagneticParticle" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Material Thickness
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtMaterialThickness" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Cleaner
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtCleaner" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Set Calibration
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtSetCalibration" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Penetrant
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtPenetrant" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Pole Spacing
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtPoleSpacing" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Developer
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtDeveloper" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle center" colspan="2">
                                                                            Equipment - Mag Current
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center">
                                                                            System
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center">
                                                                            Surface Preparation
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" valign="top">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        Yoke
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlYoke" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        Coil
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlCoil" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="MPI_chkIsBlacklight" runat="server" Text="Blacklight" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="MPI_chkIsRods" runat="server" Text="Rods" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        Fluorescent
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlFluorescent" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        Contrast B/W
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlContrastBW" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="MPI_chkIsDyePenetrant" runat="server" Text="Dye Penetrant" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="MPI_chkIsWireBrush" runat="server" Text="Wire Brush" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="MPI_chkIsBlastCleaning" runat="server" Text="Blast Cleaning" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="MPI_chkIsGrinding" runat="server" Text="Grinding" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="MPI_chkIsMachining" runat="server" Text="Machining" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Inspection Result/Comments
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="MPI_txtInspectionResult" runat="server" Width="100%" TextMode="MultiLine"
                                                                                Height="50" Font-Names="Segoe UI, Arial, Verdana"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Notes
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="MPI_txtNotes" runat="server" Width="100%" TextMode="MultiLine" Height="50"
                                                                                Font-Names="Segoe UI, Arial, Verdana"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Panel ID="MPI_pnlMPIDt" runat="server">
                                                                                <table cellpadding="2" cellspacing="1" width="100%">
                                                                                    <tr>
                                                                                        <td class="gridHeaderStyle center">
                                                                                            Image File
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%--<input id="MPI_ImageFile" type="file" runat="server" autopostback="True" name="MPI_ImageFile"
                                                                                                class="imguploader" style="width: 404;" />--%>
                                                                                            <asp:FileUpload ID="MPI_fuImage" runat="server" />
                                                                                            <asp:DropDownList ID="MPI_ddlPicGroup" runat="server" Width="150">
                                                                                            </asp:DropDownList>
                                                                                            <asp:TextBox ID="MPI_txtPicDescription" runat="server" Width="300"></asp:TextBox>
                                                                                            <asp:Button ID="MPI_btnUploadImage" runat="server" Text="Upload" CssClass="sbttn"
                                                                                                Width="100" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Image ID="MPI_ImagePreview" runat="server" />
                                                                                            <!-- Place for DataGrid MPIDt -->
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
                                                </asp:Panel>
                                                <asp:Panel ID="pnlHardnessTestReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="12">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="HT_txtHardnessTestHdID" runat="server" Width="200" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="HT_txtReportNo" runat="server" Width="200" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:Button ID="HT_btnReportNo" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="HT_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="gridAlternatingItemStyle center" style="width: 50px;" rowspan="2">
                                                                Pipe No.
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 100px;" rowspan="2">
                                                                Location
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 40%;" colspan="5">
                                                                Rockwell B Method (HRB)
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 40%;" colspan="5">
                                                                Brinell Method (HB)
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="gridAlternatingItemStyle center">
                                                                1
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                2
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                3
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                4
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Avg
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                1
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                2
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                3
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                4
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Avg
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHardnessTestDtID" runat="server" Visible="false"></asp:TextBox>
                                                                <asp:TextBox ID="HT_txtPipeNo" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="HT_ddlLocation" runat="server" Width="100%">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB1" runat="server" Width="100%" onkeyup="countAvgHRB()"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB2" runat="server" Width="100%" onkeyup="countAvgHRB()"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB3" runat="server" Width="100%" onkeyup="countAvgHRB()"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB4" runat="server" Width="100%" onkeyup="countAvgHRB()"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRBAvg" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB1" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB2" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB3" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB4" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHBAvg" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="12">
                                                                <asp:DataGrid ID="HT_grdHardnessTestDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="HT_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="HT_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Pipe No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="HT_lblHardnessTestDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "hardnessTestDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "pipeNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Location">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "locationName") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HRB-1">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HRB1") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HRB-2">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HRB2") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HRB-3">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HRB3")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HRB-4">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HRB4")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HRB-Avg">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HRBAvg")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HB-1">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HB1") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HB-2">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HB2")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HB-3">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HB3")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HB-4">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HB4")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="HB-Avg">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "HBAvg")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlDrillPipeInspectionReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="6">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report ID - Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_txtDrillPipeReportHdID" runat="server" Width="166" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:Button ID="DP_btnSearchDrillPipeReport" runat="server" Text="..." Width="30" />
                                                                            <asp:TextBox ID="DP_txtReportNo" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="DP_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Specification
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_txtSpecificationID" runat="server" Width="200" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="DP_txtSpecificationCode" runat="server" Width="166" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:Button ID="DP_btnSearchSpecification" runat="server" Text="..." Width="30" />
                                                                            <asp:TextBox ID="DP_txtSpecificationName" runat="server" Width="200" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table cellpadding="2" cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center" colspan="2">
                                                                            Size
                                                                        </td>
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center" colspan="2">
                                                                            Weight
                                                                        </td>
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center" colspan="3">
                                                                            Grade
                                                                        </td>
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center" colspan="3">
                                                                            Connection
                                                                        </td>
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center" colspan="3">
                                                                            Range
                                                                        </td>
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center" colspan="3">
                                                                            Nominal W.T.
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="DP_txtSize" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="DP_txtWeight" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtGrade" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtConnection" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtRange" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtNominalWT" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="16" class="gridHeaderStyle center">
                                                                            Criteria
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridFooterStyle center" colspan="5">
                                                                            Premium Class
                                                                        </td>
                                                                        <td class="gridFooterStyle center" colspan="11">
                                                                            Class 2
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. OD
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Max. ID
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. Wall
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. Shldr
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. Seal
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. OD
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Max. ID
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. Wall
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. Shldr
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Min. Seal
                                                                        </td>
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center">
                                                                            Min. Tong Space P/B
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Max. QC
                                                                        </td>
                                                                        <td style="width: 40px;" class="gridAlternatingItemStyle center">
                                                                            Bevel Dia
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Min. QC Depth
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Max. Length Pin
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Max. Pin Neck
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Premium_txtMinOD" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Premium_txtMaxID" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Premium_txtMinWall" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Premium_txtMinShoulder" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Premium_txtMinSeal" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinOD" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxID" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinWall" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinShoulder" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinSeal" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinTongSpacePB" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxQC" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtBevelDia" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinQCDepth" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxLengthPin" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxPinNeck" runat="server" Width="100%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table cellpadding="2" cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_txtDrillPipeReportDtID" runat="server" Width="200" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="DP_txtSequenceNo" runat="server" Width="80"></asp:TextBox>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_txtSerialNo" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Body
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <table cellpadding="2" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Body Wear
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Bent
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Body Damage
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        EMI
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        UT End Area
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Plastic Coating
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Wall
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Wall Remanent
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Tube Class
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdBodyWear" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdBent" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdBodyDamage" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdEMI" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdUTEndArea" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdPlasticCoating" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdWall" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdWallRemanent" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbdTubeClass" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Pin Connection
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <table cellpadding="2" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Tool Joint Year
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Outside Dia
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Inside Dia
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Tong Space
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Thread Length
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Bevel Dia
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Lead
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Shoulder Width
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Neck Length
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Reface
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Final Condition
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcToolJointYear" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcOutsideDia" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcInsideDia" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcTongSpace" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcThreadLength" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcBevelDia" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcLead" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcShoulderWidth" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcNeckLength" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcReface" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtpcFinalCondition" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Box Connection
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <table cellpadding="2" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Outside Dia
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Tong Space
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        QC Dia
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        QC Depth
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Shoulder Witdh
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Bevel Dia
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Seal Width
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Reface
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Final Condition
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcOutsideDia" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcTongSpace" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcQCDia" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcQCDepth" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcShoulderWidth" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcBevelDia" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcSealWidth" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcReface" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtbcFinalCondition" runat="server" CssClass="txtSmallText" Width="100%"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Remarks
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtRemarks" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" class="txtweak">
                                                                <asp:DataGrid ID="DP_grdDrillPipeReportDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="DP_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="DP_lblDrillPipeReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DrillPipeReportDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Serial No.">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "serialNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td style="width: 250px;" colspan="3" class="rheaderSmallText center">
                                                                                            Body
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Body Wear
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Bent
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Body Damage
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdBodyWear")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdBent")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdBodyDamage")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            EMI
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            UT End Area
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Plastic Coating
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdEMI")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdUTEndArea")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdPlasticCoating")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Wall
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Wall Remanent
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Tube Class
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdWall")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdWallRemanent")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bdTubeClass")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td style="width: 250px;" colspan="3" class="rheaderSmallText center">
                                                                                            Pin Connection
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Tool Joint Year
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Outside Dia
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Inside Dia
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcToolJointYear")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcOutsideDia")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcInsideDia")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Tong Space
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Thread Length
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Bevel Dia
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcTongSpace")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcThreadLength")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcBevelDia")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Lead
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Shoulder Width
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Neck Length
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcLead")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcShoulderWidth")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcNeckLength")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Reface
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Final Condition
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcReface")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pcFinalCondition")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td style="width: 250px;" colspan="3" class="rheaderSmallText center">
                                                                                            Box Connection
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Outside Dia
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Tong Space
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            QC Dia
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcOutsideDia")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcTongSpace")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcQCDia")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            QC Depth
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Shoulder Width
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Bevel Dia
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcQCDepth")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcShoulderWidth")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcBevelDia")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Seal Width
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Reface
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Final Condition
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcSealWidth")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcReface")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bcFinalCondition")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remarks">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "remarks") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlThroughVisualInspectionReport" runat="server">
                                                    This is Through Visual Inspection Report Panel
                                                </asp:Panel>
                                                <asp:Panel ID="pnlInspectionTallyReport" runat="server">
                                                    This is Inspection Tally Report Panel
                                                </asp:Panel>
                                                <asp:Panel ID="pnlUTSpotCheck" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtUTSpotCheckHdID" runat="server" Width="200" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="UTSC_txtReportNo" runat="server" Width="200" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:Button ID="UTSC_btnReportNo" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="UTSC_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Nominal W.T.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtNominalWT" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Minimal W.T.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtMinimalWT" runat="server" Width="200"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="gridAlternatingItemStyle center" rowspan="2">
                                                                Tally No.
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" rowspan="2">
                                                                Location
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 40%;" colspan="3">
                                                                Wall Thickness in Inch
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" rowspan="2">
                                                                Remark
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="gridAlternatingItemStyle center">
                                                                1
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                2
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                3
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtUTSpotCheckDtID" runat="server" Visible="false"></asp:TextBox>
                                                                <asp:TextBox ID="UTSC_txtTallyNo" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtLocation" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtWallThicknessInch1" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtWallThicknessInch2" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtWallThicknessInch3" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtRemark" runat="server" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:DataGrid ID="UTSC_grdUTSpotCheckDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="UTSC_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="UTSC_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Tally No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="UTSC_lblUTSpotCheckDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UTSpotCheckDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "tallyNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Location">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "location") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Wall Thickness-1 (Inch)">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "wallThicknessInch1") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Wall Thickness-2 (Inch)">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "wallThicknessInch2")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Wall Thickness-3 (Inch)">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "wallThicknessInch3")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remark">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "remark")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlRotaryShoulderConnectionReport" runat="server">
                                                    This is Rotary Shoulder Connection Report Panel
                                                </asp:Panel>
                                                <asp:Panel ID="pnlUTSpotEndArea" runat="server">
                                                    This is UT Spot End Area (Cat 5) Panel
                                                </asp:Panel>
                                                <asp:Panel ID="pnlCertificateInspection" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Certificate No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtCertificateInspectionID" runat="server" Width="300" Visible="false"></asp:TextBox>
                                                                            <asp:TextBox ID="COI_txtCertificateNo" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Certificate Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="COI_calCertificateDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Owner
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtOwner" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            User
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtUser" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Location
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtLocation" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtDescription" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtSerialNo" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Max Gross Weight (R)
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtMaxGossWeightR" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Load Test
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtLoadTest" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Duration
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtDuration" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Specification
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtSpecification" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Examination
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtExamination" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Result
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtResult" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Inspection Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="COI_caInspectionDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Expired Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="COI_calExpiredDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Notes
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtNotes" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataGrid ID="COI_grdCertificateInspection" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="COI_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="COI_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Certificate No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="COI_lblCertificateOfInspectionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "certificateInspectionID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "certificateNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "certificateDate"), "dd-MMM-yyyy")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Expired Date">
                                                                            <ItemTemplate>
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "expiredDate"), "dd-MMM-yyyy")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Serial No.">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "serialNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Result">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "result") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="bottom">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
