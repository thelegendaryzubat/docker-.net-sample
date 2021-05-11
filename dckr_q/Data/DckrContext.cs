using Microsoft.EntityFrameworkCore;

namespace dckr_q.Data
{
    public class DckrContext : DbContext
    {
        public DckrContext(DbContextOptions<DckrContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}