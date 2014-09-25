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

            Console.WriteLine("Medianlönen är: {0:c}", Math.Round(median));
            
//Hitta medellön i originalarrayen
            Console.WriteLine("Medellönen är: {0:c}", Math.Round(salaries.Average()));

//Hitta lönespridning
            Console.WriteLine("Lönespridningen är: {0:c}",salaries.Max() - salaries.Min());

//Skriv ut lönerna i originalordning, tre per rad

            int rowCount = count;
            int index = 0;

            Console.WriteLine("Du angav lönerna: ");
            while(rowCount >= 3)
            {
                Console.WriteLine(String.Format("{0, 10} {1, 10} {2, 10}", salaries[index], salaries[index + 1], salaries[index + 2]));
                index += 3;
                rowCount -= 3;
            }
            if(rowCount == 2)
            {
                Console.WriteLine("{0, 10} {1, 10}", salaries[index], salaries[index + 1]);
                index += 2;
                rowCount -= 2;
            }
            else if(rowCount == 1)
            {
                Console.WriteLine("{0, 10}", salaries[index]);
                index += 1;
                rowCount -= 1;
            }
            else
            {
                return;
            }

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
