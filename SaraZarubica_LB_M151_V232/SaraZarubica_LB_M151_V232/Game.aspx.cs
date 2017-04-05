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
        private const int questionsCountGame = 2;
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
                List<int> playedQuestions = getPlayedQuestions();
                if (playedQuestions == null)
                {
                    Session["PlayedQuestions"] = new List<int>();
                }

                int questionsAnswered = getQuestionsAnswered();
                if (questionsAnswered == 0)
                {
                    Session["QuestionsAnswered"] = new Int32();
                }
                setView();
            }
        }
        public void setView()
        {
            QuestionRepository qRep = new QuestionRepository();
            List<int> playedQuestions = getPlayedQuestions();
            int answeredQuestionsCount = getQuestionsAnswered();
            if (answeredQuestionsCount == questionsCountGame)
            {
                string win = "Sie haben 1 Mio. gewonnen!";
                SetHighScore();
                Session["PlayedPoints"] = null;
                Session["PlayedQuestions"] = null;
                Session["QuestionsAnswered"] = null;
                Session["StartTime"] = null;
                Session["Joker5050"] = null;
                Response.Redirect(String.Format("~/PlayerWinOrStop.aspx?winOrStop={0}&highscoreId={1}", win, Session["HighscoreId"].ToString()));
                Session["HighscoreId"] = null;

            }
            List<Question> qList = qRep.GetQuestionsFromCategories(getCids(), playedQuestions);
            Question q = getRandomQuestion(qList);
            hiddenQId.Value = q.Id.ToString();
            if (q.AnsweredCount > 0)
            {
                lblATrue.Text = (((Convert.ToDouble(q.CorrectCount) / Convert.ToDouble(q.AnsweredCount)) * 100) + "%").ToString();
            }
            else
            {
                lblATrue.Text = "Noch nie beantwortet.";
            }
            playedQuestions.Add(q.Id);
            setQuestionsAndAnswersToView(q);
            Session["PlayedQuestions"] = playedQuestions;
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
                Session["QuestionsAnswered"] = getQuestionsAnswered() + 1;
                btnA1.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }else
            {
                btnA1.BackColor = System.Drawing.Color.Red;
                getRightAnswerButton().BackColor = System.Drawing.Color.Green;
                refreshAfterSecondsWhenLost();
            }
        }

        protected void btnA2_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            if (isAnswerCorrect(btnA2, aRep))
            {
                Session["QuestionsAnswered"] = getQuestionsAnswered() + 1;
                btnA2.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }
            else
            {
                btnA2.BackColor = System.Drawing.Color.Red;
                getRightAnswerButton().BackColor = System.Drawing.Color.Green;
                refreshAfterSecondsWhenLost();
            }
        }

        protected void btnA3_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            if (isAnswerCorrect(btnA3, aRep))
            {
                Session["QuestionsAnswered"] = getQuestionsAnswered() + 1;
                btnA3.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }
            else
            {
                btnA3.BackColor = System.Drawing.Color.Red;
                getRightAnswerButton().BackColor = System.Drawing.Color.Green;
                refreshAfterSecondsWhenLost();
            }
        }

        protected void btnA4_Click(object sender, EventArgs e)
        {
            AnswerRepository aRep = new AnswerRepository();
            if (isAnswerCorrect(btnA4, aRep))
            {
                Session["QuestionsAnswered"] = getQuestionsAnswered() + 1;
                btnA4.BackColor = System.Drawing.Color.Green;
                refreshAfterSeconds();
            }
            else
            {   
                btnA4.BackColor = System.Drawing.Color.Red;
                getRightAnswerButton().BackColor = System.Drawing.Color.Green;
                getRightAnswerButton();
                refreshAfterSecondsWhenLost();
            }
        }

        private void refreshAfterSeconds(int sec = 2)
        {
            Response.AppendHeader("Refresh", sec + ";url=Game.aspx?cIds=" + string.Join(",", getCids().Select(n => n.ToString()).ToArray())); //komishes ~ ?
        }

        private void refreshAfterSecondsWhenLost(int sec = 2)
        {
            Session["QuestionsAnswered"] = null;
            Session["PlayedPoints"] = null;
            Session["PlayedQuestions"] = null;
            Session["StartTime"] = null;
            Session["HighscoreId"] = null;
            Response.AppendHeader("Refresh", sec + ";url=PlayerLost?"); //komishes ~ ?
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            SetHighScore();
            Session["StartTime"] = null;
            Session["QuestionsAnswered"] = null;
            Session["PlayedPoints"] = null;
            Session["PlayedQuestions"] = null;
            Session["Joker5050"] = null;
            string stop = "Sie haben ihren Gewinn mit nach Hause genommen!";
            Response.Redirect(String.Format("~/PlayerWinOrStop.aspx?winOrStop={0}&highscoreId={1}", stop, Session["HighscoreId"].ToString()));
            Session["HighscoreId"] = null;
        }

        protected void SetHighScore()
        {
            Highscore score = new Highscore();
            score.GameDuration = (DateTime.Now - ((DateTime)Session["StartTime"])).Seconds;
            score.MomentOfGame = (DateTime)Session["StartTime"];
            score.Points = GetPoints();
            score.WeightedPoints = -1;
            score.PlayedCategories = getCids().Select(x => new PlayedCategories()
            {
                CategoryId = x
            }).ToList();
            HighScoreRepository hRep = new HighScoreRepository();
            hRep.Save(score);
            Session["HighscoreId"] = score.Id;

        }

        protected void btn50Joker_Click(object sender, EventArgs e)
        {
            Session["Joker5050"] = true;
            btn50Joker.Enabled = false;
            set5050Answers();
        }

        private bool isAnswerCorrect(Button btn, AnswerRepository aRep, bool setPoints = true)
        {
            bool correct = aRep.checkAnswer(Convert.ToInt32(btn.Attributes["answerId"]));
            if (correct && setPoints) SetPoints();
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

        private int GetPoints()
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
        private int getQuestionsAnswered()
        {
            if (Session["QuestionsAnswered"] != null)
            {
                return Convert.ToInt32(Session["QuestionsAnswered"]);
            }
            return 0;
        }

        private List<int> getCids()
        {
            string strIds = Request.QueryString["cIds"];
            if (string.IsNullOrEmpty(strIds))
            {
                Response.Redirect("~/PlayerChooseCategory.aspx");
            }
            List<int> ids = strIds.Split(',').Select(Int32.Parse).ToList();
            return ids;
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
                if(isAnswerCorrect(buttons[i], aRep, false))
                {
                    buttons.Remove(buttons[i]);
                    buttonListCount = 0;
                }
            }

            buttons.Shuffle();

            buttons[1].Visible = false;
            buttons[2].Visible = false;

        }

        private Button getRightAnswerButton()
        {
            AnswerRepository aRep = new AnswerRepository();

            if (isAnswerCorrect(btnA1 , aRep))
            {
                return btnA1;
            }else if (isAnswerCorrect(btnA2, aRep))
            {
                return btnA2;
            }
            else if (isAnswerCorrect(btnA3, aRep))
            {
                return btnA3;
            }
            else if (isAnswerCorrect(btnA4, aRep))
            {
                return btnA4;
            }else
            {
                throw new System.ArgumentException("Fehler bei richtiger Antwortausgabe", "original");
            }
        }
    }
}
