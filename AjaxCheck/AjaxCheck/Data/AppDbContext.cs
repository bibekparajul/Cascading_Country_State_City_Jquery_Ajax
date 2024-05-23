using AjaxCheck.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AjaxCheck.Data
{

    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }
        public DbSet<CountryModel> Countries { get; set; }

        public DbSet<StatesModel> States { get; set; }
        public DbSet<CityModel> Cities { get; set; }
    }
}
