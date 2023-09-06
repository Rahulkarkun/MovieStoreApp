using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForMovieManager.Exceptions
{
    internal class NoMovieAvailableToClearException:Exception
    {
        public NoMovieAvailableToClearException(string msg) : base(msg)
        { }
    }
}
