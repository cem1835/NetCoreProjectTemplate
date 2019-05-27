using Microsoft.EntityFrameworkCore;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Core.EntityFramework.PostgreSQL
{

    //dotnet ef migrations add 'MigrationName' --context PostgreSQL_DatabaseContext --output-dir Postgresql/Migrations

    public class PostgreSQL_DatabaseContext:DbContext
    {
        public PostgreSQL_DatabaseContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Username=cem;Password=18351835;Database=LawyerProjectDB;");

             
        }

        public DbSet<SampleEntity> SampleEntities { get; set; }
    }
}
