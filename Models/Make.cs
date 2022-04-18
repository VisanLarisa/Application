using Application.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{ 
    public class Make: Entity
    {
        public string BrandName { get; set; }
        public string OriginCountry { get; set; }
        public ICollection<Model> Models { get; set; }  //reverse property
    }

}
