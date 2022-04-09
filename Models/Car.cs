using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Application.Models.Base;
using Application.Models.Enums;

namespace Application.Models
{
    public class Car: Entity
    {

        public string BodyType { get; set; }
        public int Year { get; set; }
        public float Power { get; set; }
        public float CilindricalCapacity { get; set; }
        public string Gearbox { get; set; }//
        public string PollutionNorm { get; set; }//
        public string Transmission { get; set; }//
        public Fuel Fuel { get; set; }
        public float Kilometers { get; set; }
        public Guid ModelId { get; set; }
        public Model Model { get; set; }
     //   public Guid UserId { get; set; }
     //   public User User { get; set; }
        public ICollection<CarIntervention> CarInterventions { get; set; }
    }
}
