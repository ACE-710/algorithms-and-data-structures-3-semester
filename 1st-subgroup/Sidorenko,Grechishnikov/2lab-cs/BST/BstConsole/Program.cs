using System;

namespace BstConsole {
    class Program {
        // ReSharper disable once InconsistentNaming
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
            tree.insert(2, 58);
            tree.insert(6, 59);
            tree.insert(7, 512);
            tree.insert(5, 511);
            tree.insert(5, 513);
            tree.insert(3, 515);
            tree.insert(2, 516);
            tree.insert(6, 517);
            tree.insert(7, 518);
            tree.insert(5, 519);
            tree.insert(4, 519);

            Console.WriteLine(tree.size);
            
            tree.printTree();
            
            //tree.iterator.setValue(510);
            
            Console.WriteLine(tree[6]);
            Console.Read();
        }
    }
}