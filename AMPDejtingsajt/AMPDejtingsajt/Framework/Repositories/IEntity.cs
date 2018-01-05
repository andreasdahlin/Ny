using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMPDejtingsajt.Framework.Repositories
{
    public interface IEntity : IEntity<int> { }

    public interface IEntity<T>
    {
        T PersonAID { get; set; }
        T PersonBID { get; set; }
    }
}