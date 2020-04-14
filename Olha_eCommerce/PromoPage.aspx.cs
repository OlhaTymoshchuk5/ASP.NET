using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Olha_eCommerce
{
    public partial class PromoPage : System.Web.UI.Page
    {
        string webSitePics = HttpContext.Current.Server.MapPath(".") + @"\Images";
        protected void Page_Load(object sender, EventArgs e)
        {
            
                imgPictures.ImageUrl = "Images/dsdshampoo.jpg";
           
        }
        
        
    }
}