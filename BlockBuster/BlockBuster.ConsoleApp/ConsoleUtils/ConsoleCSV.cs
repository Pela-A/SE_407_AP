using BlockBuster.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.ConsoleApp.ConsoleUtils
{
    public class ConsoleCSV : IConsoleUtils
    {
        public void ConsoleFunction(IEnumerable<Movie> movies)
        {
            using (var streamWriter = new StreamWriter("..\\Movies.csv"))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {

                    csvWriter.WriteRecords(movies);
                }
            }
        }
    }
}
