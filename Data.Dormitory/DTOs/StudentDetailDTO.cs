using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Dormitory.DTOs
{
    public class StudentDetailDTO
    {
        // Properties from StudentInRoom
        public int BuildingId { get; set; }
        public string RoomName { get; set; }
        public int RoomID { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Class { get; set; }
        public string AcademicYear { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string PhoneNumber { get; set; }

        // Properties from Student
        public string Username { get; set; }
        public string Major { get; set; }
        public string PersonalID { get; set; }
        public Nullable<System.DateTime> DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Gmail { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Commune { get; set; }

        public static StudentDetailDTO combine(StudentInRoom sir, Student student)
        {
            return new StudentDetailDTO
            {
                // Properties from StudentInRoom
                BuildingId = sir.BuildingId,
                RoomName = sir.RoomName,
                RoomID = sir.RoomID,
                StudentID = sir.StudentID,
                StudentName = sir.StudentName,
                Class = sir.Class,
                AcademicYear = sir.AcademicYear,
                DOB = sir.DOB,
                PhoneNumber = sir.PhoneNumber,

                // Properties from Student
                Username = student.Username,
                Major = student.Major,
                PersonalID = student.PersonalID,
                DateOfIssue = student.DateOfIssue,
                PlaceOfIssue = student.PlaceOfIssue,
                Gender = student.Gender,
                Religion = student.Religion,
                Gmail = student.Gmail,
                CreatedTime = student.CreatedTime,
                ModifiedTime = student.ModifiedTime,
                IsDeleted = student.IsDeleted,
                Province = student.Province,
                District = student.District,
                Commune = student.Commune
            };
        }
    }
}