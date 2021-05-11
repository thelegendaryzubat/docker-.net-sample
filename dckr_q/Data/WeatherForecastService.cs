using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dckr_q.Data
{
    public class WeatherForecastService
    {
        private readonly DckrContext _context;

        public WeatherForecastService(DckrContext context)
        {
            _context = context;
        }
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<WeatherForecast>> GetForecastAsync()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }

        public async Task AddForecastAsync()
        {
            var result = await _context.WeatherForecasts.AddAsync(new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = new Random().Next(-10, 25)
            });
            await _context.SaveChangesAsync();
        }
    }
}