using System.ComponentModel.DataAnnotations;

namespace HungryPizza.Api.Model
{
    public class PedidoRetornoModel
    {
        public Guid Id { get;set; }
        public double ValorPedido { get; set; }
        public DateTime DataHora { get; set; }
        public int QuantidadeItens { get; set; }
    }

    public class PedidoModel
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Informe o CPF")]
        public string CPF { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public double? ValorTotal { get; set; }
        public IEnumerable<PedidoItemModel> Itens { get; set; }
    }

    public class PedidoItemModel
    {
        [Required(ErrorMessage = "Informar 1 Sabor")]
        public Guid Sabor1 { get; set; }
        public string? NomeSabor1 { get; set; }
        public Guid? Sabor2 { get; set; }
        public string? NomeSabor2 { get; set; }
    }
}
