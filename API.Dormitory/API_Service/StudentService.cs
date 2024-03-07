using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace API.Dormitory.API_Service
{
    //Services encapsulate business logic and interact with data
    public class StudentService
    {
        private readonly Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();

        public List<Student> GetSome(int pageIndex, int pageSize)
        {
            var allStudents = db.Students.ToList();
            return allStudents.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public Student GetOne(string studentID)
        {
            return db.Students.SingleOrDefault(x => x.StudentID == studentID);
        }

        public void UpdateOne(Student student)
        {
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void AddOne(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void DeleteOne(string studentID)
        {
            var student = db.Students.SingleOrDefault(x => x.StudentID == studentID);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}
