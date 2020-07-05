using Microsoft.EntityFrameworkCore;
using StorageData.Mapping.Storage;
using StorageEntities.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageData
{
    public class DbContextStorage : DbContext
    {
        public DbSet<Category> Categories { get; set; }
       
        public DbContextStorage(DbContextOptions<DbContextStorage> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryMap());
            
        }
    }
}
