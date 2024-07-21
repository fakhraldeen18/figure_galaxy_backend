using Microsoft.EntityFrameworkCore;
namespace sda_onsite_2_csharp_backend_teamwork.src.Databases
{
    public class DatabaseContext : DbContext // DbContext is built in class to give me access to database (gateway to database)
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}






