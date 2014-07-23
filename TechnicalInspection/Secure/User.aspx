<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="User.aspx.vb" Inherits="Raven.Web.Secure.User" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>User</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
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
                                            User
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
                                                        Username
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtUserID" Width="300" MaxLength="15" runat="server" AutoPostBack="True"
                                                            Visible="false" />
                                                        <asp:TextBox ID="txtUserName" Width="300" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                                            ErrorMessage="Username" Display="dynamic" Text="*">																
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Password
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassword" Width="300" runat="server" TextMode="Password" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active?" Checked="False" />
                                                    </td>
                                                    <td>
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
                                        <td valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Salutation
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtSalutation" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Address
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddress1" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPersonID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtFirstName" Width="97" MaxLength="100" runat="server" />
                                                        <asp:TextBox ID="txtMiddleName" Width="97" MaxLength="100" runat="server" />
                                                        <asp:TextBox ID="txtLastName" Width="98" MaxLength="100" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtFirstName"
                                                            ErrorMessage="Name" Display="dynamic" Text="*">									
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="right">
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddress2" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Academic Title
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAcademicTitle" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddress3" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Sex / Gender
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSex" Width="148" runat="server" />
                                                        <asp:DropDownList ID="ddlGender" Width="148" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        City / Postal Code
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCity" Width="200" MaxLength="500" runat="server" />
                                                        <asp:TextBox ID="txtPostalCode" Width="96" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Religion
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlReligion" Width="300" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Phone / Mobile / Fax
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPhone" Width="98" MaxLength="500" runat="server" />
                                                        <asp:TextBox ID="txtMobile" Width="98" MaxLength="500" runat="server" />
                                                        <asp:TextBox ID="txtFax" Width="96" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Nationality
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlNationality" Width="300" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Email / Url
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmail" Width="148" MaxLength="500" runat="server" />
                                                        <asp:TextBox ID="txtUrl" Width="148" MaxLength="500" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading1">
                                            User Profile
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <table width="100%" cellspacing="1">
                                                <tr>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdProfile" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Profile Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProfileID") %>'
                                                                            ID="_lblProfileID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "ProfileName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                    <td valign="top" class="center">
                                                        <asp:Button ID="btnUserProfileAdd" runat="server" Text="Add >" CssClass="sbttn" Width="100px" /><br />
                                                        <asp:Button ID="btnUserProfileAddAll" runat="server" Text="Add All >>" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <br />
                                                        <asp:Button ID="btnUserProfileRemoveAll" runat="server" Text="<< Remove All" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <asp:Button ID="btnUserProfileRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                            Width="100px" />
                                                    </td>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdUserProfile" runat="server" BorderWidth="0" GridLines="None"
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Profile Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserProfileID") %>'
                                                                            ID="_lblUserProfileID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "ProfileName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading1">
                                            User Site
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <table width="100%" cellspacing="1">
                                                <tr>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdSite" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Site Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SiteID") %>'
                                                                            ID="_lblSiteID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "SiteName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                    <td valign="top" class="center">
                                                        <asp:Button ID="btnUserSiteAdd" runat="server" Text="Add >" CssClass="sbttn" Width="100px" /><br />
                                                        <asp:Button ID="btnUserSiteAddAll" runat="server" Text="Add All >>" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <br />
                                                        <asp:Button ID="btnUserSiteRemoveAll" runat="server" Text="<< Remove All" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <asp:Button ID="btnUserSiteRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                            Width="100px" />
                                                    </td>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdUserSite" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Site Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserSiteID") %>'
                                                                            ID="_lblUserSiteID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "SiteName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading1">
                                            User Customer
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <table width="100%" cellspacing="1">
                                                <tr>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdCustomer" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Customer Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>'
                                                                            ID="_lblCustomerID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "CustomerName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                    <td valign="top" class="center">
                                                        <asp:Button ID="btnUserCustomerAdd" runat="server" Text="Add >" CssClass="sbttn" Width="100px" /><br />
                                                        <asp:Button ID="btnUserCustomerAddAll" runat="server" Text="Add All >>" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <br />
                                                        <asp:Button ID="btnUserCustomerRemoveAll" runat="server" Text="<< Remove All" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <asp:Button ID="btnUserCustomerRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                            Width="100px" />
                                                    </td>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdUserCustomer" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Customer Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserCustomerID") %>'
                                                                            ID="_lblUserCustomerID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "CustomerName") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
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
                                        <td valign="top">
                                            <asp:DataGrid ID="grdUser" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                    <asp:TemplateColumn runat="server" HeaderText="Username">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'
                                                                ID="_lblUsername" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Fisrt Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "FirstName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Middle Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "MiddleName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Last Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "LastName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Gender">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "GenderName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Phone">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Phone")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Mobile">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Mobile") %>
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
