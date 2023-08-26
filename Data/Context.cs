using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration dosyalarını şuan çalıştığımız assembly içerisinden getir diyoruz 
            //şuan çalıştığımız proje = data katmanı - klasörü oluyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
