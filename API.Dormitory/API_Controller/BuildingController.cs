using API.Dormitory.API_Service;
using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Dormitory.API_Controller
{
    public class BuildingController : ApiController
    {
        BuildingService buildingService = new BuildingService();

        [Route("api/building/getAll")]
        public List<Building> getAll()
        {
            return buildingService.getAll();
        }
    }
}