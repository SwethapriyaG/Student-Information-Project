using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmering_2_projekt
{
    class Menu
    {
        public void MainMenuText() // visar meny till anvender
        {
            //FileMethods fileMethods = new FileMethods();

            Console.WriteLine("\n      Elev           ");
            Console.WriteLine("*************************");
            Console.WriteLine("1: Lägg till elev.");
            Console.WriteLine("2: Ta bort elev.");
            Console.WriteLine("3: Modifiera elev.");
            Console.WriteLine("4: Visa elev.");
            
            Console.WriteLine("\n      Märken          ");
            Console.WriteLine("*************************");
            Console.WriteLine("5: Lägg Märken.");
            Console.WriteLine("6: Ta bort Märken.");
            Console.WriteLine("7: Visa Märken.");
            
            Console.WriteLine("\n      Allmän          ");
            Console.WriteLine("*************************");
            Console.WriteLine("8: Ta bort filen.");
            Console.WriteLine("9: Avslut program");
            Console.WriteLine("\nVälj menyn...");



        }
    }
}
