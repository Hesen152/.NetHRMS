using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class WebSite
    {
        public WebSite()
        {
            JobSeekerCvWebSites = new HashSet<JobSeekerCvWebSite>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobSeekerCvWebSite> JobSeekerCvWebSites { get; set; }
    }
}
