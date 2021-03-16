using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_NyelviEszkozok
{
    public static class Kiterjesztett
    {
        public static string Reverse(this string input)
        {
            string s = "";
            for (int i = input.Length - 1; i > 0; i--)
                s += input[i];
            return s;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {

            string s = "Alma";
            Console.WriteLine(s.Reverse());
            
        }
    }
}
