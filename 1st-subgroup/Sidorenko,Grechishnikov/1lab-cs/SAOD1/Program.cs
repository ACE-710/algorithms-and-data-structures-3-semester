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
            list.Add(555, 3);
            list.RemoveAt(4);
//            list.Remove(1);
//            list.Remove(3);

            for (int i = 0; i < list.GetSize(); i++)
                Console.WriteLine(list.Get(i));
            Console.ReadLine();
        }
    }
}