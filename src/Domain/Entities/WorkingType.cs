using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class WorkingType
    {
        public WorkingType()
        {
            JobAdverts = new HashSet<JobAdvert>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobAdvert> JobAdverts { get; set; }
    }
}
