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
    public partial class PlayerChooseCategory : System.Web.UI.Page
    {
        public const int minCountQuestions = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            setView();
        }

        public void setView()
        {
            CategoryRepository cRep = new CategoryRepository();
            var categories = cRep.GetAllCategories();

            foreach (Category ci in categories)
            {
                if (cRep.CountQuestionFromCategory(ci.Id) >= minCountQuestions)
                {
                    ListItem item = new ListItem();
                    item.Text = ci.CategoryText;
                    item.Value = ci.Id.ToString();
                    lboxC.Items.Add(item);
                }
            }

            if (lboxC.Items.Count < 1)
            {
                ListItem item = new ListItem();
                item.Text = "Keine Kategorien >= 15 Fragen!, Admin benachrichtigen";
                item.Value = (-1).ToString();
                lboxC.Items.Add(item);
            }
        }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            List<int> selectedCats = new List<int>();
            foreach(ListItem item in lboxC.Items)
            {
                if (item.Selected)
                {
                    int id = Convert.ToInt32(item.Value);
                    if(id>0) selectedCats.Add(id);
                }
            }
            if (selectedCats.Count() > 0)
            {
                string ids = string.Join(",", selectedCats.Select(n => n.ToString()).ToArray());
                Response.Redirect("~/Game.aspx?cIds=" + ids);
            }
        }
    }
}