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
        public ActionResult MasMultiply()
        {
            forMatrix formatrix = new forMatrix();
            return View(formatrix);
        }
        [HttpPost] //вызывается после нажатия на кнопку
        public ActionResult Index2(Mult mult, int rows, int col)
        {
            mult.mas = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                mult.mas[i] = new int[col];
            }
            mult.rows = rows;
            mult.col = col;
            return View(mult);
        }
        [HttpPost]
        public ActionResult MasMultiply(forMatrix formatrix, int rows, int col)
        {
            if (formatrix.rows != 0 && formatrix.col != 0)
            {
                for (int i = 0; i < formatrix.col; i++)
                {
                    for (int j = 0; j < formatrix.rows; j++)
                    {
                        formatrix.mas[i][j] = formatrix.mas[i][j] ^ 2;
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    formatrix.mas[i] = new int[col];
                }
                formatrix.rows = rows;
                formatrix.col = col;

            }
            return View(formatrix);

        }
    }
}