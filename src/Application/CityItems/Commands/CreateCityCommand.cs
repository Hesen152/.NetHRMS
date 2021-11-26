using System.Threading;
using System.Threading.Tasks;
using dotnethrmsmy.Application.Common.Interfaces;
using dotnethrmsmy.Domain.Entities;
using MediatR;

namespace dotnethrmsmy.Application.CityItems.Commands
{
    public class CreateCityCommandResponse
    {

        public bool IsSuccess { get; set; }

    }

    public class CreateCityCommand : IRequest<int>
    {
        public string Name { get; set; }
  
  
    }


    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {

        private readonly IApplicationDbContext _context;

        public CreateCityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCityCommand request,
            CancellationToken cancellationToken)
        {
            var city = new City();

            city.Name = request.Name;
            

            _context.Cities.Add(city);
            await _context.SaveChangesAsync(cancellationToken);
            return city.Id;
        }


    }

}
