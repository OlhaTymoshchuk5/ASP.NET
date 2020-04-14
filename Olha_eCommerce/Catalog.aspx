<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Olha_eCommerce.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalog of products</title>
    <link href="Styles/catalog.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Oswald&display=swap" rel="stylesheet" />
    <style type="text/css">
        .TableStyle {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="tblCatalog" CssClass="TableStyle" runat="server" Height="400px" Width="898px" BackColor="#ffffff" BorderColor="#00FFCC" BorderStyle="Dashed"></asp:Table>
        <asp:Button ID="btnTemplate" runat="server" Text="Button"  Visible="False" OnClick="btnTemplate_Click" />
        <br />
        <asp:Label ID="lblRowSelected" CssClass="Labels" runat="server" Text="...select a button" ForeColor="#0033CC"></asp:Label>
    </form>
</body>
</html>
