using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekerCvLanguage
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public string LanguageId { get; set; }
        public short Level { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual JobSeekerCv JobSeekerCv { get; set; }
        public virtual Language Language { get; set; }
    }
}
