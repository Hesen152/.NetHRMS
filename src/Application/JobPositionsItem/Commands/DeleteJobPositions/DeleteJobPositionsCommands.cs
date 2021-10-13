 using System.Linq;
 using System.Threading;
 using System.Threading.Tasks;
 using dotnethrmsmy.Application.Common.Exceptions;
 using dotnethrmsmy.Application.Common.Interfaces;
 using dotnethrmsmy.Domain.Entities;
 using MediatR;
 using Microsoft.EntityFrameworkCore;
 using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace dotnethrmsmy.Application.JobPositionsItem.Commands.DeleteJobPositions
{



  public  class DeleteJobPositionsCommands:IRequest
    {
      public int   Id { get; set; }
    }

  public class DeleteJobPositionsCommandHandler : IRequestHandler<DeleteJobPositionsCommands>
  {
    private readonly IApplicationDbContext _context;

    public DeleteJobPositionsCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }


    public async Task<Unit> Handle(DeleteJobPositionsCommands request, CancellationToken cancellationToken)
    {
      var entity = await _context.JobPositions
        .Where(c => c.Id == request.Id)
        .FirstOrDefaultAsync(cancellationToken);

      if (entity is null)
      {
        throw  new NotFoundException(nameof(JobPosition),request.Id);
        
        
      }

      _context.JobPositions.Remove(entity);
      await _context.SaveChangesAsync(cancellationToken);

      return Unit.Value;



    }
  }






}