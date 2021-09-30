using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobAdvert
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int JobPositionId { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
        public int NumberOfOpenPositions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public short? WorkingTypeId { get; set; }
        public short? WorkingTimeId { get; set; }

        public virtual City City { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobPosition JobPosition { get; set; }
        public virtual WorkingTime WorkingTime { get; set; }
        public virtual WorkingType WorkingType { get; set; }
    }
}
