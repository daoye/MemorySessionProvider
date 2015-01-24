using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string val = this.txtVal.Text.Trim();
            if (string.IsNullOrEmpty(val))
            {
                val = "You have not set session value.";
            }

            Session["test"] = val;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx");
        }
    }
}