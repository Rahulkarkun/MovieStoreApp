using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMovieManager
{
    [Serializable]
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Movie(string id, string name, string genre, int year)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Year = year;
        }
    }
}
