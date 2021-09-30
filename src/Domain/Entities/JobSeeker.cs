using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeeker
    {
        public JobSeeker()
        {
            JobSeekerCvs = new HashSet<JobSeekerCv>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int? CvId { get; set; }

        public virtual JobSeekerCv Cv { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<JobSeekerCv> JobSeekerCvs { get; set; }
    }
}
