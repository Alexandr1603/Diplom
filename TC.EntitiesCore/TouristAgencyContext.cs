using Microsoft.EntityFrameworkCore;
using TA.EntitiesCore.Models;

namespace TA.EntitiesCore
{
    public class TouristAgencyContext : DbContext
    {
        private static DbContextOptions<TouristAgencyContext> _dbContextOptions =
           new DbContextOptionsBuilder<TouristAgencyContext>()
           .UseSqlServer(@"Server=DESKTOP-O9EVJ69\MSSQLSERVER01; Database=TouristAgency;Trusted_Connection=True;")
           .Options;

        public DbSet<WorkersDb> Workers { get; set; }
        public DbSet<AttractionsDb> Attractions { get; set; }
        public DbSet<HotelsDb> Hotels { get; set; }
        public DbSet<CustomersDb> Customers { get; set; }
        public DbSet<CititesDb> Citites { get; set; }
        public DbSet<CountriesDb> Countries { get; set; }
        public DbSet<RouteDb> Routs { get; set; }
        public DbSet<RouteAttractionDb> RoteAttractions { get; set; }
        public DbSet<RouteHotelDb> RouteHotels { get; set; }
        public DbSet<ToursDb> Tours { get; set; }
        public DbSet<TourClientsDb> TourClients { get; set; }
        public DbSet<HotelRoomsDb> HotelRooms { get; set; }

        public TouristAgencyContext(): base(_dbContextOptions) { }
    }
}
