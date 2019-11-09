using System;
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
                              "6. Show list\n");
        }

        private static void processMenu(Bst<int> tree, int pos) {
            switch (pos) {
                case 1: {
                    Console.WriteLine("Enter key and value: ");
                    var input = Console.ReadLine().Split(" ").ToArray();
                    var position = Convert.ToInt32(input[0]);
                    var elem = Convert.ToInt32(input[1]);
                    tree.insert(position, elem);
                    break;
                }
                case 2: {
                    Console.WriteLine(tree.isEmpty);
                    break;
                }
                case 3: {
                    Console.WriteLine("Enter pos: ");
                    Console.WriteLine(tree[Convert.ToInt32(Console.ReadLine())]);
                    break;
                }
                case 4: {
                    Console.WriteLine("Remove pos: ");
                    tree.remove(Convert.ToInt32(Console.ReadLine()));
                    break;
                }
                case 5: {
                    tree.clear();
                    break;
                }
                case 6: {
                    tree.printTree();
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