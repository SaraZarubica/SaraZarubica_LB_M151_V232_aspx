using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Repositories;
using DataLayer.Entities;

namespace SaraZarubica_LB_M151_V232
{
    public partial class QuestionList : System.Web.UI.Page
    {
        QuestionRepository qRep;
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            qRep = new QuestionRepository();
            userId = 1;//Convert.ToInt32(Session["UserId"]);
            List<Question> list = qRep.GetAllQuestionsFromUserId(userId);
            gvQuestions.DataSource = list;
            gvQuestions.DataBind();

        }

        protected void gvQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvQuestions.Rows)
            {
                if (row.RowIndex == gvQuestions.SelectedIndex)
                {
                    string id = row.Attributes["qId"];
                    Response.Redirect("QuestionEdit.aspx?qId=" + id);
                }
            }
        }

        protected void gvQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Question q = (Question)e.Row.DataItem;
                e.Row.Attributes["qId"] = q.Id.ToString();
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvQuestions, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }
    }
}