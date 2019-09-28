using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        Base context = new Base();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "A")]
        public ActionResult MainAdmin()
        {
            return View();
        }
        [Authorize(Roles = "A")]
        public ActionResult CaseManagment()
        {
            CaseListForCB caseList = new CaseListForCB();
            caseList.Cases = context.Cases.ToArray();
            caseList.selected = new bool[caseList.Cases.Count()];
            return View(caseList);
        }
        [HttpPost]
        public ActionResult CaseManagment(List<Cases> tempC)
        {
            return View();
        }
        [Authorize(Roles = "A")]
        public ActionResult SCM(int id)
        {
            Cases Case = context.Cases.Where(x => x.Id == id).FirstOrDefault();

            return View(Case);
        }
        [HttpPost]
        public ActionResult SCM(Cases Case)
        {
            HttpPostedFileBase Profile = Request.Files["profile"];
            if (Profile.ContentLength != 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(Profile.FileName, "(.jpg||.png||.jpeg||.ico)$"))
                {
                    var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                    byte[] image = new byte[Profile.ContentLength];
                    Profile.InputStream.Read(image, 0, Convert.ToInt32(Profile.ContentLength));
                    Case.Image = image;
                    // save changes to database
                    db.SaveChanges();
                }
            }
            context.Entry(Case).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("CaseManagment");
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AddCase()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCase(Cases caseT)
        {
            HttpPostedFileBase Profile = Request.Files["profile"];
            if (Profile.ContentLength != 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(Profile.FileName, "(.jpg||.png||.jpeg||.ico)$"))
                {
                    var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                    byte[] image = new byte[Profile.ContentLength];
                    Profile.InputStream.Read(image, 0, Convert.ToInt32(Profile.ContentLength));
                    caseT.Image = image;
                    // save changes to database
                }
            }
            context.Cases.Add(caseT);
            return RedirectToAction("CaseManagment");
        }
        [HttpGet]
        public ActionResult WeapManag()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddWeap()
        {
            if (ModelState.IsValid)
            {
                ViewData["TypeName"] = new SelectList(context.Types.Select(n => n.Name), "TypeName");
                ViewData["SkinName"] = new SelectList(context.SkinNs.Select(n=>n.Name), "SkinName");
                ViewData["WeapName"] = new SelectList(context.WeapNs.Select(n => n.Name), "WeapName");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddWeap(Weapons weap)
        {
            HttpPostedFileBase Profile = Request.Files["profile"];
            if (Profile.ContentLength != 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(Profile.FileName, "(.jpg||.png||.jpeg||.ico)$"))
                {
                    var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                    byte[] image = new byte[Profile.ContentLength];
                    Profile.InputStream.Read(image, 0, Convert.ToInt32(Profile.ContentLength));
                    weap.Image = image;
                    // save changes to database
                }
            }
            context.Weapons.Add(weap);
            return RedirectToAction("CaseManagment");
        }
        public ActionResult SWM(int id)
        {
            Weapons Weap = context.Weapons.Where(x => x.Id == id).FirstOrDefault();
            return View(Weap);
        }
        [HttpPost]
        public ActionResult SWM(Weapons Weap)
        {
            HttpPostedFileBase Profile = Request.Files["profile"];
            if (Profile.ContentLength != 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(Profile.FileName, "(.jpg||.png||.jpeg||.ico)$"))
                {
                    var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                    byte[] image = new byte[Profile.ContentLength];
                    Profile.InputStream.Read(image, 0, Convert.ToInt32(Profile.ContentLength));
                    Weap.Image = image;
                }
            }
            context.Entry(Weap).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("CaseManagment");
        }
        public FileContentResult CasePhoto(int id)
        {
            Cases Case = context.Cases.Where(x => x.Id == id).First();
            if(Case!=null&&Case.Image!=null)
            return new FileContentResult(Case.Image, "image/png");
            return null;
        }
        public FileContentResult WeapPhoto(int id)
        {
            Weapons Weapon = context.Weapons.Where(x => x.Id == id).First();
            if (Weapon != null && Weapon.Image != null)
                return new FileContentResult(Weapon.Image, "image/png");
            return null;
        }
    }
}