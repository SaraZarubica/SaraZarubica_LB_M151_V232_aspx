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
        public const int minCountQuestions = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["PlayedPoints"] = null;
            Session["PlayedQuestions"] = null;
            Session["QuestionsAnswered"] = null;
            Session["StartTime"] = null;
            Session["Joker5050"] = null;
            Session["HighscoreId"] = null;

            if (!Page.IsPostBack)
            {
                setView();
            }
        }

        public void setView()
        {
            int minQuestionPerCategory = 1;
            CategoryRepository cRep = new CategoryRepository();
            var categories = cRep.GetAllCategories();
            lboxC.Items.Clear();
            foreach (Category ci in categories)
            {
                if (cRep.CountQuestionFromCategory(ci.Id) >= minQuestionPerCategory)
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
                item.Text = "Keine Kategorien hat genügend Fragen!, Admin benachrichtigen";
                item.Value = (-1).ToString();
                lboxC.Items.Add(item);
            }
        }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            int questionsCount = 0;
            List<int> selectedCats = new List<int>();
            foreach(ListItem item in lboxC.Items)
            {
                if (item.Selected)
                {
                    int id = Convert.ToInt32(item.Value);
                    if (id > 0)
                    {
                        selectedCats.Add(id);
                        CategoryRepository cRep = new CategoryRepository();
                        questionsCount += cRep.CountQuestionFromCategory(id);
                    }
                }
            }
            if (selectedCats.Count() > 0)
            {
                if(questionsCount >= minCountQuestions)
                {
                    string ids = string.Join(",", selectedCats.Select(n => n.ToString()).ToArray());
                    Response.Redirect("~/Game.aspx?cIds=" + ids);
                }
                else
                {
                    txtBoxError.Visible = true;
                    txtBoxError.Text =
                        "Die gewählte Kategorie/en hat nicht genügend Fragen. " +
                        "Wählen sie noch zusätzliche Kategorien an, oder " +
                        "informieren Sie den Admin.";
                }
            }
            else
            {
                txtBoxError.Visible = true;
                txtBoxError.Text = "Sie müssen mindestens Eine Kategorie auswählen.";
            }
        }
    }
}