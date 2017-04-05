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
    public partial class PlayerHighScoreList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HighScoreRepository hRep = new HighScoreRepository();
            List<Highscore> list = hRep.GetAllHighscores();
            CategoryRepository catRep = new CategoryRepository();
            int ranking = 1;
            List<VmHighScoreGvItem> vmList = new List<VmHighScoreGvItem>();
            foreach (var h in list)
            {
                List<int> catIds = h.PlayedCategories.Select(x => x.CategoryId).ToList();
                vmList.Add(ToGvItem(h, catRep.GetCategoriesByIds(catIds), ranking));
                ranking++;
            }

            gvHighscore.DataSource = vmList;
            gvHighscore.DataBind();
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

        private VmHighScoreGvItem ToGvItem(Highscore h, List<Category> cs, int ranking)
        {
            VmHighScoreGvItem vm = new VmHighScoreGvItem();
            vm.CategoryName = string.Join(";", cs.Select(x => x.CategoryText));
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