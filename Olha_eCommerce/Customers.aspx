<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Olha_eCommerce.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Maintenance</title>
    <link href="Styles/customers.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panMain" CssClass="MainPanel" runat="server">
            <asp:Label ID="lblCustomerID" runat="server" CssClass="Labels" style="left:10px; top:20px;" Text="Customer ID"></asp:Label>
            <asp:TextBox ID="txtCustomerID" CssClass="Textboxes" style="left:135px; top:20px; width:111px; color:red" runat="server"></asp:TextBox>
         
            <asp:Label ID="lblFirst" runat="server" CssClass="Labels" style="left:10px; top:50px;" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFirst" CssClass="Textboxes" style="left:135px; top:50px; width:200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblLast" runat="server" CssClass="Labels" style="left:10px; top:80px;" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLast" CssClass="Textboxes" style="left:136px; top:81px; width:200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblAddress" runat="server" CssClass="Labels" style="left:10px; top:110px;" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" CssClass="Textboxes" style="left:135px; top:111px; width:200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblCity" runat="server" CssClass="Labels" style="left:10px; top:140px;" Text="City"></asp:Label>
            <asp:TextBox ID="txtCity" CssClass="Textboxes" style="left:134px; top:140px; width:120px" runat="server"></asp:TextBox>

           <asp:Label ID="lblProvince" runat="server" CssClass="Labels" style="left:10px; top:170px;" Text="Province"></asp:Label>
           <asp:TextBox ID="txtProvince" CssClass="Textboxes" style="left:135px; top:170px; width:100px" runat="server"></asp:TextBox>
        

            <asp:Label ID="lblPostal" runat="server" CssClass="Labels" style="left:10px; top:200px;" Text="Postal Code"></asp:Label>

            <asp:Button ID="btnNew" CssClass="Buttons" style="left:10px; bottom:10px" runat="server" Text="New" OnClick="btnNew_Click" />
            <asp:Button ID="btnAdd" CssClass="Buttons" style="left:150px; bottom:10px" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" CssClass="Buttons" style="left:290px; bottom:10px"  runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" CssClass="Buttons" style="left:430px; bottom:10px"  runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnFind" CssClass="Buttons" style="left:570px; bottom:10px" runat="server" Text="Find" OnClick="btnFind_Click" />

            <asp:TextBox ID="txtPostal" runat="server" CssClass="Textboxes" style="left:134px; top:200px; width:60px"></asp:TextBox>
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>

        </asp:Panel> 

    </form>
</body>
</html>
