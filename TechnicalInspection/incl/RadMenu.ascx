<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RadMenu.ascx.vb" Inherits="Raven.RadMenu" %>
<%@ Register Src="~/Libs/Controls/Menu.ascx" TagName="Menu" TagPrefix="ucMenu" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Import Namespace="Raven.Web" %>
<telerik:RadScriptManager ID="ScriptManager" runat="server" />
<link href="/PureravensLib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
<link rel="shortcut icon" type="image/x-icon" href="/PureravensLib/images/Ravenicon.ico" />
<style type="text/css">
        #ulRepApplication
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepApplication li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #eeeeee;
            width: 120px;
            height: 120px;
            margin: 5px;
        }
    </style>
<table width="100%" cellpadding="1" cellspacing="0">
    <tr>
        <td class="Menu" align="left" valign="middle" style="width: 95%; padding-left: 5px">
            <table width="100%" cellspacing="0" cellpadding="2">
                <tr>
                    <td class="Menu">
                        <img style="cursor: pointer" onclick="javascript:if (divApplicationSelector.style.display == '') {divApplicationSelector.style.display = 'none'; this.src='/pureravensLib/images/modules.png'; } else { divApplicationSelector.style.display = ''; this.src='/pureravensLib/images/modules.png';}"
                            alt="Modules" src="/pureravensLib/images/modules.png" align="absmiddle">
                    </td>
                    <td class="Menu Separator">
                        <img src="/PureravensLib/images/separator.png" border="0" alt="" align="absmiddle" />
                    </td>
                    <td class="Menu center" style="width: 100px;">
                        OPTIMUS&reg
                    </td>
                    <td class="Menu Separator">
                        <img src="/PureravensLib/images/separator.png" border="0" alt="" align="absmiddle" />
                    </td>
                    <td class="Menu center">
                        <asp:Label ID="lblApplicationID" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblApplicationName" runat="server"></asp:Label>
                    </td>
                    <td class="Menu Separator">
                        <img src="/PureravensLib/images/separator.png" border="0" alt="" align="absmiddle" />
                    </td>
                    <td class="Menu center">
                        <asp:Label ID="lblUserFullName" runat="server"></asp:Label>
                    </td>
                    <td class="Menu Separator">
                        <img src="/PureravensLib/images/separator.png" border="0" alt="" align="absmiddle" />
                    </td>
                    <td class="Menu center" style="width: auto;">
                        <asp:Label ID="lblProfileName" runat="server"></asp:Label>
                    </td>
                    <td class="Menu" style="width: 30%; padding-right: 5px" align="right">
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
                <tr>
                    <td colspan="12">
                        <div id="divApplicationSelector" style="overflow: auto; width: 100%; display: none;">
                            <asp:Repeater ID="repApplication" runat="server" OnItemCommand="repApplication_ItemCommand">
                                <HeaderTemplate>
                                    <ul id="ulRepApplication">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <table cellspacing="1" width="100%">
                                            <tr>
                                                <td class="center" style="width: 120; height: 30; background-color: #A9E2F3;">
                                                    <asp:Label ID="_lblAppID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "appID")%>'></asp:Label>
                                                    <asp:LinkButton ID="_lbtnApplication" runat="server" CommandName="SelectApplication"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "appName")%>'></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="middle">
                                                    <asp:Image ID="_imgApplication" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "appImageFileName")%>' ImageAlign="AbsMiddle" />
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top" class="Menubg">
            <ucMenu:Menu ID="Menu" runat="server" />
        </td>
    </tr>
</table>
