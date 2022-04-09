using Application.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CarIntervention: Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Status { get; set; }
        public float Price { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid InterventionId { get; set; }
        public Intervention Intervention { get; set; }
    }
}
