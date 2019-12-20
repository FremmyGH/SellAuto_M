using System;
using System.Collections.Generic;

namespace SellAuto.Models
{
    public partial class Ad
    {
        public Ad()
        {
            Photo = new HashSet<Photo>();
            Sub = new HashSet<Sub>();
        }

        public string IdAd { get; set; }
        public string Vin { get; set; }
        public string Sts { get; set; }
        public Guid MarkId { get; set; }
        public Guid SteeringWheelId { get; set; }
        public int YearPublish { get; set; }
        public Guid TypeCarBodyId { get; set; }
        public Guid? DriveId { get; set; }
        public Guid? KppId { get; set; }
        public double? Volume { get; set; }
        public double? Power { get; set; }
        public Guid? ColorId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CityId { get; set; }
        public string Phone1 { get; set; }
        public Guid UserId { get; set; }
        public Guid CarModelId { get; set; }
        public string PhotoFile { get; set; }
        public Guid? StatusId { get; set; }

        public virtual CarModel CarModel { get; set; }
        public virtual City City { get; set; }
        public virtual Color Color { get; set; }
        public virtual Drive Drive { get; set; }
        public virtual Kpp Kpp { get; set; }
        public virtual CarMark Mark { get; set; }
        public virtual Status Status { get; set; }
        public virtual SteeringWheel SteeringWheel { get; set; }
        public virtual TypeCarBody TypeCarBody { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Photo> Photo { get; set; }
        public virtual ICollection<Sub> Sub { get; set; }
    }
}
