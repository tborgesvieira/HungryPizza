using HungryPizza.Data.Context;

namespace HungryPizza.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HungryPizzaContext _hungryPizzaContext;

        public UnitOfWork(HungryPizzaContext hungryPizzaContext)
        {
            _hungryPizzaContext = hungryPizzaContext;
        }

        public bool Commit()
        {
            return _hungryPizzaContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _hungryPizzaContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
