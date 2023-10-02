using MediatR;

namespace BusinessLogic.CQRS
{
    public interface IQueryHandler<in TQuery, TResponse> :
       IRequestHandler<TQuery, TResponse>
       where TQuery : IQuery<TResponse>
    {
    }
}