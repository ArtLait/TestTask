using System;
using TestTask.Data.Models;

namespace TestTask.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Gps { get; set; }
        public string Exif { get; set; }
    }
}
