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
//METODER ATT IMPLEMENTERA
//IsContinuing() - Check
//GetDispersion()
//GetMedian()
//ReadSalaries()
//ViewMessage() - Check
//ViewResult()
            do
            {
                int noOfSalaries = ReadInt("Ange antal löner att mata in: ");

                if(noOfSalaries < 2)
                {
                    ViewMessage("Du måste mata in minst två löner för att kunna göra en beräkning!", true);
                }
                else
                {
                    ProcessSalaries(noOfSalaries);
                }
            } while (IsContinuing() == true);

            return;
        }

        static void ProcessSalaries(int count)
        {
            int[] salaries = new int[count];

            Console.WriteLine("");

            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt(String.Format("Ange lön nummer {0}: ", i + 1));
            }

            Console.WriteLine("");

//Klona arrayen och sortera den
            int[] salariesSorted = (int[]) salaries.Clone();
            Array.Sort(salariesSorted);

//Hitta medianvärde i den klonade (Klumpig funktion, kommer dock inte på något smartare just nu)
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
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Medianlönen är: {0:c0}", Math.Round(median));
            
//Hitta medellön i originalarrayen
            Console.WriteLine("Medellönen är: {0:c0}", Math.Round(salaries.Average()));

//Hitta lönespridning
            Console.WriteLine("Lönespridningen är: {0:c0}",salaries.Max() - salaries.Min());
            Console.WriteLine("---------------------------------------------");

//Skriv ut lönerna i originalordning, tre per rad (Här finns antagligen också mycket smartare sätt att göra det på)
            int rowCount = count;
            int index = 0;

            Console.WriteLine("Du angav lönerna: ");
            while(rowCount >= 3)
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10}", salaries[index], salaries[index + 1], salaries[index + 2]);
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
                    ViewMessage("Var vänlig ange ett positivt heltal formaterat som siffror.\n", true);
                }
            } while (startOver == true);
            return count;
            
        }

        static int GetDispersion(int[] source)
        {
            throw new NotImplementedException();
        }
        
        static int GetMedian(int[] source)
        {
            throw new NotImplementedException();
        }

        static bool IsContinuing()
        {
            ViewMessage("\nTryck tangent för ny beräkning - Esc avslutar\n", false);
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
        
        static int[] ReadSalaries(int count)
        {
            throw new NotImplementedException();
        }

        static void ViewMessage(string message, bool isError)
        {
            if(isError == true)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            
        }

        static void ViewResult(int[] salaries)
        {
            throw new NotImplementedException();
        }
    }
}
