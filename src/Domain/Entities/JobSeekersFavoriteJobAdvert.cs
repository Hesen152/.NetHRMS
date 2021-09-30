using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekersFavoriteJobAdvert
    {
        public int Id { get; set; }
        public int JobSeekerId { get; set; }
        public int JobAdvertId { get; set; }

        public virtual JobAdvert JobAdvert { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
    }
}
