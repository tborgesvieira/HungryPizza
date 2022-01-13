namespace HungryPizza.Domain
{
    public class Pizza
    {
        public Guid Id { get; private set; }
        public string Sabor { get; private set; }
        public double Valor { get; private set; }
        public bool EmFalta { get; private set; }

        public Pizza(string sabor, double valor)
        {
            Id = Guid.NewGuid();

            Sabor = sabor;

            Valor = valor;

            EmFalta = false;
        }
    }
}
