using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.ConsoleApp.ConsoleUtils
{
    internal interface IConsoleUtils
    {
        public void ConsoleFunction(IEnumerable<Movie> movies);

    }
}
