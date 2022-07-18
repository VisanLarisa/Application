using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Application.Models
{
    public class Appointment2
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string? PatientName { set; get; }

        public string? Text => PatientName;

        [JsonPropertyName("patient")]
        public string? PatientId { set; get; }

        public string Status { get; set; } = "free";


    }

/*    public class Appointment2DbContext : DbContext
    {
        public DbSet<Appointment2> Appointments2 { get; set; }

        public Appointment2DbContext(DbContextOptions<Appointment2DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment2>();

        }
    }*/
}
