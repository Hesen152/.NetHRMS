using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekerCvExperience
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public int JobPositionId { get; set; }
        public string WorkplaceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual JobPosition JobPosition { get; set; }
        public virtual JobSeekerCv JobSeekerCv { get; set; }
    }
}
