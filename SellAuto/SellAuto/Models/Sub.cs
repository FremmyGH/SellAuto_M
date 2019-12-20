using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Sub
    {
        public Guid IdSub { get; set; }
        public Guid UserId { get; set; }
        public string AdId { get; set; }

        public virtual Ad Ad { get; set; }
        public virtual User User { get; set; }
    }
}
