using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Olha_eCommerce
{
    public partial class Customers : System.Web.UI.Page
    {
        string dbConnect = @"integrated security = True; data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            flushData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            //establishing connection to database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "INSERT INTO Customers(FirstName, LastName, Address, City, Province, PostalCode) VALUES (@fn, @ln, @ad, @ct, @pr, @pc) ";
            //perform CRUD operation in this case Create and Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@fn", txtFirst.Text);
                cmd.Parameters.AddWithValue("@ln", txtLast.Text);
                cmd.Parameters.AddWithValue("@ad", txtAddress.Text);
                cmd.Parameters.AddWithValue("@ct", txtCity.Text);
                cmd.Parameters.AddWithValue("@pr", txtProvince.Text);
                cmd.Parameters.AddWithValue("@pc", txtPostal.Text);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResources(ref connectCmd, ref cmd);
                return;
            }

            string id = "SELECT IDENT_CURRENT('Customers') FROM Customers";
            cmd = new SqlCommand(id, connectCmd);
            int idValue = Convert.ToInt32(cmd.ExecuteScalar());
            txtCustomerID.Text = idValue.ToString();
            lblMessage.Text = "New Customer Added!";
            _default.customerID = idValue;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            //establishing connection to database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "UPDATE Customers SET FirstName=@fn, LastName=@ln, Address=@ad, City=@ct, Province=@pr, PostalCode=@pc VALUES (@fn, @ln, @ad, @ct, @pr, @pc) WHERE CustomerId=@cid";
            //perform CRUD operation in this case Create and Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@fn", txtFirst.Text);
                cmd.Parameters.AddWithValue("@ln", txtLast.Text);
                cmd.Parameters.AddWithValue("@ad", txtAddress.Text);
                cmd.Parameters.AddWithValue("@ct", txtCity.Text);
                cmd.Parameters.AddWithValue("@pr", txtProvince.Text);
                cmd.Parameters.AddWithValue("@pc", txtPostal.Text);
                cmd.Parameters.AddWithValue("@cid", txtCustomerID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResources(ref connectCmd, ref cmd);
                return;
            }

            string id = "SELECT IDENT_CURRENT('Customers') FROM Customers";
            cmd = new SqlCommand(id, connectCmd);
            int idValue = Convert.ToInt32(cmd.ExecuteScalar());
            txtCustomerID.Text = idValue.ToString();
            lblMessage.Text = "Customer Value Updated!";
           

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            //establishing connection to database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "DELETE FROM Customers WHERE CustomerId=@cid";
            //perform CRUD operation in this case Create and Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@cid", txtCustomerID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResources(ref connectCmd, ref cmd);
                return;
            }

           
            lblMessage.Text = "Customer Value Updated!";
            DisposeResources(ref connectCmd, ref cmd);
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter dataAdapter = null;
            DataSet ds = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            
            //establishing connection to database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "SELECT * FROM Customers WHERE CustomerId=@cid";

            try
            {
                ds = new DataSet();
                cmd = new SqlCommand(query, connectCmd);

                cmd.Parameters.AddWithValue("@cid", txtCustomerID.Text);
                //create new sql adapter to retrieve data and store it into a data test
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Customers");
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResources(ref connectCmd, ref cmd);
                return;
            }
            if(ds.Tables["Customers"].Rows.Count == 1)
            {
                //fields should match the db
                _default.customerID = Convert.ToInt32((ds.Tables["Customers"].Rows[0]["CustomerId"]));
                txtFirst.Text = ds.Tables["Customers"].Rows[0]["FirstName"].ToString();
                txtLast.Text = ds.Tables["Customers"].Rows[0]["LastName"].ToString();
                txtAddress.Text = ds.Tables["Customers"].Rows[0]["Address"].ToString();
                txtCity.Text = ds.Tables["Customers"].Rows[0]["City"].ToString();
                txtProvince.Text = ds.Tables["Customers"].Rows[0]["Province"].ToString();
                txtPostal.Text = ds.Tables["Customers"].Rows[0]["PostalCode"].ToString();
                
            }
            else
            {
                lblMessage.Text = "Customer Not Found";
            }
            lblMessage.Text = "";
            
        }


        private void flushData()
        {
            txtCustomerID.Text = "";
            txtFirst.Text = "";
            txtLast.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtPostal.Text = "";
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