<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DataLayerGenerator.aspx.vb" Inherits="CommonLibs.DataLayerGenerator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>OPTIMUS - Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <script src='<%= ResolveUrl("~/Libs/Scripts/jquery/jquery-1.4.3.js")%>' type='text/javascript'></script>
        <script src='<%= ResolveUrl("~/Libs/Scripts/jquery/jquery-1.7.min.js")%>' type='text/javascript'></script>
        <script type="text/javascript">
            $(function () {
                $('#<%=cboTable.ClientID %>').change(function () {
                    setTxtTableNameText();
                });
                $('#<%=cboView.ClientID %>').change(function () {
                    setTxtViewNameText();
                });
                function setTxtTableNameText() {
                    $('#<%=txtTableName.ClientID %>').val($('#<%=cboTable.ClientID %> option:selected').text());
                }
                function setTxtViewNameText() {
                    $('#<%=txtViewName.ClientID %>').val($('#<%=cboView.ClientID %> option:selected').text());
                }

                setTxtTableNameText();
                setTxtViewNameText();
            });
        </script>
        Table
        <asp:DropDownList ID="cboTable" runat="server" />
        <asp:TextBox ID="txtTableName" runat="server" />
        <asp:Button ID="btnGenerate" runat="server" Text="Generate"/>
        <br />
        View
        <asp:DropDownList ID="cboView" runat="server" />
        <asp:TextBox ID="txtViewName" runat="server" />
        <asp:Button ID="btnGenerateView" runat="server" Text="Generate"/>
        <br />

        <table style="width:100%">
            <colgroup>
                <col style="width:50%" />
                <col style="width:50%" />
            </colgroup>
            <tr>
                <td style="vertical-align:top"><div id="divResult" runat="server"></div></td>
                <td style="vertical-align:top"><div id="divBusinessLayer" runat="server"></div></td>
            </tr>
        </table>
        
    </form>
</body>
</html>
