using dotnethrmsmy.Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace dotnethrmsmy.Domain.Entities
{
    public partial class City
    {
        public City()
        {
            JobAdverts = new HashSet<JobAdvert>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobAdvert> JobAdverts { get; set; }
    }
}
