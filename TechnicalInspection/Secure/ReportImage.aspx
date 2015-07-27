<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportImage.aspx.vb" Inherits="Raven.Web.Secure.ReportImage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Report Image Attachment</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
    <script language="javascript" type="text/javascript" src="/PureravensLib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepImages
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepImages li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            width: 35px;
            height: auto;
            margin: 0px;
        }
    </style>
</head>
<body onload="center();">
    <form id="frmReportImage" runat="server">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" style="height: 100%;">
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr>
                                        <td class="rheader">
                                            Report Image Attachment for
                                            <asp:label ID="lblReportNo" runat="server"></asp:label>
                                            <asp:label ID="lblReportTypeID" runat="server" visible="false"></asp:label>
                                            <asp:label ID="lblReportHdID" runat="server" visible="false"></asp:label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtReportImageID" runat="server" Visible="false">
                                            </asp:TextBox>
                                            <input id="ImageFile" type="file" runat="server" autopostback="True" name="ImageFile"
                                                class="imguploader" style="width: 100%;" />                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtPicDescription" runat="server" Width="100%">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkShowOnMainReport" runat="server" text="Is Show on Main Report?"></asp:CheckBox>
                                            <asp:Button ID="btnUploadImage" runat="server" Text="Upload" CssClass="sbttn" Width="100" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <!-- Place for DataGrid MPIDt -->
                                            <asp:Repeater ID="repImages" runat="server">
                                                <headertemplate>
                                                    <ul id="ulRepImages">
                                                </headertemplate>
                                                <itemtemplate>
                                                    <li>
                                                        <table cellspacing="1">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="_lblReportImageIDonRep" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "reportImageID") %>'></asp:Label>
                                                                    <asp:Image ID="_imgReportPic" runat="server" Width="200" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" cellspacing="0" cellpadding="2">
                                                                        <tr>
                                                                            <td class="gridAlternatingItemStyle">
                                                                                <%# DataBinder.Eval(Container.DataItem, "picDescription") %>&nbsp;(<%# DataBinder.Eval(Container.DataItem, "picType")%>)
                                                                            </td>
                                                                            <td align="right" class="gridAlternatingItemStyle">
                                                                                <asp:ImageButton ID="_ibtnpicEdit" runat="server" CommandName="Edit" ImageUrl="/pureravensLib/images/edit_small.png"
                                                                                    ImageAlign="AbsMiddle" ToolTip="Edit" />
                                                                                <asp:ImageButton ID="_ibtnpicDelete" runat="server" CommandName="Delete" ImageUrl="/pureravensLib/images/delete_small.png"
                                                                                    ImageAlign="AbsMiddle" ToolTip="Delete" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="gridAlternatingItemStyle">
                                                                                <asp:CheckBox ID="_chkIsShowOnMainReport" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "isShowOnMainReport")%>' text="Show on Main Report" Enabled="false"></asp:CheckBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                </itemtemplate>
                                                <footertemplate>
                                                    </ul>
                                                </footertemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
