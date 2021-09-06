using Microsoft.EntityFrameworkCore;

namespace SnowShop.Models
{
    public class SnowboardContext : DbContext
    {
        public SnowboardContext(DbContextOptions<SnowboardContext> options) : base(options)
        {
        }
        //database context can had db sets for mult models, add them as props also create multiple db contexts
        public DbSet<Snowboard> Snowboards { get; set;  }
    }
}