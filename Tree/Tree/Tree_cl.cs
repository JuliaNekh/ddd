using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tree
{
    class Tree_cl
    {
        public class Node
        {
            public int inf;  //информационная часть
            public Node left;
            public Node right;
            public Node parent;
            public Node(int inf, Node left, Node right, Node parent)
            {
                this.inf = inf;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }
            public void WriteNode(StreamWriter w)
            {
                if (this != null)
                {
                    if (left != null)
                    {
                        w.WriteLine(Convert.ToString(inf) + "->" + Convert.ToString(left.inf) + ";");
                        left.WriteNode(w);
                    }
                    if (right != null)
                    {
                        w.WriteLine(Convert.ToString(inf) + "->" + Convert.ToString(right.inf) + ";");
                        right.WriteNode(w);
                    }
                }
            }
            public bool IsLeaf(Node t)
            {
                if ((t.left == null) && (t.right == null)) return true;
                else return false;
            }
        }
        Node top; //вершина
        public Tree_cl()
        {
            top = null;
        }
        public Node Finder(int val, Node tmp)
        {
            if (val < tmp.inf)
            {
                if (tmp.left == null) return tmp;
                else
                    return Finder(val, tmp.left);
            }
            else
            {
                if (tmp.right == null) return tmp;
                else
                    return Finder(val, tmp.right);
            }
        }
        public void Add(int val)
        {
            Node tmp = top;
            if (top == null)
                top = new Node(val, null, null, null);
            else 
            {
                Node p = Finder(val, tmp);
                if (val < p.inf) p.left = new Node(val, null, null, p);
                else p.right = new Node(val, null, null, p);
            }
        }
        public Node FinderForDelete(int val, Node tmp)
        {
            if (val < tmp.inf)
            {
                if (tmp.left == null) throw new InvalidOperationException();
                else return FinderForDelete(val, tmp.left);
            }
            if (val > tmp.inf)
            {
                if (tmp.right == null) throw new InvalidOperationException();
                else return FinderForDelete(val, tmp.right);
            }
            return tmp;
        }
        public void SimpleDelete(int val)
        {
            Node tmp = top;
            if (tmp == null) throw new InvalidOperationException();
            else 
            {
                tmp = FinderForDelete(val, tmp);
                if (val<tmp.parent.inf) tmp.parent.left = null;
                else tmp.parent.right = null;
            }
        }

        public void NormalDelete(int val)
        {
            Node tmp = top;
            if (tmp == null) throw new InvalidOperationException();
            else
            {
                tmp = FinderForDelete(val, tmp);
                if (IsLeaf(tmp))
                {
                    /* if (RightOrLeft(tmp)) tmp.parent.left = null;
                     else tmp.parent.right = null; */
                    SimpleDelete(tmp.inf);
                }
                else
                {
                    if (tmp.right != null)
                    {
                        if (tmp.left == null)
                        {
                            if (RightOrLeft(tmp)) tmp.parent.left = tmp.right;
                            else tmp.parent.right = tmp.right;
                        }
                    }
                    if (tmp.left != null)
                    {
                        if (tmp.right == null)
                        {
                            if (RightOrLeft(tmp)) tmp.parent.left = tmp.left;
                            else tmp.parent.right = tmp.left;
                        }
                        else
                        {
                            Node help = tmp;
                            tmp = tmp.left;
                            while (tmp.right != null) tmp = tmp.right;
                            Node helper = tmp;
                            NormalDelete(tmp.inf);
                            tmp = FinderForDelete(tmp.inf, tmp);
                            help.inf = helper.inf;
                        }
                    }
                }
            }
        }
        public bool RightOrLeft(Node tmp)    //true - левый потомок, false - правый
        {
            if (tmp.parent.inf > tmp.inf) return true;
            else return false;
        }
        public bool IsLeaf(Node tmp)
        {
            if ((tmp.left == null) && (tmp.right == null)) return true;
            else return false;
        }
        public Node FinderForNormalDelete(int val, Node tmp)
        {
            tmp = tmp.left;
            while (tmp.right!=null) tmp=tmp.right;
            return tmp;
        }
        public void Writer(string path)
        {
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter w = new StreamWriter(f);
            w.WriteLine("digraph G {");
            top.WriteNode(w);
            w.WriteLine("}");
            w.Close();
            f.Close();
        }
      /*  public void ScanTree(Node top)
        {
            Node tmp = top;
            if (!tmp.IsLeaf(tmp)) ScanTree(tmp.left);  

        } */

    }
}
