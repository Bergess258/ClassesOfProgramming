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
            caseList.Cases= context.Case.ToArray();
            caseList.selected = new bool[caseList.Cases.Count()];
            return View(caseList);
        }
        [HttpPost]
        public ActionResult CaseManagment(List<Case> tempC)
        {
            return View();
        }
        [Authorize(Roles = "A")]
        public ActionResult SCM(int id)
        {
            Case Case = context.Case.Where(x => x.Id == id).FirstOrDefault();
            return View(Case);
        }
        [HttpPost]
        public ActionResult SCM(Case Case)
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
        public FileContentResult Photo(int id)
        {
            Case Case = context.Case.Where(x => x.Id == id).First();
            if(Case!=null&&Case.Image!=null)
            return new FileContentResult(Case.Image, "image/png");
            return null;
        }
        
    }
}