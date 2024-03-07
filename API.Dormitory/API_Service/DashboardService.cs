using Data.Dormitory.Models;
using System.Linq;

namespace API.Dormitory.API_Service
{
    public class DashboardService
    {
        Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();

        public object getTotalFour()
        {
            return new
            {
                TotalStudents = db.Students.ToList().Count(),
                TotalManagers = db.Managers.ToList().Count(),
                TotalRooms = db.Rooms.ToList().Count(),
                TotalBuildings = db.Buildings.ToList().Count()
            };
        }
    }
}