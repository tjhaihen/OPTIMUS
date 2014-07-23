<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="searchlist.aspx.vb" Inherits="Raven.SearchList" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal ID="litSearchList" runat="server" Text="" /></title>
    <link rel="shortcut icon" type="image/x-icon" href="/PureravensLib/images/Ravenicon.ico" />
    <link rel="Stylesheet" type="text/css" href="/PureravensLib/css/styles_blue.css" />
    <script language="javascript" src="/PureravensLib/scripts/JScript.js"></script>
</head>
<body onload="ffocus('txtFilterValue')" onkeydown="closeWindow_Escape(event.keyCode)">
    <form id="form1" runat="server">
    <table border="0" style="height: 100%;" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" style="height: 32px;">
                <table cellspacing="0" cellpadding="1" width="100%" border="0">
                    <tr class="menu_gray">
                        <td align="left" style="width: 100px; padding: 0 0 0 5px;">
                            Count:
                            <asp:Label ID="lblSearchResults" runat="server" />
                        </td>
                        <td style="text-align: right; width: 100px">
                            <asp:Label ID="lblFilterValueCaption" runat="server" Text="Filter value" />&nbsp;
                        </td>
                        <td style="width: 220px">
                            <asp:TextBox ID="txtFilterValue" runat="server" Text="" onkeypress="javascript:PostBackCtrlID_Enter(event.keyCode,'linkApplyFilter');"
                                onfocus="javascript:setSelectionRange('txtFilterValue');" Width="200px" />
                            <asp:Label ID="lblSearchProcedure" runat="server" Style="display: none" />
                            <asp:Label ID="lblSearchCode" runat="server" Style="display: none" />
                        </td>
                        <td style="text-align: right; width: 50px">
                            <asp:Label ID="lblShowCaption" runat="server" Text="Show" />&nbsp;
                        </td>
                        <td style="width: 150px">
                            <asp:TextBox ID="txtMaxRecord" runat="server" Text="" Style="text-align: center"
                                MaxLength="4" Width="50px" />                            
                        </td>
                        <td align="right" style="padding: 0 5px 0 0;">
                            <asp:LinkButton ID="linkApplyFilter" runat="server" Width="60px" Text="Apply" Visible="false" />
                            <asp:Button ID="btnApplyFilter" runat="server" Text="Go" CssClass="sbttn" Height="24px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%; margin-top: 32px;">
                <div style="width: 100%; height: 100%; overflow: scroll;">
                    <table cellspacing="1" cellpadding="1" border="0" width="100%" style="height: 100%;">
                        <!-- PAGE CONTENT BEGIN HERE -->
                        <tr>
                            <td valign="top" colspan="2" style="height: 100%;">
                                <asp:DataGrid ID="grdSearchList" runat="server" BorderWidth="0" GridLines="None"
                                    Width="100%" CellPadding="2" CellSpacing="1">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                    <ItemStyle CssClass="gridItemStyle" />
                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                    <Columns>
                                        <asp:TemplateColumn runat="server" HeaderText="" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="5px" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px"
                                            Visible="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="_lbtnok" runat="server" CssClass="MyButton" Text="Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <!-- PAGE CONTENT END HERE -->
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
