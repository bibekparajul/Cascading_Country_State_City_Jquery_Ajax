using AjaxCheck.Data;
using Microsoft.AspNetCore.Mvc;

namespace AjaxCheck.Controllers
{
    public class CascadingController : Controller
    {
        private readonly AppDbContext _context;
        public CascadingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetCountries()
        {
            var countries = _context.Countries.OrderBy(x=> x.CountryName).ToList();
            return new JsonResult(countries);
        }


        public JsonResult GetStates(int id)
        {
            var states = _context.States.Where(x=> x.CountryId == id).OrderBy(x => x.StateName).ToList();
            return new JsonResult(states);
        }

        public JsonResult GetCities(int id)
        {
            var cities = _context.Cities.Where(x=> x.States.StateId == id).OrderBy(x => x.CityName).ToList();
            return new JsonResult(cities);
        }
    }
}
