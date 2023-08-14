using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository_pattern.Model;

namespace Repository_pattern.context
{
    public class DbClass : DbContext
    {
        public DbClass(DbContextOptions<DbClass> options):base(options) { }
        public DbSet<user> users { get; set; }
    }
}
