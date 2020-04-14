<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Olha_eCommerce._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hairproducts eCommerce</title>
    <link href="Styles/default.css" rel="stylesheet" />
    <style type="text/css">
        #form1 {
            height: 661px;
            width: 1378px;
            margin-left: 309px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panMain" runat="server" BorderStyle="Solid" BorderWidth="1" Font-Names="Arial" Font-Size="X-Large" BackColor="#d4f7be" BorderColor="#a1ed71" CssClass="MainPanel" ForeColor="Black" Height="670px" Width="300px">Olha eCommerce
            <asp:Button ID="btnPromo" runat="server" style="top:57px; left:80px" Text="Promotions" CssClass="Buttons" OnClick="btnPromo_Click" />
            <asp:Button ID="btnCatalog" runat="server" style="top:131px; left:80px" Text="Catalog" CssClass="Buttons" OnClick="btnCatalog_Click" />
            <asp:Button ID="btnCart" runat="server" style="top:206px; left:81px" Text="Cart" CssClass="Buttons" OnClick="btnCart_Click" />
            <asp:Button ID="btnWeather" runat="server" style="top:289px; left:78px" Text="Weather Page" CssClass="Buttons" OnClick="btnWeather_Click" />
            <asp:Button ID="btnCustomers" runat="server" style="top:371px; left:77px" Text="Customers" CssClass="Buttons" OnClick="btnCustomers_Click" />
            <asp:Button ID="btnProducts" runat="server" style="top:451px; left:77px" Text="Products" CssClass="Buttons" OnClick="btnProducts_Click" />
            <asp:Button ID="btnSalesReport" runat="server" style="top:531px; left:77px" Text="Sales Report" CssClass="Buttons" OnClick="btnSalesReport_Click" />
        </asp:Panel>
        <iframe id="MyFrame" class="MainFrame" src="" runat="server">
        </iframe>
    </form>
</body>
</html>
