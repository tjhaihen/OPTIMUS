<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WorkRequest.aspx.vb" Inherits="Raven.Web.Secure.WorkOrder" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Work Request</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
    <link rel="stylesheet" href="/PureravensLib/css/jquery-ui-1.10.3/themes/base/jquery.ui.all.css">
    <script src="/PureravensLib/scripts/jquery-1.9.1.js"></script>
    <script src="/PureravensLib/scripts/ui/jquery.ui.core.js"></script>
    <script src="/PureravensLib/scripts/ui/jquery.ui.widget.js"></script>
    <script src="/PureravensLib/scripts/ui/jquery.ui.datepicker.js"></script>
    <script language="javascript" type="text/javascript" src="/PureravensLib/scripts/JScript.js"></script>
</head>
<body>
    <form id="frm" runat="server">
    <asp:Panel ID="pnlProposed" Visible="false" runat="server">
        <div class="transparent" id="Popup" style="width: 50%">
            <table cellpadding="1" cellspacing="1" style="background-color: Red;">
                <tr>
                    <td class="center" style="background-color: Red; color: #ffffff; font-size: 20pt;">
                        PROPOSED
                    </td>
                </tr>
                <tr>
                    <td class="center" style="background-color: #ffffff; color: Red;">
                        by:&nbsp;<asp:Label ID="lblProposedBy" runat="server"></asp:Label>&nbsp;on:&nbsp;<asp:Label
                            ID="lblProposedDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlApproved" Visible="false" runat="server">
        <div class="transparent" id="Div1" style="width: 50%">
            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                <tr>
                    <td class="center" style="background-color: Red; color: #ffffff; font-size: 20pt;">
                        APPROVED
                    </td>
                </tr>
                <tr>
                    <td class="center" style="background-color: #ffffff; color: Red;">
                        by:&nbsp;<asp:Label ID="lblApprovalBy" runat="server"></asp:Label>&nbsp;on:&nbsp;<asp:Label
                            ID="lblApprovalDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
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
                                            Work Request
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="Menu" cellpadding="4" cellspacing="1" width="100%">
                                                <tr>
                                                    <td style="width: 20px;" class="Menu center">
                                                        1
                                                    </td>
                                                    <td class="gridAlternatingItemStyle" style="font-size: 12pt; padding-left: 10;">
                                                        Input Work Request Data
                                                    </td>
                                                    <td style="width: 20px;" class="Menu center">
                                                        2
                                                    </td>
                                                    <td class="gridAlternatingItemStyle" style="font-size: 12pt; padding-left: 10;">
                                                        Assign Project Resource
                                                    </td>
                                                    <td style="width: 20px;" class="Menu center">
                                                        3
                                                    </td>
                                                    <td class="gridAlternatingItemStyle" style="font-size: 12pt; padding-left: 10;">
                                                        Add Project Report Type
                                                    </td>
                                                </tr>
                                            </table>
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
                                                        Work Request No.
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtProjectID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtProjectCode" Width="266" runat="server" AutoPostBack="True" CssClass="txtAutoGenerate" />
                                                        <asp:Button ID="btnSearchProject" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Site
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSite" runat="server" Width="300">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Project Name
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtProjectName" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Work Period
                                                    </td>
                                                    <td>
                                                        <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                                        &nbsp;to&nbsp;
                                                        <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        To Department
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtToDepartment" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Customer Work Order Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        FR/WO/JO No.
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtWorkOrderNo" Width="300" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Work Location (Summary)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtWorkLocation" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        FR/WO/JO Date
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <Module:Calendar ID="calWorkOrderDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Required Date
                                                    </td>
                                                    <td>
                                                        <Module:Calendar ID="calRequiredDate" runat="server" DontResetDate="true" />
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
                                                        Priority
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPriority" runat="server" Width="300">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Customer Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCustomerName" Width="300" MaxLength="500" runat="server" ReadOnly="true"
                                                            CssClass="txtReadOnly" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Expired Date
                                                    </td>
                                                    <td>
                                                        <Module:Calendar ID="calExpiredDate" runat="server" DontResetDate="true" />
                                                        <asp:CheckBox ID="chkIsNoExpiredDate" runat="server" Text="No Expired Date" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Work Request Reference
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtWorkRequestReference" Width="100%" Height="50" runat="server"
                                                            TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Job Description / Scope of Work
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="hseparator" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr class="rbody">
                                                    <td colspan="4" valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 450px;" class="center">
                                                                    Description
                                                                </td>
                                                                <td style="width: 100px;" class="center">
                                                                    Reference No.
                                                                </td>
                                                                <td style="width: 80px;" class="center">
                                                                    Qty
                                                                </td>
                                                                <td style="width: 100px;" class="center">
                                                                    UOM
                                                                </td>
                                                                <td style="width: 350px;" class="center">
                                                                    Detail Description
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtProjectDtID" runat="server" Width="100%" Visible="false"></asp:TextBox>
                                                                    <asp:TextBox ID="txtDescription" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtReferenceNo" runat="server" Width="100%" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtQty" runat="server" Width="100%" CssClass="right"></asp:TextBox>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtUOM" runat="server" Width="100%" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtDescriptionDetail" runat="server" Width="100%" Height="50" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:Button ID="btnAddDetail" runat="server" Text="Add" CssClass="sbttn" Width="100" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="rbody">
                                                    <td colspan="4" valign="top">
                                                        <asp:DataGrid ID="grdProjectDetail" runat="server" BorderWidth="0" GridLines="None"
                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                            AutoGenerateColumns="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                            <ItemStyle CssClass="gridItemStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <Columns>
                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/PureravensLib/images/edit.png"
                                                                            ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" Visible="false" />
                                                                        <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                            ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Description" ItemStyle-Width="450px">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="_lblProjectDtID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "projectDtID") %>' />
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
                                                                        <asp:TextBox ID="_txtdescriptionDetail" runat="server" BorderStyle="None" CssClass="txtweak"
                                                                            TextMode="MultiLine" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "descriptionDetail") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Job Description / Scope of Work (Additional)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtJobDescription" Width="100%" Height="100" runat="server" TextMode="MultiLine" />
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
                                                        <asp:TextBox ID="txtNote" Width="100%" Height="50" runat="server" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Customer PIC
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtCustomerPIC" Width="100%" Height="80" runat="server" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Work Location Description (Detail of Work Location)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtWorkLocationDescription" Width="100%" Height="50" runat="server"
                                                            TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Terms and Conditions
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtTermsAndConditions" Width="100%" Height="50" runat="server" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Company To Provide
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtCompanyToProvide" Width="100%" Height="80" runat="server" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Customer To Provide
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtCustomerToProvide" Width="100%" Height="80" runat="server" TextMode="MultiLine" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Work Request Acknowledgement
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="heading2">
                                                        Marketing
                                                    </td>
                                                    <td colspan="2" class="heading2">
                                                        Operational
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Requested by
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtRequestedBy" Width="300" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Checked by
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCheckedBy" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Acknowledged by
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtAcknowledgedBy" Width="300" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Approved by
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtApprovedBy" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td style="width: 500px;">
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Prepared by
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPreparedBy" Width="300" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td style="width: 500px;">
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Warehouse PIC
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtWarehousePIC" Width="300" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td class="heading1" colspan="4">
                                                        Service for Equipment
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td class="hseparator" colspan="4" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td class="right">
                                                        Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtServiceName" Width="300" MaxLength="100" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Serial No.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSerialNo" Width="300" MaxLength="100" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td class="right">
                                                        Asset No.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAssetNo" Width="300" MaxLength="100" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Manufacturer
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtManufacturer" Width="300" MaxLength="100" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td class="right">
                                                        Model / Type
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtModel" Width="300" MaxLength="100" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Heading1" colspan="4">
                                                        Project Resource
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Resource Code
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPersonID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtResourceID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtResourceCode" Width="266" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:Button ID="btnSearchResource" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Role
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlResourceRole" runat="server" Width="300">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Resource Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtResourceName" Width="300" MaxLength="500" runat="server" ReadOnly="true"
                                                            CssClass="txtReadOnly" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Button ID="btnAddResource" runat="server" Text="Add" CssClass="sbttn" Width="100" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:DataGrid ID="grdProjectResource" runat="server" BorderWidth="0" GridLines="None"
                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                            AutoGenerateColumns="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                            <ItemStyle CssClass="gridItemStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <Columns>
                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                            ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Resource Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="_lblProjectResourceID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectResourceID") %>' />
                                                                        <%# DataBinder.Eval(Container.DataItem, "resourceName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Role">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "resourceRoleName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Job Title">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "resourceJobTitle") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Heading1" colspan="4">
                                                        Project Report Type
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: auto;" colspan="4">
                                                        <table width="100%" cellspacing="1">
                                                            <tr>
                                                                <td valign="top" style="width: 40%;">
                                                                    <asp:DataGrid ID="grdReportType" runat="server" BorderWidth="0" GridLines="None"
                                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                        AutoGenerateColumns="false">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                        <ItemStyle CssClass="gridItemStyle" />
                                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                        <Columns>
                                                                            <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Report Type Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ReportTypeID") %>'
                                                                                        ID="_lblReportTypeID" Visible="false" />
                                                                                    <%# DataBinder.Eval(Container.DataItem, "ReportTypeName") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                        </Columns>
                                                                    </asp:DataGrid>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:Button ID="btnProjectReportTypeAdd" runat="server" Text="Add >" CssClass="sbttn"
                                                                        Width="100px" /><br />
                                                                    <asp:Button ID="btnProjectReportTypeAddAll" runat="server" Text="Add All >>" CssClass="sbttn"
                                                                        Width="100px" /><br />
                                                                    <br />
                                                                    <asp:Button ID="btnProjectReportTypeRemoveAll" runat="server" Text="<< Remove All"
                                                                        CssClass="sbttn" Width="100px" /><br />
                                                                    <asp:Button ID="btnProjectReportTypeRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                                        Width="100px" />
                                                                </td>
                                                                <td valign="top" style="width: 40%;">
                                                                    <asp:DataGrid ID="grdProjectReportType" runat="server" BorderWidth="0" GridLines="None"
                                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                        AutoGenerateColumns="false">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                        <ItemStyle CssClass="gridItemStyle" />
                                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                        <Columns>
                                                                            <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Report Type Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectReportTypeID") %>'
                                                                                        ID="_lblProjectReportTypeID" Visible="false" />
                                                                                    <%# DataBinder.Eval(Container.DataItem, "ReportTypeName") %>
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
