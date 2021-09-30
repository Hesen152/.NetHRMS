using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class EmployerUpdate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CompanyStaffId { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string CorporateEmail { get; set; }
        public string Phone { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Employer User { get; set; }
    }
}
