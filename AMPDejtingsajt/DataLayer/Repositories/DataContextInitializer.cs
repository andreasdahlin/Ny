using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataLayer.Repositories
{
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {

    }
}