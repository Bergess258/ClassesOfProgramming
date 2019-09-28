using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using WebApplication2.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Base context = new Base();
            if (context.Types.Count() == 0)
            {
                context.Types.Add(new Types() { Name = "Прямо с завода", Id = context.Types.Count() });
                context.Types.Add(new Types() { Name = "Немного поношенное", Id = context.Types.Count() });
                context.Types.Add(new Types() { Name = "После полевых испытаний", Id = context.Types.Count() });
                context.Types.Add(new Types() { Name = "Поношенное", Id = context.Types.Count() });
                context.Types.Add(new Types() { Name = "Закаленное в боях", Id = context.Types.Count() });
                context.SaveChanges();
            }
            if (context.Rares.Count() == 0)
            {
                context.Rares.Add(new Rares() { Name = "Ширпотреб", Id = context.Rares.Count() });
                context.Rares.Add(new Rares() { Name = "Промышленное качество", Id = context.Rares.Count() });
                context.Rares.Add(new Rares() { Name = "Армейское качество", Id = context.Rares.Count() });
                context.Rares.Add(new Rares() { Name = "Запрещенное", Id = context.Rares.Count() });
                context.Rares.Add(new Rares() { Name = "Засекреченное", Id = context.Rares.Count() });
                context.Rares.Add(new Rares() { Name = "Тайное", Id = context.Rares.Count() });
                context.Rares.Add(new Rares() { Name = "Редкое", Id = context.Rares.Count() });
                context.Rares.Add(new Rares() { Name = "Контрабанда", Id = context.Rares.Count() });
                context.SaveChanges();
            }
            // Теперь мы считываем сразу три файла и получается, что у нас есть сразу все необходимые данные по оружию
            // У файлов надо поменять расположение
            using (FileStream fstream = new FileStream(@"C:\Users\Администратор.BERGESS\Source\Repos\ClassesOfProgramming\WebApplication2\WebApplication2\output.txt", FileMode.Open))
            {
                using (StreamReader wr = new StreamReader(fstream))
                {
                    using (FileStream fstream2 = new FileStream(@"C:\Users\Администратор.BERGESS\Source\Repos\ClassesOfProgramming\WebApplication2\WebApplication2\output2.txt", FileMode.Open))
                    {
                        using (StreamReader wr2 = new StreamReader(fstream2))
                        {
                            using (FileStream fstream3 = new FileStream(@"C:\Users\Администратор.BERGESS\Source\Repos\ClassesOfProgramming\WebApplication2\WebApplication2\output3.txt", FileMode.Open))
                            {
                                using (StreamReader wr3 = new StreamReader(fstream3))
                                {
                                    using (FileStream fstream4 = new FileStream(@"C:\Users\Администратор.BERGESS\Source\Repos\ClassesOfProgramming\WebApplication2\WebApplication2\output4.txt", FileMode.Open))
                                    {
                                        using (StreamReader wr4 = new StreamReader(fstream4))
                                        {
                                            // Кста называть так переменные(s,s2,s3 и выше названия потоков(FileStream)) не оч хорошо
                                            string s = wr.ReadLine();
                                            string s2 = wr2.ReadLine();
                                            string s3 = wr3.ReadLine();
                                            string s4 = wr4.ReadLine();
                                            while (!wr.EndOfStream)
                                            {
                                                // Проверки на звезду
                                                if (s[0] == '★')
                                                {
                                                    s = s.Substring(1);
                                                }
                                                if (s4[0] == '★')
                                                {
                                                    s4 = s4.Substring(1);
                                                }
                                                // Для оружия
                                                if (context.WeapNs.Where(x => x.Name == s).Count() == 0)
                                                {
                                                    context.WeapNs.Add(new WeapNs() { Name = s, Id = context.WeapNs.Count() });
                                                    context.SaveChanges();
                                                }
                                                // Для скина
                                                if (context.SkinNs.Where(x => x.Name == s2).Count() == 0)
                                                {
                                                    context.SkinNs.Add(new SkinNs() { Name = s2, Id = context.SkinNs.Count() });
                                                    context.SaveChanges();
                                                }
                                                // Тут должно будет идти добавление в сами оружия(таблица Weapon) уже, но это я оставил тебе) Сделай
                                                // Запуск веб-клиента(браузера так сказать)
                                                WebClient myWebClient = new WebClient();
                                                // Скачивание в массив битов изображения по ссылке переданной в функцию
                                                byte[] fileContents = myWebClient.DownloadData(s3);
                                                // Дальше идут две строчки бесполечного для нашей задачи кода(без коментов), но все равно посмотри
                                                // Запись в поток, чтобы перевести его в изображение(Нет реализации по получению изображения из массива битов, но есть из потока, следовательно просто переводим массив в поток)
                                                //MemoryStream strForImg = new MemoryStream(fileContents); - код)
                                                // Получение изображения(как-то так просто полезная инфа)
                                                //Image img = Image.FromStream(strForImg);  - код)
                                                Weapons weap = new Weapons();
                                                weap.SkinNameId = context.SkinNs.Where(x => x.Name == s2).First().Id;
                                                weap.WeapNId = context.WeapNs.Where(x => x.Name == s).First().Id;
                                                if (context.Weapons.Where(x => x.SkinNameId == weap.SkinNameId && x.WeapNId == weap.WeapNId).Count() == 0)
                                                {
                                                    weap.TypeId = 1;
                                                    weap.Id = context.Weapons.Count();
                                                    weap.Image = fileContents;
                                                    weap.RareId = context.Rares.Where(x => x.Name == s4).First().Id;
                                                    context.Weapons.Add(weap);
                                                    context.SaveChanges();
                                                }
                                                s = wr.ReadLine();
                                                s2 = wr2.ReadLine();
                                                s3 = wr3.ReadLine();
                                                s4 = wr4.ReadLine().Replace(" ", "");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
