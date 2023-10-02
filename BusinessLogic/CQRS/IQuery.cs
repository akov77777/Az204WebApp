using MediatR;

namespace BusinessLogic.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}