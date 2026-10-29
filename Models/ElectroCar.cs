namespace WebApplication1.Models
{
	public class ElectroCar : Car
	{
		public int Battery { get; set; }

		public ElectroCar(string model, string manufacturer, int year, int price, int battery) : base(model, manufacturer, year, price)
		{
			Battery = battery;
		}
	}
}
