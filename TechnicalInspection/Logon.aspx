<%@ Import Namespace="Raven.Web" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Logon.aspx.vb" Inherits="Raven.Web.Logon"
    EnableSessionState="true" EnableViewState="true" %>

<%@ Register TagPrefix="Module" TagName="Copyright" Src="incl/copyright.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>OPTIMUS - Log In</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/PureravensLib/css/styles_blue.css" type="text/css" rel="Stylesheet">
    <script language="javascript">
        function ffocus() {
            try {
                document.getElementById('txtUsername').focus()
            }
            catch (e) {
            }
        }
    </script>
</head>
<body ms_positioning="GridLayout" onload="ffocus()">
    <form id="frmLogin" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0" style="height: 100%;">
        <tr>
            <td align="center">
                <table width="50%">
                    <tr>
                        <td style="width: 50%; padding-top: 20px;" valign="top">
                            <asp:Panel ID="pnlLogin" runat="server">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="txttitle" valign="top" colspan="2" style="padding: 0 0 20px 0;">
                                            <img src="/PureravensLib/images/OPTIMUS_logo_small.png" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="txterrmsg">
                                            <asp:Label ID="lblErrLogin" runat="server" Visible="False">The Username and/or Password is incorrect. Be sure you're using the valid Username and Password.</asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" Display="dynamic" ErrorMessage="Username"
                                                ControlToValidate="txtUsername" CssClass="txterrmsg" Text="Please enter your Username.">                                            
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Username
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 0 0 10px 0;">
                                            <asp:TextBox ID="txtUsername" runat="server" Width="250" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="txterrmsg">
                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="dynamic" ErrorMessage="Password"
                                                ControlToValidate="txtPassword" CssClass="txterrmsg" Text="Please enter your Password.">                                            
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Password
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="15" TextMode="Password" Width="250" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 20px; padding-bottom: 100px;">
                                            <asp:Button CssClass="sbttn" ID="btnLogin" runat="server" Text="Log In" Height="24px"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlChooseProfileAndSite" runat="server">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="txttitle" valign="top" colspan="2">
                                            <img src="/PureravensLib/images/OPTIMUS_logo_small.png" alt="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="txtusername" style="padding-top: 20px;">
                                            Welcome,
                                            <asp:Label ID="lblUserFullName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 20px;">
                                            Profile
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlUserProfile" runat="server" Width="250">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 20px; padding-bottom: 116px;">
                                            <asp:Button ID="btnContinue" runat="server" Width="100" Text="Continue" CssClass="sbttn" />
                                            <asp:Button ID="btnLogout" runat="server" Width="100" Text="Log Out" CssClass="sbttn" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table width="100%">
                                <tr>
                                    <td class="hseparator" style="width: 100%;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 2px;">
                                        <table cellpadding="1" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <img src="/pureravensLib/images/clientCompanyLogo.png" width="70" alt="" />
                                                </td>
                                                <td valign="top" style="padding-left: 5px;">
                                                    <table cellpadding="1" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblCompanyAddress" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblCompanyPhone" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblCompanyCityPostalCode" runat="server"></asp:Label>
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
                        <td style="width: 50%; padding-top: 20px; padding-left: 50px;" valign="top">
                            <img src="/PureravensLib/images/main.png" alt="Main" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 20px 0 0 0;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 1px 0 0 0; background-color: #dddddd;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="txtweak center">
                            Pureravens Indonesia. Cluster Imperium Design No. 33. Lippo Karawaci. Tangerang
                            15810. Indonesia. Mobile: +62 878 8214 7959 | Email: support@pureravens.com
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="bottom">
                <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
