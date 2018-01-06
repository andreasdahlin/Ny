﻿using DataLayer.Models;
using DataLayer.Repositories.Bas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(DataContext context) : base(context)
        {

        }
    }
}