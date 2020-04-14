<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Olha_eCommerce.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My cart</title>
    <link href="Styles/Cart.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="tblCart" CssClass="CellStyle" Height="123" runat="server" Width="567" BackColor="#CCFFCC" BorderStyle="Dotted"></asp:Table>
        <asp:Button ID="btnTemplateRemove" runat="server" Text="Button" style="visibility:hidden"/>
        <br />
        <br />
        <asp:Label ID="lblRowSelected" CssClass="Labels" runat="server" Text="...Select a button" ForeColor="#FF0066"></asp:Label>
        <br />
        <asp:Label ID="lblTotal" CssClass="LabelTotal" runat="server" Text="0.00" ForeColor="#FF0066"></asp:Label>
        <asp:Button ID="btnRecalculate" runat="server" Text="Recalculate Total" />
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" />
    </form>
</body>
</html>
