using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Conference> Conferences {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=midax-a-minjs-rds.cuxi7qfyfqir.us-west-2.rds.amazonaws.com;User Id=admin;Password=Aneeka97;Database=conference");
        }
    }

}