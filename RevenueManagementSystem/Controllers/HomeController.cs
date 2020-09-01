using RevenueManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevenueManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        //GET
        public ActionResult Index()
        {
            if (this.AuthenticateUser())
            {
                return RedirectToAction("Home");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Index(Citizen user)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {
                    var usr = db.Citizens.Single(a => a.Username == user.Username && a.Password == user.Password);
                    if (usr == null)
                    {
                        ModelState.AddModelError("", "Invalid Login Details!");
                        return RedirectToAction("Index");
                    }

                        Session["user"] = usr;
                }
            }

            return RedirectToAction("Home"); ;
        }

        public ActionResult Home()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Logout()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }
            Session.Clear();

            return RedirectToAction("Index");
        }


        public ActionResult TaxRevenue()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var payment = db.Births.ToList();
                if (payment == null)
                {
                    return RedirectToAction("TaxRevenue");
                }
                payment.Reverse();
                return View(payment);
            }
        }


       /* public ActionResult ListOfPayment()
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var payment = db.Births.ToList();
                if (payment == null)
                {
                    return RedirectToAction("TaxRevenue");
                }
                payment.Reverse();
                return View(payment);
            }
        }*/


        public ActionResult Registration()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Registration";

            return View();
        }


        //GET
        public ActionResult Licenses()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Licenses(License license)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {
                    var result1 = db.Admins.Where(a => a.Email == license.Email).FirstOrDefault();
                    if (result1 != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("Licenses");
                    }
                    db.SaveChanges();

                    var result = db.Citizens.Single(a => a.Email == license.Email);
                    db.SaveChanges();

                    if (result == null)
                    {
                        return View();

                    }


                    license.CitizenId = result.CitizenId;
                    db.Licenses.Add(license);

                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Feedback = "Successfully Registered.";
                }
            }
            return View();
        }



        public ActionResult Payment()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Payment";

            return View();
        }

        public ActionResult Verify()
        {
            ViewBag.Title = "Verify";

            return View();
        }

        public ActionResult ManageAccount(Citizen citizen)
        {

            return View();
        }


        //GET
        public ActionResult RegisterClient()
        {
            ViewBag.Title = "Register.";

            return View();
        }


        [HttpPost]
        public ActionResult RegisterClient(Citizen citizen)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {

                    var result = db.Citizens.Where(a => a.Email == citizen.Email).FirstOrDefault();
                    if (result != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("RegisterClient");
                    }
                    db.SaveChanges();

                    db.Citizens.Add(citizen);
                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Feedback = "Successfully Registered.";
                }
            }
            return View();
        }




        public ActionResult RecoverPass(Citizen citizen)
        {
            if (citizen.Password != citizen.ConfirmPassword)
            {
                return RedirectToAction("Index");

            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var user = db.Citizens.SingleOrDefault(c => c.Username == citizen.Username);
                if (user == null)
                {
                    return View();
                }

                user.Password = citizen.Password;
                user.ConfirmPassword = citizen.ConfirmPassword;
                ViewBag.Message = "Successful";
                db.SaveChanges();

            }
            return View();
        }

        public  ActionResult CitizenProfile(int? id)
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }
            return View();
        }






        //GET
        public ActionResult Birth()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Birth(Birth birth)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {
                    var result1 = db.Births.Where(a => a.Email == birth.Email).FirstOrDefault();
                    if (result1 == null)
                    {
                        ViewBag.Feedback = "Failed";
                        return RedirectToAction("Birth");

                    }


                    var result = db.Citizens.Single(a => a.Email == birth.Email);

                    if (result == null)
                    {
                        ViewBag.Feedback = "Failed";
                        return RedirectToAction("Birth");

                    }


                    birth.CitizenId = result.CitizenId;
                    db.Births.Add(birth);
                    db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Feedback = result1.Id;

                }
            }
            return View();
        }


        //GET
        public ActionResult Death()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpPost]
        public ActionResult Death(Death death)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {
                    var result1 = db.Deaths.Where(a => a.Email == death.Email).FirstOrDefault();
                    if (result1 != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("Death");
                    }
                    db.SaveChanges();


                    var result = db.Citizens.Single(a => a.Email == death.Email);
                    db.SaveChanges();

                    if (result == null)
                    {
                        return View();

                    }


                    death.CitizenId = result.CitizenId;
                    db.Deaths.Add(death);

                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Feedback = "Successfully Registered.";
                }
            }
            return View();
        }




        //GET
        public ActionResult Marriage()
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Marriage(Marriage marriage)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {

                    var result1 = db.Marriages.Where(a => a.Email == marriage.Email).FirstOrDefault();
                    if (result1 != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("Marriage");
                    }
                    db.SaveChanges();

                    var result = db.Citizens.Single(a => a.Email == marriage.Email);
                    db.SaveChanges();

                    if (result == null)
                    {
                        return View();
                    }


                    marriage.CitizenId = result.CitizenId;
                    db.Marriages.Add(marriage);

                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Feedback = "Successfully Registered.";
                }
            }
            return View();
        }




        public ActionResult BirthReceipt(int? id)
        {
            if (!this.AuthenticateUser())
            {
                return RedirectToAction("Index");
            }

            if (id == null || id == 0)
            {
                return RedirectToAction("Birth");
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var result1 = db.Births.Single(a => a.Id == id);
                if (result1 == null)
                {
                    return RedirectToAction("Birth");

                }


                var result = db.Citizens.Single(a => a.Email == result1.Email);

                if (result == null)
                {
                    return RedirectToAction("Birth");

                }

                Session["BirthInfo"] = result1;

            }
            return View();
        }

        public Boolean AuthenticateUser()
        {
            if (Session["user"] != null)
            {
               return true;
            }

            return false;
        }
    }
}