using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using WebApplication2.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            using (FileStream fstream = new FileStream(@"C:\Users\parsh\Source\Repos\NewRepo\WebApplication2\WebApplication2\bin\output2.txt", FileMode.Open))
            {
                using (StreamReader wr = new StreamReader(fstream))
                {
                    Base context = new Base();
                    string s = wr.ReadLine();
                    while (!wr.EndOfStream)
                    {

                        if (context.SkinN.Where(x => x.Name == s).Count() == 0)
                        {
                            context.SkinN.Add(new SkinN() { Name = s, Id = context.SkinN.Count() });
                            context.SaveChanges();
                        }
                        s = wr.ReadLine();
                    }
                    
                }
            }
            //using (FileStream fstream = new FileStream(@"C:\Users\parsh\Source\Repos\NewRepo\WebApplication2\WebApplication2\bin\output3.txt", FileMode.Open))
            //{
            //    using (StreamReader wr = new StreamReader(fstream))
            //    {
            //        Base context = new Base();
            //        string s = wr.ReadLine();
            //        int prefs = -1;
            //        int[] mas = new int[53];
            //        while (!wr.EndOfStream)
            //        {

            //            if (context.WeapN.Where(x => x.Name == s).Count() == 1)
            //            {
            //                ++mas[prefs];
            //            }
            //            else
            //            {
            //                context.WeapN.Add(new WeapN() { Name = s });
            //                ++mas[++prefs];
            //            }
            //            s = wr.ReadLine();
            //        }
            //    }
            //}
        }
    }
}
