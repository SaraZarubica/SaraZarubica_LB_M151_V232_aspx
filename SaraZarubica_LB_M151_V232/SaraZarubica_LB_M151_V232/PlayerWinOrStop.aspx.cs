using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaraZarubica_LB_M151_V232
{
    public partial class PlayerWinOrStop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWinOrStop.Text = Request.QueryString["winOrStop"];
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (validateName() == null)
            {
                Response.Redirect("~/PlayerHighScoreList.aspx");
            }

            txtBoxError.Visible = true;
            txtBoxError.Text = validateName();
        }

        private string validateName()
        {
            string errorMessage = null;
            if (txtBoxHName.Text == "")
            {
                errorMessage = "Geben Sie Ihren Namen ein.";
            }
            return errorMessage;
        }
    }
}