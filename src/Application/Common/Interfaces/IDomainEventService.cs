using dotnethrmsmy.Domain.Common;
using System.Threading.Tasks;

namespace dotnethrmsmy.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
