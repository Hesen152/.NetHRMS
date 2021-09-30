using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            CompanyStaffVerifications = new HashSet<CompanyStaffVerification>();
            EmailActivations = new HashSet<EmailActivation>();
            MernisActivations = new HashSet<MernisActivation>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CompanyStaff CompanyStaff { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
        public virtual ICollection<CompanyStaffVerification> CompanyStaffVerifications { get; set; }
        public virtual ICollection<EmailActivation> EmailActivations { get; set; }
        public virtual ICollection<MernisActivation> MernisActivations { get; set; }
    }
}
