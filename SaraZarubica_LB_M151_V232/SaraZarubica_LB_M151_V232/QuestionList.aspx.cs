using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Repositories;
using DataLayer.Entities;
using SaraZarubica_LB_M151_V232.Models;

namespace SaraZarubica_LB_M151_V232
{
    public partial class QuestionList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            redirectToLoginIfNecessary();
            QuestionRepository qRep = new QuestionRepository();
            int userId = getUserId();
            List<Question> list = qRep.GetAllQuestionsFromUserId(userId);

            List<VmQuestionGvItem> vmList = new List<VmQuestionGvItem>();
            foreach (var h in list)
            {
                vmList.Add(ToGvItem(h));
            }

            gvQuestions.DataSource = vmList;
            gvQuestions.DataBind();
        }

        protected void gvQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvQuestions.Rows)
            {
                if (row.RowIndex == gvQuestions.SelectedIndex)
                {
                    string id = row.Attributes["qId"];
                    Response.Redirect("~/QuestionEdit.aspx?qId=" + id);
                }
            }
        }

        protected void gvQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                VmQuestionGvItem q = (VmQuestionGvItem)e.Row.DataItem;
                e.Row.Attributes["qId"] = q.Id.ToString();
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvQuestions, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }
        private int toInt(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return Convert.ToInt32(str);
            }
            return -1;
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
        private void redirectToLoginIfNecessary()
        {
            if (getUserId() < 1)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuestionEdit.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminStartPage.aspx");
        }
        private VmQuestionGvItem ToGvItem(Question h)
        {
            VmQuestionGvItem vm = new VmQuestionGvItem();
            vm.QuestionText = h.QuestionText;
            vm.Id = h.Id;
            vm.CategoryId = h.CategoryId;
            QuestionRepository qRep = new QuestionRepository();
            vm.CategoryText = qRep.getCategoryTextById(h.CategoryId);
            return vm;
        }
    }
}