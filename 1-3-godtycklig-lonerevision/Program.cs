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
                salaries[i] = ReadInt(String.Format("Ange lön nummer {0}: ", i + 1));
            }

//Klona arrayen och sortera den
            int[] salariesSorted = (int[]) salaries.Clone();
            Array.Sort(salariesSorted);

//Hitta medianvärde i den klonade
            double median;
            int medianIndex = count / 2;

            if(count % 2 == 1)
            {
                median = salariesSorted[medianIndex];
            }
            else
            {
                median = ((double)salariesSorted[medianIndex - 1] + salariesSorted[medianIndex]) / 2;
            }

            Console.WriteLine("Medianlönen är {0:c}: ", median);
            

            //Console.WriteLine("Du angav lönerna: ");
            //foreach (int i in salaries)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("Sorterade är de: ");
            //foreach (int i in salariesSorted)
            //{
            //    Console.WriteLine(i);
            //}

        }

        static int ReadInt(string prompt)
        {
            bool startOver = true;
            int count = 0;

            do
            {
                Console.Write(prompt);
                try
                {
                    count = int.Parse(Console.ReadLine());
                    if (count < 0)
                    {
                        throw new SystemException();
                    }
                    startOver = false;
                }
                catch
                {
                    Console.WriteLine("Var vänlig ange ett heltal formaterat som siffror.");
                }
            } while (startOver == true);
            return count;
            
        }
    }
}
