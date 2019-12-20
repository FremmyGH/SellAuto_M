using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Area
    {
        public Area()
        {
            City = new HashSet<City>();
        }

        public Guid IdArea { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
