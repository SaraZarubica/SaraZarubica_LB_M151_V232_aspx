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
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            cRep = new CategoryRepository();
            //List<Category> list = cRep.GetAllCategoriesFromUserId(userId);
            //gvCategories.DataSource = list;
            gvCategories.DataBind();
        }
    }
}