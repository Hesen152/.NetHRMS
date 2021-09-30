using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class Employer
    {
        public Employer()
        {
            EmployerUpdates = new HashSet<EmployerUpdate>();
            JobAdverts = new HashSet<JobAdvert>();
        }

        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string CorporateEmail { get; set; }
        public string Phone { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<EmployerUpdate> EmployerUpdates { get; set; }
        public virtual ICollection<JobAdvert> JobAdverts { get; set; }
    }
}
