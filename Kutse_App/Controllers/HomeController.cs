using Kutse_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var now = DateTime.Now;
            int hour = now.Hour;
            int month = now.Month;

            var holiday = new HolidayLists();

            string[] greetings = { "Tere ööd", "Tere hommikust", "Tere päevast", "Tere õhtust" };
            ViewBag.Greeting = hour < 5 ? greetings[0] : hour < 12 ? greetings[1] : hour < 17 ? greetings[2] : greetings[3];

            ViewBag.HolidayImage = holiday.ImageUrls.ContainsKey(month) ? Url.Content("~/Images/" + holiday.ImageUrls[month]) : Url.Content("~/Images/default.png");
            ViewBag.Message = "Ootan sind minu peole! Palun tule!! Hetkel on " + holiday.Messages[month];

            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }


        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                E_mail(guest);

                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }

        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "mvcprogrammeermine@gmail.com";
                WebMail.Password = "hnil npyp rxex wpuz";
                WebMail.From = "mvcprogrammeermine@gmail.com";
                WebMail.Send("ultramax2516@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }


        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        GuestContext db = new GuestContext();
        [Authorize]

        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
            return RedirectToAction("Guests");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            db.Guests.Remove(g);
            db.SaveChanges();
            return RedirectToAction("Guests");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(Guest guest)
        {
            db.Entry(guest).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Guests");
        }

        [HttpGet] // Измените здесь на HttpGet
        public ActionResult GuestTrue()
        {
            IEnumerable<Guest> guests = db.Guests.Where(g => g.WillAttend == true).ToList();
            return View("Guests", guests); // Убедитесь, что вы возвращаете правильный вид
        }

        [HttpGet] // Измените здесь на HttpGet
        public ActionResult GuestFalse()
        {
            IEnumerable<Guest> guests = db.Guests.Where(g => g.WillAttend == false).ToList();
            return View("Guests", guests); // Убедитесь, что вы возвращаете правильный вид
        }


        HolidayContext db2 = new HolidayContext();
        [Authorize]

        public ActionResult Holidays()
        {
            IEnumerable<Holiday> holidays = db2.Holidays;
            return View(holidays);

        }

        [HttpGet]
        public ActionResult HolCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HolCreate(Holiday holiday)
        {
            db2.Holidays.Add(holiday);
            db2.SaveChanges();
            return RedirectToAction("Holidays");
        }

        [HttpGet]
        public ActionResult HolDelete(int id)
        {
            Holiday h = db2.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        [HttpPost, ActionName("HolDelete")]
        public ActionResult HolDeleteConfirmed(int id)
        {
            Holiday h = db2.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db2.Holidays.Remove(h);
            db2.SaveChanges();
            return RedirectToAction("Holidays");
        }

        [HttpGet]
        public ActionResult HolEdit(int? id)
        {
            Holiday h = db2.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        [HttpPost, ActionName("HolEdit")]
        public ActionResult HDEditConfirmed(Holiday holiday)
        {
            db2.Entry(holiday).State = EntityState.Modified;
            db2.SaveChanges();
            return RedirectToAction("Holidays");
        }

    }
}