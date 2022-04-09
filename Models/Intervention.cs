using Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Intervention: Entity
    {
        public string Name { get; set; }
        public ICollection<CarIntervention> CarInterventions { get; set; }
    }
}
