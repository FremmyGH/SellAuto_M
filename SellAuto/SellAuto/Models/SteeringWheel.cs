using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class SteeringWheel
    {
        public SteeringWheel()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdSteeringWheel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
