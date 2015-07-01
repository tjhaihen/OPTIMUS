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
                                            Customer Inspection Information Detail for
                                            <asp:label ID="lblProjectCode" runat="server"></asp:label>
                                            <asp:label ID="lblProjectID" runat="server" visible="false"></asp:label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataGrid ID="grdSummaryOfInspection" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                <itemstyle cssclass="gridItemStyle" />
                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                <columns>
                                                    <asp:TemplateColumn runat="server" HeaderText="Description of Equipment" ItemStyle-VerticalAlign="Top" ItemStyle-Width="120">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "descriptionOfEquipment") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Serial No." ItemStyle-VerticalAlign="Top" ItemStyle-Width="120">
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
                                                            <%# Format(DataBinder.Eval(Container.DataItem, "ExpireDate"),"dd-MMM-yyyy") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Result" ItemStyle-VerticalAlign="Top" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "result") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Defect Found" ItemStyle-VerticalAlign="Top" ItemStyle-Width="200">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "defectFound") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Remarks" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "remarks") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>                                                                                  
                                                </columns>
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
    </table>
    </form>
</body>
</html>
