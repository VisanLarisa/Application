using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Appointments
    {
        public int ID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
    public class AppointmentsDBContext : DbContext
    {
        public DbSet<Appointments> Appointments { get; set; }
    }
}
