using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnethrmsmy.Application.TodoLists.Queries.GetTodos;
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
   
        public class GetCityQuery : IRequest<CityVm>
        {

    

         }


    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, CityVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCityQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CityVm> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {

            return new CityVm
            {
               

                Lists = await _context.Cities
                  .AsNoTracking()
                  .ProjectTo<CityListDto>(_mapper.ConfigurationProvider)
                  .ToListAsync(cancellationToken)
            };
        }



    }

}
