using DataLayer.Models;
using DataLayer.Repositories;
using AMPDejtingsajt.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPDejtingsajt.Controllers
{
    public class ProfilePageController : Controller
    {
        private DataContext dataContext = new DataContext();
        private PersonRepository personRepository;
        private MessageRepository messageRepository;


        public ProfilePageController()
        {

            personRepository = new PersonRepository(dataContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult User()
        //{
        //    if (Session["PersonID"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account", new { area = "" });
        //    }
        //}

        [HttpGet]
        public ActionResult User(int id)
        {
            string personid = (string)(Session["PersonID"]);
            
            if(personid == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = GetProfileWall();
                var user = personRepository.GetById(id);
                var message = dataContext.Message.Where(p => p.RecieverId == id).ToList();

                model.Person = user;
                model.Message = message;

                ViewBag.UserProfile = id;

                return View(model);
            }
        }

        private ProfileWallViewModel GetProfileWall()
        {
            return new ProfileWallViewModel { Person = new Person(), Message = new List<Message>() };
        }


        public ActionResult Edit(int id)
        {
            var person = personRepository.GetById(id);
            var userid = person.PersonID.ToString();
            string personid = (string)(Session["PersonID"]);

            if (userid == personid)
            {
                var model = person;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult Edit(Person person, HttpPostedFileBase upload)
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
            personRepository.Edit(person);

            personRepository.Save(person);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult Image(int id)
        {
            var user = personRepository.GetById(id);

            return File(user.File, user.ContentType);
        }

        public ActionResult Image1()
        {
            var user = personRepository.GetById(1);

            return File(user.File, user.ContentType);
        }

        public ActionResult Image2()
        {
            var user = personRepository.GetById(2);

            return File(user.File, user.ContentType);
        }

        public ActionResult Image3()
        {
            var user = personRepository.GetById(3);

            return File(user.File, user.ContentType);
        }

        public void AddMessage(int receiverID)
        {
            using (DataContext db = new DataContext())
            {
                string senderID = (string)(Session["PersonID"]);
                int newSenderID = Int32.Parse(senderID);
                var message = new Message
                {
                    SenderId = newSenderID,
                    RecieverId = receiverID,
                    MessageText = "In progress",
                    MessageDate = DateTime.Today
                };

                db.Message.Add(message);
                db.SaveChanges();

            }
        }

        public void AddFriend(int receiverID)
        {
            using (DataContext db = new DataContext())
            {
                string senderID = (string)(Session["PersonID"]);
                int newSenderID = Int32.Parse(senderID);
                var friendRequest = new FriendRequest
                {
                    SenderId = newSenderID,
                    ReceiverId = receiverID,
                    Status = "In progress",
                    FriendRequestDate = DateTime.Today
                };

                db.FriendRequest.Add(friendRequest);
                db.SaveChanges();

                ViewBag.Alert = "You have a new friend";

            }
        }
    }
}