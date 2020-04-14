using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;

namespace Olha_eCommerce
{
    public partial class Catalog : System.Web.UI.Page
    {
        string dbConnect = @"integrated security = True; data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        private object txtDescription;

        //it will every time we start the page it'll load the catalog
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            try
            {
                // create a new data set object called ds
                ds = new DataSet();
                // create a connection to the database called connectFill
                connectCmd = new SqlConnection(dbConnect);

                // create SQL string to select customer record
                string sqlString = "SELECT * FROM Products";

                // create new SQL command object based on SQL string and connection
                cmd = new SqlCommand(sqlString, connectCmd);

                // create a new SQL data adapter to retrieve the data and
                // will the data set
                sqlDataAdapter = new SqlDataAdapter();
                //extention property, command to select 
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                //lblMessage.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectCmd, ref cmd);
                return;
            }

            //iterate through all the products in dataset and display in the table

        if(ds.Tables["Products"].Rows.Count > 0)
            {
                //constructor
                
                for(int i = 0; i < ds.Tables["Products"].Rows.Count; i++)
                {
                    //we should add table rows in the loop to have as many rows as loop will iterate. if we put it outside the loop it will print only once
                    TableRow row = new TableRow();
                    //create new cells

                    for (int j = 0; j < 4; j++)
                    {
                        TableCell cell = new TableCell();
                        if (j == 0)
                        {
                            Image image = new Image();
                            image.ImageUrl = "Images/" + ds.Tables["Products"].Rows[i]["Picture"].ToString();
                            image.Height = 100;
                            image.Width = 120;
                            _default.pics[i] = image.ImageUrl;
                      
                            _default.productID[i] = Convert.ToInt32(ds.Tables["Products"].Rows[i]["ProductId"]);

                            cell.Controls.Add(image);
                        }
                        else if(j == 1)
                        {
                            Label label = new Label();
                            label.Text = ds.Tables["Products"].Rows[i]["Description"].ToString();
                            _default.descrip[i] = label.Text;
                            cell.Controls.Add(label);
                        }
                        else if(j == 2)
                        {
                            cell.Text = ds.Tables["Products"].Rows[i]["Price"].ToString();
                            _default.price[i] = cell.Text;
                        }
                        else if(j == 3)
                        {
                            Button btnAddToCart = new Button();
                            //we have to split the text or string 
                            btnAddToCart.ID = "btnSelect_" + i + "_" + j; //btnSelect_0_1
                            btnAddToCart.Click += new EventHandler(btnTemplate_Click);
                            btnAddToCart.Text = "Add to Cart";
                            cell.Controls.Add(btnAddToCart);
                        }

                        row.Cells.Add(cell);
                    }
                    tblCatalog.Rows.Add(row);
                }
            }
            
            

            // release all database resources (memory)
         DisposeResources(ref sqlDataAdapter, ref ds, ref connectCmd, ref cmd);
        }

        protected void btnTemplate_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string id = b.ID;

            //change he color of the btn when the user has added the item to the cart
            b.Style["color"] = "gray";
            string[] idParts = id.Split('_');

            //like in JS parseInt
            int rowNum = int.Parse(idParts[1]);
            lblRowSelected.Text = "You selected " + _default.descrip[rowNum];

            if (_default.numItems > 0)
            {
                bool matchRow = false;
                for (int i = 0; i < _default.numItems; i++)
                {
                    if (rowNum == _default.cartInfo[i])
                    {
                        matchRow = true;
                    }
                }

                if (!matchRow)
                {
                    //like we push into array in JS 
                    _default.cartInfo[_default.numItems] = rowNum;
                    //added a new item into the cart
                    _default.numItems++;

                }
            }

            else
            {
                _default.cartInfo[_default.numItems] = rowNum;
                //added a new item into the cart
                _default.numItems++;
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

        
    }
}