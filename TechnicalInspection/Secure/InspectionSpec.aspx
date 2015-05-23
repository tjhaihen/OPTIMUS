<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InspectionSpec.aspx.vb" Inherits="Raven.Web.Secure.InspectionSpec" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Inspection Specification</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/PureravensLib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/PureravensLib/scripts/common/common.js'></script>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" style="height: 100%;">
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
                                            Inspection Specification
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
                                                        Inspection Spec. Code
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtInspectionSpecificationID" Width="300" runat="server" AutoPostBack="True"
                                                            Visible="false" />
                                                        <asp:TextBox ID="txtInspectionSpecificationCode" Width="300" MaxLength="15" runat="server"
                                                            AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvInspectionSpecificationCode" runat="server" ControlToValidate="txtInspectionSpecificationCode"
                                                            ErrorMessage="Inspection Specification Code" Display="dynamic" Text="*">																
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Inspection Spec. Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtInspectionSpecificationName" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active?" Checked="False" />
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
                                                    <td style="width: 150px; font-weight: bold;" class="right">
                                                        Size
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtSize" Width="300" MaxLength="50" runat="server" AutoPostBack="true" />
                                                    </td>
                                                    <td style="width: 150px; font-weight: bold;" class="right">
                                                        Connection
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtConnection" Width="300" MaxLength="50" runat="server" AutoPostBack="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="font-weight: bold;">
                                                        Weight
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtWeight" Width="300" MaxLength="50" runat="server" AutoPostBack="true" />
                                                    </td>
                                                    <td class="right" style="font-weight: bold;">
                                                        Grade
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtGrade" Width="300" MaxLength="50" runat="server" AutoPostBack="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Range
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRange" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Nominal Width
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNominalWidth" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="heading1">
                                            Premium Class
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
                                                        Min. Outside Diameter
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtMinODPremium" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Min. Shoulder Width
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinShoulderPremium" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Max. Inside Diameter
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxIDPremium" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Min. Bevel Diameter                                                        
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinBevelDiaPremium" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Min. Wall
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinWallPremium" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Min. Seal
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinSealPremium" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="heading1">
                                            Class 2
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
                                                        Min. Outside Diameter
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtMinODClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                        Min. Shoulder Width
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinShoulderClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Max. Inside Diameter
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxIDClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Min. Bevel Diameter
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBevelDiaClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Min. Wall
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinWallClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Min. Seal
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinSealClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Min. Tong Space Pin
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinTongSpacePinClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Min. Tong Space Box                                                        
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinTongSpaceBoxClass2" Width="300" MaxLength="50" runat="server" />                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Max. Pin Length
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxLengthPinClass2" Width="300" MaxLength="50" runat="server" />                                                        
                                                    </td>
                                                    <td class="right">
                                                        Max. Pin Neck
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxPinNeckClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Min. QC Depth
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMinQCDepthClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Max. QC
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxQCClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Max C. Bore
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxCBoreClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                    <td class="right">
                                                        Max. Bevel Diameter
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxBevelDiaClass2" Width="300" MaxLength="50" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:DataGrid ID="grdInspectionSpec" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InspectionSpecCode") %>'
                                                                ID="_lblInspectionSpecCode" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "InspectionSpecName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Size">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "size")%>'
                                                                ID="_lblSize" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Weight">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "weight")%>'
                                                                ID="_lblWeight" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Connection">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "connection")%>'
                                                                ID="_lblConnection" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Grade">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "grade")%>'
                                                                ID="_lblGrade" />
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
