using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table
{
    class Hash
    {
        public MyList[] table;
        public bool IsEmpty;
        public Hash()
        {
            IsEmpty = true;
            table = new MyList[1621];
        }

        public int HashFunction(string key)        
        {
            char[] tmp = key.ToCharArray();
            int p = 0;
            for (int i = 0; i < tmp.Length; i++)
                p = p + tmp[i];                    
            double f = p * 0.36;                   
            f = f - (int)f;                        
            double HashKey = 31 * f;               
            return (int)HashKey;                   
        }

        public void Add(string key, string inf)
        {
            int Hkey = HashFunction(key);
            MyList c = new MyList();
            c.Add(key, inf);
            table[Hkey] = c;
            IsEmpty = false;
        }
        public void Delete(string key, string inf)
        {
            if (IsEmpty) throw new InvalidOperationException();
            else
            {
                int HKey = HashFunction(key);
                MyList c = table[HKey];
                c.Delete(inf);
            }
        }

        public string Search(string key)
        {
            int Hkey = HashFunction(key);
            MyList c = table[Hkey];
            MyNode k = c.GetNode(key);
            return k.inf;
        }
    }
}
