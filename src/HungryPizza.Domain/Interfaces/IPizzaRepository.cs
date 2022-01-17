namespace HungryPizza.Domain.Interfaces
{
    public interface IPizzaRepository : IDisposable
    {
        Task<IEnumerable<Pizza>> ObterTodos();
        Task<Pizza> ObterPorId(Guid id);
    }
}
