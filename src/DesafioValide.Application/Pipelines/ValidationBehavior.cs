using DesafioValide.Domain.Notifications;
using FluentValidation;
using MediatR;

namespace DesafioValide.Application.Pipelines
{
    public sealed class ValidationBehavior<TRequest, TResponse>
         : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IMediator _mediator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IMediator mediator)
        {
            _validators = validators;
            _mediator = mediator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context)));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors);
            var notifications = errors
                .Select(validationFailure => new DomainNotification(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage))
                .ToList();

            if (errors.Any())
            {
                foreach (var notification in notifications)
                {
                    await _mediator.Publish(notification);
                }

                throw new ValidationException(errors);
            }

            var response = await next();

            return response;
        }
    }
}