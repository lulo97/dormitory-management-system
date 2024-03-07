using API.Dormitory.API_Service;
using Data.Dormitory.DTOs;
using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API.Dormitory.API_Controller
{
    public class StudentInRoomController : ApiController
    {
        StudentInRoomService studentInRoomService = new StudentInRoomService();

        [Route("api/studentinroom/getall")]
        public List<StudentInRoom> getAll()
        {
            return studentInRoomService.getAll();
        }

        [Route("api/studentinroom/deleteOne")]
        public string deleteOne(string StudentID)
        {
            return studentInRoomService.deleteOne(StudentID);
        }

        [Route("api/studentinroom/getStudentDetails")]
        public StudentDetailDTO getStudentDetails(string StudentID)
        {
            return studentInRoomService.getStudentDetails(StudentID);
        }

        [Route("api/studentinroom/getAllRoommate")]
        public List<StudentInRoom> getAllRoommate(string Username)
        {
            return studentInRoomService.getAllRoommate(Username);
        }

        [Route("api/studentinroom/getOne")]
        public StudentInRoom getOne()
        {
            string Username = HttpContext.Current.User.Identity.Name;
            return studentInRoomService.getOne(Username);
        }

        [Route("api/studentinroom/addone")]
        public string addOne(StudentInRoom studentInRoom)
        {
            return studentInRoomService.addOne(studentInRoom);
        }
    }
}
