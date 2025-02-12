using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleApp.ConsoleUtils
{
    internal interface IConsoleUtils
    {
        public void ConsoleFunction(IEnumerable<Book> books);

    }
}
