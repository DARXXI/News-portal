using AdminPanel.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Console
{
    public static class Program_2
    {
        public static int CharCount(this string someString, char exactLetter)
        {
            int counter = 0;
            foreach (var symbol in someString)
            {
                if (symbol == exactLetter)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
