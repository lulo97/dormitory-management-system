using Data.Dormitory.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using Web.Dormitory.Models;

namespace Web.Dormitory.RoleAPI
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        Dormitory_ManagerEntities db;

        public RoleService()
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            db = new Dormitory_ManagerEntities();
        }

        public IList<AspNetUser> GetAllUsers()
        {
            return db.AspNetUsers.ToList();
        }

        public IList<object> GetAllUsersSimplify()
        {
            var usersWithRoles = db.AspNetUsers
                .Select(user => new
                {
                    Id = user.Id,
                    Email = user.Email,
                    AspNetRoles = user.AspNetRoles.Select(role => role.Name).ToList()
                })
                .ToList<object>();

            return usersWithRoles;
        }

        public IList<AspNetRole> GetAllRoles()
        {
            return db.AspNetRoles.ToList();
        }

        public IList<object> GetAllRolesSimplify()
        {
            var roles = db.AspNetRoles.Select(role => new
            {
                Id = role.Id,
                Name = role.Name,
            })
            .ToList<object>();
            return roles;
        }

        public string CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                //BadRequest
                return "Role name cannot be empty or null.";
            }

            if (_roleManager.RoleExists(roleName))
            {
                //BadRequest
                return $"Role '{roleName}' already exists.";
            }

            var newRole = new IdentityRole
            {
                Name = roleName
            };

            var result = _roleManager.Create(newRole);

            if (result.Succeeded)
            {
                return null;
            }
            else
            {
                //BadRequest
                return $"Failed to create role '{roleName}'.";
            }
        }

        public string DeleteRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return "Role name cannot be empty or null.";
            }

            var roleToDelete = _roleManager.FindByName(roleName);

            if (roleToDelete == null)
            {
                return $"Role '{roleName}' does not exist.";
            }

            var result = _roleManager.Delete(roleToDelete);

            if (result.Succeeded)
            {
                return null;
            }
            else
            {
                return $"Failed to delete role '{roleName}'.";
            }
        }

        public string EditRole(string oldRoleName, string editRoleName)
        {
            if (string.IsNullOrWhiteSpace(oldRoleName) || string.IsNullOrWhiteSpace(editRoleName))
            {
                return "Old and new role names cannot be empty or null.";
            }

            var roleToEdit = _roleManager.FindByName(oldRoleName);

            if (roleToEdit == null)
            {
                return $"Role '{oldRoleName}' does not exist.";
            }

            roleToEdit.Name = editRoleName;

            var result = _roleManager.Update(roleToEdit);

            if (result.Succeeded)
            {
                return null;
            }
            else
            {
                return $"Failed to update role '{oldRoleName}' to '{editRoleName}'.";
            }
        }

        public string AddRoleToUser(string userId, string roleName)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(roleName))
            {
                return "User ID and role name cannot be empty or null.";
            }

            var user = _userManager.FindById(userId);

            if (user == null)
            {
                return $"User with ID '{userId}' does not exist.";
            }

            if (!_roleManager.RoleExists(roleName))
            {
                return $"Role '{roleName}' does not exist.";
            }

            if (_userManager.IsInRole(userId, roleName))
            {
                return $"User is already in role '{roleName}'.";
            }

            var result = _userManager.AddToRole(userId, roleName);

            if (result.Succeeded)
            {
                return null;
            }
            else
            {
                return $"Failed to add role '{roleName}' to user '{user.UserName}'.";
            }
        }

        public string RemoveRoleFromUser(string userId, string roleName)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(roleName))
            {
                return "User ID and role name cannot be empty or null.";
            }

            var user = _userManager.FindById(userId);

            if (user == null)
            {
                return $"User with ID '{userId}' does not exist.";
            }

            if (!_userManager.IsInRole(userId, roleName))
            {
                return $"User is not in role '{roleName}'.";
            }

            var result = _userManager.RemoveFromRole(userId, roleName);

            if (result.Succeeded)
            {
                return null;
            }
            else
            {
                return $"Failed to remove role '{roleName}' from user '{user.UserName}'.";
            }
        }
    }

}