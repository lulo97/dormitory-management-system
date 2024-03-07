using Data.Dormitory.DTOs;
using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Dormitory.API_Service
{
    public class StudentInRoomService
    {
        Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();

        public List<StudentInRoom> getAll()
        {
            return db.StudentInRooms.ToList();
        }

        public List<StudentInRoom> getAllRoommate(string Username)
        {
            AccountService AccountService = new AccountService();
            string StudentID = AccountService.fetchUser(Username).StudentID;
            StudentInRoom studentInRoom = db.StudentInRooms.FirstOrDefault(ele => ele.StudentID == StudentID);
            if (studentInRoom == null)
            {
                //If that student not in any room
                return null;
            }
            int RoomID = db.StudentInRooms.FirstOrDefault(ele => ele.StudentID == StudentID).RoomID;
            List<StudentInRoom> roommates = db.StudentInRooms
                                  .Where(ele => ele.RoomID == RoomID)
                                  .ToList();
            return roommates;
        }

        public StudentInRoom getOne(string Username)
        {
            AccountService AccountService = new AccountService();
            Student student = AccountService.fetchUser(Username);
            if (student == null)
            {
                return null;
            }
            StudentInRoom sir = db.StudentInRooms.FirstOrDefault(ele => ele.StudentID == student.StudentID);
            return sir;
        }

        public string addOne(StudentInRoom studentInRoom)
        {
            // Check for duplicates
            bool isAlreadyInRoom = db.StudentInRooms.Any(
                s => s.StudentID == studentInRoom.StudentID
            );

            if (isAlreadyInRoom)
            {
                return "DuplicateRecord";
            }

            db.StudentInRooms.Add(studentInRoom);
            db.SaveChanges();

            return "Add successfully";
        }

        public bool ExistItem(StudentInRoom sir)
        {
            return db.StudentInRooms.Any(x => x.StudentID == sir.StudentID);
        }

        public string deleteOne(string StudentID)
        {
            // Check if the record exists
            StudentInRoom existingRecord = db.StudentInRooms.FirstOrDefault(ele => ele.StudentID == StudentID);

            if (existingRecord == null)
            {
                return "Record not found";
            }

            // Delete the record
            db.StudentInRooms.Remove(existingRecord);
            db.SaveChanges();

            return "Delete student from room successfully";
        }

        public StudentDetailDTO getStudentDetails(string StudentID)
        {
            StudentInRoom sir = db.StudentInRooms.FirstOrDefault(ele => ele.StudentID == StudentID);
            Student student = db.Students.FirstOrDefault(ele => ele.StudentID == StudentID);
            if (student == null) { return null; }
            if (sir == null) { return null; }
            return StudentDetailDTO.combine(sir, student);
        }
    }
}