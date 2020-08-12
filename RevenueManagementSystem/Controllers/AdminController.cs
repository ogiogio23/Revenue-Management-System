using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevenueManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult TaxRevenue()
        {
            ViewBag.Title = "Tax Revenue";
            return View();
        }

        public ActionResult Registration()
        {
            ViewBag.Title = "Registration";
            return View();
        }

        public ActionResult Licenses()
        {
            ViewBag.Title = "Licenses";
            return View();
        }

        public ActionResult Payment()
        {
            ViewBag.Title = "Payment";
            return View();
        }

        public ActionResult Verify()
        {
            ViewBag.Title = "Verify";
            return View();
        }

        public ActionResult RegisterAdmin()
        {
            ViewBag.Title = "Register Admin.";
            return View();
        }

        public ActionResult ManageAccount()
        {
            ViewBag.Title = "Manage Account.";
            return View();
        }

        public ActionResult Report()
        {
            ViewBag.Title = "Report.";
            return View();
        }

        public ActionResult Birth()
        {
            ViewBag.Title = "Birth Registration.";

            return View();
        }

        public ActionResult Death()
        {
            ViewBag.Title = "Death Registration.";

            return View();
        }

        public ActionResult Marriage()
        {
            ViewBag.Title = "Marriage Registration.";

            return View();
        }
    }
}