using Application.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Appointment: Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
