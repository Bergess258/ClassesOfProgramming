using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        Base context = new Base();
        public ActionResult Index()
        {
            context.Case.Co
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult About(string s)
        {
            ViewBag.Message = s + "SomeTExt";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public FileContentResult Image(string caseNAme)
        {
            List<Case> temp = context.Case.Where(p => p.Name == caseNAme).ToList();
            if (temp != null && temp.Count != 0)
            {
                return new FileContentResult(temp[0].Image, "png");
            }
            throw new Exception("Such case not founded");

        }
        public FileContentResult WeaponImage(int Id)
        {
            List<Weapon> tempW = context.Weapon.Where(p => p.Id == 0).ToList();
            //context.possSkinsInCase.Find(Id).Weapon.Image; possSkinsInCase поменять на название таблицы
            if (tempW != null && tempW.Count != 0)
            {
                return new FileContentResult(tempW[0].Image, "png");
            }
            throw new Exception("Such case not founded");
        }
    }
}