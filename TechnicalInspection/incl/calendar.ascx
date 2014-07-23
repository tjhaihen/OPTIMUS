<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="calendar.ascx.vb" Inherits="Raven.Web.Calendar"
    TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:TextBox ID="txtPopUpCal" runat="server" MaxLength="11" AutoPostBack="False"
    CssClass="center" Width="100"></asp:TextBox>
<img id="calIcon" alt="Click here to select a date" src="/PureravensLib/images/datepicker_popup.gif"
    style="cursor: pointer; padding-left: 4px; vertical-align: middle;" border="0" runat="server" />
