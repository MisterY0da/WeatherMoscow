using System.Collections.Generic;
using WeatherMoscow.Models;

namespace WeatherMoscow.Services
{
    public interface IExcelService
    {
        public List<WeatherRecord> GetRecordsFromFile(string filePath);
    }
}
