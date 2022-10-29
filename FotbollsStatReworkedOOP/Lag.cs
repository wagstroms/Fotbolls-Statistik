using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FotbollsStatReworkedOOP
{
    internal class Lag
    {
        public string Namn { get; set; }
        public int Poäng { get; set; }
        public int Mål { get; set; }
        public int Insläptta { get; set; }
        public int Målskillnad { get; set; }
        public int Matcher { get; set; }
        public int Vinster { get; set; }
        public int Lika { get; set; }
        public int Förluster { get; set; }

        public void Sort()
        {
            Program.lagLista = Program.lagLista.OrderByDescending(x => x.Poäng)
                .ThenByDescending(x => x.Målskillnad)
                .ThenByDescending(x => x.Mål)
                .ToList();
        }
        
        public void NewStats()
        {
            
            Console.Write("Hemmalag : ");
            string hemmalag = Console.ReadLine();
            int hemlag;
            while(true)
            {
                while(!int.TryParse(hemmalag, out hemlag) || hemlag <= 0 || hemlag > Program.lagLista.Count())
                {
                    Console.WriteLine("Felaktig inmatning, detta lag finns inte!");
                    Console.Write("Hemmalag : ");
                    hemmalag = Console.ReadLine();
                }
                while(int.TryParse(hemmalag, out hemlag))
                {
                    if(hemlag >= 1 && hemlag <= Program.lagLista.Count())
                    {
                        Console.WriteLine("Bra input");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Brutalt fel, kolla igenom koden..");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                break;
               
            }
            Console.Write("Bortalag : ");
            string bortalag = Console.ReadLine();
            int bortlag;
            while (true)
            {
                while (!int.TryParse(bortalag, out bortlag) || bortlag <= 0 || bortlag > Program.lagLista.Count() || bortlag == hemlag)
                {
                    Console.WriteLine("Felaktig inmatning, detta lag finns inte!");
                    Console.Write("Bortalag : ");
                    bortalag = Console.ReadLine();
                }
                while (int.TryParse(bortalag, out bortlag))
                {
                    if (bortlag >= 1 && bortlag <= Program.lagLista.Count())
                    {
                        Console.WriteLine("Bra input");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Brutalt fel, kolla igenom koden..");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                break;
                
            }

            Console.Write("Mål-Insläpp : ");
            string resultat = Console.ReadLine();
            int mål;
            int insläpp;
            while (true)
            {
                string[] resSplit = resultat.Split('-');

                if(!int.TryParse(resSplit[0], out mål) || !int.TryParse(resSplit[1], out insläpp))
                {
                    while (!int.TryParse(resSplit[0], out mål) || !int.TryParse(resSplit[1], out insläpp))
                    {
                        resSplit = resultat.Split('-');
                        if (int.TryParse(resSplit[0], out mål) && int.TryParse(resSplit[1], out insläpp))
                        {
                            break;
                        }
                        Console.WriteLine("Felaktig inmatning, försök igen!");
                    Console.Write("Mål-Insläpp : ");
                    resultat = Console.ReadLine();
                    }
                }
                break;
            }
            ProcessStats(mål, insläpp, hemlag, bortlag);
         
        }
        public void ProcessStats(int mål, int insläpp, int hemlag, int bortlag) 
        {
            Program.lagLista[hemlag].Matcher++;
            Program.lagLista[bortlag].Matcher++;

            if (mål > insläpp)
            {
                Program.lagLista[hemlag].Poäng += 3;
                Program.lagLista[hemlag].Vinster++;
                Program.lagLista[bortlag].Förluster++;
            }
            else if (mål < insläpp)
            {
                Program.lagLista[bortlag].Poäng += 3;
                Program.lagLista[bortlag].Vinster++;
                Program.lagLista[hemlag].Förluster++;
            }
            else if (mål == insläpp)
            {
                Program.lagLista[hemlag].Poäng++;
                Program.lagLista[bortlag].Poäng++;
                Program.lagLista[hemlag].Lika++;
                Program.lagLista[bortlag].Lika++;
            }
        }

        public void NewLag()
        {
            Console.WriteLine("Vad heter laget?");
            string Namn = Console.ReadLine();

            Lag lag = new Lag();
            lag.Namn = Namn;
            Program.lagLista.Add(lag);
        }

        
        
    }
}
