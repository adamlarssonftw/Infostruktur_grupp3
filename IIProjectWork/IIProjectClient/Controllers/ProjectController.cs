using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IIProjectClient.Models;



namespace IIProjectClient.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            List<FordonPassage> test = new List<FordonPassage>();
            test.Add(new FordonPassage{Id=1, Name="test"});
            return View(test);
        }

    }
}