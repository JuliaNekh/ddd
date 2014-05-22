using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree_cl q = new Tree_cl();
            q.Add(5);
            q.Add(3);
            q.Add(4);
            q.Add(2);
            q.Add(8);
            q.Add(7);
            q.Add(19);
            q.Add(6);
            q.Add(10);
            q.Add(9);
            q.Add(13);
            q.Add(12);
            q.Add(119);
            q.Add(111);
            q.Add(120);
            q.Writer("test.txt");
            q.SimpleDelete(3);
            q.Writer("DeleteTest.txt"); 
            q.NormalDelete(19);
            q.Writer("NormalDelete.txt");
        }
    }
}
