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
//GetDispersion() - Check 
//GetMedian() - Check 
//ReadSalaries() - Check
//ViewMessage() - Check
//ViewResult() - Check
            do
            {
                int noOfSalaries = ReadInt("Ange antal löner att mata in: ");

                if(noOfSalaries < 2)
                {
                    ViewMessage("Du måste mata in minst två löner för att kunna göra en beräkning!", true);
                }
                else
                {
                    int[] salaries = ReadSalaries(noOfSalaries);
                    ViewResult(salaries);
                    
                    //ProcessSalaries(noOfSalaries);
                }
            } while (IsContinuing() == true);

            return;
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
            int dispersion = source.Max() - source.Min();

            return dispersion;
        }
        
        static int GetMedian(int[] source)
        {
            int count = source.Length;
            int median;

            Array.Sort(source);

            if (count % 2 == 1)
            {
                median = source[count / 2];
            }
            else
            {
                median = (source[(count / 2) - 1] + source[count / 2]) / 2;
            }

            return median;
        }

        static bool IsContinuing()
        {
            ViewMessage("\nTryck tangent för ny beräkning - Esc avslutar\n", false);
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
        
        static int[] ReadSalaries(int count)
        {
            int[] salaries = new int[count];

            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt(String.Format("Ange lön nummer {0}: ", i + 1));
            }
            return salaries;
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
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Medianlönen är: {0:c0}", (GetMedian(salaries)));

            Console.WriteLine("Medellönen är: {0:c0}", salaries.Average());

            Console.WriteLine("Lönespridningen är: {0:c0}", GetDispersion(salaries));
            Console.WriteLine("---------------------------------------------");

            //Skriv ut lönerna i originalordning, tre per rad (Här finns antagligen också mycket smartare sätt att göra det på)
            int rowCount = salaries.Length;
            int index = 0;

            Console.WriteLine("Du angav lönerna: ");
            while (rowCount >= 3)
            {
                Console.WriteLine("{0, 10} {1, 10} {2, 10}", salaries[index], salaries[index + 1], salaries[index + 2]);
                index += 3;
                rowCount -= 3;
            }
            if (rowCount == 2)
            {
                Console.WriteLine("{0, 10} {1, 10}", salaries[index], salaries[index + 1]);
                index += 2;
                rowCount -= 2;
            }
            else if (rowCount == 1)
            {
                Console.WriteLine("{0, 10}", salaries[index]);
                index += 1;
                rowCount -= 1;
            }
        }
    }
}
