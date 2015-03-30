<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RadMenu.ascx.vb" Inherits="Raven.RadMenu" %>
<%@ Register Src="~/Libs/Controls/Menu.ascx" TagName="Menu" TagPrefix="ucMenu" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Import Namespace="Raven.Web" %>
<link href="/PureravensLib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
<link rel="shortcut icon" type="image/x-icon" href="/PureravensLib/images/Ravenicon.ico" />
<table width="100%" cellpadding="1" cellspacing="0">
    <tr>
        <td class="Menu" align="left" valign="middle" style="width: 95%; padding-left: 5px">
            <table width="100%" cellspacing="0" cellpadding="2">
                <tr>
                    <td class="Menu" style="width: 100px;">
                        OPTIMUS&reg
                    </td>
                    <td class="Menu Separator">
                        <img src="/PureravensLib/images/separator.png" border="0" alt="" align="absmiddle" />                    
                    </td>
                    <td class="Menu center" style="width: auto;">
                        <asp:Label ID="lblUserFullName" runat="server"></asp:Label>
                    </td>
                    <td class="Menu Separator">
                        <img src="/PureravensLib/images/separator.png" border="0" alt="" align="absmiddle" />                    
                    </td>
                    <td class="Menu center" style="width: auto;">
                        <asp:Label ID="lblProfileName" runat="server"></asp:Label>
                    </td>
                    <td class="Menu" style="width: 50%; padding-right: 5px" align="right">
                        <a href='<%=PageBase.UrlBase & "/secure/main.aspx"%>'>
                            <img src="/PureravensLib/images/home.png" border="0" alt="" title="Home" align="absmiddle" /></a>&nbsp;
                        <asp:ImageButton runat="server" ID="btnLogout" ImageUrl="/PureravensLib/images/close.png"
                            ToolTip="Log Out" ImageAlign="AbsMiddle" CausesValidation="false" />                                                                        
                    </td>
                    <td class="Menu Separator">
                        <img src="/PureravensLib/images/separator.png" border="0" alt="" align="absmiddle" />                    
                    </td>
                    <td class="Menu center" style="width: auto;">
                        <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="2" class="Menubg">
            <ucMenu:Menu ID="Menu" runat="server" />
        </td>
    </tr>
</table>
