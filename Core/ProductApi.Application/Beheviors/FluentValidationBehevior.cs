using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Beheviors
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public IEnumerable<IValidator<TRequest>> Validator { get; }
        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            Validator = validator;
        }


        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var context = new ValidationContext<TRequest>(request);
            var failures = Validator
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(e => e.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null).ToList();
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return next();

        }
    }
}
