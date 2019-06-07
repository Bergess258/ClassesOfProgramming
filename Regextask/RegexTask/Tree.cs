using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace SuhovLab1
{
    [Serializable]
    public class Tree
    {
        public IDent ident;
        public Tree Left, Right;
        //int x = 0;
        public Tree()
        {

        }
        public Tree(IDent dent)
        {
            ident = dent;
        }
        public Tree(IDent dent,int deep)
        {
            ident = dent;
            //x = deep;
        }
        public void Add(IDent dent)
        {
            Tree node = this;
            if (ident != null)
                while (true)
                {
                    if (node.ident.Hash > dent.Hash)
                        if (node.Left == null)
                        {
                            node.Left = new Tree(dent);
                            return;
                        }
                        else
                            node = node.Left;
                    else
                    if (node.ident.Hash < dent.Hash)
                        if (node.Right == null)
                        {
                            node.Right = new Tree(dent);
                            return;
                        }
                        else
                            node = node.Right;
                    else return;
                }
            else
                ident = dent;
        }
        //public void Print()
        //{
            
        //}
        //private int CheckDeep(int x,Tree node)
        //{
        //    if()
        //}
    }
}