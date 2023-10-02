using MediatR;

namespace BusinessLogic.CQRS
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }

    public interface ICommand : IRequest
    {
    }
}