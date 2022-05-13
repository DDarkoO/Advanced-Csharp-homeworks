using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_06_homework_advLinq.Models
{
    public static class Helper
    {
        public static void Print<T>(this IEnumerable<T> collection, string tableHeader = null)
        {            
            if (!string.IsNullOrEmpty(tableHeader))
            {
                Console.WriteLine(tableHeader);
                Console.WriteLine(new string('~', tableHeader.Length));
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        public static void HeaderColor(string header)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(header);
            Console.ResetColor();
        }
    }
}
