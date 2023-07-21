using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary
{
    public class Book
    {
        public enum Genre { роман, повесть, драма, комедия, трагикомедия, рассказ }
        
        public int Id { get; set; }
        public string? TitleBook { get; set; }
        public string? Author { get; set; }
        public string GenreBook { get; set; }
        public DateTime? YearRelease { get; set; }
        public int? UserId { get; set; }
        public User? user { get; set; }
    }
}
