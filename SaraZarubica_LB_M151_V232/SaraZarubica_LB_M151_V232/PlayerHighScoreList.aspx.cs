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
    public partial class PlayerHighScoreList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HighScoreRepository hRep = new HighScoreRepository();
            List<Highscore> list = hRep.GetAllHighscores();
            List<Highscore> sortedList = list.OrderBy(x => x.WeightedPoints).ToList();

            gvHighscore.DataSource = sortedList;
            gvHighscore.DataBind();
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
    }
}