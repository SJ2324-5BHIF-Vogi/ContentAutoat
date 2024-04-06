using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Repository;

namespace Vogi.ContentAutoat.Application.LoggingHandler
{
    public class AddLoggingHandler : IRequestHandler<LoggingDto,bool>
    {
        private readonly ILoggingRepository _loggingRepo;
        public AddLoggingHandler(ILoggingRepository loggingRepo)
        {
            _loggingRepo = loggingRepo;
        }

        public Task<bool> Handle(LoggingDto request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_loggingRepo.LogData(request));
        }
    }
}
