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
            //WORKFLOW
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

            //NOTER
            //Göra While/DoWhile-loopar istället för att återanropa funktioner
            bool startOver = true;

            do
            {
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

                startOver = Console.ReadKey(true).Key != ConsoleKey.Escape;

            } while (startOver == true);

            return;
        }

        static void ProcessSalaries(int count)
        {
            int[] salaries = new int[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write("Ange lön nummer {0}: ", i+1);
                salaries[i] = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Du angav lönerna: ");
            foreach (int i in salaries)
            {
                Console.WriteLine(i);
            }

        }

        static int ReadInt(string prompt)
        {
            bool startOver;
            int count = 0;

            do
            {
                startOver = false;

                Console.Write(prompt);
                try
                {
                    count = int.Parse(Console.ReadLine());
                    if (count < 0)
                    {
                        throw new SystemException();
                    }
                }
                catch
                {
                    Console.WriteLine("Var vänlig ange ett heltal formaterat som siffror.");
                    startOver = true;
                }
            } while (startOver == true);
            return count;
            
        }
    }
}
