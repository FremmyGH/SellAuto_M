using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class City
    {
        public City()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdCity { get; set; }
        public string Name { get; set; }
        public Guid AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<Ad> Ad { get; set; }
    }
}
