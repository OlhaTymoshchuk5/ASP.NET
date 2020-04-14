<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Olha_eCommerce.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link href="Styles/Checkout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <iframe id="CustomerFrame" class="CheckoutFrame" src="Customers.aspx" runat="server" style="left:10px; top:10px"></iframe>
         <iframe id="DetailFrame" class="CheckoutFrame" src="Details.aspx" runat="server" style="left:10px; top:340px"></iframe>
    </form>
</body>
</html>
