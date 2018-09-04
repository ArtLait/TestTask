namespace TestTask.Data.Repositories
{
    public interface IUnitOfWork<TContext, T>
        where TContext : class
        where T : class
    {
        IRepository<T> GetRepository(string repositoryName);
        void Commit();
        void Register(IRepository<T> genericRepository);
    }
}
