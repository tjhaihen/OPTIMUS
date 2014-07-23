<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Menu.ascx.vb" Inherits="CommonLibs.Menu" %>
<link href="/PureravensLib/css/cssmenu.css" type="text/css" rel="Stylesheet" />
<link rel="shortcut icon" type="image/x-icon" href="/PureravensLib/images/pureravensico.ico" />
<script src="/PureravensLib/scripts/jquery/jquery-1.7.1.js"></script>
<script src="/PureravensLib/scripts/jquery/superfish.js"></script>
<script type="text/javascript">
    $(function () {
        $('#dropDownMenu').superfish({
        });
    });
</script>
<asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
    <HeaderTemplate>
        <ul class="sf-menu" id="dropDownMenu">
    </HeaderTemplate>
    <ItemTemplate>
        <li class="liHeader"><a href="<%# GetResolveUrl(DataBinder.Eval(Container.DataItem, "Url").ToString) %>">
            <%# DataBinder.Eval(Container.DataItem, "Caption").ToString.Trim %></a>
            <asp:Repeater ID="rptMenuLevel2" runat="server" OnItemDataBound="rptMenuLevel2_ItemDataBound">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href="<%# GetResolveUrl(DataBinder.Eval(Container.DataItem, "Url").ToString) %>">
                        <%# DataBinder.Eval(Container.DataItem, "Caption").ToString.Trim%></a>
                        <asp:Repeater ID="rptMenuLevel3" runat="server" OnItemDataBound="rptMenuLevel3_ItemDataBound">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><a href="<%# GetResolveUrl(DataBinder.Eval(Container.DataItem, "Url")) %>">
                                    <%# DataBinder.Eval(Container.DataItem, "Caption").ToString.Trim%></a>
                                    <asp:Repeater ID="rptMenuLevel4" runat="server">
                                        <HeaderTemplate>
                                            <ul>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li><a href="<%# GetResolveUrl(DataBinder.Eval(Container.DataItem, "Url")) %>">
                                                <%# DataBinder.Eval(Container.DataItem, "Caption").ToString.Trim %></a></li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
