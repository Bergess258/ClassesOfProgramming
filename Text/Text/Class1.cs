using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text
{
    class ReadFile
    {
        public void readInput()
        {
            System.IO.StreamReader ForReading = new System.IO.StreamReader("INPUT.TXT");
            string[] temp = ForReading.ReadLine().Split(' ');
            int m = Convert.ToInt32(temp[0]) - 1, n = Convert.ToInt32(temp[1]);
            int a = Convert.ToInt32(temp[0]) - 1, b = Convert.ToInt32(temp[1]) - 1;
            int p = Convert.ToInt32(ForReading.ReadLine());
            ReadMas rm = new ReadMas();
            rm.ReadMas1();
            Create cm = new Create();
            cm.createMas(n,m);
        }
    }
    class Create : ReadFile
    {
        public void createMas(int n,int m)
        {            
            int[][] First = new int[n][];
            int[][] Temp = new int[n][];
            for (int i1 = 0; i1 < n; i1++)
            {
                First[i1] = new int[n];
                Temp[i1] = new int[n];
            }
            Multiply mm = new Multiply();
            mm.multiplyMass(Temp,First);
        }
    }
    class Multiply : Create
    {
        public void multiplyMass(int[][] Temp, int[][] First)
        {
            int[][] r = new int[First.Length][];
            for (int i = 0; i < First.Length; i++)
            {
                for (int j = 0; j < First.Length; j++)
                {
                    for (int k = 0; k < Temp.Length; k++)
                    {
                        r[i][j] += First[i][k] * Temp[k][j];
                    }
                }
            }
            //for (int i = 0; i < First.Length; i++)
            //{
            //    for (int j = 0; j < First.Length; j++)
            //    {
            //    Console.WriteLine(First[i][j]);
            //    }
            //}
        }
    }
    class ReadMas : ReadFile
    {
        public void ReadMas1()
        {

        }
    }

}
