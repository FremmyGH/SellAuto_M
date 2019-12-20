using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Drive
    {
        public Drive()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdDrive { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
