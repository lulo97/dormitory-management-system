using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Dormitory.API_Service
{
    public class RoomService
    {
        Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();

        public List<Room> getAll()
        {
            return db.Rooms.ToList();
        }

        public Room getOne(int RoomID)
        {
            Room room = db.Rooms.FirstOrDefault(ele => ele.RoomID == RoomID);
            if (room == null)
            {
                throw new ArgumentException("Không tìm thấy RoomID");
            }
            return room;
        }

        public List<Dictionary<string, object>> getAllRoomOfABuilding(int BuildingID)
        {
            Building building = db.Buildings.FirstOrDefault(x => x.ID == BuildingID);
            string Price = building.Price;
            List<Room> roomsInBuilding = db.Rooms.Where(room => room.BuildingID == BuildingID).ToList();

            var roomsWithBuildingPrice = roomsInBuilding.Select(room =>
            {
                var roomProperties = room.GetType().GetProperties()
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(room));
                roomProperties.Add("Price", Price);
                return roomProperties;
            }).ToList();

            return roomsWithBuildingPrice;
        }
    }
}