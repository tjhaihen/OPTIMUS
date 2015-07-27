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
        
        #ulRepMPIimages
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepMPIimages li
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
                                            <asp:TextBox ID="txtWorkRequestListFilter" runat="server" Width="200">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlWorkRequestListFilter" runat="server" Width="130" AutoPostBack="true">
                                                <asp:ListItem Text="In Progress" Value="InProgress">
                                                </asp:ListItem>
                                                <asp:ListItem Text="Done" Value="Done">
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtWorkRequestListDisplayFilter" runat="server" Width="80" ToolTip="Display top N records"
                                                CssClass="right" Text="50">
                                            </asp:TextBox>
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
                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                    <itemstyle cssclass="gridItemStyle" />
                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                    <columns>
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
                                    </columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlInspectorScreen" runat="server">
                    <table style="height: 100%;">
                        <tr>
                            <td style="width: 200px; background: #eeeeee;" valign="top">
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
                                            <asp:TextBox ID="txtProjectID" runat="server" Visible="false">
                                            </asp:TextBox>
                                            <asp:TextBox ID="txtProjectCode" runat="server" Width="146" AutoPostBack="true">
                                            </asp:TextBox>
                                            <asp:Button ID="btnSearchProject" runat="server" Text="..." Width="30" />
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td>
                                            <asp:TextBox ID="txtProjectName" runat="server" ReadOnly="true" CssClass="txtreadonly">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr class="rheaderexpable">
                                                    <td align="left" valign="middle">
                                                        <img style="cursor: pointer" onclick="javascript:if (divAddRemoveReport.style.display == '') {divAddRemoveReport.style.display = 'none'; this.src='/pureravensLib/images/add.png'; } else { divAddRemoveReport.style.display = ''; this.src='/pureravensLib/images/add.png';}"
                                                            alt="Add/Remove" src="/pureravensLib/images/add.png" align="absmiddle">
                                                        Add/Remove Report
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divAddRemoveReport" style="overflow: auto; width: 100%; display: none;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnAddReportType" runat="server" text="Add" width="100%" CssClass="sbttn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DataGrid ID="grdReportTypeAdd" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                <itemstyle cssclass="gridItemStyle" />
                                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                <columns>
                                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="_chkSelect" runat="server"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Report Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportTypeID") %>'
                                                                                ID="_lblReportTypeID" Visible="false" />
                                                                            <%# DataBinder.Eval(Container.DataItem, "reportTypeName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnRemoveReportType" runat="server" text="Remove" width="100%" CssClass="sbttn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DataGrid ID="grdReportTypeRemove" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                <itemstyle cssclass="gridItemStyle" />
                                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                <columns>
                                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="_chkSelect" runat="server"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Report Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectReportTypeID") %>'
                                                                                ID="_lblProjectReportTypeID" Visible="false" />
                                                                            <%# DataBinder.Eval(Container.DataItem, "reportTypeName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataGrid ID="grdReportTypeByProject" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="2" ShowHeader="false" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                <itemstyle cssclass="gridMedHeightItemStyle" />
                                                <alternatingitemstyle cssclass="gridMedHeightItemStyle" />
                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                <columns>
                                                    <asp:TemplateColumn runat="server">
                                                        <ItemTemplate>
                                                            <asp:Panel ID="_pnlProduct" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "isheader") %>'>
                                                                <table width="100%" cellspacing="0" cellpadding="2" style="background: #eeeeee;">
                                                                    <tr>
                                                                        <td style="margin: 15 0 0 0; background: #36C1D6; color: #ffffff;">
                                                                            <%# DataBinder.Eval(Container.DataItem, "ProductName") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 0 0 10 0; background: #ffffff;">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <table width="100%" cellspacing="0" cellpadding="2" style="background: #eeeeee;">
                                                                <tr>
                                                                    <td style="margin: 15 0 0 0; width: 2px; background: #89929A;">
                                                                    </td>
                                                                    <td style="margin: 15 0 0 0; height: 36px; background: #ffffff; vertical-align: top;">
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportTypeID") %>'
                                                                            ToolTip='<%# DataBinder.Eval(Container.DataItem, "ReportTypeCode") %>' ID="_lblReportTypeID"
                                                                            Visible="false" />
                                                                        <asp:LinkButton ID="_lbtnReportTypeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportTypeName")%>'
                                                                            Width="100%" CommandName="SelectReportType" CssClass="txtnormallink" ToolTip='<%# DataBinder.Eval(Container.DataItem, "PanelID")%>' />
                                                                        <asp:CheckBox ID="_chkIsHasAttachment" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "isHasAttachment")%>' Visible="false"></asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </columns>
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
                                        <asp:Panel ID="pnlProjectFile" runat="server">
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr class="message">
                                                            <td align="left" valign="middle">
                                                                <img style="cursor: pointer" onclick="javascript:if (divMessage.style.display == '') {divMessage.style.display = 'none'; this.src='/pureravensLib/images/information.png'; } else { divMessage.style.display = ''; this.src='/pureravensLib/images/information.png';}"
                                                                    alt="Show/Hide Message" src="/pureravensLib/images/information.png" align="absmiddle">
                                                                This project has shared attachment(s)
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div id="divMessage" style="overflow: auto; width: 100%; display: none;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:DataGrid ID="grdSharedProjectFile" runat="server" BorderWidth="0" GridLines="None"
                                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                        AutoGenerateColumns="false">
                                                                        <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                        <itemstyle cssclass="gridItemStyle" />
                                                                        <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                        <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                        <columns>
                                                                            <asp:TemplateColumn runat="server" HeaderText="" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderStyle-Width="26" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="26">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="_lblProjectFileID" runat="server" visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "projectFileID") %>' />                                                                                                                                                
                                                                                    <a href='<%# DataBinder.Eval(Container.DataItem, "fileUrl") %>' target="_blank">
                                                                                        <img src="/pureravensLib/images/look.png" border="0" align="middle" alt='<%# DataBinder.Eval(Container.DataItem, "fileName") %>' />
                                                                                    </a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="File No." HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderStyle-Width="200" ItemStyle-Width="200" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "fileNo") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="File Name" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "fileName") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="txtweak">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Type" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150">
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "fileExtension") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                        </columns>
                                                                    </asp:DataGrid>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </asp:Panel>
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
                                                <asp:Label ID="lblReportTypeID" runat="server" Visible="false"></asp:Label>
                                                <asp:CheckBox ID="chkIsHasAttachment" runat="server" Visible="false"></asp:CheckBox>
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
                                                                <asp:TextBox ID="CCR_txtCCRID" runat="server" Visible="false">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="CCR_txtSequenceNo" runat="server" Width="50">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td style="width: auto;">
                                                                <asp:TextBox ID="CCR_txtDescription" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:DropDownList ID="CCR_ddlTypeOfReport" runat="server" Width="100">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:TextBox ID="CCR_txtPreparedByName" runat="server" Width="100">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <Module:Calendar ID="CCR_calPreparedDate" runat="server" DontResetDate="true" />
                                                            </td>
                                                            <td style="width: 150px;">
                                                                <asp:TextBox ID="CCR_txtReportNo" runat="server" Width="150">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:TextBox ID="CCR_txtRemarks" runat="server" Width="100">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:DataGrid ID="CCR_grdCheckListOfCompletionReport" runat="server" BorderWidth="0"
                                                                    GridLines="None" Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true"
                                                                    ShowFooter="false" AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
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
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlServiceAcceptance" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:DataGrid ID="SA_grdProjectDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="SA_ibtnPrint" runat="server" ImageUrl="/PureravensLib/images/print.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Print" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Description" ItemStyle-Width="450px">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="SA_lblProjectDtID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "projectDtID") %>' />
                                                                                <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Reference No." ItemStyle-Width="100px">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "referenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Qty" ItemStyle-Width="80px">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "Qty") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="UOM" ItemStyle-Width="100px">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "unitOfMeasurement") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Detail Description" ItemStyle-Width="450px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="SA_txtdescriptionDetail" runat="server" BorderStyle="None" CssClass="txtweak"
                                                                                    TextMode="MultiLine" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "descriptionDetail") %>'></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                                    <asp:ListItem Value="Entry" Text="Entry" Selected="True">
                                                                    </asp:ListItem>
                                                                    <asp:ListItem Value="Upload" Text="Upload">
                                                                    </asp:ListItem>
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
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Location
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Inspect By (SES)
                                                                </td>
                                                                <td style="width: 100px;" class="gridAlternatingItemStyle center">
                                                                    Report No. (#1)
                                                                </td>
                                                                <td class="gridAlternatingItemStyle center">
                                                                    Description of Equipment
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Dimensional
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Serial/ID No.
                                                                </td>
                                                                <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                    Manufacture
                                                                </td>
                                                                <td style="width: 100px;" class="gridAlternatingItemStyle center">
                                                                    SWL/WWL/MGW
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtSummaryOfInspectionID" runat="server" Width="50" Visible="false">
                                                                    </asp:TextBox>
                                                                    <asp:TextBox ID="SOI_txtSequenceNo" runat="server" Width="100%" CssClass="right">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtLocation" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtInspectorName" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtReportNo_1" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtDescOfEquip" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtDimensional" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtSerialNo" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtManufacture" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtSWLWWLMGW" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table cellpadding="2" cellspacing="1" width="100%">
                                                            <tr>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Result
                                                                </td>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                    Defect Found
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
                                                                <td style="width: 240px;" class="gridAlternatingItemStyle center" colspan="4">
                                                                    Type of Inspect
                                                                </td>
                                                                <td style="width: 240px;" class="gridAlternatingItemStyle center" colspan="3">
                                                                    Process
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 60px;" class="gridAlternatingItemStyle center">
                                                                    DS 1 CAT 3-5
                                                                </td>
                                                                <td style="width: 60px;" class="gridAlternatingItemStyle center">
                                                                    DS 1 CAT 4
                                                                </td>
                                                                <td style="width: 60px;" class="gridAlternatingItemStyle center">
                                                                    API SPEC 7
                                                                </td>
                                                                <td style="width: 60px;" class="gridAlternatingItemStyle center">
                                                                    API RP 7G
                                                                </td>
                                                                <td style="width: 60px;" class="gridAlternatingItemStyle center">
                                                                    Hard Banding
                                                                </td>
                                                                <td style="width: 60px;" class="gridAlternatingItemStyle center">
                                                                    Int-Ext Cleaning
                                                                </td>
                                                                <td style="width: 60px;" class="gridAlternatingItemStyle center">
                                                                    UT Slip & Upset Area
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtResult" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtDefectFound" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <Module:Calendar ID="SOI_calExamDate" runat="server" DontResetDate="true" />
                                                                </td>
                                                                <td>
                                                                    <Module:Calendar ID="SOI_calExpiredDate" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtReportNumber" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsV" runat="server" visible="false">
                                                                    </asp:CheckBox>
                                                                    <asp:CheckBox ID="SOI_chkIsDS1CAT3to5" runat="server">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsN" runat="server" visible="false">
                                                                    </asp:CheckBox>
                                                                    <asp:CheckBox ID="SOI_chkIsDS1CAT4" runat="server">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsT" runat="server" visible="false">
                                                                    </asp:CheckBox>
                                                                    <asp:CheckBox ID="SOI_chkIsAPISPEC7" runat="server">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsAPIRP7G" runat="server">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsHardbanding" runat="server">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsIntExtCleaning" runat="server">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td class="center">
                                                                    <asp:CheckBox ID="SOI_chkIsUTSlipUpsetArea" runat="server">
                                                                    </asp:CheckBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 150px;" class="gridAlternatingItemStyle center">
                                                                    Interval
                                                                </td>
                                                                <td style="width: 250px;" class="gridAlternatingItemStyle center">
                                                                    Remarks
                                                                </td>
                                                                <td colspan="2" class="gridAlternatingItemStyle center">
                                                                    Upload File
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtInterval" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="SOI_txtRemarks" runat="server" Width="100%">
                                                                    </asp:TextBox>
                                                                </td>
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
                                                                    <asp:TextBox ID="SOI_txtSheetName" runat="server" Width="200" Text="Sheet1">
                                                                    </asp:TextBox>
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
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
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
                                                                    </columns>
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
                                                                                <headertemplate>
                                                                                    <ul id="ulRepDate">
                                                                                </headertemplate>
                                                                                <itemtemplate>
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
                                                                                </itemtemplate>
                                                                                <footertemplate>
                                                                                    </ul>
                                                                                </footertemplate>
                                                                            </asp:Repeater>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <asp:ListView ID="lvwTimeSheet" runat="server" OnItemDataBound="lvwTimeSheet_ItemDataBound">
                                                                    <layouttemplate>
                                                                        <table id="tblView" runat="server" class="lvwView" cellspacing="1" border="0" style="border-style: solid;
                                                                            border-width: 1px; border-color: #999999;">
                                                                            <tr runat="server" id="itemPlaceholder">
                                                                            </tr>
                                                                        </table>
                                                                    </layouttemplate>
                                                                    <itemtemplate>
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
                                                                    </itemtemplate>
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
                                                                            <asp:TextBox ID="DPR_txtDailyReportHdID" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:TextBox>
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
                                                            <td style="width: 300px;" class="gridAlternatingItemStyle center" rowspan="2">
                                                                Description
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" colspan="3">
                                                                Quantity/UOM
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Current
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Previous
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Cumulative
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="gridAlternatingItemStyle right">
                                                                Material Detail
                                                            </td>
                                                            <td colspan="4">
                                                                <asp:TextBox ID="DPR_txtMaterialDetail" runat="server" Width="99.2%">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50px;">
                                                                <asp:TextBox ID="DPR_txtDailyReportDtID" runat="server" Width="50" Visible="false">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="DPR_txtSequenceNo" runat="server" Width="50">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td style="width: 100px;">
                                                                <asp:DropDownList ID="DPR_ddlWeatherCondition" runat="server" Width="100">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: auto;">
                                                                <asp:TextBox ID="DPR_txtDescription" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DPR_txtQtyCurrent" runat="server" Width="48%">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="DPR_txtUOMCurrent" runat="server" Width="48%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DPR_txtQtyPrevious" runat="server" Width="48%">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="DPR_txtUOMPrevious" runat="server" Width="48%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DPR_txtQtyCumulative" runat="server" Width="48%">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="DPR_txtUOMCumulative" runat="server" Width="48%">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:DataGrid ID="DPR_grdDailyReportDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="DPR_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="DPR_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Sequence No." ItemStyle-Width="90">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="DPR_lblDailyReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DailyReportDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Material Detail" ItemStyle-Width="220">
                                                                            <ItemTemplate>
                                                                                <%# Left(DataBinder.Eval(Container.DataItem, "materialDetail"), 30) + "..." %>
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
                                                                                <%# DataBinder.Eval(Container.DataItem, "currentUOM") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Previous Qty">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "beginningQty") %>
                                                                                <%# DataBinder.Eval(Container.DataItem, "beginningUOM")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Cumulative">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "endingQty") %>
                                                                                <%# DataBinder.Eval(Container.DataItem, "endingUOM") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlDailyProgressReportMPI" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="5">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report ID
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DIR_txtDailyReportHdID" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:TextBox>
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
                                                            <td class="gridAlternatingItemStyle center" style="width: 120px;">
                                                                Quantity/UOM
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 30%;">
                                                                Result
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtDailyReportDtID" runat="server" Visible="false">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="DIR_txtSequenceNo" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DIR_ddlWeatherCondition" runat="server" Width="100%">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtDescription" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtQty" runat="server" Width="70" CssClass="right">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="DIR_txtUOM" runat="server" Width="50">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="DIR_txtResult" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <asp:DataGrid ID="DIR_grdDailyReportDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
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
                                                                                &nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "currentUOM") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Result">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "result")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
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
                                                                            <asp:DropDownList ID="SR_ddlServiceReportFor" runat="server" Width="300" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="SR_txtServiceReportID" runat="server" Width="266" Visible="false">
                                                                            </asp:TextBox>
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
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="SR_txtTypeOfInspectionCol1" runat="server" Width="100%" TextMode="MultiLine"
                                                                                Height="100" Style="font-family: Segoe UI, Arial, tahoma">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="SR_txtTypeOfInspectionCol2" runat="server" Width="100%" TextMode="MultiLine"
                                                                                Height="100" Style="font-family: Segoe UI, Arial, tahoma">
                                                                            </asp:TextBox>
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
                                                                                <asp:TextBox ID="SR_txtManufacturer" runat="server" Width="300">
                                                                                </asp:TextBox>
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
                                                                                <asp:TextBox ID="SR_txtTypeOfPipe" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Pipe Wt. Lbs/ft
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtPipeWeight" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Pipe O.D.
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtPipeOD" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Thread Connection
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtThreadConnection" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Pipe Grade
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtPipeGrade" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Range
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtRange" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Total Inspected
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtTotalInspected" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                Total Accepted
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="SR_txtTotalAccepted" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="SR_txtMaterialDescription" runat="server" Width="100%" TextMode="MultiLine"
                                                                                Height="100" Style="font-family: Segoe UI, Arial, tahoma; font-size: 12pt; font-weight: bold;">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" class="Heading1">
                                                                            Result
                                                                        </td>
                                                                        <td class="right">
                                                                            <asp:Button id="SR_btnSaveServiceReportDt" runat="server" text="Add" CssClass="sbttn" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" style="width: 100%;">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 80px;" class="right">
                                                                                        Qty
                                                                                    </td>
                                                                                    <td style="width: 100px;">
                                                                                        <asp:TextBox ID="SR_txtServiceReportDtID" runat="server" Visible="False">
                                                                                        </asp:TextBox>
                                                                                        <asp:TextBox ID="SR_txtNTQty" runat="server" Width="100%" class="right">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;" class="right">
                                                                                        U.O.M.
                                                                                    </td>
                                                                                    <td style="width: 100px;">
                                                                                        <asp:TextBox ID="SR_txtNTUOM" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;" class="right">
                                                                                        Result
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="SR_txtNTResult" runat="server" Width="300">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none;">
                                                                        <td style="width: 100px;" class="right">
                                                                            Name
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="SR_txtNTName" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="SR_txtNTSerialNo" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="SR_txtNTDimension" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:DataGrid ID="SR_grdServiceReportDt" runat="server" BorderWidth="0" GridLines="None"
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
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Name" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="SR_lblServiceReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "serviceReportDtID") %>' Visible="false"></asp:Label>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ntName")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Serial No." Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ntSerialNo")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ntQty")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="U.O.M.">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ntUOM")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Dimension" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ntDimension")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Result">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ntResult")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                                ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </columns>
                                                                            </asp:DataGrid>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="Heading1">
                                                                            Final Judgement and Notes
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="hseparator" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="SR_txtResult" runat="server" Width="100%" TextMode="MultiLine" Height="100"
                                                                                Style="font-family: Segoe UI, Arial, tahoma">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataGrid ID="SR_grdServiceReport" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
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
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="SR_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
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
                                                                        <td colspan="2">
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
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtMPIHdID" runat="server" Width="200" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="MPI_txtReportNo" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:TextBox>
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
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtSerialNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Expired Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="MPI_calExpiredDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Description
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtDescription" runat="server" Width="200">
                                                                            </asp:TextBox>
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
                                                                                        <asp:CheckBox ID="MPI_chkACIsASME" runat="server" Text="" />
                                                                                        <asp:TextBox ID="MPI_txtACASMEDescription" runat="server" Text="ASME" Width="100">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="MPI_chkACIsAPISpec" runat="server" Text="" />
                                                                                        <asp:TextBox ID="MPI_txtACAPISpecDescription" runat="server" Text="API Spec." Width="100">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="MPI_chkIsACDS1" runat="server" Text="" />
                                                                                        <asp:TextBox ID="MPI_txtACDS1Description" runat="server" Text="DS-1" Width="100">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="MPI_chkIsACOther" runat="server" Text="" />
                                                                                        <asp:TextBox ID="MPI_txtACOtherDescription" runat="server" Text="Other" Width="100">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Quantity
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtQty" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Dimension
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtDimension" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Area Inspection
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtAreaInspection" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Material
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtMaterial" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Cleaner
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtCleaner" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Surface Condition
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtSurfaceCondition" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Penetrant
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtPenetrant" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Metal Surface Temp.
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtMetalSurfaceTemp" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Developer
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtDeveloper" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Material Thickness
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtMaterialThickness" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Contrast
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtContrast" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Set Calibration
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtSetCalibration" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Magnetic Particle
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtMagneticParticle" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Pole Spacing
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="MPI_txtPoleSpacing" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="right">
                                                                            Application
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="MPI_txtApplication" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle center">
                                                                            Equipment
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center">
                                                                            Serial Number
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center">
                                                                            Mag Current
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center">
                                                                            System
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center">
                                                                            Surface Preparation
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table>
                                                                                <tr style="display: none;">
                                                                                    <td class="right">
                                                                                        Yoke
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlYoke" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="display: none;">
                                                                                    <td class="right">
                                                                                        Coil
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlCoil" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Yoke
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlEqpYoke" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Coil
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlEqpCoil" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Rods
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlRods" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Blacklight
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlBlacklight" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="MPI_txtYokeSerialNo" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="MPI_txtCoilSerialNo" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="MPI_txtRodsSerialNo" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="MPI_txtBlacklightSerialNo" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Permanent
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlMagPermanent" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Active
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlMagActive" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table>
                                                                                <tr style="display: none;">
                                                                                    <td class="right">
                                                                                        Fluorescent
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlFluorescent" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="display: none;">
                                                                                    <td class="right">
                                                                                        Contrast B/W
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlContrastBW" runat="server" RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Wet
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlSysWet" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Dry
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlSysDry" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Dye
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlSysDye" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Fluorescent
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlSysFluorescent" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Contrast B/W
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlSysContrastBW" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Dye Penetrant
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlDyePenetrant" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Grinding
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlGrinding" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Machining
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlMachining" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Blast Cleaning
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlBlastCleaning" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="right">
                                                                                        Wire Brushing
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="MPI_rbtnlWireBrush" runat="server" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="Yes">
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Text="No" Value="No">
                                                                                            </asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Inspection Result/Comments
                                                                        </td>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="MPI_txtInspectionResult" runat="server" Width="100%" TextMode="MultiLine"
                                                                                Height="50" Font-Names="Segoe UI, Arial, Verdana">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="right">
                                                                            Notes
                                                                        </td>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="MPI_txtNotes" runat="server" Width="100%" TextMode="MultiLine" Height="50"
                                                                                Font-Names="Segoe UI, Arial, Verdana">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5" class="hseparator">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <asp:Panel ID="MPI_pnlMPIDt" runat="server">
                                                                                <table cellpadding="2" cellspacing="1" width="100%">
                                                                                    <tr>
                                                                                        <td class="gridHeaderStyle center">
                                                                                            Image File
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="MPI_txtMPIDtID" runat="server" Visible="false">
                                                                                            </asp:TextBox>
                                                                                            <input id="MPI_ImageFile" type="file" runat="server" autopostback="True" name="MPI_ImageFile"
                                                                                                class="imguploader" style="width: 404;" />
                                                                                            <asp:DropDownList ID="MPI_ddlPicGroup" runat="server" Width="150">
                                                                                            </asp:DropDownList>
                                                                                            <asp:TextBox ID="MPI_txtPicDescription" runat="server" Width="300">
                                                                                            </asp:TextBox>
                                                                                            <asp:Button ID="MPI_btnUploadImage" runat="server" Text="Upload" CssClass="sbttn"
                                                                                                Width="100" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <!-- Place for DataGrid MPIDt -->
                                                                                            <asp:Repeater ID="MPI_repMPIimages" runat="server">
                                                                                                <headertemplate>
                                                                                                    <ul id="ulRepMPIimages">
                                                                                                </headertemplate>
                                                                                                <itemtemplate>
                                                                                                    <li>
                                                                                                        <table cellspacing="1">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:Label ID="MPI_lblMPIDtIDonRep" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "MPIDtID") %>'></asp:Label>
                                                                                                                    <asp:Image ID="MPI_img" runat="server" Width="200" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <table width="100%" cellspacing="0" cellpadding="2">
                                                                                                                        <tr>
                                                                                                                            <td class="gridAlternatingItemStyle">
                                                                                                                                <%# Left(DataBinder.Eval(Container.DataItem, "MPIpicDescription"),15) %>&nbsp;(<%# DataBinder.Eval(Container.DataItem, "MPIpicType")%>)
                                                                                                                            </td>
                                                                                                                            <td align="right" class="gridAlternatingItemStyle">
                                                                                                                                <asp:ImageButton ID="MPI_ibtnMPIpicEdit" runat="server" CommandName="Edit" ImageUrl="/pureravensLib/images/edit_small.png"
                                                                                                                                    ImageAlign="AbsMiddle" ToolTip="Edit" />
                                                                                                                                <asp:ImageButton ID="MPI_ibtnMPIpicDelete" runat="server" CommandName="Delete" ImageUrl="/pureravensLib/images/delete_small.png"
                                                                                                                                    ImageAlign="AbsMiddle" ToolTip="Delete" />
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
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
                                                                            <asp:TextBox ID="HT_txtHardnessTestHdID" runat="server" Width="200" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="HT_txtReportNo" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:TextBox>
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
                                                                <asp:TextBox ID="HT_txtHardnessTestDtID" runat="server" Visible="false">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="HT_txtPipeNo" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="HT_ddlLocation" runat="server" Width="100%">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB1" runat="server" Width="100%" onkeyup="countAvgHRB()">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB2" runat="server" Width="100%" onkeyup="countAvgHRB()">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB3" runat="server" Width="100%" onkeyup="countAvgHRB()">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRB4" runat="server" Width="100%" onkeyup="countAvgHRB()">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHRBAvg" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB1" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB2" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB3" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHB4" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="HT_txtHBAvg" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="12">
                                                                <asp:DataGrid ID="HT_grdHardnessTestDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
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
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlDrillPipeInspectionReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report ID - Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_txtDrillPipeReportHdID" runat="server" Width="166" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="DP_btnSearchDrillPipeReport" runat="server" Text="..." Width="30" />
                                                                            <asp:TextBox ID="DP_txtReportNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Specification
                                                                        </td>
                                                                        <td style="width: 200px;">
                                                                            <asp:TextBox ID="DP_txtSpecificationID" runat="server" Width="200" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="DP_txtSpecificationCode" runat="server" Width="166" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="DP_btnSearchSpecification" runat="server" Text="..." Width="30" />
                                                                            <asp:TextBox ID="DP_txtSpecificationName" runat="server" Width="200" ReadOnly="true">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date - Caption Template
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="DP_calReportDate" runat="server" DontResetDate="true" />
                                                                            <asp:DropDownList ID="DP_ddlCaptionTemplate" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:DropDownList>
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
                                                                        <td style="width: 100px;" class="gridAlternatingItemStyle center" colspan="2">
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
                                                                            <asp:TextBox ID="DP_txtSize" runat="server" Width="100%" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="DP_txtWeight" runat="server" Width="100%" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="DP_txtGrade" runat="server" Width="100%" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtConnection" runat="server" Width="100%" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtRange" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_txtNominalWT" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="15" class="gridHeaderStyle center bold">
                                                                            Criteria
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridFooterStyle center bold" colspan="15">
                                                                            Premium Class
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle center" colspan="3">
                                                                            Min. OD
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center" colspan="3">
                                                                            Max. ID
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center" colspan="3">
                                                                            Min. Wall
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center" colspan="3">
                                                                            Min. Shldr
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle center" colspan="3">
                                                                            Min Seal
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_Premium_txtMinOD" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_Premium_txtMaxID" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_Premium_txtMinWall" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_Premium_txtMinShoulder" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:TextBox ID="DP_Premium_txtMinSeal" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridFooterStyle center bold" colspan="15">
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
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Min. Tong Space
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Max. C. Bore Dia
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Bevel Dia
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Min. C. Bore Depth
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Max. Pin Length
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Max. Pin Neck
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Pin Conn. Length
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Pin Cyl. Dia
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Pin Nose Dia
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Min. Box Length
                                                                        </td>
                                                                        <td style="width: 80px;" class="gridAlternatingItemStyle center">
                                                                            Max. Pin Base Length
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinOD" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxID" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinWall" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinShoulder" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 30px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMinTongSpacePin" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30px;">
                                                                                        Box
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMinTongSpaceBox" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxCBoreDia" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMinBevelDia" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMaxBevelDia" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinCBoreDepth" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxLengthPin" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxPinNeck" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtPinConnLength" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 30px;">
                                                                                        Min
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMinPinCylDia" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30px;">
                                                                                        Max
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMaxPinCylDia" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 30px;">
                                                                                        Min
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMinPinNoseDia" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30px;">
                                                                                        Max
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="DP_Class2_txtMaxPinNoseDia" runat="server" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMinBoxLength" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_Class2_txtMaxPinBaseLength" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table cellpadding="2" cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            No.
                                                                        </td>
                                                                        <td style="width: 100;">
                                                                            <asp:TextBox ID="DP_txtDrillPipeReportDtID" runat="server" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="DP_txtSequenceNo" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right bold">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="DP_txtSerialNo" runat="server" Width="350">
                                                                            </asp:TextBox>
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
                                                                                        <asp:Label ID="DP_lblBod001Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod002Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod003Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod004Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod005Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod006Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod007Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod008Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBod009Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod001Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod002Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod003Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod004Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod005Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod006Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod007Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod008Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBod009Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
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
                                                                                        <asp:Label ID="DP_lblPin001Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin002Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin003Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin004Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin005Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin006Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin007Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin008Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin009Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin010Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin011Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin012Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblPin013Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Is HB?
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin001Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin002Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin003Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin004Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin005Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin006Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin007Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin008Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin009Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin010Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin011Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin012Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtPin013Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:CheckBox ID="DP_chkIsPinHB" runat="server" />
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
                                                                                        <asp:Label ID="DP_lblBox001Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox002Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox003Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox004Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox005Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox006Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox007Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox008Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox009Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox010Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:Label ID="DP_lblBox011Caption" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        Is HB?
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox001Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox002Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox003Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox004Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox005Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox006Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox007Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox008Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox009Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox010Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="DP_txtBox011Value" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td class="rheaderSmallText center" style="width: 80px;">
                                                                                        <asp:CheckBox ID="DP_chkIsBoxHB" runat="server" />
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
                                                                            <asp:DropDownList ID="DP_ddlRemarks" runat="server" Width="300">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="DP_txtRemarks" runat="server" Width="300">
                                                                            </asp:TextBox>
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
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="32" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="DP_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="32" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="DP_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="No." ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="DP_lblDrillPipeReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DrillPipeReportDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Serial No." ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "serialNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-VerticalAlign="Top" HeaderText="Body"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod001Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod002Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod003Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod001Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod002Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod003Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod004Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod005Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod006Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod004Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod005Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod006Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod007Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod008Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod009Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod007Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod008Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "bod009Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-VerticalAlign="Top" HeaderText="Pin Connection"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin001Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin002Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin003Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin001Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin002Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin003Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin004Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin005Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin006Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin004Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin005Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin006Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin007Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin008Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin009Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin007Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin008Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin009Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin010Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin011Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Is HB?
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin010Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "pin011Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <asp:CheckBox ID="DP_grdDPDt_chkIsPinHB" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "isPinHB")%>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-VerticalAlign="Top" HeaderText="Box Connection"
                                                                            HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box001Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box002Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box003Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box001Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box002Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box003Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box004Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box005Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box006Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box004Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box005Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box006Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box007Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box008Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box009Caption")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box007Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box008Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box009Value")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box010Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box011Caption")%>
                                                                                        </td>
                                                                                        <td class="rheaderSmallText center" style="width: 80px;">
                                                                                            Is HB?
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box010Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "box011Value")%>
                                                                                        </td>
                                                                                        <td class="center" style="width: 80px;">
                                                                                            <asp:CheckBox ID="DP_grdDPDt_chkIsBoxHB" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "isBoxHB")%>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remarks" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "remarksText") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlThoroughVisualInspectionReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtTVIHdID" runat="server" Width="200" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="TVI_txtReportNo" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="TVI_btnReportNo" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="TVI_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Type
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="TVI_ddlTVIType" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtDescription" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtSerialNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            <asp:Label ID="TVI_lblWLLSWLCaption" runat="server" Text="WLL"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtWLLSWL" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            <asp:Label ID="TVI_lblDimensionDiameterCaption" runat="server" Text="Dimension"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtDimensionDiameter" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Reference Level
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtReferenceLevel" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <asp:Panel ID="TVI_pnlLength" runat="server">
                                                                            <td style="width: 100px;" class="right">
                                                                                Length
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="TVI_txtLength" runat="server" Width="200">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </asp:Panel>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Manufacturer
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtManufacturer" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Cal Reference
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TVI_txtCalReference" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <asp:Panel ID="TVI_pnlDefectFound" runat="server">
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Defect Found
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="TVI_txtDefectFound" runat="server" Width="200">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                    <tr>
                                                                        <td class="heading1" colspan="4">
                                                                            Image
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="hseparator" colspan="4" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:RadioButtonList ID="TVI_rbtnlImage" runat="server" RepeatDirection="Horizontal"
                                                                                AutoPostBack="True">
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="center">
                                                                            <asp:Image ID="TVI_imgFilePic" runat="server" Width="160" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="heading1" colspan="4">
                                                                            Examine in Accordance with
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="hseparator" colspan="4" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="TVI_txtExamineWith" Width="100%" Height="50" runat="server" TextMode="MultiLine" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="heading1" colspan="4">
                                                                            Result of Inspection
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="hseparator" colspan="4" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="TVI_txtResult" Width="100%" Height="50" runat="server" TextMode="MultiLine" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="heading1" colspan="4">
                                                                            Note
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="hseparator" colspan="4" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:TextBox ID="TVI_txtNote" Width="100%" Height="50" runat="server" TextMode="MultiLine" />
                                                                        </td>
                                                                    </tr>
                                                                    <asp:Panel ID="TVI_pnlNextInspectionDate" runat="server">
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Next Inspection Date
                                                                            </td>
                                                                            <td>
                                                                                <Module:Calendar ID="TVI_calNextInspectionDate" runat="server" />
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                    <tr>
                                                                        <td class="hseparator" colspan="4" style="width: 100%;">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlInspectionTallyReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report ID
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtInspectionTallyHdID" runat="server" Width="166" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="IT_btnInspectionTallyHdID" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="IT_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td rowspan="5" valign="top">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td class="gridHeaderStyle center">
                                                                                        Acceptance Criteria
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="IT_chkIsAC1" runat="server" />
                                                                                        <asp:TextBox ID="IT_txtAC1" runat="server" Width="200" Text="API RP 5A5">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="IT_chkIsAC2" runat="server" />
                                                                                        <asp:TextBox ID="IT_txtAC2" runat="server" Width="200" Text="API RP 5C1">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="IT_chkIsAC3" runat="server" />
                                                                                        <asp:TextBox ID="IT_txtAC3" runat="server" Width="200" Text="API SPEC 5B">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="IT_chkIsAC4" runat="server" />
                                                                                        <asp:TextBox ID="IT_txtAC4" runat="server" Width="200" Text="API SPEC 5CT">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtReportNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            For
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="IT_ddlTallyType" runat="server" width="200">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Size
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtSize" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Grade
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtGrade" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Weight
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtWeight" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Connection
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtConnection" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Range
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtRange" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Nominal W.T.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtNominalWT" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table cellpadding="2" cellspacing="1">
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Pipe No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtInspectionTallyDtID" runat="server" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="IT_txtPipeNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Pipe Length
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtPipeLength" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            VBI
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="IT_ddlVBI" runat="server" width="200">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            RWT
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtRWT" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Color Coding (Used)
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:RadioButtonList ID="IT_rdblCCU" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Text="Yellow" Value="Y">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Blue" Value="B">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Green" Value="G">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Red" Value="R">
                                                                                </asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right">
                                                                            VTI
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 99px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 99px;">
                                                                                        Box
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 99px;">
                                                                                        <asp:DropDownList ID="IT_ddlVTIPin" runat="server" width="200">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 99px;">
                                                                                        <asp:DropDownList ID="IT_ddlVTIBox" runat="server" width="200">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            FLD
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="IT_ddlFLD" runat="server" width="200">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Color Coding (New)
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:RadioButtonList ID="IT_rdblCCN" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Text="White" Value="W">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Yellow" Value="Y">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Red" Value="R">
                                                                                </asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right">
                                                                            Final Class
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtFinalClass" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Internal/External
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 99px;">
                                                                                        Cleaning
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 99px;">
                                                                                        Coating
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 99px;">
                                                                                        <asp:TextBox ID="IT_txtInternalExternalCleaning" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 99px;">
                                                                                        <asp:TextBox ID="IT_txtInternalExternalCoating" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right">
                                                                            Remark
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="IT_txtRemark" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" class="txtweak">
                                                                <asp:DataGrid ID="IT_grdInspectionTally" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="IT_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="IT_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Pipe No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="IT_lblInspectionTallyDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InspectionTallyDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "pipeNo")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Pipe Length">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "pipeLength") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="VBI">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "VBI") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="RWT">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "RWT")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="VTI">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td colspan="2" class="center">VTI</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%;" class="center">Pin</td>
                                                                                        <td style="width: 50%;" class="center">Box</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td style="width: 50%;" class="center"><%# DataBinder.Eval(Container.DataItem, "VTIPin")%></td>
                                                                                        <td style="width: 50%;" class="center"><%# DataBinder.Eval(Container.DataItem, "VTIBox")%></td>
                                                                                    </tr>
                                                                                </table>                                                                                
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="FLD">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "FLD")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Final Class">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "finalClass")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remark">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "remarks")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>                                                                        
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlUTSpotCheck" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="12">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtUTSpotCheckHdID" runat="server" Width="200" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="UTSC_txtReportNo" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="UTSC_btnReportNo" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="UTSC_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none;">
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Type
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="UTSC_ddlUTSpotType" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtDescription" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtSerialNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Material
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtMaterial" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Equipment
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtEquipment" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Couplant
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtCouplant" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Probe Type
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtProbeType" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Impact Device
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtImpactDevice" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none;">
                                                                        <td style="width: 100px;" class="right">
                                                                            Reference Level
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtReferenceLevel" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Cal Reference
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtCalReference" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none;">
                                                                        <td style="width: 100px;" class="right">
                                                                            Frequency
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSC_txtFrequency" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 50%;" class="center">
                                                                                        <table width="100%" cellspacing="1" cellpadding="2" class="gridHeaderStyle">
                                                                                            <tr>
                                                                                                <td class="gridItemStyle center">
                                                                                                    <img src="/pureravensLib/images/UTSpotCheckAreaSquare.png" alt="" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="gridAlternatingItemStyle center">
                                                                                                    <asp:CheckBox ID="UTSC_chkIsAreaSpotSquare" runat="server" Text="Area Spot Check Wall Thickness" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td style="width: 50%;" class="center">
                                                                                        <table width="100%" cellspacing="1" cellpadding="2" class="gridHeaderStyle">
                                                                                            <tr>
                                                                                                <td class="gridItemStyle center">
                                                                                                    <img src="/pureravensLib/images/UTSpotCheckAreaCylinder.png" alt="" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="gridAlternatingItemStyle center">
                                                                                                    <asp:CheckBox ID="UTSC_chkIsAreaSpotCylinder" runat="server" Text="Area Spot Check Wall Thickness" />
                                                                                                </td>
                                                                                            </tr>
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
                                                            <td class="gridAlternatingItemStyle center" rowspan="2">
                                                                Structure/Tally#
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" rowspan="2">
                                                                Size (Inch)
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" rowspan="2">
                                                                Length (mm)
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 30%;" colspan="4">
                                                                Wall Thickness
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" style="width: 30%;" colspan="4">
                                                                Hardness Test (HRA,HRB,HRC,HB,HV)
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center" rowspan="2" style="width: 120px;">
                                                                Remark
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="gridAlternatingItemStyle center">
                                                                0
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                90
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                180
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                270
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                0
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                90
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                180
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                270
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtUTSpotCheckDtID" runat="server" Visible="false">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="UTSC_txtStructureTallyNo" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtSize" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtLength" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtWallThickness1" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtWallThickness2" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtWallThickness3" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtWallThickness4" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtHardnessTest1" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtHardnessTest2" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtHardnessTest3" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UTSC_txtHardnessTest4" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td style="width: 120px;">
                                                                <asp:TextBox ID="UTSC_txtRemark" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="12">
                                                                <asp:DataGrid ID="UTSC_grdUTSpotCheckDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
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
                                                                        <asp:TemplateColumn runat="server" HeaderText="Structure/Tally#">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="UTSC_lblUTSpotCheckDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UTSpotCheckDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "structureTallyNo")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Size">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "size") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Length">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "length") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Wall Thickness-0">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "wallThickness1")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Wall Thickness-90">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "wallThickness2")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Wall Thickness-180">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "wallThickness3")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Wall Thickness-270">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "wallThickness4")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Hardness Test-0">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "hardnessTest1")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Hardness Test-90">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "hardnessTest2")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Hardness Test-180">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "hardnessTest3")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Hardness Test-270">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "hardnessTest4")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remark">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "remark")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlUTSpotArea" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="4">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtUTSpotCheckHdID" runat="server" Width="200" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="UTSA_txtReportNo" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="UTSA_btnReportNo" runat="server" Text="..." Width="30" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="UTSA_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Type
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="UTSA_ddlUTSpotType" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtDescription" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Equipment
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtEquipment" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Couplant
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtCouplant" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Probe
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtProbe" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Reference Level
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtReferenceLevel" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Cal Reference
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtCalReference" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Frequency
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtFrequency" runat="server" Width="200">
                                                                            </asp:TextBox>
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
                                                            <td class="gridAlternatingItemStyle center">
                                                                Pipe No.
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Area Inspection
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Condition/Result
                                                            </td>
                                                            <td class="gridAlternatingItemStyle center">
                                                                Remark
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:TextBox ID="UTSA_txtUTSpotAreaDtID" runat="server" Visible="false">
                                                                </asp:TextBox>
                                                                <asp:TextBox ID="UTSA_txtPipeNo" runat="server" Width="100%">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td valign="top" style="width: 120px;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="height: 24px;">
                                                                            <asp:TextBox ID="UTSA_txtPinCaption" runat="server" Width="100%" CssClass="gridAlternatingItemStyle right"
                                                                                BorderStyle="None" Text="Pin" ReadOnly="true">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="height: 24px;">
                                                                            <asp:TextBox ID="UTSA_txtBoxCaption" runat="server" Width="100%" CssClass="gridAlternatingItemStyle right"
                                                                                BorderStyle="None" Text="Box" ReadOnly="true">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" style="width: 300px;">
                                                                <table width="100%" cellpadding="0" cellspacing="1">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtConditionResultPin" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtConditionResultBox" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" style="width: 300px;">
                                                                <table width="100%" cellpadding="0" cellspacing="1">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtRemarkPin" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="UTSA_txtRemarkBox" runat="server" Width="100%">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:DataGrid ID="UTSA_grdUTSpotAreaDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="UTSA_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="UTSA_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Pipe No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="UTSA_lblUTSpotAreaDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UTSpotAreaDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "pipeNo")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Area Inspection" ItemStyle-Width="120">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td class="gridAlternatingItemStyle right" style="height: 24px;">
                                                                                            <asp:TextBox ID="UTSA_txtPinCaption" runat="server" Width="100%" CssClass="gridAlternatingItemStyle right"
                                                                                                BorderStyle="None" Text="Pin" ReadOnly="true"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="gridAlternatingItemStyle right" style="height: 24px;">
                                                                                            <asp:TextBox ID="UTSA_txtBoxCaption" runat="server" Width="100%" CssClass="gridAlternatingItemStyle right"
                                                                                                BorderStyle="None" Text="Box" ReadOnly="true"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Condition/Result">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellpadding="0" cellspacing="1">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "conditionResultPin") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "conditionResultBox") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Remark">
                                                                            <ItemTemplate>
                                                                                <table width="100%" cellpadding="0" cellspacing="1">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "remarkPin") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "remarkBox") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlInspectionReport" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="6">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report ID - Report No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="INS_txtInspectionReportHdID" runat="server" Width="166" AutoPostBack="true">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="INS_btnSearchInspectionReport" runat="server" Text="..." Width="30" />
                                                                            <asp:TextBox ID="INS_txtReportNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td style="width: 200px;">
                                                                            <Module:Calendar ID="INS_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Type - Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="INS_ddlInspectionReportType" runat="server" Width="200" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="INS_txtDescriptionHd" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Type of Inspection
                                                                        </td>
                                                                        <td colspan="5">
                                                                            <asp:CheckBox ID="INS_chkMPI" runat="server" Text="Magnetic Particle Inspection" />
                                                                            &nbsp&nbsp;
                                                                            <asp:CheckBox ID="INS_chkVTI" runat="server" Text="Visual Thread Inspection" />
                                                                            &nbsp;&nbsp;
                                                                            <asp:CheckBox ID="INS_chkDIM" runat="server" Text="Dimensional" />
                                                                            &nbsp;&nbsp;
                                                                            <asp:CheckBox ID="INS_chkBLC" runat="server" Text="Blacklight Connection" />
                                                                            &nbsp;&nbsp;
                                                                            <asp:CheckBox ID="INS_chkVBI" runat="server" Text="Visual Body Inspection" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Notes
                                                                        </td>
                                                                        <td colspan="5">
                                                                            <asp:TextBox ID="INS_txtNotes" runat="server" Width="510" TextMode="MultiLine" Height="40">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Customer PIC Name
                                                                        </td>
                                                                        <td colspan="5">
                                                                            <asp:TextBox ID="INS_txtCustomerPICName" runat="server" Width="510">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <table cellpadding="2" cellspacing="1">
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="INS_txtInspectionReportDTID" runat="server" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="INS_txtDescription" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="INS_txtSerialNo" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Total Length
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="INS_txtTotalLength" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            ID
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="INS_txtIDDescription" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Connection
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center">
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                        Size
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                        OD
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 60px;">
                                                                                        <asp:DropDownList ID="INS_ddlConnectionPinCaption" runat="server" width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtConnectionSizePin" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtConnectionODPin" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 60px;">
                                                                                        <asp:DropDownList ID="INS_ddlConnectionBoxCaption" runat="server" width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtConnectionSizeBox" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtConnectionODBox" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <asp:Panel ID="INS_pnlElevatorGroove" runat="server">
                                                                            <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                                Elevator Groove
                                                                            </td>
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="1">
                                                                                    <tr>
                                                                                        <td class="gridAlternatingItemStyle center">
                                                                                        </td>
                                                                                        <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                            Dia
                                                                                        </td>
                                                                                        <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                            Depth
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        </td>
                                                                                        <td style="width: 80px;">
                                                                                            <asp:TextBox ID="INS_txtElevatorGrooveDiaPin" runat="server" CssClass="txtSmallText"
                                                                                                Width="100%">
                                                                                            </asp:TextBox>
                                                                                        </td>
                                                                                        <td style="width: 80px;">
                                                                                            <asp:TextBox ID="INS_txtElevatorGrooveDepthPin" runat="server" CssClass="txtSmallText"
                                                                                                Width="100%">
                                                                                            </asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </asp:Panel>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            B.Back/R.Groove
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center">
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                        Dia
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                        Length
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtBBackRGrooveDiaPin" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtBBackRGrooveLengthPin" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Box
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtBBackRGrooveDiaBox" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtBBackRGrooveLengthBox" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Bevel Diameter
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" colspan="2" style="height: 20px;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtBevelDiameterPin" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Box
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtBevelDiameterBox" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Thread Length
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" colspan="2" style="height: 20px;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 60px;">
                                                                                        <asp:DropDownList ID="INS_ddlThreadLengthPinCaption" runat="server" width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtThreadLengthPin" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 60px;">
                                                                                        <asp:DropDownList ID="INS_ddlThreadLengthBoxCaption" runat="server" width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtThreadLengthBox" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <asp:Panel ID="INS_pnlCenterPad" runat="server">
                                                                            <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                                Center Pad
                                                                            </td>
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="1">
                                                                                    <tr>
                                                                                        <td class="gridAlternatingItemStyle center">
                                                                                        </td>
                                                                                        <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                            Dia
                                                                                        </td>
                                                                                        <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                            Depth
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        </td>
                                                                                        <td style="width: 80px;">
                                                                                            <asp:TextBox ID="INS_txtCenterPadDiaPin" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                            </asp:TextBox>
                                                                                        </td>
                                                                                        <td style="width: 80px;">
                                                                                            <asp:TextBox ID="INS_txtCenterPadDepthPin" runat="server" CssClass="txtSmallText"
                                                                                                Width="100%">
                                                                                            </asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </asp:Panel>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Counter Bore
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center">
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                        Dia
                                                                                    </td>
                                                                                    <td class="gridAlternatingItemStyle center" style="width: 80px;">
                                                                                        Depth
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtCounterBoreDiaPin" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtCounterBoreDepthPin" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Box
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtCounterBoreDiaBox" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtCounterBoreDepthBox" runat="server" CssClass="txtSmallText"
                                                                                            Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Tong Space
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" colspan="2" style="height: 20px;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtTongSpacePin" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Box
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtTongSpaceBox" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Condition
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" colspan="2" style="height: 20px;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 60px;">
                                                                                        <asp:DropDownList ID="INS_ddlConditionPinCaption" runat="server" width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtConditionPin" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 60px;">
                                                                                        <asp:DropDownList ID="INS_ddlConditionBoxCaption" runat="server" width="100%">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtConditionBox" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            BSR
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="INS_txtBSR" runat="server" Width="200">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            Remarks
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle center" colspan="2" style="height: 20px;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtRemarksPin" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Box
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtRemarksBox" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="gridAlternatingItemStyle right" style="width: 100px;">
                                                                            HB
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="1">
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Pin
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtHBPin" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <asp:Panel ID="INS_pnlHBCenterPad" runat="server">
                                                                                    <tr>
                                                                                        <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                            CP
                                                                                        </td>
                                                                                        <td style="width: 80px;">
                                                                                            <asp:TextBox ID="INS_txtHBCenterPad" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                            </asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <tr>
                                                                                    <td class="gridAlternatingItemStyle right" style="width: 30px;">
                                                                                        Box
                                                                                    </td>
                                                                                    <td style="width: 80px;">
                                                                                        <asp:TextBox ID="INS_txtHBBox" runat="server" CssClass="txtSmallText" Width="100%">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" class="txtweak">
                                                                <asp:DataGrid ID="INS_grdInspectionReportDt" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="INS_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="INS_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="INS_lblInspectionReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InspectionReportDtID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "description")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Serial No.">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "serialNo")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Total Length">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "totalLength")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="ID">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "IDdescription")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="" HeaderStyle-Width="100" ItemStyle-Width="100">
                                                                            <HeaderTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td colspan="2" class="center">
                                                                                            Condition
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center">
                                                                                            Pin
                                                                                        </td>
                                                                                        <td class="center">
                                                                                            Box
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td class="center">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "conditionPin")%>
                                                                                        </td>
                                                                                        <td class="center">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "conditionBox")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="" HeaderStyle-Width="100" ItemStyle-Width="100">
                                                                            <HeaderTemplate>
                                                                                <table width="100%" cellspacing="1">
                                                                                    <tr>
                                                                                        <td colspan="2" class="center">
                                                                                            Remarks
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="center">
                                                                                            Pin
                                                                                        </td>
                                                                                        <td class="center">
                                                                                            Box
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td class="center">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "remarksPin")%>
                                                                                        </td>
                                                                                        <td class="center">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "remarksBox")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlCertificateInspection" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Inspection Type
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="COI_ddlCOIType" runat="server" width="300" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Certificate No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtCertificateInspectionID" runat="server" Width="300" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="COI_txtCertificateNo" runat="server" Width="300">
                                                                            </asp:TextBox>
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
                                                                            <asp:TextBox ID="COI_txtOwner" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            User
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtUser" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Location
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtLocation" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Description
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtDescription" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Serial No.
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtSerialNo" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Max Gross Weight (R)
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtMaxGossWeightR" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <asp:Panel id="COI_pnlPullTest" runat="server">
                                                                        <tr>
                                                                            <td style="width: 100px;" class="right">
                                                                                Size
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="COI_txtSize" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 100px;" class="right">
                                                                                SWL
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="COI_txtSWL" runat="server" Width="300">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            <asp:Label id="COI_lblLoadPullTestCaption" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtLoadTest" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Duration
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtDuration" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Specification
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtSpecification" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Examination
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtExamination" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Result
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtResult" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            <asp:Label id="COI_lblActualTestCaption" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="COI_txtActualLoadTest" runat="server" Width="148" CssClass="right">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="COI_txtActualLoadTestUOM" runat="server" Width="148" Text="KG">
                                                                            </asp:TextBox>
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
                                                                            <asp:TextBox ID="COI_txtNotes" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <table cellpadding="2" cellspacing="1" width="100%">
                                                                                <tr>
                                                                                    <td class="gridHeaderStyle center" colspan="3">
                                                                                        Image File
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <input id="COI_ImageFilePic1" type="file" runat="server" autopostback="True" name="COI_ImageFilePic1"
                                                                                            class="imguploader" style="width: 200;" />
                                                                                        <asp:Button ID="COI_btnUploadPic1" runat="server" Text="Upload Pic-1" CssClass="sbttn"
                                                                                            Width="100" /><br />
                                                                                        <asp:Image ID="COI_imgPic1" runat="server" Width="200" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="COI_ImageFilePic2" type="file" runat="server" autopostback="True" name="COI_ImageFilePic2"
                                                                                            class="imguploader" style="width: 200;" />
                                                                                        <asp:Button ID="COI_btnUploadPic2" runat="server" Text="Upload Pic-2" CssClass="sbttn"
                                                                                            Width="100" /><br />
                                                                                        <asp:Image ID="COI_imgPic2" runat="server" Width="200" />
                                                                                    </td>
                                                                                    <td style="display: none;">
                                                                                        <input id="COI_ImageFilePic3" type="file" runat="server" autopostback="True" name="COI_ImageFilePic3"
                                                                                            class="imguploader" style="width: 200;" />
                                                                                        <asp:Button ID="COI_btnUploadPic3" runat="server" Text="Upload Pic-3" CssClass="sbttn"
                                                                                            Width="100" /><br />
                                                                                        <asp:Image ID="COI_imgPic3" runat="server" Width="200" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="COI_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
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
                                                                        <asp:TemplateColumn runat="server" HeaderText="Actual Test">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "actualLoadTest") %>&nbsp;
                                                                                <%# DataBinder.Eval(Container.DataItem, "actualLoadTestUOM") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Result">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "result") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="COI_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlBeritaAcara" runat="server">
                                                    <table cellpadding="2" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            No. Berita Acara
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="BA_txtOfficialReportID" runat="server" Width="300" Visible="false">
                                                                            </asp:TextBox>
                                                                            <asp:TextBox ID="BA_txtReportNo" runat="server" Width="300">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Date
                                                                        </td>
                                                                        <td>
                                                                            <Module:Calendar ID="BA_calReportDate" runat="server" DontResetDate="true" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100px;" class="right">
                                                                            Report Type
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList id="BA_ddlOfficialReportType" runat="server" width="300" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100px;" class="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <asp:Panel id="BA_pnlBeritaAcaraAkhir" runat="server">
                                                                        <tr>
                                                                            <td colspan="4">
                                                                                <asp:DataGrid ID="BA_grdBeritaAcaraAkhir" runat="server" BorderWidth="0" GridLines="None"
                                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                                    AutoGenerateColumns="false">
                                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                                    <columns>
                                                                                        <asp:TemplateColumn runat="server" HeaderText="Description" ItemStyle-Width="450px">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label runat="server" ID="BA_lblProjectDtID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "projectDtID") %>' />
                                                                                                <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn runat="server" HeaderText="Reference No." ItemStyle-Width="100px">
                                                                                            <ItemTemplate>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "referenceNo") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn runat="server" HeaderText="Qty" ItemStyle-Width="80px">
                                                                                            <ItemTemplate>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "Qty") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn runat="server" HeaderText="Qty Actual" ItemStyle-Width="80px">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox id="BA_txtQtyActual" runat="server" width="100" class="right" text='<%# DataBinder.Eval(Container.DataItem, "QtyActual") %>'></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn runat="server" HeaderText="UOM" ItemStyle-Width="100px">
                                                                                            <ItemTemplate>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "unitOfMeasurement") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>                                                                    
                                                                                    </columns>
                                                                                </asp:DataGrid>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataGrid ID="BA_grdBeritaAcara" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                                    <itemstyle cssclass="gridItemStyle" />
                                                                    <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                                    <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                                    <columns>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="BA_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="BA_ibtnPrint" runat="server" ImageUrl="/PureravensLib/images/print.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Print" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="No. Berita Acara">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="BA_lblOfficialReportID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "officialReportID") %>'
                                                                                    Visible="false"></asp:Label>
                                                                                <%# DataBinder.Eval(Container.DataItem, "reportNo") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "reportDate"), "dd-MMM-yyyy")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="ReportType">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "officialReportTypeName") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="BA_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                                    ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>                                                                        
                                                                    </columns>
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
