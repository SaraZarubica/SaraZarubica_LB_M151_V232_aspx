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
        private int? cId;
        protected void Page_Load(object sender, EventArgs e)
        {
            redirectToLoginIfNecessary();

            if (!Page.IsPostBack) // first load.
            {
                string strId = Request.QueryString["cId"];
                if (!string.IsNullOrEmpty(strId)) // existiert schon
                {
                    int cId = Convert.ToInt32(strId);
                    loadAndSetCategory(cId);
                }
                else
                {
                    setView(null);
                }
            }
        }

        protected void setView(Category c)
        {
            if (c != null)
            {
                btnDelete.Visible = true;
                HiddenCId.Value = c.Id.ToString();
                txtBoxC.Text = c.CategoryText;
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
            return c;
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

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            CategoryRepository cRep = new CategoryRepository();

            Category c = getCategoryFromView();
            c.UserId = getUserId();

            if (validateCategory(c) == null)
            {
                cRep.Save(c);
                Response.Redirect("~/CategoryList.aspx");
            }
            else
            {
                txtBoxError.Visible = true;
                txtBoxError.Text = validateCategory(c);
            }

        }

        private string validateCategory(Category c)
        {
            string errorMessage = null;
            if (c.CategoryText == "")
            {
                errorMessage = "Geben Sie eine Kategorie ein.";
            }
            return errorMessage;
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CategoryRepository cRep = new CategoryRepository();
            string strId = Request.QueryString["cId"];
            if (!string.IsNullOrEmpty(strId)) // existiert schon
            {
                cId = Convert.ToInt32(strId);
            }
            cRep.Delete(cId.Value);

            Response.Redirect("~/CategoryList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CategoryList.aspx");
        }
    }
}