<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CSSToolbar.ascx.vb"
    Inherits="Raven.CSSToolbar" %>
<%@ Import Namespace="Raven.Web" %>
<link rel="stylesheet" type="text/css" href="/PureravensLib/css/csstoolbar_blue.css" />
<div id="DivToolbarM">
    <table class="ToolbarM" cellpadding="1" cellspacing="0" border="0">
        <tr>
            <asp:Panel runat="server" ID="TMPnlNew">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnNew" ToolTip="New" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbnew.png" alt="" border="0" /><br />New</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlRefresh" Visible="false">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnRefresh" ToolTip="Refresh" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbrefresh.png" alt="" border="0" /><br />Refresh</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlSave">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnSave" ToolTip="Save" CausesValidation="true" Width="48"><img src="/PureravensLib/images/tbsave.png" alt="" border="0"/><br />Save</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowAdd" runat="server" Visible="false" />
                    <asp:CheckBox ID="chkIsAllowEdit" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlDelete">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnDelete" ToolTip="Delete" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbdelete.png" alt="" border="0" /><br />Delete</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowDelete" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMpnlPropose" Visible="false">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnPropose" ToolTip="Propose" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbpropose.png" alt="" border="0" /><br />Propose</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlApprove">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnApprove" ToolTip="Approve" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbapprove.png" alt="" border="0" /><br />Approve</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowApprove" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlVoid">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnVoid" ToolTip="Void" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbvoid.png" alt="" border="0" /><br />Void</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowVoid" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlPrint">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnPrint" ToolTip="Print" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbprint.png" alt="" border="0" /><br />Print</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowPrint" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMpnlAttach" Visible="false">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnAttach" ToolTip="Propose" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbattach.png" alt="" border="0" /><br />Attach</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlPrevious">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnPrevious" ToolTip="Back" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbback.png" alt="" border="0" /><br />Back</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlNext">
                <td class="center padding-LR-5">
                    <asp:LinkButton runat="server" ID="lbtnNext" ToolTip="Next" CausesValidation="false" Width="48"><img src="/PureravensLib/images/tbnext.png" alt="" border="0" /><br />Next</asp:LinkButton>
                </td>
            </asp:Panel>
        </tr>
        <tr style="display: none;">
            <td>
                <asp:Label runat="server" ID="lblMenuID" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</div>
