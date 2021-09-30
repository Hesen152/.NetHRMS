using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekerCvWebSite
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public short WebSiteId { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual JobSeekerCv JobSeekerCv { get; set; }
        public virtual WebSite WebSite { get; set; }
    }
}
