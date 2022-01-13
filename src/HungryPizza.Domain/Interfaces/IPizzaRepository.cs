namespace HungryPizza.Domain.Interfaces
{
    public interface IPizzaRepository : IDisposable
    {
        Task<IEnumerable<Pizza>> ObterTodos();
    }
}
