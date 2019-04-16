using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Models;

namespace MyBooks.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            CrudContext context = HttpContext.RequestServices.GetService(typeof(MyBooks.Models.CrudContext)) as CrudContext;
            return View(context.GetBooks());
        }
    }
}