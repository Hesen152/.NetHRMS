using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekerCvImage
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual JobSeekerCv JobSeekerCv { get; set; }
    }
}
