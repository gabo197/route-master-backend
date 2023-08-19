namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
