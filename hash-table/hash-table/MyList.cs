using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table
{
    class MyList
    {
        public MyNode head;             // голова списка
        public int count;               // число элементов
        public bool isEmpty;
        public MyList()                 // Конструктор
        {
            head = null;
            count = 0;
            isEmpty = true;
        }
        public MyNode TryToFindSameKey(string key)
        {
            MyNode p = head;
            int k = 0;
            while ((p.key != key) && (k<count))
            {
                p = p.next;
                k++;
            }
            if (k != count - 1) return p;
            else return null;
        }
        public void Add(string key, string inf)    // добавление нового элемента
        {
            if (count == 0)
                head = new MyNode(key, inf, head, head);
            else
            {
                MyNode p = TryToFindSameKey(key);
                if (p == null)
                {
                    MyNode tmp = new MyNode(key, inf, head, head.prev);
                    head = tmp;
                }
                else
                    p.inf = inf;
            }
            count++;
            isEmpty = false;
        }

        public void Printer()          // Вывод списка
        {
            MyNode p = head;
            while (p != null)
            {
                Console.Write("{0} ", p.inf);
                p = p.next;
            }
        }

        public MyNode GetNode(string inf)
        {
            MyNode p = head;
            while (p.inf != inf) 
                p = p.next;
            return p;
        }

        public void Delete(string inf) // Удалить по инфу
        {
            MyNode p;
            p = GetNode(inf);
            p.next.prev = p.prev;
            p.prev.next = p.next;
            count--;
        }
    }

    class MyNode
    {
        public string key;
        public string inf;
        public MyNode next;
        public MyNode prev;
        public MyNode(string key, string inf, MyNode next, MyNode prev)
        {
            this.key = key;
            this.inf = inf;
            this.next = next;
            this.prev = prev;
        }
    }
}


