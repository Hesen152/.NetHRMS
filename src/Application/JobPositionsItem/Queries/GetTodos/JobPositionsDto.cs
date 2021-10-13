using System;
using System.Collections.Generic;
using dotnethrmsmy.Application.Common.Mappings;
using dotnethrmsmy.Domain.Entities;

namespace dotnethrmsmy.Application.JobPositionsitem.Queries.GetTodos
{
    public class JobPositionsDto:IMapFrom<JobPosition>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


        public JobPositionsDto()
        {
            JobAdverts = new List<JobAdvert>();
            JobSeekerCvExperiences = new List<JobSeekerCvExperience>();

        }
        
        public virtual ICollection<JobAdvert> JobAdverts { get; set; }
        public virtual ICollection<JobSeekerCvExperience> JobSeekerCvExperiences { get; set; }

    }
}