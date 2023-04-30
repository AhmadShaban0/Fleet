using future_1_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Data
{
    public class FutureDbContext:DbContext
    {
        public FutureDbContext(DbContextOptions<FutureDbContext> options):base(options)
        {

        }
        public DbSet<Region> regions { get; set; }
        public DbSet<TransportationEntity> transportationEntities { get; set; }
        public DbSet<School> schools { get; set; }
        public DbSet<Fleet> fleets { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<TransportationEntityAndSchoolRel> TRS_Rel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .HasMany(s => s.transportationEntities)
                .WithMany(t => t.schools)
                .UsingEntity<TransportationEntityAndSchoolRel>(

                r=>r
                .HasOne(x=>x.transportationEntity)
                .WithMany(t=>t.transportationEntityAndSchoolRels)
                .HasForeignKey(f=>f.TransportationEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull),
                
                r=>r
                .HasOne(x => x.school)
                .WithMany(t => t.transportationEntityAndSchoolRels)
                .HasForeignKey(f => f.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)

                );

    
                
            modelBuilder.Entity<Driver>()
                .HasOne<Fleet>(x => x.fleet)
                .WithOne(y => y.driver)
                .HasForeignKey<Fleet>(f=> f.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Fleet>()
                .HasOne<TransportationEntity>(x => x.transportationEntity)
                .WithMany(y => y.fleets)
                .HasForeignKey(f => f.TransportationEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
           
        }
    }
}
