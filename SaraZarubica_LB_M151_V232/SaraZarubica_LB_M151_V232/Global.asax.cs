using BusinessLayer.Repositories;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SaraZarubica_LB_M151_V232
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var dbContext = new DataContext();
            if (dbContext.Database.Exists())
            {
                if (dbContext.Users.Count() < 1)
                {
                    CreateDb(dbContext);
                }
            }
            else{
                CreateDb(dbContext);
            }
        }

        public void CreateDb(DataContext dbContext)
        {    
            Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            CreateData(dbContext);
            
        }

        public void CreateData(DataContext dbContext)
        {
            UserRepository uRep = new UserRepository();
            uRep.Register("Admin", "admin1234", Roll.Admin);
            User admin = uRep.GetUserByUserName("Admin");

            Category katFahrzeug = new Category() { CategoryText = "Fahrzeug", UserId = admin.Id};
            dbContext.Categories.Add(katFahrzeug);
            dbContext.SaveChanges();

            Category katMathematik = new Category() { CategoryText = "Mathematik", UserId = admin.Id };
            dbContext.Categories.Add(katMathematik);
            dbContext.SaveChanges();



        }
    }
}