using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace FotbollsStatReworkedOOP
{

    
    internal class Program
    {
            
        public static List<Lag> lagLista = new List<Lag>();

        static void Main(string[] args)
        {
            Lag lag = new Lag();
            Output output = new Output();


            while (true)
            {

                lag.Sort();

                Console.Clear();
                Console.WriteLine("1. Skapa ny statistik");
                Console.WriteLine("2. Visa statistik");
                Console.WriteLine("3. Lägg till nytt lag");
                Console.WriteLine("4. Avsluta");
                string optionX = Console.ReadLine();
                int option;
                if(int.TryParse(optionX, out option))
                {
                    if (option == 1)
                    {
                        if(lagLista.Count > 1)
                        {
                            lag.NewStats();
                        }
                        else
                        {
                            Console.WriteLine("Det måste finnas fler än två lag för att lägga in statistik!");
                            Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                            Console.ReadKey();
                        }
                        
                    }
                    else if (option == 2)
                    {
                        output.Print();
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                    }
                    else if (option == 3)
                    {
                        lag.NewLag();
                    }
                    else if (option == 4)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning!");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning!");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                }

            }
        }
    }
}
