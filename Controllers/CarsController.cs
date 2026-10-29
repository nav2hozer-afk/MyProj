using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
	public class CarsController : Controller
	{
		
		private readonly AppDbContext _context;
		public CarsController(AppDbContext context)
		{
			_context = context;
		}
		



		[HttpGet]
		public IActionResult Index()
		{
			var cars = _context.ElCars.ToList();
			return View(cars);
		}
        [HttpGet]
        public IActionResult Index1()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }

        [HttpPost]
        public IActionResult addElCars(string Model, string Manufacturer, int Year, int Price, int? Battery)
        {
            // Если Battery указан (не null), создаем электромобиль
            if (Battery.HasValue && Battery.Value > 0)
            {
                var electroCar = new ElectroCar(Model, Manufacturer, Year, Price, Battery.Value);
                _context.Cars.Add(electroCar);
            }
            else
            {
                // Иначе создаем обычный автомобиль
                var car = new Car(Model, Manufacturer, Year, Price);
                _context.Cars.Add(car);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
		public IActionResult searchCar(string Model_it)
		{
			var result = _context.Cars.Where(s => s.Model == Model_it).ToList();
			return View("Index1", result);
		}

        [HttpPost]
		public IActionResult updateBattery(string Model, int newBattery)
		{
			var car = _context.Cars.OfType<ElectroCar>().FirstOrDefault(c => c.Model == Model);
			if (car != null)
			{
				car.Battery = newBattery;
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}

	}
}
