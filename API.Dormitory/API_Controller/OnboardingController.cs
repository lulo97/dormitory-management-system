using API.Dormitory.API_Service;
using Data.Dormitory.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Dormitory.API_Controller
{
    public class OnboardingController : ApiController
    {
        OnboardingService onboardingService = new OnboardingService();

        [Route("api/onboarding/test")]
        [HttpGet]
        public string test()
        {
            return "123";
        }

        [Route("api/onboarding/BindUsernameWithID")]
        [HttpPost]
        public IHttpActionResult BindUsernameWithID(string studentID)
        {
            try
            {
                // Call the OnboardingService to perform the operation
                string fail_msg = onboardingService.BindUsernameWithID(studentID, HttpContext.Current.User.Identity.Name);

                //If no fail message
                if (fail_msg == null)
                {
                    return Ok("Bind StudentID with Username successfully");
                }
                else
                {
                    return BadRequest(fail_msg);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error from OboardingController: {ex.Message}");
            }
        }
    }
}