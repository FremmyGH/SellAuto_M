using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Photo
    {
        public Guid IdPhoto { get; set; }
        public string File { get; set; }
        public string AdId { get; set; }

        public virtual Ad Ad { get; set; }
    }
}
