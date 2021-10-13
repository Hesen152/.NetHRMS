using dotnethrmsmy.Application.Common.Mappings;
using dotnethrmsmy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnethrmsmy.Application.CompanyStaffItems.Queries
{
  public  class CompanyStaffDto:IMapFrom<CompanyStaff>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public virtual User User { get; set; }


    }
}
