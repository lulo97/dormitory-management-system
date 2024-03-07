using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;

namespace API.Dormitory.API_Service
{
    public class BookingService
    {

        Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();
        AccountService accountService = new AccountService();
        RoomService roomService = new RoomService();

        public string sentBookingForm(int RoomID)
        {
            string result = "FAIL";
            bool IsUpdate = false;
            string Username = HttpContext.Current.User.Identity.Name;

            Student student = accountService.fetchUser(Username);
            Room room = roomService.getOne(RoomID);

            Booking booking = new Booking();
            booking.StudentID = student.StudentID;
            booking.StudentName = student.StudentName;
            booking.BuildingId = room.BuildingID;
            booking.RoomID = room.RoomID;
            booking.RoomName = room.RoomName;
            booking.IsAproved = false;
            booking.CreatedTime = DateTime.Now;
            booking.ModifiedTime = DateTime.Now;
            booking.Status = true;
            booking.IsDeleted = false;

            if (ExistItem(booking))
            {
                IsUpdate = true;
            }

            if (IsUpdate)
            {
                db.Entry(booking).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                result = "Update OK";
            }
            else
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                result = "Add OK";
            }

            return result;
        }

        public bool isBooked(int RoomID)
        {
            string Username = HttpContext.Current.User.Identity.Name;

            Student student = accountService.fetchUser(Username);

            RoomService roomService = new RoomService();
            Room room = roomService.getOne(RoomID);

            // Check if a booking exists for the specified StudentID, RoomID, and BuildingId
            bool isBooked = db.Bookings.Any(b =>
                b.StudentID == student.StudentID &&
                b.RoomID == RoomID &&
                b.Status == true
            );

            return isBooked;
        }

        public List<Booking> getAll()
        {
            return db.Bookings.Where(ele => ele.Status == true).ToList();
        }

        public string setApproveBookingForm(int BookingID)
        {
            Booking booking = db.Bookings.FirstOrDefault(ele => ele.ID == BookingID);

            if (booking == null)
            {
                return "Booking not found";
            }

            StudentService studentService = new StudentService();
            Student student = studentService.GetOne(booking.StudentID);

            if (student == null)
            {
                return "Student not found";
            }

            StudentInRoomService studentInRoomService = new StudentInRoomService();

            StudentInRoom studentInRoom = new StudentInRoom
            {
                BuildingId = booking.BuildingId,
                RoomName = booking.RoomName,
                RoomID = booking.RoomID,
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                Class = student.Class,
                AcademicYear = student.AcademicYear,
                DOB = student.DOB,
                PhoneNumber = student.PhoneNumber,
                isDeleted = false // Assuming you want to set it as false initially
            };

            studentInRoomService.addOne(studentInRoom);

            // Remove booking record
            booking.IsAproved = true;
            booking.Status = false;
            db.Bookings.AddOrUpdate(booking);
            db.SaveChanges();

            return "Ok";
        }

        public string setDenyBookingForm(int BookingID)
        {
            Booking booking = db.Bookings.FirstOrDefault(ele => ele.ID == BookingID);

            if (booking == null)
            {
                return "Booking not found";
            }

            // Remove booking record
            booking.IsAproved = false;
            booking.Status = false;
            db.Bookings.AddOrUpdate(booking);
            db.SaveChanges();

            return "Ok";
        }

        public bool ExistItem(Booking booking)
        {
            return db.Bookings.Any(x => x.ID == booking.ID);
        }
    }
}