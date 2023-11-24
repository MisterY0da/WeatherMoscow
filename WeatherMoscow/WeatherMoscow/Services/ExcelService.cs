using NPOI.HPSF;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using WeatherMoscow.Models;

namespace WeatherMoscow.Services
{
    public class ExcelService : IExcelService
    {
        public List<WeatherRecord> GetRecordsFromFile(string filePath)
        {
            List<WeatherRecord> records = new List<WeatherRecord>();

            XSSFWorkbook workbook;

            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file);
            }

            var sheet = workbook.GetSheetAt(0);

            for (int rowIndex = 4; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);

                decimal? temperature = null;
                decimal? humidity = null;
                decimal? dewPoint = null;
                int? pressure = null;
                int? windSpeed = null;
                int? cloudiness = null;
                int? cloudinessLowerBound = null;
                int? horizontalVisibility = null;

                if (!row.GetCell(2).ToString().Trim().Equals(""))
                {
                    temperature = decimal.Parse(row.GetCell(2).ToString().Trim());
                }

                if (!row.GetCell(3).ToString().Trim().Equals(""))
                {
                    humidity = decimal.Parse(row.GetCell(3).ToString().Trim());
                }

                if (!row.GetCell(4).ToString().Trim().Equals(""))
                {
                    dewPoint = decimal.Parse(row.GetCell(4).ToString().Trim());
                }

                if (!row.GetCell(5).ToString().Trim().Equals(""))
                {
                    pressure = int.Parse(row.GetCell(5).ToString().Trim());
                }

                if (!row.GetCell(7).ToString().Trim().Equals(""))
                {
                    windSpeed = int.Parse(row.GetCell(7).ToString().Trim());
                }

                if (!row.GetCell(8).ToString().Trim().Equals(""))
                {
                    cloudiness = int.Parse(row.GetCell(8).ToString().Trim());
                }

                if (!row.GetCell(9).ToString().Trim().Equals(""))
                {
                    cloudinessLowerBound = int.Parse(row.GetCell(9).ToString().Trim());
                }

                if (!row.GetCell(10).ToString().Trim().Equals(""))
                {
                    horizontalVisibility = int.Parse(row.GetCell(10).ToString().Trim());
                }

                records.Add(new WeatherRecord
                {
                    Date = row.GetCell(0) != null ? row.GetCell(0).ToString() : "",
                    Time = row.GetCell(1) != null ? row.GetCell(1).ToString() : "",
                    Temperature = temperature,
                    Humidity = humidity,
                    DewPoint = dewPoint,
                    Pressure = pressure,
                    WindDirection = row.GetCell(6) != null ? row.GetCell(6).ToString() : "",
                    WindSpeed = windSpeed,
                    Cloudiness = cloudiness,
                    CloudinessLowerBound = cloudinessLowerBound,
                    HorizontalVisibility = horizontalVisibility,
                    WeatherConditions = row.GetCell(11) != null ? row.GetCell(11).ToString() : ""
                });
            }

            return records;
        }
    }
}
