using System.Collections.Generic;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
		{
		}

		public DbSet<Car> Cars { get; set; }
        public DbSet<ElectroCar> ElCars { get; set; }
    }
}