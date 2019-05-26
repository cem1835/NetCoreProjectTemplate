using DataStorage.Core.EntityFramework;
using DataStorage.Core.EntityFramework.PostgreSQL;
using DataStorage.Interfaces;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Implementations
{
    public class SampleEntityDAL : EfEntityRepositoryBase<SampleEntity, DatabaseContext>, ISampleEntityDAL
    {
        public void TestDAL()
        {
            throw new NotImplementedException();
        }
    }
}
