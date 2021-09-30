using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekerCvSkill
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual JobSeekerCv JobSeekerCv { get; set; }
    }
}
