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
        public ActionResult Index(forMatrix formatrix, int rows, int col)
        {
            formatrix.mas = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                formatrix.mas[i] = new int[col];
            }
            formatrix.rows = rows;
            formatrix.col = col;
            return View(formatrix);
        }
    }
}