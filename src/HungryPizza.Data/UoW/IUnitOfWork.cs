namespace HungryPizza.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
