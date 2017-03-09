using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SaraZarubica_LB_M151_V232.Models;
using BusinessLayer.Repositories;
using DataLayer.Entities;

namespace SaraZarubica_LB_M151_V232.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UserRepository uRep = new UserRepository();
                bool res = uRep.Login(userName.Text, Password.Text);
                User u = uRep.GetUserByUserName(userName.Text);
                SignInStatus result = res ? SignInStatus.Success : SignInStatus.Failure;
                switch (result)
                {
                    case SignInStatus.Success:
                        Session["UserId"] = u.Id;
                        Response.Redirect("~/AdminStartPage.aspx");
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}