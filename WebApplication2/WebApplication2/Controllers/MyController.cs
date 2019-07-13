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
        [HttpPost]
        public ActionResult MasMultiply(forMatrix formatrix)
        {
            int row = formatrix.mas.Length;
            
            if (row != 0)
            {
                int col = formatrix.mas[0].Length;

                for (int i = 0; i < col; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        formatrix.mas[i][j] *= formatrix.mas[i][j];
                    }
                }
            }
            ModelState.Clear();
            return View(formatrix);

        }
    }
}