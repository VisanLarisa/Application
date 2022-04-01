using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CarInterventions
    {
        public int ID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public float status { get; set; }
        public float price { get; set; }
    }

    public class CarInterventionsDBContext : DbContext
    {
        public DbSet<CarInterventions> CarInterventions { get; set; }
    }
}
