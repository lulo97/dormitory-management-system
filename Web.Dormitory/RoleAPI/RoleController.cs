using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.Dormitory.Models;
using Data.Dormitory.Models;
using System.Web.ApplicationServices;
using System;

namespace Web.Dormitory.RoleAPI
{
    public class RoleController : ApiController
    {
        RoleService _roleService = new RoleService();

        [HttpGet]
        [Route("api/role/getAllUsers")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var result = _roleService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/role/getAllUsersSimplify")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetAllUsersSimplify()
        {
            try
            {
                var result = _roleService.GetAllUsersSimplify();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/role/getAllRoles")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetAllRoles()
        {
            try
            {
                var result = _roleService.GetAllRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/role/getAllRolesSimplify")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetAllRolesSimplify()
        {
            try
            {
                var result = _roleService.GetAllRolesSimplify();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/role/createRole")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult CreateRole(string roleName)
        {
            try
            {
                var result = _roleService.CreateRole(roleName);
                if (result == null)
                {
                    return Ok("Role created successfully.");
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/role/deleteRole")]
        public IHttpActionResult DeleteRole(string roleName)
        {
            try
            {
                var result = _roleService.DeleteRole(roleName);
                if (result == null)
                {
                    return Ok($"Role '{roleName}' deleted successfully.");
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/role/editRole")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult EditRole(string OldRoleName, string EditRoleName)
        {
            try
            {
                var result = _roleService.EditRole(OldRoleName, EditRoleName);
                if (result == null)
                {
                    return Ok($"Role '{OldRoleName}' updated to '{EditRoleName}' successfully.");
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/role/addRoleToUser")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddRoleToUser(string UserId, string RoleName)
        {
            try
            {
                var result = _roleService.AddRoleToUser(UserId, RoleName);
                if (result == null)
                {
                    return Ok($"Role '{RoleName}' added to user successfully.");
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/role/removeRoleFromUser")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult RemoveRoleFromUser(string UserId, string RoleName)
        {
            try
            {
                var result = _roleService.RemoveRoleFromUser(UserId, RoleName);
                if (result == null)
                {
                    return Ok($"Role '{RoleName}' removed from user successfully.");
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
