using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Lakcim
    {
        public string Orszag;
        public string Varos;
        public string Utca;
        public int Hazszam;
    }
    class Alkalmazott
    {
        public string ID;
        public string Nev;
        public string Email;
        public Lakcim Cim;
    }

    class Termek
    {
        public string Nev;
        public string Sorszam;
        public string GyartoID; //Kapcsolo mező
        public DateTime Elkeszült;

    }
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


            //Projekcio
            List<Alkalmazott> alkalmazottak = new List<Alkalmazott>()
            {
                new Alkalmazott()
                {
                    ID ="Abc123",
                    Nev = "Kiss Irén",
                    Email = "irenke123@ceges.hu",
                    Cim = new Lakcim()
                    {
                        Orszag = "Magyarorszag",
                        Varos = "Kecskemét",
                        Utca = "Kossuth út",
                        Hazszam = 19
                    }
                },
                new Alkalmazott()
                {
                    ID ="XYZ987",
                    Nev = "Vak Bela",
                    Email = "bela_vak@ceges.hu",
                    Cim = new Lakcim()
                    {
                        Orszag = "Magyarorszag",
                        Varos = "Lajosmizse",
                        Utca = "Petőfi Sándor utca",
                        Hazszam = 2
                    }
                }
            };

            //Írjuk ki az alkalmazottakat (Név,Email)

            var result7 = from ember in alkalmazottak
                          select new
                          {
                              ember.Nev,
                              ember.Email
                          };

            foreach(var item in result7)
                Console.WriteLine("Név "+item.Nev+", Email: "+item.Email);
            Console.WriteLine();


            //Lekérdezésen belül változó létrehozása - Let
            string[] vers = new string[]
            {
                "Elvadult tájon gázolok:",
                "Ős,buja földön dudva, muhar.",
                "Ezt a vad mezőt ismerem,",
                "Ez a magyar Ugar."
            };
            //Szeretném szavanként szétvágni a verset!

            var result8 = from sor in vers
                            let szavak = sor.Split(' ')
                            from szo in szavak
                            select szo;

            foreach(var item in result8)
                Console.WriteLine(item);

            //Melyik a leghosszabb szó?
            var leghosszabb = (from szo in result8
                               orderby szo.Length descending
                               select new
                               {
                                   szo,
                                   hossz = szo.Length
                               }).First();
            Console.WriteLine("Leghosszabb szó: "+leghosszabb.szo+", karakterek száma: "+leghosszabb.hossz);
            //Ugyan ez allekérdezéssel

            var max = (from szo in result8
                       orderby szo.Length descending
                       select new
                       {
                           hossz = szo.Length
                       }).First();

            var leghosszabb2 = from szavak in result8
                               where szavak.Length == max.hossz
                               select szavak;

            Console.WriteLine("A leghosszabb szavak: ");
            foreach(var item in leghosszabb2)
                Console.WriteLine("\t"+item);


            //objektumok összekapcsolása
            List<Termek> termekek = new List<Termek>()
            {
                new Termek()
                {
                    Nev = "Gyerekjáték",
                    Sorszam = "qwert98ik",
                    GyartoID = "XYZ987",
                    Elkeszült = new DateTime(2020,10,2)
                },
                new Termek()
                {
                    Nev = "Társasjáték",
                    Sorszam = "uhjnk123ert",
                    GyartoID = "XYZ987",
                    Elkeszült = new DateTime(2021,1,8)
                },
                new Termek()
                {
                    Nev = "Mikrohullámú sütő",
                    Sorszam = "MNVJ419CD",
                    GyartoID = "Abc123",
                    Elkeszült = new DateTime(2020,3,29)
                },
            };
            alkalmazottak.Add(
                new Alkalmazott()
                {
                    ID = "IQ123",
                    Nev = "Charlie",
                    Email = "charlie1234@gmail.com",
                    Cim = new Lakcim()
                    {
                        Orszag = "Egyseült Királyság",
                        Varos = "London",
                        Utca = "21. Street",
                        Hazszam = 123
                    }
                }) ;
            //Listázzuk ki, hoigy mely alkalmazott milyen terméket gyártott! -INNER JOIN
            var resTermekek = from ember in alkalmazottak
                              join termek in termekek on ember.ID equals termek.GyartoID
                              select new
                              {
                                AlkNév = ember.Nev,
                                 TermékNév = termek.Nev
                              };
        }

    }
}
