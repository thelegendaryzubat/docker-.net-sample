using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace dckr_q.Data
{
    [Table("weather_forecasts")]
    public class WeatherForecast
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
    }
}