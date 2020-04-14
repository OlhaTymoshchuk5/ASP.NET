using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Olha_eCommerce
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnPay.Click += new EventHandler(PayForOrder);

            CreateDetailGrid();
            CalculateTotal();
        }

        private void CreateDetailGrid()
        {
            TblDetailGrid.Rows.Clear();

            for(int i = 0; i < _default.numItems; i++)
            {
                //create an object
                TableRow row = new TableRow();
                for(int y = 0; y < 3; y++)
                {
                    TableCell cell = new TableCell();
                    if(y == 0)
                    {
                        Label label = new Label();
                        label.Text = _default.descrip[_default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        cell.Controls.Add(label);
                    }
                    else if(y == 1)
                    {
                        Label label = new Label();
                        label.Text = _default.price[_default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        cell.Controls.Add(label);
                    }
                    else if (y == 2)
                    {
                        TextBox text = new TextBox();
                        text.Text = _default.qty[_default.cartInfo[i]];
                        text.Style["font-family"] = "helvetica";
                        text.Style["color"] = "blue";
                        text.Style["background-color"] = "white";
                        text.Style["width"] = "20px";
                        text.Style["border"] = "solid 1px #002594";
                        text.Enabled = false;
                        cell.Controls.Add(text);
                    }
                    row.Cells.Add(cell);
                }
                TblDetailGrid.Rows.Add(row);
            }
        }

        private void CalculateTotal()
        {
            //var type decimal (for money)
            decimal total = 0;

            for(int i = 0; i < _default.numItems; i++)
            {
                //converte string to number decimal.Parse
                decimal rowPrice = Decimal.Parse(_default.price[_default.cartInfo[i]]);
                string qty = _default.qty[_default.cartInfo[i]];
                decimal rowTotal = rowPrice * int.Parse(qty);
                total += rowTotal;

            
            }
            LblTotal.Text = total.ToString("$##,##0.#0");
        }

        //because it is an event heandler we have to create a protected void
        protected void PayForOrder (object sender, EventArgs e)
        {
            string dbConnect = @"integrated security = True; data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";

            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string sqlString = "INSERT INTO Sales(ProdId, CusId, QtySold, SellingPrice, OrderDate) VALUES (@PId, @CId, @QtySold, @SP, @OD)";
            
         
                try
                {
                    for (int i = 0; i < _default.numItems; i++)
                    {
                        cmd = new SqlCommand(sqlString, connectCmd);
                        cmd.Parameters.AddWithValue("@PId", _default.productID[_default.cartInfo[i]]);
                        cmd.Parameters.AddWithValue("@CId", _default.customerID);
                        cmd.Parameters.AddWithValue("@QtySold", _default.qty[_default.cartInfo[i]]);
                        cmd.Parameters.AddWithValue("@SP", _default.price[_default.cartInfo[i]]);
                        cmd.Parameters.AddWithValue("@OD", DateTime.Now.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }
                   
                }
                catch (Exception ex)
                {
                    //lblMessage.Text = ex.Message;
                    DisposeResources(ref connectCmd, ref cmd);
                    return;
                }
            
           
        }
        private static void DisposeResources(ref SqlDataAdapter sqlDataAdapter,
           ref DataSet ds,
           ref SqlConnection connectCmd,
           ref SqlCommand cmd)
        {
            if (sqlDataAdapter != null)
                sqlDataAdapter.Dispose();
            if (ds != null)
                ds.Dispose();
            if (connectCmd != null)
                connectCmd.Dispose();
            if (cmd != null)
                cmd.Dispose();
        }

        private static void DisposeResources(
            ref SqlConnection connectCmd,
            ref SqlCommand cmd)
        {
            if (connectCmd != null)
                connectCmd.Dispose();
            if (cmd != null)
                cmd.Dispose();
        }
    }

}
