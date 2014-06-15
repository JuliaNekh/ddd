using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table
{
    class Program
    {
        static void Main(string[] args)
        {
            int k=1;
            while (k == 1)
            {
                Console.WriteLine("введите ключ элемента");
                string key = Console.ReadLine();
                Console.WriteLine(" введите значение элемента");
                string inf = Console.ReadLine();
                Hash c = new Hash();
                c.Add(key, inf);
                Console.WriteLine(c.HashFunction(key));
                Console.WriteLine("добавить еще элементы? 1 - добавить, 0 - закончить добавление");
                k = Convert.ToInt16(Console.ReadLine());
            }
            Console.ReadKey();
        }
    }
}
