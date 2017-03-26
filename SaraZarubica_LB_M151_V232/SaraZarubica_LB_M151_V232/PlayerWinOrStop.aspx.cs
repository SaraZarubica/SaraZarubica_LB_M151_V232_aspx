using BusinessLayer.Repositories;
using DataLayer.Entities;
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
                Highscore h = getHighscore(getHid());
                h.Name = txtBoxHName.Text;
                HighScoreRepository hRep = new HighScoreRepository();
                hRep.Save(h);
                Response.Redirect("~/PlayerHighScoreList.aspx?hId=" + getHid());
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

        private int getHid()
        {
            string strId = Request.QueryString["highscoreId"];
            return Convert.ToInt32(strId);
        }

        protected Highscore getHighscore(int id)
        {
            HighScoreRepository hRep = new HighScoreRepository();
            Highscore h = hRep.getHighscoreById(id);
            return h;
        }
    }
}