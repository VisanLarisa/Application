using Application.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class App2 : Entity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
