using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Cars
    {
        public int ID { get; set; }
        public string bodyType { get; set; }
        public int year { get; set; }
        public float power { get; set; }
        public float cilindricalCapacity { get; set; }
        public string gearbox { get; set; }
        public string pollutionNorm { get; set; }
        public string transmission { get; set; }
        public string fuel { get; set; }
        public float kilometers { get; set; }
    }

    public class CarsDBContext :  DbContext
    {
        public DbSet<Cars> Cars { get; set; }
    }
}
