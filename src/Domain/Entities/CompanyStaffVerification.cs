using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class CompanyStaffVerification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }

        public virtual User User { get; set; }
    }
}
