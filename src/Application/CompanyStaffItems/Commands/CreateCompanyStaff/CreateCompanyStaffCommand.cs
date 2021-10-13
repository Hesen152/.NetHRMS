using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotnethrmsmy.Application.Common.Interfaces;
using dotnethrmsmy.Domain.Entities;

namespace dotnethrmsmy.Application.CompanyStaffItems.Commands.CreateCompanyStaff
{

     public class CreateCompanyStaffCommand:IRequest<int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        
    }


     public class CreateCompanyStaffCommandHandler : IRequestHandler<CreateCompanyStaffCommand, int>
     {

         private IApplicationDbContext _context;

         public CreateCompanyStaffCommandHandler(IApplicationDbContext context)
         {
             _context = context;
         }


         public async Task<int> Handle(CreateCompanyStaffCommand request, CancellationToken cancellationToken)
         {
             var entity = new CompanyStaff();

             


             entity.FirstName = request.FirstName;
             entity.LastName = request.LastName;
             _context.CompanyStaffs.Add(entity);
             
             
             await _context.SaveChangesAsync(cancellationToken);
             return entity.UserId;
         }
     }




}