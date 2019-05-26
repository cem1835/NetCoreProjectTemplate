using Microsoft.EntityFrameworkCore;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Core.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
            
        }

        public DbSet<SampleEntity> SampleEntities { get; set; }
    }
}
