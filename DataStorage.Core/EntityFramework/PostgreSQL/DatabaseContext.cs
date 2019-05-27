using Microsoft.EntityFrameworkCore;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Core.EntityFramework.PostgreSQL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=LawyerProjectDB;Username=cem;Password=18351835");
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Username=cem;Password=18351835;Database=LawyerProjectDB;");
        }

        public DbSet<SampleEntity> SampleEntities { get; set; }
    }
}
