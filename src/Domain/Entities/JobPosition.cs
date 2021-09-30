using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobPosition
    {
        public JobPosition()
        {
            JobAdverts = new HashSet<JobAdvert>();
            JobSeekerCvExperiences = new HashSet<JobSeekerCvExperience>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<JobAdvert> JobAdverts { get; set; }
        public virtual ICollection<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }
    }
}
