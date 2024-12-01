using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class StartMenu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("    KASSASYSTEMET    ");
                Console.WriteLine("\nVälj ett av följande alternativ.");
                Console.WriteLine("1. Ny kund");
                Console.WriteLine("2. Avsluta");
                Console.WriteLine("");

                if (!int.TryParse(Console.ReadLine(), out int inputStartChoice) ||
                    (inputStartChoice != 1 && inputStartChoice != 2))
                {
                    Console.WriteLine("Felaktigt val. Var god försök igen.");
                    Console.ReadKey();
                    continue;
                }

                HandleMenuChoice(inputStartChoice);
            }
        }

        private void HandleMenuChoice(int choice)
        {
            if (choice == 1)
            {
                var productDisplay = new ProductDisplay();
                productDisplay.ShowProductsInConsole();
                Console.ReadKey();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Du har avslutat kassasystemet");
                Environment.Exit(0);
            }
        }
    }
}

