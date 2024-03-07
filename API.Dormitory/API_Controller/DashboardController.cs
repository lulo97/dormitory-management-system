using API.Dormitory.API_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Dormitory.API_Controller
{
    public class DashboardController : ApiController
    {
        DashboardService dashboardService = new DashboardService();

        [HttpGet]
        [Route("api/dashboard/getTotalFour")]
        public object getTotalFour()
        {
            return dashboardService.getTotalFour();
        }
    }
}
