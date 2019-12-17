using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalvationArmyProject.Controllers
{
    public class ErrorContentController : Controller
    {
        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}