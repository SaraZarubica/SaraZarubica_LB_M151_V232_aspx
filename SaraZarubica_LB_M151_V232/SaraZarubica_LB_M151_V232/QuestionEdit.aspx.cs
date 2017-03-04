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
    public partial class QuestionEdit : System.Web.UI.Page
    {
        private int? qId;
        protected void Page_Load(object sender, EventArgs e)
        {
            redirectToLoginIfNecessary();
            string strId = Request.QueryString["qId"];
            if (!string.IsNullOrEmpty(strId)) // existiert schon
            {
                 qId = Convert.ToInt32(strId);
            }

            if (!Page.IsPostBack) // first load.
            {
              if(qId != null)
                { 
                    loadAndSetQuestion(qId.Value);
                }
                else // neue frage
                {
                    setView(null, null);
                }
            }
        }



        protected void setView(Question q, Category c)
        {
            CategoryRepository cRep = new CategoryRepository();
            var categories = cRep.GetAllCategories();

            foreach(Category ci in categories)
            {
                ListItem item = new ListItem();
                item.Text = ci.CategoryText;
                item.Value = ci.Id.ToString();
                ddListCategories.Items.Add(item);
            }

            if (q != null && c != null) {
                btnDelete.Visible = true;
                ddListCategories.SelectedValue = c.Id.ToString();
                hiddenQId.Value = q.Id.ToString();
                txtBoxQ.Text = q.QuestionText;

                txtBoxA1.Text = q.Answers[0].AnswerText;
                ddA1.SelectedValue = boolToString(q.Answers[0].Correctness);
                hiddenA1.Value = q.Answers[0].Id.ToString();

                txtBoxA2.Text = q.Answers[1].AnswerText;
                ddA2.SelectedValue = boolToString(q.Answers[1].Correctness);
                hiddenA2.Value = q.Answers[1].Id.ToString();

                txtBoxA3.Text = q.Answers[2].AnswerText;
                ddA3.SelectedValue = boolToString(q.Answers[2].Correctness);
                hiddenA3.Value = q.Answers[2].Id.ToString();

                txtBoxA4.Text = q.Answers[3].AnswerText;
                ddA4.SelectedValue = boolToString(q.Answers[3].Correctness);
                hiddenA4.Value = q.Answers[3].Id.ToString();


            }
        }


        protected void loadAndSetQuestion(int id)
        {
            QuestionRepository qRep = new QuestionRepository();
            Question q = qRep.getQuestionById(id);
            Category c = q.Category;
            setView(q, c);
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            QuestionRepository qRep = new QuestionRepository();

            Question q = getQuestionFromView();
            List<Answer> listAnswer = getAnwersFromView();

            qRep.Save(q);
            listAnswer.ForEach(x => {
                x.QuestionId = q.Id;
                x.UserId = getUserId();
                });
            aRep.Save(listAnswer);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            QuestionRepository qRep = new QuestionRepository();
            
            
            
            
            
        }

        private Question getQuestionFromView()
        {
            Question q = new Question();
            q.Id = toInt(hiddenQId.Value);
            q.QuestionText = txtBoxQ.Text;
            q.CategoryId = toInt(ddListCategories.SelectedValue);
            q.UserId = getUserId();
            return q;
        }

        private List<Answer> getAnwersFromView()
        {
            Answer a1 = new Answer();
            a1.Id = toInt(hiddenA1.Value);
            a1.AnswerText = txtBoxA1.Text;
            a1.QuestionId = toInt(hiddenQId.Value);
            a1.Correctness = stringToBool(ddA1.SelectedValue);

            Answer a2 = new Answer();
            a2.Id = toInt(hiddenA2.Value);
            a2.AnswerText = txtBoxA2.Text;
            a2.QuestionId = toInt(hiddenQId.Value);
            a2.Correctness = stringToBool(ddA2.SelectedValue);

            Answer a3 = new Answer();
            a3.Id = toInt(hiddenA3.Value);
            a3.AnswerText = txtBoxA3.Text;
            a3.QuestionId = toInt(hiddenQId.Value);
            a3.Correctness = stringToBool(ddA3.SelectedValue);

            Answer a4 = new Answer();
            a4.Id = toInt(hiddenA4.Value);
            a4.AnswerText = txtBoxA4.Text;
            a4.QuestionId = toInt(hiddenQId.Value);
            a4.Correctness = stringToBool(ddA4.SelectedValue);

            List<Answer> answers = new List<Answer>();
            answers.Add(a1);
            answers.Add(a2);
            answers.Add(a3);
            answers.Add(a4);

            return answers;
        }

        private void validateQuestion(Question q)
        {
            if(q.CategoryId < 1)
            {
                txtBoxError.Text += "Kategorie wählen";
                txtBoxError.Visible = true;
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

        private bool stringToBool(string val)
        {
            return val == "1" ? true : false;
        }

        private string boolToString(bool val)
        {
            return val ? "1" : "0";
        }

    }
}