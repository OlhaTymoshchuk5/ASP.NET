using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Olha_eCommerce
{
    public partial class Cart : System.Web.UI.Page
    {
        string dbConnect = @"integrated security = True; data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = _default.pics[0];
            btnRecalculate.Click += new EventHandler(btnRecalculate_Click);
            btnCheckout.Click += new EventHandler(LoadCheckoutPage);
            createCartGrid();
            recalculateTotal();
        }

        protected void btnTemplateRemove_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string id = b.ID;

            string[] idParts = id.Split('_');

            int row = int.Parse(idParts[1]);
            lblRowSelected.Text = "You selected row " + row;

            _default.qty[_default.cartInfo[row]] = "1";

            for (int i = row; i < _default.numItems; i++)
            {
                _default.cartInfo[i] = _default.cartInfo[i + 1];
            }

            _default.numItems--;

            createCartGrid();
            recalculateTotal();
        }

        protected void btnRecalculate_Click(object sender, EventArgs e)
        {
            recalculateTotal();
        }

        private void createCartGrid()
        {
            //clear the table
            tblCart.Rows.Clear();

            for(int i = 0; i < _default.numItems; i++)
            {
                TableRow row = new TableRow();
                for(int y = 0; y < 5; y++)
                {
                    TableCell cell = new TableCell();

                    if (y == 0)
                    {
                        Image image = new Image();
                        image.ImageUrl = _default.pics[_default.cartInfo[i]];
                        image.Height = 200;
                        image.Width = 200;
                        cell.Controls.Add(image);
                    }
                    else if (y == 1)
                    {
                        Label label = new Label();
                        label.Text = _default.descrip[_default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        cell.Controls.Add(label);
                    }
                    else if (y == 2)
                    {
                        Label label = new Label();
                        label.Text = _default.price[_default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        cell.Controls.Add(label);
                    }
                    else if (y == 3)
                    {
                        Button btnRemoveFromCart = new Button();
                        btnRemoveFromCart.ID = "btnSelect_" + i + "_" + y;
                        btnRemoveFromCart.Click += new EventHandler(btnTemplateRemove_Click);
                        btnRemoveFromCart.Text = "Remove";
                        cell.Controls.Add(btnRemoveFromCart);
                    }
                    else if (y == 4)
                    {
                        TextBox text = new TextBox();
                        text.Text = _default.qty[_default.cartInfo[i]];
                        text.Style["font-family"] = "helvetica";
                        text.Style["color"] = "blue";
                        text.Style["background-color"] = "white";
                        text.Style["width"] = "20px";
                        text.Style["border"] = "solid 1px #002594";
                        cell.Controls.Add(text);
                    }
                    
                    row.Cells.Add(cell);
                }
                tblCart.Rows.Add(row);
            }

        }

        private void recalculateTotal()
        {
            decimal total = 0;

            for (int i = 0; i < _default.numItems; i++)
            {
                TableRow row = tblCart.Rows[i];
                decimal rowPrice = 0;

                for (int j = 0; j < 5; j++)
                {
                    TableCell cell = row.Cells[j];
                    if (j == 2)
                    {
                        Control ctrl = cell.Controls[0];
                        Label lbl = (Label)ctrl;
                        string price = lbl.Text;
                        rowPrice = decimal.Parse(price);
                    }
                    else if (j == 4)
                    {
                        Control ctrl = cell.Controls[0];
                        TextBox txt = (TextBox)ctrl;
                        //txt.Text = "0";
                        string qty = txt.Text;
                        _default.qty[_default.cartInfo[i]] = qty;
                        decimal rowTotal = rowPrice * int.Parse(qty);
                        total += rowTotal;
                    }
                }
            }
            lblTotal.Text = total.ToString("$##,##0.##");
        }
        protected void LoadCheckoutPage(object sender, EventArgs e)
        {
            //server.transver ---> to replace the current page with a new page
            Server.Transfer("Checkout.aspx");
        }

    }
}