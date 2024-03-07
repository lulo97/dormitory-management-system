using API.Dormitory.API_Service;
using Data.Dormitory.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Dormitory.API_Controller
{
    public class RoomController : ApiController
    {
        RoomService roomService = new RoomService();

        [HttpGet]
        [Route("api/room/getAll")]
        public List<Room> getAll()
        {
            return roomService.getAll();
        }

        [HttpGet]
        [Route("api/room/getOne")]
        public Room getOne(int RoomID)
        {
            return roomService.getOne(RoomID);
        }

        [HttpGet]
        [Route("api/room/getAllRoomOfABuilding")]
        public List<Dictionary<string, object>> getAllRoomOfABuilding(int BuildingID)
        {
            return roomService.getAllRoomOfABuilding(BuildingID);
        }
    }
}