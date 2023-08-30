﻿using Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasKey(e => e.InvoiceID);
            
            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Item>()
                .Property(e => e.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Configure the Price property as decimal(18,2)
            modelBuilder.Entity<Item>()
                .Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
