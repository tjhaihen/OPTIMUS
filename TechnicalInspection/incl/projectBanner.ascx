<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="projectBanner.ascx.vb" Inherits="Raven.ProjectBanner" %>
<table width="100%" cellpadding="3" cellspacing="0" class="projectbanner">
    <tr>
        <td valign="top" align="left" colspan="4">
            <asp:Label ID="lblProjectID" runat="server" Visible="false"></asp:Label>            
            <asp:Label ID="lblCustomerID" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblCustomerName" runat="server" CssClass="projectbanner_heading1" Text="[Customer Name]"></asp:Label>            
        </td>        
        <td valign="top" align="right" colspan="2">
            <asp:Label ID="lblProjectCode" runat="server" Text="[Project Code]" CssClass="projectbanner_heading1"></asp:Label>
        </td>
    </tr>
    <tr>    
        <td class="right">
            Job Description:
        </td>
        <td>            
            <asp:Label ID="lblJobDescription" runat="server" Text="[Job Description]"></asp:Label>
        </td>  
        <td style="width: 100px;" class="right">
            Location:
        </td>
        <td style="width: 180px;">
            <asp:Label ID="lblLocation" runat="server" Text="[Project Location]" style="font-weight: bold;"></asp:Label>
        </td>
        <td style="width: 140px;" class="right">
            FR/WO/PO/JO No.:
        </td>
        <td>
            <asp:Label ID="lblWorkOrderNo" runat="server" Text="[###]" style="font-weight: bold;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="right">
            Period:
        </td>
        <td>
            <asp:Label ID="lblPeriod" runat="server" Text="[Period]" style="font-weight: bold;"></asp:Label>
        </td>        
        <td class="right">
            Project:
        </td>
        <td>
            <asp:Label ID="lblProjectName" runat="server" Text="[Project Name]" style="font-weight: bold;"></asp:Label>
        </td>
        <td class="right">
            Work Order Date:
        </td>
        <td>
            <asp:Label ID="lblWorkOrderDate" runat="server" Text="[dd-MMM-yyyy]" style="font-weight: bold;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="6" class="projectbanner_space"></td>
    </tr>
</table>