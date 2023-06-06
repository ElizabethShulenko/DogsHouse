using DogsHouse.Db.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DogsHouseApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost("Ping")]
        public string Ping()
        {
            return "Dogs Hpuse service. Version 1.0.1";
        }

        [HttpPost("dogs")]
        public List<Dog> Dogs()
        {
            
            return result;
        }
    }
}
