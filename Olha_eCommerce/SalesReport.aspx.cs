using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Olha_eCommerce
{
    public partial class SalesReport : System.Web.UI.Page
    {
        string dbConnect = @"integrated security = True; data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
    
        protected void Page_Load(object sender, EventArgs e)
        {
            using(SqlConnection sqlConnect = new SqlConnection(dbConnect))
            {
                sqlConnect.Open();
                SqlDataAdapter data = new SqlDataAdapter("SELECT Sales.Sellingprice, Sales.QtySold, Products.Description, Products.ManufactCode, Customers.FirstName, Customers.LastName FROM Sales INNER JOIN Products ON Sales.ProdId = Products.ProductID INNER JOIN Customers ON Sales.CusId = Customers.CustomerID;", sqlConnect);
                DataTable table = new DataTable();
                data.Fill(table);
                tbSalesReport.DataSource = table;
                tbSalesReport.DataBind();
            }
            //SqlConnection connectCmd = null;
            //SqlCommand cmd = null;
            //establishing connection to database
            //connectCmd = new SqlConnection(dbConnect);
            //connectCmd.Open();

            //create a query that will build a table
            //string query = "SELECT Sales.Sellingprice, Sales.QtySold, Products.Description, Products.ManufactCode, Customers.FirstName, Customers.LastName FROM Sales INNER JOIN Products ON Sales.ProdId = Products.ProductID INNER JOIN Customers ON Sales.CusId = Customers.CustomerID;";


        }

        
    }
}