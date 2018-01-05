using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AMPDejtingsajt.Repositories
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {

    }
}