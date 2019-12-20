using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class CarMark
    {
        public CarMark()
        {
            Ad = new HashSet<Ad>();
            CarModel = new HashSet<CarModel>();
        }

        public Guid IdMark { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
        public virtual ICollection<CarModel> CarModel { get; set; }
    }
}
