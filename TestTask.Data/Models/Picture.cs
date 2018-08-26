using System;

namespace TestTask.Data.Models
{
    public class Picture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Gps { get; set; }
        public string Exif { get; set; }
    }
}
