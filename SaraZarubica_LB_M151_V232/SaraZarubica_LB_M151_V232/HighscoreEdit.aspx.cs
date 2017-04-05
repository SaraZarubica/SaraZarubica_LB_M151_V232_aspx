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
    public partial class HighscoreEdit : System.Web.UI.Page
    {
        private int? hId;
        protected void Page_Load(object sender, EventArgs e)
        {
            redirectToLoginIfNecessary();

            if (!Page.IsPostBack) // first load.
            {
                string strId = Request.QueryString["hId"];
                if (!string.IsNullOrEmpty(strId)) // existiert schon
                {
                    int hId = Convert.ToInt32(strId);
                    loadAndSetHighscore(hId);
                }
                else // sollte nicht gehen (Neuer Highscore)
                {
                    setView(null);
                }
            }
        }
        protected void setView(Highscore h)
        {
            if (h != null)
            {
                lblRank.Text = getRanking().ToString();
                lblWeightedPoints.Text = h.WeightedPoints.ToString();
                lblName.Text = h.Name;
                lblMomentOfGame.Text = h.MomentOfGame.ToString();
                lblPoints.Text = h.Points.ToString();
                lblDurationGame.Text = h.GameDuration.ToString() + " Sekunden";
                CategoryRepository catRep = new CategoryRepository();
                for (int i = 0; i < h.PlayedCategories.Count; i++)
                {
                    Category cat = catRep.getCategoryById(h.PlayedCategories[i].CategoryId);
                    lblCategories.Text += cat.CategoryText;
                }
            }
        }
        protected void loadAndSetHighscore(int id)
        {
            HighScoreRepository hRep = new HighScoreRepository();
            Highscore h = hRep.getHighscoreById(id);
            setView(h);
        }

        private int toInt(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return Convert.ToInt32(str);
            }
            return -1;
        }

        private void redirectToLoginIfNecessary()
        {
            if (getUserId() < 1)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private int getUserId()
        {
            string userId = Session["UserId"]?.ToString();
            if (!string.IsNullOrEmpty(userId))
            {
                return toInt(userId);
            }
            else { return -1; }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            HighScoreRepository hRep = new HighScoreRepository();
            string strId = Request.QueryString["hId"];
            if (!string.IsNullOrEmpty(strId)) // existiert schon
            {
                hId = Convert.ToInt32(strId);
            }
            hRep.Delete(hId.Value);

            Response.Redirect("~/HighscoreList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HighscoreList.aspx");
        }

        private int getRanking()
        {
            string strRank = Request.QueryString["rank"];
            int ranking = Convert.ToInt32(strRank) + 1;
            return ranking;
        }
    }
}