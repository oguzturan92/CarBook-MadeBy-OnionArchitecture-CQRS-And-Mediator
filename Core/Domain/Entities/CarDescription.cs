using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionId { get; set; }
        public string CarDescriptionDetail { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}