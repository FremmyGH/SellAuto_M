using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Status
    {
        public Status()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
