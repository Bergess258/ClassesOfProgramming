using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SuhovLab1
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader Reader = new StreamReader("input.txt");
            string varReg = @"(int||sbyte||short||long||byte||ushort||uint||ulong||char||float||double||decimal||bool||object||string)";
            Regex vars = new Regex(@"^"+varReg+@"(\[\]||\[\,\])(\s)\D\w*(\;)");
            Regex type = new Regex(varReg);
            //Напиши regex сам для классов и присваивания переменных
            //Для методов написал сам,чтобы не мучался)
            Regex method = new Regex(@"(int||sbyte||short||long||byte||ushort||uint||ulong||char||float||double||decimal||bool||object||string||void)\s\D\w*\(((\s*((ref||out)\s)*"+varReg+ @"\s\D\w*\,)*(\s((ref||out)\s)*" + varReg + @"\s\D\w*))?\)\;");
            //Посмотри файл, он находится в папке проекта затем bin\Debug
            //Дальше построчно считывай из файла и работай с Regex
            //Попробуй немного поиграться с MatchCollection//Посмотри видосы, если не будет получаться. Но вообще можешь просто через откладку и брейк проинт смотреть, что как происходит, если что-то не получается или хочешь узнать
            while (true)
            {
                //считывание с файла и если дошел до конца использую catch. Оно сработает, т.к. файл закончится и у потока не будет прав читать данные не из файла
                string line = line = Reader.ReadLine();
                string[] masLine;
                try
                {
                    masLine = line.Split(' ');
                }
                catch
                {
                    break;
                }
                //Дальше уже сам)
                //Много if-ов и немного запары с методами)
            }
            Reader.Close();//Не забывай закрывать потоки(тип тоже самое когда пытаешься заархивировать проект, а у тебя это открыто в визуалке))
        }
    }
}
