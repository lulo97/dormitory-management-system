using Data.Dormitory.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Dormitory.API_Service
{
    public class OnboardingService
    {
        Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();

        public string BindUsernameWithID(string studentID, string username)
        {
            try
            {
                // Validate input parameters
                if (string.IsNullOrEmpty(studentID))
                {
                    return "StudentID can't be null of empty";
                }

                // Find the student by ID
                var student = db.Students.FirstOrDefault(ele => ele.StudentID == studentID);

                if (student == null)
                {
                    return "Not found any student have that StudentID";
                }

                // Update the student's username
                student.Username = username;

                // Save changes to the database
                db.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                // Log the exception or perform additional error handling as needed
                return $"Error from OboardingService: {ex.Message}";
            }
        }
    }
}