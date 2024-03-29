﻿using Application.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Make>().HasMany(x=>x.Models).WithOne(x=>x.Make);

            builder.Entity<Model>().HasMany(x => x.Cars).WithOne(x => x.Model);

            builder.Entity<Car>().HasMany(x => x.CarInterventions).WithOne(x => x.Car).HasForeignKey(x=>x.CarId);

            builder.Entity<Intervention>().HasMany(x => x.CarInterventions).WithOne(x => x.Intervention).HasForeignKey(x=>x.InterventionId);
            
            builder.Entity<Appointment2>();

            builder.Entity<Event>();
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<CarIntervention> CarInterventions { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Appointment2> Appointments2 { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
