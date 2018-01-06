using DataLayer.Models;
using DataLayer.Repositories;
using AMPDejtingsajt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPDejtingsajt.Controllers
{
    public class FriendsController : Controller
    {
        private DataContext dataContext = new DataContext();
        private PersonRepository personRepository;

        public FriendsController()
        {
            personRepository = new PersonRepository(dataContext);
        }

        [HttpGet]
        public ActionResult User(int id)
        {
            var model = GetFriends();
            List<int> ids = new List<int>();
            var friendRequests = dataContext.FriendRequest.Where(p => p.ReceiverId == id).ToList();

            foreach (var item in friendRequests)
            {
                ids.Add(item.SenderId);
            }

            foreach (var personID in ids)
            {
                var userID = dataContext.User.Where(p => p.PersonID == personID);
                model.Person = userID;
            }

            return View(model);
        }

        private FriendsViewModel GetFriends()
        {
            return new FriendsViewModel { Person = new List<Person>() };
        }
    }
}