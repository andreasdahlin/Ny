﻿using AMPDejtingsajt.Models;
using AMPDejtingsajt.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPDejtingsajt.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Person person, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                person.FileName = upload.FileName;
                person.ContentType = upload.ContentType;

                using (var reader = new BinaryReader(upload.InputStream))
                {
                    person.File = reader.ReadBytes(upload.ContentLength);
                }
            }

            if (ModelState.IsValid)
            {
                using (DataContext db = new DataContext())
                {
                    db.User.Add(person);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = person.UserName + " successfully registered.";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Person person)
        {
            using (DataContext db = new DataContext())
            {
                var validation = db.User.Where(p => p.UserName == person.UserName && p.Password == person.Password).FirstOrDefault();

                if (validation != null)
                {
                    Session["PersonID"] = validation.PersonID.ToString();
                    string id = (string)(Session["PersonID"]);
                    Session["Username"] = validation.UserName.ToString();
                    return RedirectToAction("User", "ProfilePage", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }

            return View();

        }
    }
}