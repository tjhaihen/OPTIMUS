<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Toolbar.ascx.vb"
    Inherits="Raven.Toolbar" %>
<%@ Import Namespace="Raven.Web" %>
<link rel="stylesheet" type="text/css" href="/PureravensLib/css/csstoolbar.css" />
<div id="DivToolbarM">
    <table class="ToolbarM" cellpadding="1" cellspacing="0" border="0">
        <tr align="center" valign="middle">
            <asp:Panel runat="server" ID="TMPnlNew">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnNew" ToolTip="New" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbnew.png" alt="" border="0" /><br />New</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlSave">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnSave" ToolTip="Save" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbsave.png" alt="" border="0"/><br />Save</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowAdd" runat="server" Visible="false" />
                    <asp:CheckBox ID="chkIsAllowEdit" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlDelete">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnDelete" ToolTip="Delete" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbdelete.png" alt="" border="0" /><br />Delete</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowDelete" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlApprove">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnApprove" ToolTip="Approve" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbapprove.png" alt="" border="0" /><br />Approve</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowApprove" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlVoid">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnVoid" ToolTip="Void" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbvoid.png" alt="" border="0" /><br />Void</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowVoid" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlPrint">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnPrint" ToolTip="Print" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbprint.png" alt="" border="0" /><br />Print</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowPrint" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlPrevious">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnPrevious" ToolTip="Back" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbback.png" alt="" border="0" /><br />Back</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlNext">
                <td align="center" valign="middle" style="width: 62px;">
                    <asp:LinkButton runat="server" ID="lbtnNext" ToolTip="Next" CausesValidation="false" style="width: 62px;"><img src="/PureravensLib/images/tbnext.png" alt="" border="0" /><br />Next</asp:LinkButton>
                </td>
            </asp:Panel>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Label runat="server" ID="lblMenuID" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</div>
