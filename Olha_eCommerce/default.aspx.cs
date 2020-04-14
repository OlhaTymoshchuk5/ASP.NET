using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

namespace Olha_eCommerce
{
    public partial class _default : System.Web.UI.Page
    {

        //global variable public means we can use it everywhere
        public static string webSiteData = HttpContext.Current.Server.MapPath(".") + @"\Data\Products";
        
        //arrays for catalog, static helps to access them
      
        //public static string[] countFiles;
        public static string[] pics;
        public static string[] descrip;
        public static string[] price;
        
        //array type integer with certain size (100 elements);cannot have more that 100
        public static int[] cartInfo = new int[100];

        //global variable
        public static int numItems = 0;
        //global array
        public static string[] qty = new string[100];

        //to add data to sales table
        public static int customerID;
        public static int[] productID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //here we say how big the array should be
                resetArrays();
            }
        }
        protected void btnPromo_Click(object sender, EventArgs e)
        {
            MyFrame.Attributes.Add("src", "PromoPage.aspx");
        }

        protected void btnCatalog_Click(object sender, EventArgs e)
        {
            MyFrame.Attributes.Add("src", "Catalog.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            MyFrame.Attributes.Add("src", "Cart.aspx");
        }

        protected void btnWeather_Click(object sender, EventArgs e)
        {
            MyFrame.Attributes.Add("src", "https://www.theweathernetwork.com/ca/weather/ontario/london");
        }

        protected void btnCustomers_Click(object sender, EventArgs e)
        {
            MyFrame.Attributes.Add("src", "Customers.aspx");
        }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            MyFrame.Attributes.Add("src", "Products.aspx");
        }
        //C# method how many elements in the database
        public static void resetArrays()
        {
            //loads up the list of all product files
            //countFiles = Directory.GetFiles(webSiteData, "*.*");
            
            //sql query to get the number of files
            string dbConnect = @"integrated security = True; data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";

            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "SELECT COUNT(*) FROM Products";

            cmd = new SqlCommand(query, connectCmd);
            int countRows = Convert.ToInt32(cmd.ExecuteScalar());
           
            //how many we have
            pics = new string[countRows];
            descrip = new string[countRows];
            price = new string[countRows];

            //do index number 1
            for(int i = 0; i < countRows; i++)
            {
                qty[i] = "1";
            }

            customerID = 0;
            productID = new int[countRows];
        }

        protected void btnSalesReport_Click(object sender, EventArgs e)
        {
            MyFrame.Attributes.Add("src", "SalesReport.aspx");
        }
    }
}