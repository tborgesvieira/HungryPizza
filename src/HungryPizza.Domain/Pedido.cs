using HungryPizza.Domain.ValueObjects;

namespace HungryPizza.Domain
{
    public class Pedido
    {
        public const int Quantidade_Maxima_Itens = 10;

        public Guid Id { get; private set; }
        public Usuario Usuario { get; private set; }
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

        public Pedido(string logradouro, int? numero, string bairro, string cidade, string uf)
        {
            Id = Guid.NewGuid();

            EnderecoEntrega = new Endereco(logradouro, numero, bairro, cidade, uf);

            Usuario = null;
        }

        public void AdicionarItem(Pizza sabor1, Pizza sabor2)
        {
            if (Itens == null) Itens = new List<PedidoItem>();

            var pedidoItem = new PedidoItem(this, sabor1, sabor2);

            var valor = sabor1.Valor;

            if (sabor2 != null)
            {
                valor += sabor2.Valor;

                valor /= 2;
            }

            ValorPedido += valor;

            Itens.Add(pedidoItem);
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
        }
    }
}
