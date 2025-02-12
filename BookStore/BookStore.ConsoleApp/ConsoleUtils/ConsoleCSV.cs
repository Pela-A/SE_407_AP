using BookStore.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleApp.ConsoleUtils
{
    public class ConsoleCSV : IConsoleUtils
    {
        public void ConsoleFunction(IEnumerable<Book> books)
        {
            using (var streamWriter = new StreamWriter("..\\Books.csv"))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {

                    csvWriter.WriteRecords(books);
                }
            }
        }
    }
}
