using AMPDejtingsajt.Models;
using AMPDejtingsajt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPDejtingsajt.Controllers
{
    public class HomeController : Controller
    {
        private DataContext dataContext = new DataContext();

        public ActionResult Index()
        {
            var profiles = dataContext.User.ToList();

            return View(profiles);
        }

        public bool CheckForFriendRequests()
        {
            string id = (string)(Session["PersonID"]);
            int intId = Int32.Parse(id);
            List<FriendRequest> friendRequests = dataContext.FriendRequest.Where(
                i => i.ReceiverId == intId).
                Where(i => i.Status == "In progress")
                .ToList();

            if (friendRequests != null)
                return true;
            else
                return false;
        }

        public JsonResult GetSearchValue(string search)
        {
            List<Person> allSearch = dataContext.User.Where(n => n.FirstName
            .Contains(search))
            .Where(a => a.isSearchable == false)
            .ToList();

            return new JsonResult
            {
                Data = allSearch,
                JsonRequestBehavior =
                JsonRequestBehavior.AllowGet
            };
        }


        public ActionResult Friends()
        {
            var friends = dataContext.User.ToList();

            return View(friends);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var PersonA = dataContext.User.Find(id);

            dataContext.User.Remove(PersonA);

            dataContext.SaveChanges();

            return View();
        }
    }
}