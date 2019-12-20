using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class User
    {
        public User()
        {
            Ad = new HashSet<Ad>();
            Sub = new HashSet<Sub>();
        }

        public Guid IdUser { get; set; }
        public string Fio { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserPhoto { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
        public virtual ICollection<Sub> Sub { get; set; }
    }
}
