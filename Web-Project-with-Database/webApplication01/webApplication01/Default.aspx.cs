using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webApplication01
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if(Request.Cookies["userName"] ==null)
            //    Response.Redirect("~/LogIn.aspx", true);
            // or
            //HttpCookie reqCookies = Request.Cookies["cookieName"];
            //if (reqCookies == null)
            //    Response.Redirect("~/LogIn.aspx", true);
            //else
            //   reqCookies["UserName"].ToString();
            
            //session
            if (Session["UserName"]==null)
                   Response.Redirect("~/LogIn.aspx", true);

            //message
            lblMessage.Text = "LogIn Successfully";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}