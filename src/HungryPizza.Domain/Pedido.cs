using HungryPizza.Domain.ValueObjects;

namespace HungryPizza.Domain
{
    public class Pedido
    {
        public const int Quantidade_Maxima_Itens = 10;

        public Guid Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public Cpf Cpf { get; set; }
        public double ValorPedido { get; private set; }
        public Endereco EnderecoEntrega { get; set; }
        public ICollection<PedidoItem> Itens { get; private set; }

        protected Pedido()
        {

        }

        public Pedido(Usuario usuario)
        {
            Id = Guid.NewGuid();

            EnderecoEntrega = usuario.Endereco;
        }

        public Pedido(Cpf cpf, string logradouro, int? numero, string bairro, string cidade, string uf)
        {
            Id = Guid.NewGuid();

            EnderecoEntrega = new Endereco(logradouro, numero, bairro, cidade, uf);

            Usuario = null;

            Cpf = cpf;
        }

        public void AdicionarItem(Pizza sabor1, Pizza sabor2)
        {
            if (Itens == null) Itens = new List<PedidoItem>();

            var pedidoItem = new PedidoItem(this, sabor1, sabor2);            

            ValorPedido += ValorDoPedido(pedidoItem);

            Itens.Add(pedidoItem);
        }

        private double ValorDoPedido(PedidoItem pedidoItem)
        {
            var valor = pedidoItem.Sabor1.Valor;

            if (pedidoItem.Sabor2 != null)
            {
                valor += pedidoItem.Sabor2.Valor;

                valor /= 2;
            }

            return valor;
        }

        //Implementado com exception mas deve ser feito via notificação de domínio
        public void IsValid()
        {
            if (Itens == null || !Itens.Any())
            {
                throw new Exception("Pedido deve ter ao menos 1 item");
            }

            if (Itens.Count > Quantidade_Maxima_Itens)
            {
                throw new Exception($"Quantidade máxima de itens deve ser {Quantidade_Maxima_Itens}");
            }

            var valor = 0.0;

            foreach(var pedidoItem in Itens)
            {
                valor += ValorDoPedido(pedidoItem);
            }

            if (!ValorPedido.Equals(valor))
            {
                throw new Exception("Valor do pedido não confere com o dos itens");
            }
        }
    }
}
