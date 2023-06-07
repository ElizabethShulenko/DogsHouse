using DogsHouse.Db.Entities;
using DogsHouseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DogsHouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDogService _dogService;

        public HomeController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet("Ping")]
        public string Ping()
        {
            return "Dogs Hpuse service. Version 1.0.1";
        }

        [HttpGet("dogs")]
        public async Task<IEnumerable<Dog>> Dogs(string attribute, string order, int pageNumber = 0, int pageSize = 0)
        {
            var result = await _dogService.GetAllAsync();

            if (!String.IsNullOrEmpty(attribute))
            {
                result = _dogService.Sort(result, attribute, order);
            }
            if (pageNumber != 0 && pageSize != 0)
            {
                result = _dogService.GetDogsByPage(result, pageNumber, pageSize);
            }

            return result;
        }

        [HttpPost("Dog")]
        public async Task<string> Dog(string name, string color, double tailLength, double weight)
        {
            await _dogService.AddDogAsync(name, color, tailLength, weight);

            return "successfully added new dog!";
        }
    }
}
