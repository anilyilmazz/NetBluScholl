using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NetBluSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetBluSchool.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                return Redirect("/teacher/index");
            }
            else
            {
                return View();
            }

        }
    }
}