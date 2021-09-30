using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class JobSeekerCvEducation
    {
        public int Id { get; set; }
        public int JobSeekerCvId { get; set; }
        public string SchoolName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual JobSeekerCv JobSeekerCv { get; set; }
    }
}
