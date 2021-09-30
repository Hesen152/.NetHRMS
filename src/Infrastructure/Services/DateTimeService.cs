using dotnethrmsmy.Application.Common.Interfaces;
using System;

namespace dotnethrmsmy.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
