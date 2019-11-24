using System;
using System.Collections.Generic;
using System.Linq;

namespace BstConsole {
    class Program {
        // ReSharper disable once InconsistentNaming

        private static void showMenu() {
            Console.WriteLine("0. Exit()\n" +
                              "1. Insert element\n" +
                              "2. isEmpty\n" +
                              "3. Get\n" +
                              "4. remove\n" +
                              "5. Clear\n" +
                              "6. Show list\n" +
                              "7. Test deg tree\n" +
                              "8. Test random tree\n");
            
        }

        private static void processMenu(Bst<int> tree, int pos)
        {
            switch (pos)
            {
                case 1:
                {
                    Console.WriteLine("Enter key and value: ");
                    var input = Console.ReadLine().Split(" ").ToArray();
                    var position = Convert.ToInt32(input[0]);
                    var elem = Convert.ToInt32(input[1]);
                    tree.insert(position, elem);
                    break;
                }
                case 2:
                {
                    Console.WriteLine(tree.isEmpty);
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Enter pos: ");
                    Console.WriteLine(tree[Convert.ToInt32(Console.ReadLine())]);
                    break;
                }
                case 4:
                {
                    Console.WriteLine("Remove pos: ");
                    tree.remove(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                case 5:
                {
                    tree.clear();
                    break;
                }
                case 6:
                {
                    tree.printTree();
                    break;
                }
                case 7:
                {
                    Random rand = new Random();
                    int n = 1000;
                    var testtree = new Bst<int>();
                    List<int> m = new List<int>(n);

                    for (int i = 0; i < n; i++)
                    {
                        m.Add(rand.Next(n));
                        testtree.insert(m[i], 1);
                    }

                    testtree.getCount();
                    double I = 0;
                    double D = 0;
                    double S = 0;

                    for (int i = 0; i < n / 2; i++)
                    {
                        int k = rand.Next(n);
                        testtree.remove(k);
                        D += testtree.getCount();
                        testtree.insert(m[k], 1);
                        I += testtree.getCount();
                        testtree.getValueByKey(k);
                        S += testtree.getCount();
                    }

                    Console.WriteLine(1.39 * Math.Log(n));
                    Console.WriteLine("Вставка:");
                    Console.WriteLine(I / (n / 2));
                    Console.WriteLine("Удаление:");
                    Console.WriteLine(D / (n / 2));
                    Console.WriteLine("Поиск:");
                    Console.WriteLine(S / (n / 2));
                    break;
                }
                case 8:
                {
                    Random rand = new Random();
                    int n = 1000;
                    var testtree = new Bst<int>();
                    List<int> m = new List<int>(n);

                    for (int i = 0; i < n; i++)
                    {
                        m.Add(i);
                        testtree.insert(m[i], 1);
                    }
                    testtree.getCount();
                    double I = 0;
                    double D = 0;
                    double S = 0;

                    for (int i = 0; i < n / 2; i++)
                    {
                        int k = rand.Next(n);
                        testtree.getCount();
                        testtree.remove(k);
                        D += tree.getCount();
                        tree.insert(m[k], 1);
                        I += tree.getCount();
                        testtree.getValueByKey(k);
                        S += tree.getCount();
                    }
                    Console.WriteLine(1.39 * Math.Log(n));
                    Console.WriteLine("Вставка:");
                    Console.WriteLine(I / (n / 2));
                    Console.WriteLine("Удаление:");
                    Console.WriteLine(D / (n / 2));
                    Console.WriteLine("Поиск:");
                    Console.WriteLine(S / (n / 2));
                    break;
                }
            }
        }

        static void Main() {
            var tree = new Bst<int>();

            tree.insert(5, 5);
            tree.insert(3, 51);
            tree.insert(2, 52);
            tree.insert(7, 54);
            tree.insert(6, 53);
            tree.insert(8, 55);
            tree.insert(32, 56);
            tree.insert(7, 57);
            tree.insert(23, 58);
            tree.insert(62, 59);
            tree.insert(71, 512);
            tree.insert(54, 511);
            tree.insert(55, 513);
            tree.insert(36, 515);
            tree.insert(2, 516);
            tree.insert(6, 517);
            tree.insert(7, 518);
            tree.insert(5, 519);
            tree.insert(4, 519);
            
            tree.printTree();

            var x = -1;
            while (x != 0)
            {
                showMenu();
                var inp = Console.ReadLine();
                if (inp.Equals("help"))
                {
                    showMenu();
                }
                else
                {
                    x = Convert.ToInt32(inp);
                }

                Console.WriteLine();
                processMenu(tree, x);
            }

            Console.ReadLine();
        }
    }
}