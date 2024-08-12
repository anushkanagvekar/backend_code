using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using WebApplication6.Models;


namespace WebApplication6.Data
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {

        }

        public DbSet<Formdata> Users { get; set; }



    }
}
