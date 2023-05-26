using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
        {
        }
        public DbSet<Intrest> Intrests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
    }

}
