using LexiconApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconApi.Data.DBContext
{
    public class LexiconDBContext : DbContext
    {
        public LexiconDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Jurisdiction> Jurisdictions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Attorney> Attorneys { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Matter> Matters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matter>()
            .HasKey(m => m.Id)
            .HasName("MatterId");

            modelBuilder.Entity<Jurisdiction>()
            .HasKey(j => j.Id)
            .HasName("JurisdictionId");

            modelBuilder.Entity<Client>()
            .HasKey(c => c.Id)
            .HasName("ClientId");

            modelBuilder.Entity<Attorney>()
            .HasKey(a => a.Id)
            .HasName("AttorneyId");

            modelBuilder.Entity<Invoice>()
            .HasKey(i => i.Id)
            .HasName("InvoiceId");

            modelBuilder.Entity<Jurisdiction>()
            .HasMany(e => e.Attorneys)
            .WithOne(e => e.Jurisdiction)
            .HasForeignKey(e => e.JurisdictionId)
            .IsRequired(false);

            modelBuilder.Entity<Jurisdiction>()
            .HasMany(e => e.Matters)
            .WithOne(e => e.Jurisdiction)
            .HasForeignKey(e => e.JurisdictionId)
            .IsRequired(false);

            modelBuilder.Entity<Client>()
            .HasMany(e => e.Matters)
            .WithOne(e => e.Client)
            .HasForeignKey(e => e.ClientId)
            .IsRequired(false);

            modelBuilder.Entity<Attorney>()
            .HasMany(e => e.BillingAttorneyMatters)
            .WithOne(e => e.BillingAttorney)
            .HasForeignKey(e => e.BillingAttorneyId)
            .IsRequired(false);

            modelBuilder.Entity<Attorney>()
            .HasMany(e => e.ResponsibleAttorneyMatters)
            .WithOne(e => e.ResponsibleAttorney)
            .HasForeignKey(e => e.ResponsibleAttorneyId)
            .IsRequired(false);

            modelBuilder.Entity<Matter>()
            .HasMany(e => e.Invoices)
            .WithOne(e => e.Matter)
            .HasForeignKey(e => e.MatterId)
            .IsRequired(false);

            modelBuilder.Entity<Attorney>()
            .HasMany(e => e.Invoices)
            .WithOne(e => e.Attorney)
            .HasForeignKey(e => e.AttorneyId)
            .IsRequired(false);

        }

    }
}
