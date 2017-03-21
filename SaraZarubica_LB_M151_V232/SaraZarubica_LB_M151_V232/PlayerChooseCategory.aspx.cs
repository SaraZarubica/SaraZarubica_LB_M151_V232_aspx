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
        public const int minCountQuestions = 2;
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
                    ddC.Items.Add(item);
                }
            }

            if (ddC.Items.Count < 1)
            {
                ListItem item = new ListItem();
                item.Text = "Keine Kategorien >= 15 Fragen!, Admin benachrichtigen";
                item.Value = (-1).ToString();
                ddC.Items.Add(item);
            }
        }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            string id = ddC.SelectedValue;
            if (!string.IsNullOrEmpty(id) && Convert.ToInt32(id) > 0)
            {
                Response.Redirect("~/Game.aspx?cId=" + id);
            }
        }
    }
}