namespace WeatherMoscow.Models
{
    public partial class WeatherRecord
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? DewPoint { get; set; }
        public int? Pressure { get; set; }
        public string WindDirection { get; set; }
        public int? WindSpeed { get; set; }
        public int? Cloudiness { get; set; }
        public int? CloudinessLowerBound { get; set; }
        public int? HorizontalVisibility { get; set; }
        public string WeatherConditions { get; set; }
    }
}
