namespace HungryPizza.Domain
{
    public class PedidoItem
    {
        public Guid Id { get; private set; }
        public Pedido Pedido { get; private set; }
        public Pizza Sabor1 { get; private set; }
        public Pizza? Sabor2 { get; private set; }

        protected PedidoItem()
        {

        }

        public PedidoItem(Pedido pedido, Pizza sabor1, Pizza sabor2)
        {            
            Id = Guid.NewGuid();

            Pedido = pedido;

            Sabor1 = sabor1;

            Sabor2 = sabor2;
        }

        public void IsValid()
        {
            if (Sabor1.EmFalta)
            {
                throw new Exception("Pizza em falta");
            }

            if (Sabor2 != null && Sabor2.EmFalta)
            {
                throw new Exception("Pizza em falta");
            }
        }
    }
}
