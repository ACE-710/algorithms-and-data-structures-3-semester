using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(50, 0);

            for (int i = 0; i < list.GetSize(); i++)
                Console.WriteLine(list.Get(i));
            Console.ReadLine();
        }
    }
}
