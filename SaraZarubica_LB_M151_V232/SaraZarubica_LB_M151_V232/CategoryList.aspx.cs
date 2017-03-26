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
    public partial class CategoryList : System.Web.UI.Page
    {
        CategoryRepository cRep;
        protected void Page_Load(object sender, EventArgs e)
        {
            redirectToLoginIfNecessary();
            cRep = new CategoryRepository();
            int userId = getUserId();
            List<Category> list = cRep.GetAllCategoriesFromUserId(userId);
            gvCategories.DataSource = list;
            gvCategories.DataBind();
        }

        protected void gvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCategories.Rows)
            {
                if (row.RowIndex == gvCategories.SelectedIndex)
                {
                    string id = row.Attributes["cId"];
                    Response.Redirect("~/CategoryEdit.aspx?cId=" + id);
                }
            }
        }

        protected void gvCategories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Category c = (Category)e.Row.DataItem;
                e.Row.Attributes["cId"] = c.Id.ToString();
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvCategories, "Select$" + e.Row.RowIndex);
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
            Response.Redirect("~/CategoryEdit.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminStartPage.aspx");
        }
    }

}