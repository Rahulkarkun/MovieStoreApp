using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMovieManager
{
    public class MovieNotAvailableForYearException : Exception
    {
        public MovieNotAvailableForYearException(string msg) : base(msg)
        { }
    }
}
