using API.Dormitory.API_Service;
using Data.Dormitory.Models;
using System;
using System.Web.Http;

namespace API.Dormitory.API_Controller
{
    //Controllers handle HTTP requests and responses.
    public class StudentController : ApiController
    {
        private readonly StudentService studentService;
        public StudentController()
        {
            // Assuming Dormitory_ManagerEntities is your DbContext
            studentService = new StudentService();
        }

        [Route("api/student/GetSome")]
        [HttpGet]
        public IHttpActionResult GetSome(int pageIndex, int pageSize)
        {
            try
            {
                var allStudents = studentService.GetSome(pageIndex, pageSize);
                return Ok(allStudents);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [Route("api/student/GetOne")]
        [HttpGet]
        public IHttpActionResult GetOne(string studentID)
        {
            try
            {
                var student = studentService.GetOne(studentID);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [Route("api/student/UpdateOne")]
        [HttpPut]
        public IHttpActionResult UpdateOne(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Invalid student data");
                }

                studentService.UpdateOne(student);

                return Ok("Student updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [Route("api/student/AddOne")]
        [HttpPost]
        public IHttpActionResult AddOne(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Invalid student data");
                }

                studentService.AddOne(student);

                return Ok("Student added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [Route("api/student/DeleteOne")]
        [HttpDelete]
        public IHttpActionResult DeleteOne(string studentID)
        {
            try
            {
                if (string.IsNullOrEmpty(studentID))
                {
                    return BadRequest("StudentID cannot be null or empty.");
                }

                studentService.DeleteOne(studentID);

                return Ok("Student deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}