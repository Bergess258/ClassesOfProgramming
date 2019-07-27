using Microsoft.Owin;
using Owin;
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
            //string fileName = @"C:\Users\parsh\source\repos\NewRepo\WebApplication2\WebApplication2\Content\img\512fx384f.png";
            //FileInfo fileInfo = new FileInfo(fileName);
            //long length = fileInfo.Length;
            //FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(reader);
            //byte[] temp = br.ReadBytes((int)length);
            //Base context = new Base();
            //NameW nameW = context.NameW.Where(p => p.Id == 0).ToList()[0];
            //SkinN Skin = context.SkinN.Where(p => p.Id == 0).ToList()[0];
            //SkinN Skin = context.SkinN.Where(p => p.Id == 0).ToList()[0];
            //Type type = context.Type.Where(p => p.Id == 0).ToList()[0];
            //Weapon tempW = new Weapon();
            //tempW.TypeId = 0;
            //tempW.WeaponNId = 0;
            //tempW.SkinNameId = 0;
            //tempW.Image = temp;
            //context.Weapon.Add(tempW);
            //context.SaveChanges();
        }
    }
}
