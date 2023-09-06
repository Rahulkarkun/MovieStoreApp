using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMovieManager
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(string msg) : base(msg)
        { }
    }
}
