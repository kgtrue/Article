﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Core.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;
            _logger.LogInformation("Article Request: {Name} {@UserId} {@Request}", name, request);
            return Task.CompletedTask;
        }
    }
}
