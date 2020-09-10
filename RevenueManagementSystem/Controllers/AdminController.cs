using RevenueManagementSystem.Models;
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

        [HttpPost]
        public ActionResult Index(Admin user)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {
                    var usr = db.Admins.SingleOrDefault (a => a.Username == user.Username && a.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserId"] = usr.Id.ToString();
                        Session["Username"] = usr.Username.ToString();

                        return RedirectToAction("Home");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Username or Passwor!";
                        //ModelState.AddModelError("", "Invalid Username or Passwor!");
                    }
                }
            }

            return View();
        }



        public ActionResult Home()
        {

            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }


        public ActionResult TaxRevenue()
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var user = db.Citizens.ToList();
                if (user == null)
                {
                    return RedirectToAction("RegisterCitizen");
                }
                ViewBag.Feedback = user.Count();
                user.Reverse();
                return View(user);
            }
        }

        public ActionResult Registration()
        {
            ViewBag.Title = "Registration";
            return View();
        }


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
                    var result1 = db.Licenses.Where(a => a.Email == license.Email).FirstOrDefault();
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
            ViewBag.Title = "Payment";
            return View();
        }

        public ActionResult Verify()
        {
            ViewBag.Title = "Verify";
            return View();
        }


        //GET
        public ActionResult RegisterAdmin()
        {
            ViewBag.Title = "Register Admin.";
            return View();
        }


        [HttpPost]
        public ActionResult RegisterAdmin(Admin admin)
        {

            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {

                    var result = db.Admins.Where(a => a.Email == admin.Email).FirstOrDefault();
                    if (result != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("RegisterAdmin");
                    }
                    db.SaveChanges();

                    db.Admins.Add(admin);
                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Feedback = "Successfully Registered.";
                }
            }
            return View();

        }






        public ActionResult ManageAccount(Citizen citizen)
        {
            if (citizen.Password != citizen.ConfirmPassword)
            {
                return RedirectToAction("Index");

            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var user = db.Citizens.SingleOrDefault(c => c.Email == citizen.Email);
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



        public ActionResult Report()
        {
            List<Report> report = new List<Report>();
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var rep = db.Licenses.ToList();
                if (rep == null)
                {
                    return RedirectToAction("License");
                }
                ViewBag.Message = rep.Count();
                rep.Reverse();
                for (int i=0;i<rep.Count; i++)
                {
                    Report repInfo = new Models.Report();
                    var rp = rep[i];
                    var citizenInfo = db.Citizens.SingleOrDefault(r => r.Email == rp.Email);
                    if (citizenInfo != null)
                    {
                        repInfo.FirstName = citizenInfo.FirstName;
                        repInfo.LastName = citizenInfo.LastName;
                        repInfo.Address = citizenInfo.Address;
                        repInfo.AmountPaid = rep[i].AmountPaid;
                        repInfo.Email = rep[i].Email;
                        repInfo.LicenseType = rep[i].LicenseType;
                        repInfo.DateRegistered = rep[i].DateRegistered;
                        report.Add(repInfo);
                    }
                }
                return View(report);
            }
        }

        //GET
        public ActionResult Birth()
        {
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
                    if (result1 != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("Birth");
                    }
                    db.SaveChanges();


                    var result = db.Citizens.Single(a => a.Email == birth.Email);
                    db.SaveChanges();

                    if (result == null)
                    {
                        return View();

                    }


                    birth.CitizenId = result.CitizenId;
                    db.Births.Add(birth);

                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Feedback = "Successfully Registered.";
                }
            }
            return View();
        }



        //GET
        public ActionResult Death()
        {
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
            return View();
        }


        [HttpPost]
        public ActionResult Marriage(Marriage marriage)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {

                    var result = db.Marriages.Where(a => a.Email == marriage.Email).FirstOrDefault();
                    if (result != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("Marriage");
                    }
                    db.SaveChanges();

                    marriage.CitizenId = result.CitizenId;
                    db.Marriages.Add(marriage);

                    db.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Feedback = "Successfully Registered.";
                }
            }
            return View();
        }




        public ActionResult RegisterCitizen()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegisterCitizen(Citizen citizen)
        {
            if (ModelState != null)
            {
                using (RevenueManagementDbContext db = new RevenueManagementDbContext())
                {

                    var result = db.Citizens.Where(a => a.Email == citizen.Email).FirstOrDefault();
                    if (result != null)
                    {

                        ViewBag.Feedback = "Record Already Exist.";
                        return RedirectToAction("Citizen");
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

        public ActionResult RegisteredBirth()
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var birthReg = db.Births.ToList();
                if (birthReg == null)
                {
                    return RedirectToAction("RegisterCitizen");
                }
                ViewBag.Feedback = birthReg.Count();
                birthReg.Reverse();
                return View(birthReg);
            }
        }

        public ActionResult RegisteredDeath()
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var deathReg = db.Deaths.ToList();
                if(deathReg == null)
                {
                    return RedirectToAction("RegisterCitizen");
                }
                ViewBag.Feedback = deathReg.Count();
                deathReg.Reverse();
                return View(deathReg);
            }
        }

        public ActionResult RegisteredMarriage()
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var marriageReg = db.Marriages.ToList();
                if (marriageReg == null)
                {
                    return RedirectToAction("RegisterCitizen");
                }
                ViewBag.Message = marriageReg.Count();
                marriageReg.Reverse();
                return View(marriageReg);
            }
        }

        public ActionResult Edit(int? id)
        {
             if (id == null || id == 0)
              {
                  return HttpNotFound();
              }

              using (RevenueManagementDbContext db = new RevenueManagementDbContext())
              {
                  var birth = db.Births.Where(row => row.Id == id).FirstOrDefault();
                  return View(birth);
              }

        }

        [HttpPost]
        public ActionResult Edit(Birth emp)
        {
             using (RevenueManagementDbContext db = new RevenueManagementDbContext())
             {

                    var emp1 = db.Births.Where(row => row.Id == emp.Id).FirstOrDefault();
                    if (emp1 == null)
                    {
                        return RedirectToAction("RegisteredBirth");
                    }

                         emp1.Id = emp.Id;
                         emp1.Occupation = emp.Occupation;
                         emp1.AmountPaid = emp.AmountPaid;
                         emp1.Bank = emp.Bank;
                         emp1.NameOfBaby = emp.NameOfBaby;
                         emp1.DOB = emp.DOB;
                         emp1.PlaceOfBirth = emp.PlaceOfBirth;
                         emp1.DateRegistered = emp.DateRegistered;
                         emp1.Email = emp.Email;
                         int res = db.SaveChanges();
                    if (res > 0)
                    {
                        ViewBag.Message = "Successfully Updated";
                    }

             }
            return View();
        }



        public ActionResult DeleteBirth(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var birth = db.Births.Where(row => row.Id == id).FirstOrDefault();
                return View(birth);
            }
        }


        [HttpPost]
        [ActionName("DeleteBirth")]
        public ActionResult ComfirmDeleteAlumni(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var deleteBirth = db.Births.Where(row => row.Id == id).FirstOrDefault();
                db.Births.Remove(deleteBirth);
                db.SaveChanges();
                return RedirectToAction("RegisteredBirth");
            }
        }


        public ActionResult EditCitizen(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var birth = db.Citizens.Where(row => row.CitizenId == id).FirstOrDefault();
                return View(birth);
            }
        }



        [HttpPost]
        public ActionResult EditCitizen(Citizen emp)
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {

                var emp1 = db.Citizens.Where(row => row.CitizenId == emp.CitizenId).FirstOrDefault();
                if (emp1 == null)
                {
                    return RedirectToAction("TaxRevenue");
                }

                emp1.CitizenId = emp.CitizenId;
                emp1.FirstName = emp.FirstName;
                emp1.LastName = emp.LastName;
                emp1.Address = emp.Address;
                emp1.Email = emp.Email;
                emp1.PhoneNumber = emp.PhoneNumber;
                emp1.LGA = emp.LGA;
                emp1.DateRegistered = emp.DateRegistered;
                emp1.Gender = emp.Gender;
                int res = db.SaveChanges();
                if (res > 0)
                {
                    ViewBag.Message = "Successfully Updated";
                }

            }
            return View();
        }


        public ActionResult DeleteCitizen(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var citizen = db.Citizens.Where(row => row.CitizenId == id).FirstOrDefault();
                return View(citizen);
            }
        }


        [HttpPost]
        [ActionName("DeleteCitizen")]
        public ActionResult ComfirmDeleteCitizen(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var deleteCitizen = db.Citizens.Where(row => row.CitizenId == id).FirstOrDefault();
                db.Citizens.Remove(deleteCitizen);
                db.SaveChanges();
                return RedirectToAction("TaxRevenue");
            }
        }


        public ActionResult EditMarriage(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var marriage = db.Marriages.Where(row => row.Id == id).FirstOrDefault();
                return View(marriage);
            }

        }


        [HttpPost]
        public ActionResult EditMarriage(Marriage emp)
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {

                var emp1 = db.Marriages.Where(row => row.Id == emp.Id).FirstOrDefault();
                if (emp1 == null)
                {
                    return RedirectToAction("RegisteredMarriage");
                }

                emp1.Id = emp.Id;
                emp1.Occupation = emp.Occupation;
                emp1.AmountPaid = emp.AmountPaid;
                emp1.NameOfCouple = emp.NameOfCouple;
                emp1.Date = emp.Date;
                emp1.DateRegistered = emp.DateRegistered;
                emp1.Email = emp.Email;
                int res = db.SaveChanges();
                if (res > 0)
                {
                    ViewBag.Message = "Successfully Updated";
                }

            }
            return View();
        }


        public ActionResult DeleteMarriage(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var marriage = db.Marriages.Where(row => row.Id == id).FirstOrDefault();
                return View(marriage);
            }
        }


        [HttpPost]
        [ActionName("DeleteMarriage")]
        public ActionResult ComfirmDeleteMarriage(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var deleteMarriage = db.Marriages.Where(row => row.Id == id).FirstOrDefault();
                db.Marriages.Remove(deleteMarriage);
                db.SaveChanges();
                return RedirectToAction("RegisteredMarriage");
            }
        }


        public ActionResult EditDeath(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var death = db.Deaths.Where(row => row.Id == id).FirstOrDefault();
                return View(death);
            }

        }

        [HttpPost]
        public ActionResult EditDeath(Death emp)
        {
            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {

                var emp1 = db.Deaths.Where(row => row.Id == emp.Id).FirstOrDefault();
                if (emp1 == null)
                {
                    return RedirectToAction("RegisteredDeath");
                }

                emp1.Id = emp.Id;
                emp1.Occupation = emp.Occupation;
                emp1.AmountPaid = emp.AmountPaid;
                emp1.NameOfDeceased = emp.NameOfDeceased;
                emp1.DateOfDeath = emp.DateOfDeath;
                emp1.PlaceOfDeath = emp.PlaceOfDeath;
                emp1.Email = emp.Email;
                int res = db.SaveChanges();
                if (res > 0)
                {
                    ViewBag.Message = "Successfully Updated";
                }

            }
            return View();
        }


        public ActionResult DeleteDeath(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var death = db.Deaths.Where(row => row.Id == id).FirstOrDefault();
                return View(death);
            }
        }


        [HttpPost]
        [ActionName("DeleteDeath")]
        public ActionResult ComfirmDeleteDeath(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            using (RevenueManagementDbContext db = new RevenueManagementDbContext())
            {
                var deleteDeath = db.Deaths.Where(row => row.Id == id).FirstOrDefault();
                db.Deaths.Remove(deleteDeath);
                db.SaveChanges();
                return RedirectToAction("RegisteredDeath");
            }
        }
    }
}