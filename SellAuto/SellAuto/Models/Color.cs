using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Color
    {
        public Color()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdColor { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
