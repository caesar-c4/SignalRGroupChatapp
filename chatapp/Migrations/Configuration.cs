namespace chatapp.Migrations
{
    using chatapp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<chatapp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(chatapp.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var result = roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var result = roleManager.Create(new IdentityRole { Name = "Member" });
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            if (!context.Users.Any(r => r.UserName == "a@a.com"))
            {
                var user = new ApplicationUser { UserName = "a@a.com", PhoneNumber = "222214" };
                var result = userManager.Create(user, "@Test123");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }



            var UsAcc = new List<UserAccess>
                {
                new UserAccess{RoleName="Admin",ActionName="Index",ControllerName="GroupInfos",MenuItem="GroupCreate"},
                new UserAccess{RoleName="Member",ActionName="Chat",ControllerName="Home",MenuItem="Chat"},
                new UserAccess{RoleName="Admin",ActionName="RoleCreate",ControllerName="Account",MenuItem="RoleCreate"},

                };
            UsAcc.ForEach(s => context.UserAccesss.Add(s));
            context.SaveChanges();


            var Group = new List<GroupInfo>
                {
                new GroupInfo{GroupName="Room 1"},
                new GroupInfo{GroupName="Room 2"},
                new GroupInfo{GroupName="Room 3"},
                

                };
            Group.ForEach(s => context.GroupInfos.Add(s));
            context.SaveChanges();
        }
    }
}
