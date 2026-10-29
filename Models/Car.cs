using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Car
	{
        public int Id { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int Year { get; set; }
		public int Price { get; set; }

		public Car()
		{

		}
		public Car(string model, string manufacturer, int year, int price)
		{
			Model = model;
			Manufacturer = manufacturer;
			Year = year;
			Price = price;
		}
	}
}
