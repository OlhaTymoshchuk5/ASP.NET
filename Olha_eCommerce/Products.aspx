<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Olha_eCommerce.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Labels {
            position: absolute;
        }
        .newStyle1 {
            position: fixed;
        }
        .Textboxes {
            position: fixed;
        }
        .ListBoxes {
            position: relative;
        }
        .Images {
            position: relative;
        }
        .newStyle2 {
            position: fixed;
        }
        .newStyle3 {
            position: absolute;
        }
        .newStyle4 {
            position: absolute;
        }
        .MessageLabels {
            position: absolute;
        }
        .Buttons {
            position: absolute;
        }
        .newStyle5 {
            position: fixed;
        }
        .newStyle6 {
            position: absolute;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panMain" CssClass="MainPanel" style="left:10px; top:10px; right:10px" runat="server" BackColor="#ffffff" BorderColor="#33CC33" BorderStyle="Solid" ForeColor="Black" Height="649px" Width="896px">
            <asp:Label ID="lblProductID" CssClass="Labels" style="left:16px; top:22px" runat="server" Text="Product ID" BorderColor="Black" ForeColor="Black"></asp:Label>
            <asp:TextBox ID="txtProductID" runat="server" CssClass="Textboxes" style="left:128px; top:20px; color:red" Width="163px"></asp:TextBox>
            <asp:Label ID="lblManufact" runat="server" BorderColor="Black" CssClass="Labels" style="left: 19px; top: 60px" Text="Brand"></asp:Label>
            <asp:TextBox ID="txtManufact" runat="server" CssClass="Textboxes" style="left: 130px; top: 64px; width: 200px"></asp:TextBox>
            <asp:Label ID="lblDescription" runat="server" BorderColor="Black" CssClass="newStyle4" style="left: 17px; top: 98px" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="Textboxes" style="left: 129px; top: 99px; width: 200px"></asp:TextBox>
            <asp:Label ID="lblPicture" runat="server" BorderColor="Black" CssClass="Labels" style="left:15px; top:142px; height: 21px;" Text="Picture"></asp:Label>
            <asp:TextBox ID="txtPicture" runat="server" CssClass="Textboxes" style="left:128px; top:144px; width:150px"></asp:TextBox>
            <asp:Label ID="lblQty" runat="server" BorderColor="Black" CssClass="Labels" style="left: 17px; top: 189px; height: 22px;" Text="QOH"></asp:Label>
            <asp:TextBox ID="txtQty" runat="server" CssClass="Textboxes" style="left: 126px; top: 189px; width: 120px"></asp:TextBox>
            <asp:Label ID="lblPrice" runat="server" BorderColor="Black" CssClass="Labels" style="left: 16px; top: 235px" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="Textboxes" style="left: 127px; top: 234px; width: 120px"></asp:TextBox>
            
            <asp:Button ID="btnUpdate" runat="server" CssClass="Buttons"  OnClick="btnUpdate_Click" style="left: 252px; bottom: 226px; border-radius: 12px; height: 49px; width: 100px;" Text="Update" ToolTip="Update the current Product" />
            <asp:Button ID="btnDelete" runat="server" CssClass="Buttons"  OnClick="btnDelete_Click" style="left: 367px; bottom: 226px; border-radius: 12px; height: 51px; width: 95px;" Text="Delete" ToolTip="Delete the current Product" />
            <asp:Button ID="btnFind" runat="server" CssClass="Buttons" OnClick="btnFindCustomer_Click" style="left: 474px; bottom: 228px; border-radius: 12px; height: 48px; width: 77px;" Text="Find" ToolTip="Find the current Product" />
            <asp:Button ID="btnVerify" runat="server" CssClass="Buttons" OnClick="btnVerify_Click" style="left: 564px; bottom: 226px; border-radius: 12px; background-color:#FFB1B1; height: 49px; width: 99px;" Text="Verify?" ToolTip="Verify Deletion" Visible="false" />
            
            <asp:Image ID="imgPictures" runat="server" CssClass="newStyle6" style="left:567px; bottom:481px; height:180px; width:220px" />
            
            <asp:Button ID="btnAdd" runat="server" CssClass="Buttons" OnClick="btnAdd_Click" style="left: 151px; border-radius: 12px; bottom: 225px; height: 51px; width: 86px;" Text="Add" ToolTip="Create a new product" />
            <asp:Label ID="lblMessage" runat="server" CssClass="MessageLabels" style="left: 45px; bottom: 350px; border-radius: 12px; height: 22px;" Text="" Visible="false"></asp:Label>
            <asp:ListBox ID="lstPictures" runat="server" AutoPostBack="True" CssClass="ListBoxes" OnSelectedIndexChanged="lstPictures_SelectedIndexChanged" style="top:22px; left:428px; height:180px"></asp:ListBox>

        </asp:Panel>
            <asp:Button ID="btnNew" runat="server" CssClass="Buttons" OnClick="btnNew_Click" style="left: 34px; border-radius: 12px; bottom: 224px; text-align: center; height: 54px; width: 93px;" Text="New" ToolTip="Clear all Product fields" />
    </form>
</body>
</html>
