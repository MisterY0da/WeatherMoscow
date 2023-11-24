using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HPSF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeatherMoscow.Database;
using WeatherMoscow.Models;
using WeatherMoscow.Services;

namespace WeatherMoscow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherRecordController : ControllerBase
    {
        private readonly WeatherMoscowContext _context;
        private readonly IExcelService _excelService;

        public WeatherRecordController(WeatherMoscowContext context, IExcelService excelService)
        {
            _context = context;
            _excelService = excelService;
        }

        [HttpGet]
        public List<WeatherRecord> Get()
        {
            return _context.WeatherRecord.ToList();
        }

        [Route("add")]
        [HttpPost]        
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            string filePath = Path.Combine($"C:\\WeatherRecords", file.FileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var records = _excelService.GetRecordsFromFile(filePath);
            _context.AddRange(records);
            _context.SaveChanges();

            return Ok();
        }
    }
}
