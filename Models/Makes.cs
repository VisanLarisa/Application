using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{ 
    public class Makes
    {
        public int ID { get; set; }
        public string brandName { get; set; }
        public string originCountry { get; set; }
    }

    public class MakesDBContext : DbContext
    {
        public DbSet<Makes> Makes { get; set; }
    }
}
