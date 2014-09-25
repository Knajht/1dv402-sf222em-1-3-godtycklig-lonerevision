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
            do
            {
                int noOfSalaries = ReadInt("Ange antal löner att mata in: ");

                if(noOfSalaries < 2)
                {
                    ViewMessage("Du måste mata in minst två löner för att kunna göra en beräkning!", ConsoleColor.DarkRed, ConsoleColor.White);
                }
                else
                {
                    int[] salaries = ReadSalaries(noOfSalaries);
                    ViewResult(salaries);
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
                        throw new ArgumentOutOfRangeException();
                    }
                    startOver = false;
                }
                catch
                {
                    ViewMessage("Var vänlig ange ett positivt heltal formaterat som siffror.\n", ConsoleColor.Red, ConsoleColor.Black);
                }
            } while (startOver == true);
            return count;
        }

        static bool IsContinuing()
        {
            ViewMessage("\nTryck tangent för ny beräkning - Esc avslutar\n", ConsoleColor.Blue, ConsoleColor.Yellow);
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

        static void ViewMessage(string message, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ResetColor();


            
        }

        static void ViewResult(int[] salaries)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Medianlönen är: {0:c0}", MyExtensions.Median(salaries));

            Console.WriteLine("Medellönen är: {0:c0}", salaries.Average());

            Console.WriteLine("Lönespridningen är: {0:c0}", MyExtensions.Dispersion(salaries));
            Console.WriteLine("---------------------------------------------");

//Det här är min gamla presentation av lönerna. Nu har jag hittat ett bättre sätt (Se nedan) men 
//eftersom jag hittade det hos en av förra årets elever (pn222ez) på GitHub i samma labb vill jag låta detta
//stå kvar om ni skulle anse det vara fusk. Märk väl, jag kopierade inte någonting utan kollade igenom det
//och skrev en egen version. Bara så ni vet.

            //int rowCount = salaries.Length;
            //int index = 0;

            //Console.WriteLine("Du angav lönerna: ");
            //while (rowCount >= 3)
            //{
            //    Console.WriteLine("{0, 10} {1, 10} {2, 10}", salaries[index], salaries[index + 1], salaries[index + 2]);
            //    index += 3;
            //    rowCount -= 3;
            //}
            //if (rowCount == 2)
            //{
            //    Console.WriteLine("{0, 10} {1, 10}", salaries[index], salaries[index + 1]);
            //    index += 2;
            //    rowCount -= 2;
            //}
            //else if (rowCount == 1)
            //{
            //    Console.WriteLine("{0, 10}", salaries[index]);
            //    index += 1;
            //    rowCount -= 1;
            //}

            int index = 0;

            foreach (int i in salaries)
            {
                Console.Write("{0, 15}", i);
                if (((index + 1) % 3) == 0)
                {
                    Console.WriteLine();
                }
                index++;
            }
        }
    }
    public static class MyExtensions
    {
        public static int Dispersion(this int[] source)
        {
            int dispersion = source.Max() - source.Min();

            return dispersion;
        }

        public static int Median(this int[] source)
        {
            int count = source.Length;
            int median;
            int[] clone = (int[])source.Clone();

            Array.Sort(clone);
            if (count % 2 == 1)
            {
                median = clone[count / 2];
            }
            else
            {
                median = (clone[(count / 2) - 1] + clone[count / 2]) / 2;
            }

            return median;
        }
    }
}
