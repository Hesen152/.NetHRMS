using dotnethrmsmy.Application.Common.Mappings;
using dotnethrmsmy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnethrmsmy.Application.CityItems.Queries
{
   public  class CityListDto:IMapFrom<City>
    {

        public CityListDto()
        {
            JobAdverts = new List<JobAdvert>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobAdvert> JobAdverts { get; set; }

    }
}
