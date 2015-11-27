<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Contract.aspx.vb" Inherits="Raven.Web.Secure.Contract" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Contract</title>
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
                                            Contract
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
                                                    <td style="width: 150px;" class="right">
                                                        Contract ID
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtContractHdID" Width="266" runat="server" AutoPostBack="True" CssClass="txtAutoGenerate" />
                                                        <asp:Button ID="btnSearchContract" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Contract Period
                                                    </td>
                                                    <td>
                                                        <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                                        &nbsp;to&nbsp;
                                                        <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Contract No.
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtContractNo" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right" rowspan="3">
                                                        Description
                                                    </td>
                                                    <td rowspan="3">
                                                        <asp:TextBox ID="txtContractDescription" Width="300" MaxLength="500" runat="server" TextMode="MultiLine" Height="50" />
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
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Customer Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCustomerName" Width="300" MaxLength="500" runat="server" ReadOnly="true"
                                                            CssClass="txtReadOnly" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="heading1" colspan="4">
                                                        Job Description/Scope Of Work
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="hseparator" style="width: 100%;">
                                                    </td>
                                                </tr>
                                                <tr class="rbody">
                                                    <td colspan="4" valign="top">
                                                        <table width="100%" cellpadding="0">
                                                            <tr>
                                                                <td style="width: 450px;" class="center">
                                                                    <table width="100%" cellpadding="2">
                                                                        <tr>
                                                                            <td class="gridHeaderStyle">
                                                                                Product
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="gridHeaderStyle">
                                                                                Description
                                                                            </td>
                                                                        </tr>
                                                                    </table>                                                                    
                                                                </td>
                                                                <td style="width: 100px;" class="gridHeaderStyle center">
                                                                    Reference No.
                                                                </td>
                                                                <td style="width: 80px;" class="gridHeaderStyle center">
                                                                    Qty
                                                                </td>
                                                                <td style="width: 100px;" class="gridHeaderStyle center">
                                                                    UOM
                                                                </td>
                                                                <td style="width: 350px;" class="gridHeaderStyle center">
                                                                    Scope Of Work
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="center">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtContractDtID" runat="server" Width="100%" Visible="false">
                                                                                </asp:TextBox>
                                                                                <asp:TextBox ID="txtProductID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                                                <asp:TextBox ID="txtProductCode" Width="100" MaxLength="15" runat="server" AutoPostBack="True" />
                                                                                <asp:Button ID="btnSearchProduct" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                                                <asp:TextBox ID="txtProductName" Width="300" MaxLength="500" runat="server" ReadOnly="true"
                                                                                CssClass="txtReadOnly" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtDescription" runat="server" Width="436">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>                                                                                                                                    
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtReferenceNo" runat="server" Width="100%" MaxLength="50">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtQty" runat="server" Width="100%" CssClass="right">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtUOM" runat="server" Width="100%" MaxLength="50">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td valign="top" class="center">
                                                                    <asp:TextBox ID="txtDescriptionDetail" runat="server" Width="100%" Height="50" TextMode="MultiLine">
                                                                    </asp:TextBox>
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
                                                        <asp:DataGrid ID="grdContractDetail" runat="server" BorderWidth="0" GridLines="None"
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
                                                                            ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" Visible="false" />
                                                                        <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                            ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Product" ItemStyle-Width="450px">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="_lblContractDtID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "contractDtID") %>' />
                                                                        <%# DataBinder.Eval(Container.DataItem, "productName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Description" ItemStyle-Width="450px">
                                                                    <ItemTemplate>                                                                        
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
                                                            </columns>
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
