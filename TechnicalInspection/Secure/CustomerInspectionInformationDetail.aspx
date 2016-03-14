<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerInspectionInformationDetail.aspx.vb"
    Inherits="Raven.Web.Secure.CustomerInspectionInformationDetail" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Customer Inspection Information Detail</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
    <script language="javascript" type="text/javascript" src="/PureravensLib/scripts/JScript.js"></script>
</head>
<body onload="center();">
    <form id="frmkunjPoli" runat="server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
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
                                            Customer Inspection Information Detail for:
                                            <asp:Label ID="lblWRNo" runat="server"></asp:Label>
                                            [<asp:Label ID="lblProjectCode" runat="server"></asp:Label>]
                                            <asp:Label ID="lblProjectID" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadTabStrip ID="rtsDetailInformation" runat="server" Skin="Windows7" MultiPageID="rmpDetailInformation"
                                                SelectedIndex="0" CssClass="tabStrip">
                                                <Tabs>
                                                    <telerik:RadTab Text="Project File">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Text="Daily Progress Report">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Text="Inspector File">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Text="Summary of Inspection by Work Request">
                                                    </telerik:RadTab>
                                                </Tabs>
                                            </telerik:RadTabStrip>
                                            <telerik:RadMultiPage ID="rmpDetailInformation" runat="server" SelectedIndex="0"
                                                CssClass="multiPage">                                                
                                                <telerik:RadPageView ID="pvProjectFile" runat="server">
                                                    <asp:DataGrid ID="grdProjectFile" runat="server" BorderWidth="0" GridLines="None"
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
                                                                    <asp:Label ID="_lblProjectFileID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "projectFileID") %>' />
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
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="pvDailyReport" runat="server">
                                                    <table width="100%">
                                                        <tr>
                                                            <td valign="top" width="100">
                                                                <table width="100%" cellspacing="0" cellpadding="2" style="background: #eeeeee;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DataGrid ID="grdDailyReportHd" runat="server" BorderWidth="0" GridLines="None"
                                                                                Width="100%" CellPadding="2" CellSpacing="2" ShowHeader="false" ShowFooter="false"
                                                                                AutoGenerateColumns="false">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                <ItemStyle CssClass="gridMedHeightItemStyle" />
                                                                                <AlternatingItemStyle CssClass="gridMedHeightItemStyle" />
                                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                <Columns>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="" HeaderStyle-HorizontalAlign="Left"
                                                                                        ItemStyle-HorizontalAlign="Left">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="_lbtnReportDate" runat="server" Text='<%# Format(DataBinder.Eval(Container.DataItem, "reportDate"), "dd-MMM-yyyy")%>'
                                                                                                Width="100%" CommandName="SelectReportDate" CssClass="txtnormallink" ToolTip='<%# DataBinder.Eval(Container.DataItem, "dailyReportHdID")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </Columns>
                                                                            </asp:DataGrid>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" class="vseparator" style="height: 100%; width=1px;">
                                                            </td>
                                                            <td valign="top">
                                                                <table>
                                                                    <tr>
                                                                        <td class="Title">
                                                                            <asp:Label ID="lblDailyReportHdID" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DataGrid ID="grdDailyReportDt" runat="server" BorderWidth="0" GridLines="None"
                                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                                AutoGenerateColumns="false">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                <Columns>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="No." ItemStyle-Width="50">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="DPR_lblDailyReportDtID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DailyReportDtID") %>'
                                                                                                Visible="false"></asp:Label>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "sequenceNo") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Material Detail" ItemStyle-Width="220">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "materialDetail") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Weather">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "weatherConditionName") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Description">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "description") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Current Qty">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "currentQty") %>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "currentUOM") %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Previous Qty">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "beginningQty") %>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "beginningUOM")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Cumulative">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "endingQty") %>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "endingUOM") %>
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
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="pvResourceFile" runat="server">
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
                                                            <asp:TemplateColumn runat="server" HeaderText="Inspector" HeaderStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="200" ItemStyle-Width="200" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "resourceName") %>
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
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="pvSOIByWorkRequest" runat="server">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #058ACD;">
                                                                    <tr>
                                                                        <td class="center">
                                                                            TOTAL INSPECTED
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridItemStyle center" style="height: 25; font-size: 12pt;">
                                                                            <asp:Label ID="lblTotalItemIspected" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #66CC33;">
                                                                    <tr>
                                                                        <td class="center" colspan="2">
                                                                            <asp:LinkButton ID="lbtnAccepted" runat="server" Text="TOTAL ACCEPTED">
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridItemStyle center" style="height: 25; font-size: 12pt; width: 50%;">
                                                                            <asp:Label ID="lblTotalItemAccepted" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td class="gridItemStyle center" style="height: 25; font-size: 12pt; width: 50%;">
                                                                            <asp:Label ID="lblTotalItemAcceptedPct" runat="server"></asp:Label>%
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #EF8E19;">
                                                                    <tr>
                                                                        <td class="center" colspan="2">
                                                                            <asp:LinkButton ID="lbtnRepair" runat="server" Text="TOTAL NEED REPAIR">
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridItemStyle center" style="height: 25; font-size: 12pt; width: 50%;">
                                                                            <asp:Label ID="lblTotalItemNeedRepair" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td class="gridItemStyle center" style="height: 25; font-size: 12pt; width: 50%;">
                                                                            <asp:Label ID="lblTotalItemNeedRepairPct" runat="server"></asp:Label>%
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table class="projectbanner" cellspacing="1" cellpadding="2" width="150" style="background: #FF6666;">
                                                                    <tr>
                                                                        <td class="center" colspan="2">
                                                                            <asp:LinkButton ID="lbtnRejected" runat="server" Text="TOTAL REJECTED">
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="gridItemStyle center" style="height: 25; font-size: 12pt; width: 50%;">
                                                                            <asp:Label ID="lblTotalItemRejected" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td class="gridItemStyle center" style="height: 25; font-size: 12pt; width: 50%;">
                                                                            <asp:Label ID="lblTotalItemRejectedPct" runat="server"></asp:Label>%
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:DataGrid ID="grdSummaryOfInspection" runat="server" BorderWidth="0" GridLines="None"
                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                        AutoGenerateColumns="false">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                        <ItemStyle CssClass="gridItemStyle" />
                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                        <Columns>
                                                            <asp:TemplateColumn runat="server" HeaderText="Description of Equipment" ItemStyle-VerticalAlign="Top"
                                                                ItemStyle-Width="120">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "descriptionOfEquipment") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Serial No." ItemStyle-VerticalAlign="Top"
                                                                ItemStyle-Width="120">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "serialIDNo") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Exam Date" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center"
                                                                HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <%# Format(DataBinder.Eval(Container.DataItem, "examDate"),"dd-MMM-yyyy") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Expired Date" ItemStyle-Width="100"
                                                                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <%# IIf(DataBinder.Eval(Container.DataItem, "ExpireDate")=DataBinder.Eval(Container.DataItem, "examDate"),"No Exp. Date",Format(DataBinder.Eval(Container.DataItem, "ExpireDate"),"dd-MMM-yyyy")) %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Result" ItemStyle-VerticalAlign="Top"
                                                                ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "result") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Defect Found" ItemStyle-VerticalAlign="Top"
                                                                ItemStyle-Width="200">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "defectFound") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Remarks" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "remarks") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </telerik:RadPageView>
                                            </telerik:RadMultiPage>
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
