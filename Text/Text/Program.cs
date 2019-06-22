using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            //По классам не знабю что придумать, чтобы было адекватное задание. Поэтому просто решим одну олимпиадную задачу по программированию)
            //Ссылка на задачу https://acmp.ru/index.asp?main=task&id_task=557&ins=1#solution
            //Спомни фичу про умножение матриц, которую говорил на уроке.
            //Задачу не гугли) Любые вопросы спрашивай или пиши что не понимаешь что делать) Лучше вместе сделать. В идеале не на классе
            StreamReader ForReading = new StreamReader("input.txt");//Поток для считывания инфы с файла
            string[] temp = ForReading.ReadLine().Split(' ');//ReadLine считывает строку //Split разделяет строку на массив строк по какому-либо символу(ам)
            // числа разделяются пробелом поэтому в символы записываем пробел
            //Вообще в задаче написано, что за что отвечает, но распишу, чтобы удобней было
            int m = Convert.ToInt32(temp[0]) - 1, n = Convert.ToInt32(temp[1]);
            //Получаем число м и n
            temp = ForReading.ReadLine().Split(' ');
            int a = Convert.ToInt32(temp[0]) - 1, b = Convert.ToInt32(temp[1]) - 1;
            //Получаем номер строки и столбца искомого числа
            int p = Convert.ToInt32(ForReading.ReadLine());
            // Число для расчета остатка
            int[][] First = new int[n][];//Первый массив
            int[][] Temp = new int[n][];//Второй массив, который надо перемнодить на первый//Тип надо будет первый умножить на второй, затем результят в первый записывает и умножение происходит с третьим( опять записываем в Temp)
            ForReading.ReadLine();
            for (int i1 = 0; i1 < n; i1++)
            {
                First[i1] = new int[n];
                Temp[i1] = new int[n];
            }
            //Ходят слухи что рвание массивы([][]) работают быстрее чем [,], поэтому они тут)
            //Изначально у массивов нет ссылок на массивы, пожтому цикл выше задает их на новый пустые массивы
            //Дальше идет считывание массива, второй уже сам считывай и думай как делать
            //Совет: умнодение делай в одельную функцию. По входным и выходным сам думай
            for (int i1 = 0; i1 < n; i1++)
            {
                temp = ForReading.ReadLine().Split(' ');
                for (int g = 0; g < n; g++)
                {
                    First[i1][g] = Convert.ToInt32(temp[g]);
                }
            }
            for (int r = 0; r < m; r++)
            {
                ForReading.ReadLine();
                for (int i = 0; i < n; i++)
                {
                    temp = ForReading.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        Temp[i][j] = Convert.ToInt32(temp[j]);
                    }
                }
                First = Multiply(First, Temp, n);
            }
            Console.WriteLine(First[a][b]);
            Console.ReadKey();

        }
        static int[][] Multiply(int[][] First,int[][] Temp,int length)
        {
            int[][] tempMass2 = new int[length][];
            int[] tempMass = new int[length];
            for (int i = 0; i < length; i++)
            {
                tempMass2[i] = new int[length];
            }
            for (int q = 0; q < length; q++)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int i = 0; i < length; i++)
                    {
                        tempMass[i] = Temp[i][j];
                    }
                    for (int i = 0; i < length; i++)
                    {
                        tempMass2[q][j] += First[q][i] * tempMass[i];
                    }

                }
            }
            return tempMass2;
        }
    }
}
