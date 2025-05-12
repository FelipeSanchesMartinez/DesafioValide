using MediatR;

namespace DesafioValide.Application.Requests.Entities
{
    public class DeleteEntityByIdRequest<TRequest> : IRequest
    {
        public int? Id { get; set; }
        public DeleteEntityByIdRequest(int id)
        {
            Id = id;
        }
    }
}
