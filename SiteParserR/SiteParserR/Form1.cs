using Parser.Core;
using Parser.Core.Habra;
using SiteParserR.CoreM.CSWeap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SiteParserR
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        string[] weapLinks= new string[0];
        ParserWorker<string[,]> weapParser;
        string[,] weapSkinsNNImgs = new string[0, 0];
        public Form1()
        {
            InitializeComponent();
            // Инициализация парсера для первой страницы
            parser = new ParserWorker<string[]>(
                new CSWeapParser(),
                new CSWeapSettings()
                );
            // Привязываю функцию, чтобы получить результат выполнения другой функции
            parser.OnNewData += Parser_Result;
            parser.StartW();
        }

        private void Parser_Result(object first, List<string[]> res)
        {
            // Получаю по завершения массив ссылок на оружие и объявляю новый парсер
            weapLinks = res[0];
            // Парсер для страницы оружия
            weapParser = new ParserWorker<string[,]>(
                new SinglWeapParser(),
                new SinglWeapSettings()
                );
            // Опять привязка
            weapParser.OnNewData += Parser_SecRes;
            // Запуск функции на входе у нее массив ссылок на оружия
            weapParser.StartWWP(weapLinks);
        }

        private void Parser_SecRes(object first, List<string[,]> res)
        {
            // Закоментил просто чтобы сейчас получить тип оружия
            //using (FileStream fstream = new FileStream("output.txt", FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter wr = new StreamWriter(fstream))
            //        foreach (string[,] Wskins in res)
            //        {
            //            string weapN = Wskins[0, 0];
            //            for (int i = 1; i < Wskins.GetLength(0); ++i)
            //                wr.WriteLine("{0}",weapN);
            //        }
            //}
            //using (FileStream fstream = new FileStream("output2.txt", FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter wr = new StreamWriter(fstream))
            //        foreach (string[,] Wskins in res)
            //        {
            //            string weapN = Wskins[0, 0];
            //            for (int i = 1; i < Wskins.GetLength(0); ++i)
            //                wr.WriteLine("{0}",Wskins[i, 0]);
            //        }
            //}
            //using (FileStream fstream = new FileStream("output3.txt", FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter wr = new StreamWriter(fstream))
            //        foreach (string[,] Wskins in res)
            //        {
            //            string weapN = Wskins[0, 0];
            //            for (int i = 1; i < Wskins.GetLength(0); ++i)
            //                wr.WriteLine("{0}",Wskins[i, 1]);
            //        }
            //}
            // просто запись в файл результата парсинга
            using (FileStream fstream = new FileStream("output4.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter wr = new StreamWriter(fstream))
                    foreach (string[,] Wskins in res)
                    {
                        string weapN = Wskins[0, 0];
                        for (int i = 1; i < Wskins.GetLength(0); ++i)
                            wr.WriteLine("{0}", Wskins[i, 0]);
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
