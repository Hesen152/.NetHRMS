using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnethrmsmy.Application.Common.Interfaces;
using dotnethrmsmy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnethrmsmy.Application.CompanyStaffItems.Queries
{
   public  class GetCompanyStaffQuery:IRequest<CompanyStaffVm>
    {
    }


    public class GetCompanyStaffHandler : IRequestHandler<GetCompanyStaffQuery, CompanyStaffVm>
    {
        private readonly IMapper _mapper;
        private readonly  IApplicationDbContext _context;

        public GetCompanyStaffHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        
        


        public  async Task<CompanyStaffVm> Handle(GetCompanyStaffQuery request, CancellationToken cancellationToken)
        {
            return
                new CompanyStaffVm
                {
                    Lists = await _context.CompanyStaffs
                    .ProjectTo<CompanyStaffDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)


                };

        }
    }
}
