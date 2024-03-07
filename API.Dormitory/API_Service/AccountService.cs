using Data.Dormitory.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Dormitory.API_Service
{
    public class AccountService
    {

        Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();
        StudentService studentService = new StudentService();
        public List<AspNetUser> getAll()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.AspNetUsers.ToList();
        }

        public Student fetchUser(string Username)
        {
            Student student = db.Students.FirstOrDefault(ele => ele.Username == Username);
            return student;
        }
    }
}