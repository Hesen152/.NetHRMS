using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class Language
    {
        public Language()
        {
            JobSeekerCvLanguages = new HashSet<JobSeekerCvLanguage>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobSeekerCvLanguage> JobSeekerCvLanguages { get; set; }
    }
}
