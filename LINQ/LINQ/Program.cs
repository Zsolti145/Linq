using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{CLAs
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>()
            {
                9,6,-2,12,98,20,-4,7,5,23
            };
            //LINQ segítségével kérdezzük le a lista taartalmát
            var eredmeny = from szamok in lista
                           select szamok;


            foreach(var elem in eredmeny)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine();
            //Kérdezzük le a listábol a 10-nél nagyobb számokat

            var result = from szamok in lista
                         where szamok > 10
                         select szamok;

            foreach(var item in result)
                Console.WriteLine(item+" ");
            Console.WriteLine();


            //duplikált rekordok szűrése -Distinct






            var result4 = (from szamok in lista
                           select szamok).First();
            Console.WriteLine("A lista első eleme: "+result4);
            Console.WriteLine();

            //Rendezés
            //Rendezzük csökkenő sorrendbe a lista elemeit
            var result5 = from szamok in lista
                          orderby szamok descending
                          select szamok;
            foreach (var item in result5)

                Console.Write( item + " ");
            Console.WriteLine();

            //CSoportosítás

            List<string> állatok = new List<string>()
            {
                "Oroszlán","Zsiráf","Orángután","Pók","Hattyú","Polip","Sün","Lajhár","Ló","Elefánt","Egér"
            };
            //Csoportosítsunk az állatokat a  nevők kezdőbetűje alapján

            var result6 = from nevek in állatok
                          orderby nevek[0]
                          group nevek by nevek[0]
                          into csoport
                          select csoport;
             
            foreach(var csop in result6) 
            {
                Console.WriteLine(csop.Key + ":");
                foreach(var nev in csop)
                    Console.WriteLine("\t"+nev);
            }
        }
    }
}
