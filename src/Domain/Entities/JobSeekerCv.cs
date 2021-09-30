using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekerCv
    {
        public JobSeekerCv()
        {
            JobSeekerCvEducations = new HashSet<JobSeekerCvEducation>();
            JobSeekerCvExperiences = new HashSet<JobSeekerCvExperience>();
            JobSeekerCvImages = new HashSet<JobSeekerCvImage>();
            JobSeekerCvLanguages = new HashSet<JobSeekerCvLanguage>();
            JobSeekerCvSkills = new HashSet<JobSeekerCvSkill>();
            JobSeekerCvWebSites = new HashSet<JobSeekerCvWebSite>();
            JobSeekers = new HashSet<JobSeeker>();
        }

        public int Id { get; set; }
        public int JobSeekerId { get; set; }
        public string CoverLetter { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual JobSeeker JobSeeker { get; set; }
        public virtual ICollection<JobSeekerCvEducation> JobSeekerCvEducations { get; set; }
        public virtual ICollection<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }
        public virtual ICollection<JobSeekerCvImage> JobSeekerCvImages { get; set; }
        public virtual ICollection<JobSeekerCvLanguage> JobSeekerCvLanguages { get; set; }
        public virtual ICollection<JobSeekerCvSkill> JobSeekerCvSkills { get; set; }
        public virtual ICollection<JobSeekerCvWebSite> JobSeekerCvWebSites { get; set; }
        public virtual ICollection<JobSeeker> JobSeekers { get; set; }
    }
}
