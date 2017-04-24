using SpringMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpringMVC;
namespace SpringMVC.Controllers
{
    public class HelloController : Controller
    {
        //
        // GET: /Hello/
        public IUser theUser{get;set;}
        public ActionResult Index()
        {
            string str = theUser.Add(1, 1);
            ViewBag.str = str;
            return View();
        }
	}
}