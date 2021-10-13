using AutoMapper;
using AutoMapper.QueryableExtensions;
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
   public  class GetCitByNameContainQuery:IRequest<CityVm>
    {

        public string Name { get; set; }
    }



    public class GetCityByNameContainQueryHandler : IRequestHandler<GetCitByNameContainQuery, CityVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCityByNameContainQueryHandler(IApplicationDbContext context,IMapper mapper)
        {

            _context = context;
            _mapper = mapper;

        }
        public async Task<CityVm> Handle(GetCitByNameContainQuery request, CancellationToken cancellationToken)
        {
            var vm = new CityVm();


             var results=  await _context.Cities.Where(c => c.Name.Contains(request.Name))
                                .ProjectTo<CityListDto>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);
            vm.Lists = results;


            return await Task.FromResult(vm);



        }
    }
}
