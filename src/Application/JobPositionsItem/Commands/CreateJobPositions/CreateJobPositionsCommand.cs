using System;
using System.Threading;
using System.Threading.Tasks;
using dotnethrmsmy.Application.Common.Interfaces;
using dotnethrmsmy.Domain.Entities;
using MediatR;

namespace dotnethrmsmy.Application.JobPositionsItem.Commands.CreateJobPositions
{
    public class CreateJobPositionsCommand:IRequest<int>
    {
        public string Title { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }


    public class CreateJobPositionsCommands:IRequestHandler<CreateJobPositionsCommand,int>
    {
        private  readonly  IApplicationDbContext _context;

        public CreateJobPositionsCommands(IApplicationDbContext context)
        {
            _context = context;
        }


        public  async Task<int> Handle(CreateJobPositionsCommand request, CancellationToken cancellationToken)
        {

            try
            {
              var entity = new JobPosition();
            entity.Title = request.Title;
            entity.CreatedAt=DateTime.Now;
            entity.IsActive = request.IsActive;
            entity.IsDeleted = request.IsDeleted;
            _context.JobPositions.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           

        }
    }
}