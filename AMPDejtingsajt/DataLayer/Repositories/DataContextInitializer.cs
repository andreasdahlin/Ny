using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataLayer.Repositories
{
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext dataContext)
        {
            
            var examplePerson1 = new Person
            {
                FirstName = "Jesper",
                LastName = "Andersson",
                SocialNumber = "199108191111",
                Gender = "Male",
                City = "Stockholm",
                Mail = "jesper@live.se",
                UserName = "JesperAN",
                Password = "test",
                //PresentationText = "Hej jag heter Jesper. Det här är min exempeltext. Jag tycker om att ragga på brudar. ",
                isSearchable = false
            };

            var examplePerson2 = new Person
            {
                FirstName = "Jonatan",
                LastName = "Svensson",
                SocialNumber = "199108191111",
                Gender = "Male",
                City = "Stockholm",
                Mail = "jonatan@live.se",
                UserName = "AndreasSV",
                Password = "test",
                //PresentationText = "Hej jag heter Jonatan. Det här är min exempeltext. Jag tycker om att ragga på brudar. ",
                isSearchable = false
            };

            var examplePerson3 = new Person
            {
                FirstName = "Robert",
                LastName = "Jakobsson",
                SocialNumber = "199108191111",
                Gender = "Male",
                City = "Stockholm",
                Mail = "robert@live.se",
                UserName = "RobertJA",
                Password = "test",
                //PresentationText = "Hej jag heter Robert. Det här är min exempeltext. Jag tycker om att ragga på brudar. ",
                isSearchable = false
            };

            dataContext.User.Add(examplePerson1);
            dataContext.User.Add(examplePerson2);
            dataContext.User.Add(examplePerson3);
            dataContext.SaveChanges();
            
        }
    }
}