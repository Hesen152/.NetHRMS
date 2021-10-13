using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnethrmsmy.Application.CityItems.Queries;
using dotnethrmsmy.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dotnethrmsmy.Application.Common.Interfaces;

namespace dotnethrmsmy.Application.CityItems.Queries
{
   public  class GetCitybyNameQuery:IRequest<CityVm>
    {

        public string Name { get; set; }

    }
       


  public  class GetCitybyNameHandler : IRequestHandler<GetCitybyNameQuery, CityVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCitybyNameHandler(IApplicationDbContext context,IMapper mapper)
        {

            _mapper = mapper;
            _context = context;


        }

        public async  Task<CityVm> Handle(GetCitybyNameQuery request, CancellationToken cancellationToken)
        {

            var vm = new CityVm();

            
               
            
                var records = await _context.Cities.Where(c => c.Name.ToLower() == request.Name.ToLower())
                .ProjectTo<CityListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            vm.Lists = records;

            return await Task.FromResult(vm);

        }
    }
}
