<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Resource.aspx.vb" Inherits="Raven.Web.Secure.Resource" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Resource</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" height="100%" cellspacing="2" cellpadding="1">
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
                                            Resource
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
                                                        Resource Code
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtResourceID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtResourceCode" Width="300" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvResourceCode" runat="server" ControlToValidate="txtResourceCode"
                                                            ErrorMessage="Resource Code" Display="dynamic" Text="*">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Start Working Date
                                                    </td>
                                                    <td>
                                                        <Module:Calendar ID="calWorkingSDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Resource Type
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlResourceType" Width="300" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        End Working Date
                                                    </td>
                                                    <td>
                                                        <Module:Calendar ID="calWorkingEDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Job Title
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtJobTitle" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active?" Checked="False" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Username
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUserID" Width="300" MaxLength="15" runat="server" AutoPostBack="True"
                                                            Visible="false" />
                                                        <asp:TextBox ID="txtUserName" Width="266" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:Button ID="btnSearchUser" runat="server" Text="..." Width="30" CausesValidation="false" />
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
                                        <td class="heading1">
                                            Resource Signature
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
                                                    <td style="width: 150px;" class="right" valign="top">
                                                        Signature
                                                    </td>
                                                    <td style="width: 500px;" valign="top">
                                                        <asp:TextBox ID="txtResourceSignatureID" Width="300" MaxLength="100" runat="server"
                                                            Visible="false" />
                                                        <input id="ImageFilePicSignature" type="file" runat="server" autopostback="True"
                                                            name="ImageFilePicSignature" class="imguploader" style="width: 200;" />
                                                        <asp:Button ID="btnUploadPicSignature" runat="server" Text="Upload" CssClass="sbttn"
                                                            Width="100" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Description
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtResourceSignatureDescription" Width="300" MaxLength="100" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;">
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <table width="300" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="gridAlternatingItemStyle">
                                                                    <asp:Image ID="imgPicSignature" runat="server" Width="160" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" colspan="4">
                                                        <asp:DataGrid ID="grdResourceSignature" runat="server" BorderWidth="0" GridLines="None"
                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                            AutoGenerateColumns="false">
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Signature" ItemStyle-Width="180">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="_imgPicSignature" runat="server" Width="160" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Signature Description">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ResourceSignatureID") %>'
                                                                            ID="_lblResourceSignatureID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/PureravensLib/images/delete.png"
                                                                            ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Heading1" colspan="4">
                                                        Resource File
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Choose File
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtResourceFileID" Width="300" MaxLength="500" runat="server" Visible="false">
                                                        </asp:TextBox>
                                                        <input id="txtFileUrl" type="file" name="txtFileUrl" runat="server" class="imguploader"
                                                            style="width: 300px;">
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Description
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtResourceFileDescription" Width="300" MaxLength="500" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        File Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtResourceFileName" Width="300" MaxLength="500" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Is Shared?
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsShared" runat="server"></asp:CheckBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        File No.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtResourceFileNo" Width="300" MaxLength="500" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Button ID="btnAttachResourceFile" runat="server" Text="Attach" CssClass="sbttn"
                                                            Width="100" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:DataGrid ID="grdResourceFile" runat="server" BorderWidth="0" GridLines="None"
                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                            AutoGenerateColumns="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                            <ItemStyle CssClass="gridItemStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <Columns>
                                                                <asp:TemplateColumn runat="server" HeaderText="" HeaderStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-Width="26" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="26">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="_lblResourceFileID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "resourceFileID") %>' />
                                                                        <a href='<%# DataBinder.Eval(Container.DataItem, "fileUrl") %>' target="_blank">
                                                                            <img src="/pureravensLib/images/look.png" border="0" align="middle" alt='<%# DataBinder.Eval(Container.DataItem, "fileName") %>' />
                                                                        </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="File No." HeaderStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-Width="200" ItemStyle-Width="200" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "fileNo") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="File Name" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "fileName") %>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="txtweak">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Type" HeaderStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "fileExtension") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Is Shared?" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100" FooterStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "isShared") %>'
                                                                            ID="_lblStatus" Enabled="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Attached By" HeaderStyle-Width="100"
                                                                    FooterStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td class="txtweak">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "userName") %>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="txtweak">
                                                                                    <%# Format(DataBinder.Eval(Container.DataItem, "insertDate"), "dd-MMM-yyyy HH:mm") %>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="" HeaderStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-Width="30" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_ibtnDelete" runat="server" CommandName="Delete" ImageUrl="/pureravensLib/images/delete.png">
                                                                        </asp:ImageButton>
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
                                            <asp:DataGrid ID="grdResource" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                    <asp:TemplateColumn runat="server" HeaderText="Code">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ResourceCode") %>'
                                                                ID="_lblResourceCode" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Type">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ResourceTypeSCode")%>
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
