using BusinessLayer.Repositories;
using DataLayer.Entities;
using SaraZarubica_LB_M151_V232.Models;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            redirectToLoginIfNecessary();
            HighScoreRepository hRep = new HighScoreRepository();
            List<Highscore> list = hRep.GetAllHighscores();
            CategoryRepository catRep = new CategoryRepository();
            int ranking = 1;
            List<VmHighScoreGvItem> vmList = new List<VmHighScoreGvItem>();
            foreach(var h in list)
            {
                List<int> catIds = h.PlayedCategories.Select(x => x.CategoryId).ToList();
                vmList.Add(ToGvItem(h, catRep.GetCategoriesByIds(catIds), ranking));
                ranking++; 
            }

            gvHighscore.DataSource = vmList;
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
                    string ranking = row.RowIndex.ToString();
                    string id = row.Attributes["hId"];
                    Response.Redirect(String.Format("~/HighscoreEdit.aspx?hId={0}&rank={1}", id, ranking));
                }
            }
        }

        protected void gvHighscore_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                VmHighScoreGvItem h = (VmHighScoreGvItem)e.Row.DataItem;
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

        private VmHighScoreGvItem ToGvItem(Highscore h, List<Category> cs, int ranking)
        {
            VmHighScoreGvItem vm = new VmHighScoreGvItem();
            vm.CategoryName = string.Join(";",cs.Select(x => x.CategoryText));
            vm.GameDuration = h.GameDuration;
            vm.MomentOfGame = h.MomentOfGame;
            vm.Name = h.Name;
            vm.Points = h.Points;
            vm.Rang = ranking;
            vm.Id = h.Id;
            vm.WeightedPoints = h.WeightedPoints;
            return vm;
        }
    }
}