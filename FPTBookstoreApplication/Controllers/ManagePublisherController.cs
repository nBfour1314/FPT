using FPTBookstoreApplication.Data_base;
using FPTBookstoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class ManagePublisherController : Controller
    {
        private MyApplicationDbContext db = new MyApplicationDbContext();
        // GET: ManagePublisher
        public ActionResult Index()
        {
            if (Session["UserName"] == "Admin" && Session["UserName"] != null)
            {
                var publisher = db.Publishers.ToList();
                return View(publisher);
            }
            else
            {
                return RedirectToAction("Log_in", "Account");
            }
        }

        public ActionResult AddPublisher1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublisher1 (Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                var check = db.Publishers.FirstOrDefault(x => x.PublisherName.Equals(publisher.PublisherName));
                if (check == null)
                {
                    db.Publishers.Add(publisher);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ManagePublisher");
                }
                else
                {
                    ViewBag.Error = "This Publisher is already exist";
                    return View();
                }
            }
            return View("AddPublisher1");
        }


        public ActionResult EditPublisher1(int? id)
        {
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPublisher1(Publisher obj)
        {
            Publisher tmp = db.Publishers.ToList().Find(x => x.PublisherId == obj.PublisherId);
            if (tmp != null)
            {
                tmp.PublisherName = obj.PublisherName;
                tmp.Description = obj.Description;
            }
                
            db.SaveChanges();
            return RedirectToAction("Index", "ManagePublisher");
        }

        public ActionResult DeletePublisher(int? id)
        {
            Publisher tmp = db.Publishers.ToList().Find(x => x.PublisherId == id);
            if (tmp != null)
            {
                db.Publishers.Remove(tmp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}