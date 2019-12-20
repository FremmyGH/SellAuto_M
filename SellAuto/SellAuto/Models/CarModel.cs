using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class CarModel
    {
        public CarModel()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdModel { get; set; }
        public string Name { get; set; }
        public Guid MarkId { get; set; }

        public virtual CarMark Mark { get; set; }
        public virtual ICollection<Ad> Ad { get; set; }
    }
}
