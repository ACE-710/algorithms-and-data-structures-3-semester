using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD1
{
    class Program
    {
        static MList<int> list = new MList<int>();

        static void ShowMenu()
        {
            Console.WriteLine("1. Add element\n" +
                              "2. Add elementAt\n" +
                              "3. isEmpty\n" +
                              "4. Contains\n" +
                              "5. Get\n" +
                              "6. IndexOf\n" +
                              "7. Remove\n" +
                              "8. Remove At\n" +
                              "9. Clear\n" +
                              "10. GetSize\n" +
                              "11. Show list\n");
        }

        static void ProcessMenu(int pos)
        {
            switch (pos)
            {
                case 1:
                {
                    Console.WriteLine("Enter value: ");
                    list.Add(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter value: ");
                    var val = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter pos: ");
                    list.Add(val, Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                case 3:
                {
                    Console.WriteLine(list.IsEmpty());
                    break;
                }
                case 4:
                {
                    Console.WriteLine("Enter value: ");
                    list.Contains(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                case 5:
                {
                    Console.WriteLine("Enter pos: ");
                    Console.WriteLine(list.Get(Convert.ToInt32(Console.ReadLine())));
                    break;
                }
                case 6:
                {
                    Console.WriteLine("Enter value: ");
                    Console.WriteLine(list.Contains(Convert.ToInt32(Console.ReadLine())));
                    break;
                }
                case 7:
                {
                    Console.WriteLine("Enter element: ");
                    list.Remove(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                case 8:
                {
                    Console.WriteLine("Enter pos: ");
                    list.RemoveAt(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                case 9:
                {
                    list.Clear();
                    break;
                }
                case 10:
                {
                    Console.WriteLine(list.GetSize());
                    break;
                }
                case 11:
                {
                    for (var i = 0; i < list.GetSize(); i++)
                        Console.WriteLine(list.Get(i));
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Change(2, 555);

            var x = -1;
            while (x != 0)
            {
                var inp = Console.ReadLine();
                if (inp.Equals("help"))
                {
                    ShowMenu();
                }
                else
                {
                    x = Convert.ToInt32(inp);
                }

                Console.WriteLine();
                ProcessMenu(x);
            }

            Console.ReadLine();
        }
    }
}