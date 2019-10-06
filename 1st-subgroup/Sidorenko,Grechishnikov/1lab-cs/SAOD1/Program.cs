using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var list = new MList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.GetIterator().Next();
            Console.WriteLine(list.GetIterator().Get());

            list.GetIterator().Set(4546);
            Console.WriteLine();
            for (var i = 0; i < list.GetSize(); i++)
                Console.WriteLine(list.Get(i));
            Console.ReadLine();
        }
    }
}