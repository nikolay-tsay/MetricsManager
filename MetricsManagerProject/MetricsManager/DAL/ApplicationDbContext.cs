

using Microsoft.EntityFrameworkCore;

namespace MetricsManager.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        
    }
}