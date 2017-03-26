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
    public partial class HighscoreList : System.Web.UI.Page
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            redirectToLoginIfNecessary();
            HighScoreRepository hRep = new HighScoreRepository();
            List<Highscore> list = hRep.GetAllHighscores();
            gvHighscore.DataSource = list;
            gvHighscore.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminStartPage.aspx");
        }

        protected void gvHighscore_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvHighscore.Rows)
            {
                if (row.RowIndex == gvHighscore.SelectedIndex)
                {
                    string id = row.Attributes["hId"];
                    Response.Redirect("HighscoreEdit.aspx?hId=" + id);
                }
            }
        }

        protected void gvHighscore_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Highscore h = (Highscore)e.Row.DataItem;
                e.Row.Attributes["hId"] = h.Id.ToString();
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvHighscore, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
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
        private int toInt(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return Convert.ToInt32(str);
            }
            return -1;
        }
    }
}