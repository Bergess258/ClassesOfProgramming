using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Drawing;
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
            using (FileStream fstream = new FileStream(@"C:\Users\parsh\source\repos\NewRepo\WebApplication2\WebApplication2\output.txt", FileMode.Open))
            {
                using (StreamReader wr = new StreamReader(fstream))
                {
                    using (FileStream fstream2 = new FileStream(@"C:\Users\parsh\source\repos\NewRepo\WebApplication2\WebApplication2\output2.txt", FileMode.Open))
                    {
                        using (StreamReader wr2 = new StreamReader(fstream2))
                        {
                            using (FileStream fstream3 = new FileStream(@"C:\Users\parsh\source\repos\NewRepo\WebApplication2\WebApplication2\output3.txt", FileMode.Open))
                            {
                                using (StreamReader wr3 = new StreamReader(fstream3))
                                {
                                    Base context = new Base();
                                    string s = wr.ReadLine();
                                    string s2 = wr2.ReadLine();
                                    string s3 = wr.ReadLine();
                                    while (!wr.EndOfStream)
                                    {
                                        if (context.WeapN.Where(x => x.Name == s2).Count() == 0)
                                        {
                                            context.WeapN.Add(new WeapN() { Name = s, Id = context.WeapN.Count() });
                                            context.SaveChanges();
                                        }
                                        s = wr.ReadLine();
                                        if (context.SkinN.Where(x => x.Name == s2).Count() == 0)
                                        {
                                            context.SkinN.Add(new SkinN() { Name = s2, Id = context.SkinN.Count() });
                                            context.SaveChanges();
                                        }
                                        s2 = wr2.ReadLine();
                                        s3 = wr3.ReadLine();
                                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(s3);
                                        request.Method = WebRequestMethods.Ftp.UploadFile;
                                        WebClient myWebClient = new WebClient();
                                        byte[] fileContents = myWebClient.DownloadData(s3);
                                        request.ContentLength = fileContents.Length;
                                        Stream requestStream = request.GetRequestStream();
                                        requestStream.Write(fileContents, 0, fileContents.Length);
                                        requestStream.Close();
                                        Weapon weap = new Weapon() {
                                            Image = fileContents,
                                            Id = context.Weapon.Count(),
                                            SkinNameId = context.SkinN.Where(x=>x.Name==s2).First().Id,
                                            WeapNId = context.WeapN.Where(x => x.Name == s).First().Id,
                                        };
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
