using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Models
    {
        public int ID { get; set; }
        public string name { get; set; }
    }

    public class ModelsDBContext : DbContext
    {
        public DbSet<Models> Models { get; set; }
    }
}
