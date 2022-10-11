using NeoWorld.Control;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeoWorld.shop
{
    public partial class shoppingList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string test = (string)Session["UserId"];
            testloginid.Text = test;
        }
    }
}