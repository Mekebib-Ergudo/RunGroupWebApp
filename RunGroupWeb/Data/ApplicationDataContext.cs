
using Microsoft.EntityFrameworkCore;
using RunGroupWeb.Models;

namespace RunGroupWeb.Data
{
	public class ApplicationDataContext : DbContext
	{
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> dbContext) : base(dbContext) 
        {
            
        }
       public DbSet<Race> Races { get; set; }
		public DbSet<Club> Clubs { get; set; }
		public DbSet<Address>	Addresses { get; set; }
	}
}
