using Data.Dormitory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Dormitory.API_Service
{
    public class BuildingService
    {
        Dormitory_ManagerEntities db = new Dormitory_ManagerEntities();

        public List<Building> getAll()
        {
            return db.Buildings.ToList();
        }
    }
}