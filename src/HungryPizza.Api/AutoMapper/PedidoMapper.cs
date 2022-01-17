using AutoMapper;
using HungryPizza.Api.Model;
using HungryPizza.Domain;

namespace HungryPizza.Api.AutoMapper
{
    public class PedidoMapper : Profile
    {
        public PedidoMapper()
        {
            CreateMap<Pedido, PedidoRetornoModel>()
                .ForMember(pm => pm.QuantidadeItens, a => a.MapFrom(pm => pm.Itens.Count));                          
        }
    }
}
