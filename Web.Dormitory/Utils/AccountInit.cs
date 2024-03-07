using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using Web.Dormitory.Models;

namespace Web.Dormitory.Utils
{
    public class AccountInit
    {
        public AccountInit() { }
        public static void initAccountsAndRoles()
        {
            CreateRoles();

            CreateUsers("admin@gmail.com", "Luong12345@");
            CreateUserRoles("admin@gmail.com", "Admin");

            CreateUsers("luongpysl1@gmail.com", "Luong12345@");
            CreateUsers("luongpysl2@gmail.com", "Luong12345@");
            CreateUsers("luongpysl3@gmail.com", "Luong12345@");

            CreateUserRoles("luongpysl1@gmail.com", "Student");
            CreateUserRoles("luongpysl2@gmail.com", "Student");
            CreateUserRoles("luongpysl3@gmail.com", "Student");

            CreateUsers("manager1@gmail.com", "Luong12345@");
            CreateUsers("manager2@gmail.com", "Luong12345@");
            CreateUsers("manager3@gmail.com", "Luong12345@");

            CreateUserRoles("manager1@gmail.com", "Manager");
            CreateUserRoles("manager2@gmail.com", "Manager");
            CreateUserRoles("manager3@gmail.com", "Manager");
        }

        //Role Admin, Manager and Student
        public static void CreateRoles()
        {
            var _roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var roleNames = new List<string> { "Admin", "Student", "Manager" };

            foreach (var roleName in roleNames)
            {
                if (!_roleManager.RoleExists(roleName))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                    {
                        Name = roleName
                    };
                    _roleManager.Create(role);
                }
            }
        }

        public static void CreateUsers(string userName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Check if the user exists
            var user = userManager.FindByName(userName);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = userName,
                    Email = userName // assuming the email is also the username in this example
                };

                var result = userManager.Create(user, password);

                if (!result.Succeeded)
                {
                    // Handle errors, e.g., log or display an error message
                    foreach (var error in result.Errors)
                    {
                        throw new System.Exception(error);
                    }
                }
            }
            else
            {
                // User already exists, you might want to handle this case
                return;
            }
        }

        public static void CreateUserRoles(string userName, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = userManager.FindByName(userName);
            var role = roleManager.FindByName(roleName);

            if (user != null && role != null && !userManager.IsInRole(user.Id, role.Name))
            {
                userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}