using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Olha_eCommerce
{

    public partial class Products : System.Web.UI.Page
    {
        string dbConnect = @"integrated security = True; data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        string webSitePics = HttpContext.Current.Server.MapPath(".") + @"\Images";
        string webSiteData = HttpContext.Current.Server.MapPath(".") + @"\Data\Products\";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] fileList = Directory.GetFiles(webSitePics, "*.*");
                lstPictures.Items.Clear();

                for (int i = 0; i < fileList.Length; i++)
                {
                    string fileName = Path.GetFileName(fileList[i]);
                    lstPictures.Items.Add(fileName);
                }
            }
        }

        //leave the method
        protected void lstPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgPictures.ImageUrl = "images/" + lstPictures.SelectedItem.Text;
            txtPicture.Text = lstPictures.SelectedItem.Text;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            //method that will clear the fields
            flushData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "INSERT INTO Products(ManufactCode, Description, Picture, Quantity, Price) VALUES(@MfCode, @Desc, @Pic, @Qty, @Price)";

            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@MfCode", txtManufact.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Pic", txtPicture.Text);
                cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);

                //add one row with info that I provide from the form
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            //will get the current id
            string id = "SELECT IDENT_CURRENT('Products') FROM Products";
            cmd = new SqlCommand(id, connectCmd);
            int idValue = Convert.ToInt32(cmd.ExecuteScalar());
            txtProductID.Text = idValue.ToString();
            lblMessage.Text = "Product Value Updated!";

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            //establishing connection to database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "UPDATE Products SET  ManufactCode=@MfCode, Description = @Desc, Picture = @Pic, Quantity=  @Qty, Price =  @Price WHERE ProductID = @Pid ";


             try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@MfCode", txtManufact.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Pic", txtPicture.Text);
                cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Pid", txtProductID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResources(ref connectCmd, ref cmd);
                return;
            }

            string id = "SELECT IDENT_CURRENT('Products') FROM Products";
            cmd = new SqlCommand(id, connectCmd);
            int idValue = Convert.ToInt32(cmd.ExecuteScalar());
            txtProductID.Text = idValue.ToString();
            lblMessage.Text = "Product Value Updated!";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            //establishing connection to database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string sqlString = "DELETE FROM Products WHERE ProductID=@Pid";
            //perform CRUD operation in this case Create and Insert
            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@Pid", txtProductID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResources(ref connectCmd, ref cmd);
                return;
            }


            lblMessage.Text = "Product Value Updated!";
            DisposeResources(ref connectCmd, ref cmd);
        }

        protected void btnFindCustomer_Click(object sender, EventArgs e)
        {

            // create the objects needed for CRUD
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
                string sqlString = "SELECT * FROM Products WHERE ProductID = @Pid";

                // create new SQL command object based on SQL string and connection
                cmd = new SqlCommand(sqlString, connectCmd);

                // add the parameter to SQL string and validate
                cmd.Parameters.AddWithValue("@Pid", txtProductID.Text);

                // create a new SQL data adapter to retrieve the data and
                // will the data set
                sqlDataAdapter = new SqlDataAdapter();
                //extention property, command to select 
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectCmd, ref cmd);
                return;
            }

            // copy over the data fields from the dataset into text boxes
            //we expect only one result
            if (ds.Tables["Products"].Rows.Count == 1)
            {
                //
                txtManufact.Text = ds.Tables["Products"].Rows[0]["ManufactCode"].ToString();
                txtDescription.Text = ds.Tables["Products"].Rows[0]["Description"].ToString();
                txtPicture.Text = ds.Tables["Products"].Rows[0]["Picture"].ToString();
                txtQty.Text = ds.Tables["Products"].Rows[0]["Quantity"].ToString();
                txtPrice.Text = ds.Tables["Products"].Rows[0]["Price"].ToString();

                imgPictures.ImageUrl = "Images/" + txtPicture.Text;

                hideAll();
               
            }
            else
            {
                lblMessage.Text = "Product not found";
            }

            lblMessage.Text = "";

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectCmd, ref cmd);
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            finishDelete();
        }

        private void finishDelete()
        {
            if(File.Exists(webSiteData + txtProductID.Text + ".txt"))
            {
                File.Delete(webSiteData + txtProductID.Text + ".txt");
                flushData();
            }
            btnVerify.Visible = false;
        }

        //method to clear the fields
        private void flushData()
        {
            txtProductID.Text = "";
            txtManufact.Text = "";
            txtDescription.Text = "";
            txtPicture.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
        }

        private void hideAll()
        {
            btnVerify.Visible = false;
            lblMessage.Visible = false;
        }

        private void showMessage(string msg)
        {
            lblMessage.Visible = true;
            lblMessage.Text = msg;
        }

        // **************************************************************
        // method releases all database resources that have been assigned
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