namespace ToDoListCodeFirst.CQRS
{
    public interface ICommandHandler<TCommand, TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}