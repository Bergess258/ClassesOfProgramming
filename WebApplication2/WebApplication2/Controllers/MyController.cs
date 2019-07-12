using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            forMatrix formatrix = new forMatrix();
            return View(formatrix);
        }
        [HttpPost] //вызывается после нажатия на кнопку
        public ActionResult Index(forMatrix formatrix,bool ok=false)
        {
            if (!ok)
            {
                formatrix.mas = new int[formatrix.rows][];
                for (int i = 0; i < formatrix.rows; i++)
                {
                    formatrix.mas[i] = new int[formatrix.col];
                }
                formatrix.rows = formatrix.rows;
                formatrix.col = formatrix.col;
            }
            else
            {
                ModelState.Clear();
                for (int i = 0; i < formatrix.rows; i++)
                {
                    for (int j = 0; j < formatrix.col; j++)
                    {
                        formatrix.mas[i][j] *= formatrix.mas[i][j];
                    }
                }
            }
            return View(formatrix);
        }
    }
}