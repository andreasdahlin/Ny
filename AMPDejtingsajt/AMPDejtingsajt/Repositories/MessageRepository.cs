using AMPDejtingsajt.Models;
using AMPDejtingsajt.Repositories.Bas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMPDejtingsajt.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(DataContext context) : base(context)
        {

        }
    }
}