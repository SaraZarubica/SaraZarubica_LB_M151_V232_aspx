using BusinessLayer.Repositories;
using DataLayer.Entities;
using SaraZarubica_LB_M151_V232.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaraZarubica_LB_M151_V232
{
    public partial class Game : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Joker5050"] != null)
            {
                btn50Joker.Enabled = false;
            }
            if (Session["StartTime"] == null)
            {
                Session["StartTime"] = DateTime.Now;
            }

            if (!Page.IsPostBack) // first load.
            {
                int cid = getCid();
                List<int> playedQuestions = getPlayedQuestions();
                if (playedQuestions == null)
                {
                    Session["PlayedQuestions"] = new List<int>();
                }
                setView();
            }
        }
        public void setView()
        {
            QuestionRepository qRep = new QuestionRepository();
            int questionsSize = qRep.GetQuestionsSize();
            List<int> playedQuestions = getPlayedQuestions();
            //TODO prüfen
            if (questionsSize == playedQuestions.Count)
            {
                SetHighScore();
                string win = "Sie haben 1 Mio. gewonnen!";
                Response.Redirect("~/PlayerWinOrStop.aspx?winOrStop=" + win);
            }
            List<Question> qList = qRep.GetQuestionsFromCategory(getCid(), playedQuestions);
            Question q = getRandomQuestion(qList);
            hiddenQId.Value = q.Id.ToString();
            lblATrue.Text = q.CorrectCount.ToString();
            playedQuestions.Add(q.Id);
            setQuestionsAndAnswersToView(q);
            Session["PlayedQuestions"] = playedQuestions; ; //
        }
        private Question getRandomQuestion(List<Question> qList)
        {
            if (qList.Count > 0)
            {
                Random rnd = new Random();
                int minQId = 0;
                int maxQId = qList.Count;
                int randomQId = rnd.Next(minQId, (maxQId - 1));
                Question q = qList[randomQId];
                return q;
            }
            else
            {
                Response.Redirect("~/Error.aspx?msg=ichbinsara");
                // sollte nie soweit kommen. Categorie muss mindesten 15 fragen haben
            }
            throw new NotImplementedException();
        }

        private void setQuestionsAndAnswersToView(Question q)
        {
            lblQ.Text = q.QuestionText;
            List<Answer> answers = q.Answers;
            answers.Shuffle();
            
            btnA1.Text = answers[0].AnswerText;
            btnA1.Attributes.Add("answerId", answers[0].Id.ToString());

            btnA2.Text = answers[1].AnswerText;
            btnA2.Attributes.Add("answerId", answers[1].Id.ToString());

            btnA3.Text = answers[2].AnswerText;
            btnA3.Attributes.Add("answerId", answers[2].Id.ToString());

            btnA4.Text = answers[3].AnswerText;
            btnA4.Attributes.Add("answerId", answers[3].Id.ToString());

            lblPoints.Text = GetPoints().ToString();

        }


        protected void btnA1_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            if (isAnswerCorrect(btnA1, aRep))
            {
                btnA1.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }else
            {
                btnA1.BackColor = System.Drawing.Color.Red;
                refreshAfterSecondsWhenLost();
            }
        }

        protected void btnA2_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            if (isAnswerCorrect(btnA2, aRep))
            {
                btnA2.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }
            else
            {
                btnA1.BackColor = System.Drawing.Color.Red;
                refreshAfterSecondsWhenLost();
            }
        }

        protected void btnA3_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            if (isAnswerCorrect(btnA3, aRep))
            {
                btnA3.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }
            else
            {
                btnA1.BackColor = System.Drawing.Color.Red;
                refreshAfterSecondsWhenLost();
            }
        }

        protected void btnA4_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            if (isAnswerCorrect(btnA4, aRep))
            {
                btnA4.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }
            else
            {   
                btnA1.BackColor = System.Drawing.Color.Red;
                refreshAfterSecondsWhenLost();
            }
        }

        private void refreshAfterSeconds(int sec = 2)
        {
            Response.AppendHeader("Refresh", sec + ";url=Game.aspx?cId=" + getCid()); //komishes ~ ?
        }

        private void refreshAfterSecondsWhenLost(int sec = 2)
        {
            SetPoints();
            Session["StartTime"] = null; //warum null?
            Response.AppendHeader("Refresh", sec + ";url=PlayerLost?"); //komishes ~ ?
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            SetHighScore();
            Session["StartTime"] = null;
            string stop = "Sie haben ihren Gewinn mit nach Hause genommen!";
            Response.Redirect("~/PlayerWinOrStop.aspx?winOrStop=" + stop);
        }

        private void SetHighScore()
        {
            Highscore score = new Highscore();
            score.CategoryId = getCid();
            score.GameDuration = (DateTime.Now - ((DateTime)Session["StartTime"])).Seconds;
            score.Points = GetPoints();
        }

        protected void btn50Joker_Click(object sender, EventArgs e)
        {
            Session["Joker5050"] = true;
            btn50Joker.Enabled = false;
            set5050Answers();
        }

        private bool isAnswerCorrect(Button btn, AnswerRepository aRep)
        {
            bool correct = aRep.checkAnswer(Convert.ToInt32(btn.Attributes["answerId"]));
            if (correct) SetPoints();
            CountQuestionStatisticsOneUp(correct);
            return correct;
        }

        private void SetPoints()
        {
            if(Session["PlayedPoints"] == null)
            {
                Session["PlayedPoints"] = 30;
            }
            else
            {
                Session["PlayedPoints"] = GetPoints() + 30;
            }
        }

        private int GetPoints() //Gewinn abfangen
        {
            if (Session["PlayedPoints"] != null)
            {
               return (int)Session["PlayedPoints"];
            }
            return 0;
        }
        private void CountQuestionStatisticsOneUp(bool correct)
        {
            QuestionRepository qRep = new QuestionRepository();
             qRep.SetQuestionStatisticsOneUp(correct, Convert.ToInt32(hiddenQId.Value));
        }

        private List<int> getPlayedQuestions()
        {
            if(Session["PlayedQuestions"] != null)
            {
                return Session["PlayedQuestions"] as List<int>;
            }
            return null;
        }

        private int getCid()
        {
            string strId = Request.QueryString["cId"];
            if (string.IsNullOrEmpty(strId))
            {
                Response.Redirect("~/PlayerChooseCategory.aspx");
            }
            return Convert.ToInt32(strId);
        }
        
        private void set5050Answers()
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(btnA1);
            buttons.Add(btnA2);
            buttons.Add(btnA3);
            buttons.Add(btnA4);

            int buttonListCount = 4;
            AnswerRepository aRep = new AnswerRepository();
            for (int i = 0; 0 < buttonListCount; i++)
            {
                if(isAnswerCorrect(buttons[i], aRep))
                {
                    buttons.Remove(buttons[i]);
                    buttonListCount = 0;
                }
            }

            buttons.Shuffle();

            buttons[1].Visible = false;
            buttons[2].Visible = false;

        }
    }
}
