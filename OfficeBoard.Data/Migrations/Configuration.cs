namespace OfficeBoard.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OfficeBoardContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OfficeBoardContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                //create admin
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Admin"));

                var userManager = new UserManager<User>(new UserStore<User>(context));
                var admin = new User
                {
                    UserName = resources.Username,
                    Email = resources.Email
                };

                userManager.Create(admin, resources.Email);
                userManager.AddToRole(admin.Id, "Admin");

                //create some users
                userManager = new UserManager<User>(new UserStore<User>(context));
                var someUser = new User
                {
                    UserName = "pesho",
                    Email = "pesho@pesho.be"
                };

                userManager.Create(someUser, "peshobe");

                userManager = new UserManager<User>(new UserStore<User>(context));
                var newUser = new User
                {
                    UserName = "shoshko",
                    Email = "shoshko@gmail.com"
                };

                userManager.Create(newUser, "shoshodabest");
            }

            if(!context.Notes.Any())
            {
                var note1 = new Note()
                {
                    Title = "I am a note",
                    Content = "balblalblal",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "shoshko"),
                    DateAdded = DateTime.Now
                };
                context.Notes.Add(note1);

                var note2 = new Note()
                {
                    Title = "Winter is coming",
                    Content = "it's so cold",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "shoshko"),
                    DateAdded = DateTime.Now
                };
                context.Notes.Add(note2);

                var note3 = new Note()
                {
                    Title = "I wanna sleep",
                    Content = "ZZzzzzzz",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "pesho"),
                    DateAdded = DateTime.Now
                };
                context.Notes.Add(note3);

                var note4 = new Note()
                {
                    Title = "etsetztw",
                    Content = "blyert",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "pesho"),
                    DateAdded = DateTime.Now.AddDays(-2)
                };
                context.Notes.Add(note4);

                var note5 = new Note()
                {
                    Title = "56364737",
                    Content = "sdfsgdsg",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "pesho"),
                    DateAdded = DateTime.Now.AddDays(-10)
                };
                context.Notes.Add(note5);

                context.SaveChanges();
            }
        }
    }
}
