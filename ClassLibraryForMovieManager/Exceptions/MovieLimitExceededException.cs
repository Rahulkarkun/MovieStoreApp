using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMovieManager
{
    public class MovieLimitExceededException : Exception
    {
        public MovieLimitExceededException(string msg) : base(msg)
        { }
    }
}
