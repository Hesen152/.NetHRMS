using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnethrmsmy.Application.CityItems.Queries;
using dotnethrmsmy.Application.Common.Interfaces;
using dotnethrmsmy.Application.Constants;
using dotnethrmsmy.Application.JobPositionsitem.Queries.GetTodos;
using dotnethrmsmy.Application.Results;
using dotnethrmsmy.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotnethrmsmy.Application.JobPositionsItem.Queries.GetTodos
{

   public class GetJobPositionsQuery:IRequest<IDataResult<JobPositionsVm>>
   { 
      
       


   }


   public class GetJobPositionsQueryHandler:IRequestHandler<GetJobPositionsQuery,IDataResult<JobPositionsVm>>
   {
       private readonly IApplicationDbContext _context;
       private readonly IMapper _mapper;

       public GetJobPositionsQueryHandler(IApplicationDbContext context, IMapper mapper)
       {
           _context = context;
           _mapper = mapper;
       }


       public async  Task<IDataResult<JobPositionsVm>> Handle(GetJobPositionsQuery request, CancellationToken cancellationToken)
       {
           var vm = new JobPositionsVm();

           var results = await _context.JobPositions
               .ProjectTo<JobPositionsDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
           
           vm.Lists= results;

           if (results is null)
           {
             return await Task.FromResult(new ErrorDataResult<JobPositionsVm>(Messages.NotFound));
            
             
           }

           return await Task.FromResult(new SuccessDataResult<JobPositionsVm>(vm,Messages.Listed));

       }
   }












}