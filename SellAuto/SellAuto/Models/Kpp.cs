using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Kpp
    {
        public Kpp()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdKpp { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
