using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataStorage.Core.BaseServices
{
    public interface IQueryableRepository<T> where T:class,IEntity,new()
    {
        IQueryable<T> Table { get; }
    }
}