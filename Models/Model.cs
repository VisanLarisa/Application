using Application.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Model: Entity
    {
        public string Name { get; set; }
        public Guid MakeId { get; set; }   //obligatoriu in felul asta; fk
        public Make Make { get; set; }    //fk
        public ICollection<Car> Cars { get; set; }
    }
}
