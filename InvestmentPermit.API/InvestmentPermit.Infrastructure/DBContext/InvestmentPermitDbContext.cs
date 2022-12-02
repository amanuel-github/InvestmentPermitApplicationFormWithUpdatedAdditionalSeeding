using InvestmentPermit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Infrastructure.DBContext
{
    public class InvestmentPermitDbContext : DbContext
    {
        public InvestmentPermitDbContext()
        {
        }

        public InvestmentPermitDbContext(DbContextOptions<InvestmentPermitDbContext> options)
            : base(options)
        { }
        public  DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<BusinessOrganizationDetails> BusinessOrganizationDetails { get; set; }
        public DbSet<InvestmentPermission> InvestmentPermissions { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Kebelle> Kebelles { get; set; }
        public virtual DbSet<Woreda> Woredas { get; set; }
        public  DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<FormOfOwnerShip> FormOfOwnerShips { get; set; }
        public DbSet<LegalStatus> LegalStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        }
    }

