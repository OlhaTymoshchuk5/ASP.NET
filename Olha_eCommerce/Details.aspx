<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Olha_eCommerce.details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Details</title>
    <link href="Styles/details.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="TblDetailGrid" CssClass="CellStyle" Height="123px" Width="300px" BorderColor="#ffffcc" BorderStyle="Dashed" runat="server"></asp:Table>
        <br />
        <asp:Label ID="LblTotal" CssClass="LabelTotal" runat="server" Text="0.00" ></asp:Label>
        <asp:CheckBox ID="ChkMailingList" runat="server" CssClass="Checkboxes" Text="Add me to your mailing list" />
              <asp:Button ID="BtnPay" CssClass="Buttons" style="left:10px; bottom:20px; " runat="server" Text="Pay for my order" />
    </form>
</body>
</html>
