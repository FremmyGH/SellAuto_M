﻿using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class TypeCarBody
    {
        public TypeCarBody()
        {
            Ad = new HashSet<Ad>();
        }

        public Guid IdTypeCarBody { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
