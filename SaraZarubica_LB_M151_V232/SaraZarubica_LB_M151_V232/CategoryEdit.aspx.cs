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
    public partial class CategoryEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //redirectToLoginIfNecessary();

            if (!Page.IsPostBack) // first load.
            {
                string strId = Request.QueryString["cId"];
                if (!string.IsNullOrEmpty(strId)) // existiert schon
                {
                    int cId = Convert.ToInt32(strId);
                    loadAndSetCategory(cId);
                }
                else // neue Kategorie
                {
                    setView(null);
                }
            }
        }



        protected void setView(Category c)
        {
            if (c != null)
            {
                HiddenCId.Value = c.Id.ToString();
                txtBoxC.Text = c.Id.ToString();
            }
        }

        private string boolToString(bool val)
        {
            return val ? "1" : "0";
        }

        protected void loadAndSetCategory(int id)
        {
            CategoryRepository cRep = new CategoryRepository();
            Category c = cRep.getCategoryById(id);
            setView(c);
        }

        private Category getCategoryFromView()
        {
            Category c = new Category();
            c.Id = toInt(HiddenCId.Value);
            c.CategoryText = txtBoxC.Text;
            //c.UserId = getUserId();
            return c;
        }

        //private void validateQuestion(Question q)
        //{
        //    if (q.CategoryId < 1)
        //    {
        //        txtBoxError.Text += "Kategorie wählen";
        //        txtBoxError.Visible = true;
        //    }
        //}

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
            string userId = Session["UserId"].ToString();
            if (string.IsNullOrEmpty(userId))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (Convert.ToInt32(userId) < 1)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private int getUserId()
        {
            return 1;
            string userId = Session["UserId"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return toInt(userId);
            }
            else { return -1; }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            CategoryRepository cRep = new CategoryRepository();

            Category c = getCategoryFromView();

            cRep.Save(c);
        }
    }
}