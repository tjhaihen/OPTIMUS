<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ErrMsg.aspx.vb" Inherits="Raven.Web.ErrMsg" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>OPTIMUS - Error Handler Page</title>
    <link href="/PureravensLib/css/styles_blue.css" type="text/css" rel="Stylesheet">
</head>
<body>
    <form id="errMsg" runat="server">
    <table cellspacing="0" cellpadding="5" border="0">
        <tr>
            <td valign="middle" style="padding: 50px 0 0 60px" class="txttitle">
                <asp:Label ID="lblErrorDesc" runat="server"></asp:Label>                
            </td>
        </tr>
        <tr>
            <td valign="absmiddle" style="padding: 20px 0 0 60px;">
                Please record the message above and report to your System Administrator.<br />
                <img src="/PureravensLib/images/email.png" border="0" alt="" align="absmiddle" />&nbsp;
                support@pureravens.com&nbsp;&nbsp;
                <img src="/PureravensLib/images/phone.png" border="0" alt="" align="absmiddle" />&nbsp;
                +62 878 8214 7959
            </td>
        </tr>
        <tr>
            <td valign="middle" style="padding: 20px 0 0  60px;">
                Error date and time:&nbsp;<asp:Label ID="lblErrorDateTime" runat="server"></asp:Label>
                &nbsp;|&nbsp;Action performed by:&nbsp;<asp:Label ID="lblErrorPerformedBy" runat="server"
                    Font-Size="12px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="middle" style="padding: 20px 0 0 60px;">
                <a href="javascript:history.back();" style="color: Blue">[Back]</a> to previous page.
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
