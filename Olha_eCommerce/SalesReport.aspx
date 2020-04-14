<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="Olha_eCommerce.SalesReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Report</title>
    <link href="Styles/salesReport.css" rel="stylesheet" />
    <style type="text/css">
        .CellStyle {}
        .auto-style1 {
            margin-right: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:GridView ID="tbSalesReport" runat="server" CssClass="auto-style1" Height="379px" Width="1064px" AutoGenerateColumns="false" BorderColor="White">
            <Columns>
                <asp:BoundField DataField="Sellingprice" HeaderText="Selling Price" ItemStyle-BackColor="#CCFFFF" HeaderStyle-BackColor="#66CCFF" />
                <asp:BoundField DataField="QtySold" HeaderText="Quantity Sold" ItemStyle-BackColor="#CCFFFF" HeaderStyle-BackColor="#66CCFF"/>
                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-BackColor="#CCFFFF" HeaderStyle-BackColor="#66CCFF"/>
                <asp:BoundField DataField="ManufactCode" HeaderText="Manufacture Code" ItemStyle-BackColor="#CCFFFF" HeaderStyle-BackColor="#66CCFF"/>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-BackColor="#CCFFFF" HeaderStyle-BackColor="#66CCFF"/>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-BackColor="#CCFFFF" HeaderStyle-BackColor="#66CCFF"/>
            </Columns>
        </asp:GridView>


    </form>
</body>
</html>
