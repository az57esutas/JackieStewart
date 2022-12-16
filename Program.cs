using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Jackie
{
    internal class Program
    {
        public class Data
        {
            private int year;
            public int Year
            {
                get 
                { 
                    return year; 
                }
                set 
                { 
                    year = value; 
                }
            }

            private int races;
            public int Races
            {
                get 
                { 
                    return races; 
                }
                set 
                { 
                    races = value; 
                }
            }

            private int wins;
            public int Wins
            {
                get 
                { 
                    return wins; 
                }
                set 
                { 
                    wins = value; 
                }
            }

            private int podiums;
            public int Podiums
            {
                get 
                { 
                    return podiums; 
                }
                set 
                { 
                    podiums = value; 
                }
            }

            private int poles;
            public int Poles
            {
                get 
                { 
                    return poles; 
                }
                set 
                { 
                    poles = value; 
                }
            }

            private int fastests;
            public int Fastests
            {
                get 
                { 
                    return fastests; 
                }
                set 
                { 
                    fastests = value; 
                }
            }
        }

        static void Harmadikfeladat(List<Data> list)
        {
            Console.WriteLine("3. feladat: {0}", list.Count);
        }

        static void Negyedikfeladat(List<Data> list)
        {
            int max_races = 0;
            int max_index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Races > max_races)
                {
                    max_races= list[i].Races;
                    max_index= i;
                }
            }
            Console.WriteLine("4. feladat: {0}", list[max_index].Year);
        }

        static void Otodikfeladat(List<Data> list)
        {

            int hetvenes_evek_wins = 0;
            int hatvanas_evek_wins = 0;

            Console.WriteLine("5. feladat: ");

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Year / 10 == 196)
                {
                    hatvanas_evek_wins += list[i].Wins;
                }

                if (list[i].Year / 10 == 197)
                {
                    hetvenes_evek_wins += list[i].Wins;
                }

            }
            Console.WriteLine("       70-es évek: {0} megnyert verseny", hetvenes_evek_wins);
            Console.WriteLine("       60-es évek: {0} megnyert verseny", hatvanas_evek_wins);
        }

        static void Hatodikfeladat(List<Data> list)
        {
            FileStream fs = null;
            string path = "jackie.html";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("<!doctype html>");
                    sw.WriteLine("<html>");
                    sw.WriteLine("<head></head>");
                    sw.WriteLine("<style>td { border:1px solid black;}</style>");
                    sw.WriteLine("<body>");
                    sw.WriteLine("<h1>Jackie Stewart</h1>");
                    sw.WriteLine("<table>");
                    for (int i = 0; i < list.Count; i++)
                    {
                        sw.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", list[i].Year, list[i].Races, list[i].Wins);
                    }
                    sw.WriteLine("</table>");
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                }
            }
            Console.WriteLine("6. feladat: jackie.html létrehozása");
        }
        
        static void Main(string[] args)
        {
            string path = "jackie.txt";            
            List<Data> lista = new List<Data>();
            StreamReader sr = new StreamReader(path);

            try
            {
                string sor;
                while(!sr.EndOfStream) 
                {
                    sor = sr.ReadLine();
                    if (sor != "year\traces\twins\tpodiums\tpoles\tfastests")
                    {
                        string[] darabok = sor.Split('\t');
                        
                        Data adatok = new Data();
                        adatok.Year = Convert.ToInt32(darabok[0]);
                        adatok.Races = Convert.ToInt32(darabok[1]);
                        adatok.Wins = Convert.ToInt32(darabok[2]);
                        adatok.Podiums = Convert.ToInt32(darabok[3]);
                        adatok.Poles = Convert.ToInt32(darabok[4]);
                        adatok.Fastests = Convert.ToInt32(darabok[5]);
                        
                        lista.Add(adatok);
                    }                    
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Fájl olvasási hiba");
                Console.WriteLine(e.Message);
                throw;
            }
            
            // a harmadik feladat:
            Harmadikfeladat(lista);
            // a negyedik feladat:
            Negyedikfeladat(lista);
            // az ötödik feladat:
            Otodikfeladat(lista);
            // a hatodik feladat:
            Hatodikfeladat(lista);

            Console.ReadKey();
        }
    }
}
