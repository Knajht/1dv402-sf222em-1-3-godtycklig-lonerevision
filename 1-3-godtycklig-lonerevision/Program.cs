using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_godtycklig_lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarera variabler
            //Input: Antal löner
            //Input: Varje lön
            //Skicka till array
            //Kopiera till medianarray, sorteras
            //Beräkna medianlön, presentera
            //Beräkna medellön, presentera
            //Beräkna lönespridning, presentera
            //Presentera de inmatade lönerna
            //Börja om med tangent - Avsluta med esc |- Check, kanske finputsas
            

            int noOfSalaries = ReadInt("Ange antal löner att mata in: ");

            if(noOfSalaries < 2)
            {
                Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
            }
            else
            {
                ProcessSalaries(noOfSalaries);
            }

            Console.WriteLine("Tryck tangent för ny beräkning - Esc avslutar");
            
            if((Console.ReadKey(true).Key != ConsoleKey.Escape) == true)
            {
                Main(null);
            }
            else
            {
                return;
            }



        }

        static void ProcessSalaries(int count)
        {
            
        }

        static int ReadInt(string prompt)
        {
            int count = 0;

            Console.Write(prompt);
            try
            {
                count = int.Parse(Console.ReadLine());
                if(count < 0)
                {
                    throw new SystemException();
                }
            }
            catch
            {
                Console.WriteLine("Var vänlig ange ett heltal formaterat som siffror.");
                ReadInt(prompt);
            }
            return count;
            
        }
    }
}
