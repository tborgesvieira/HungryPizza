using AutoMapper;
using HungryPizza.Api.Model;
using HungryPizza.Domain;

namespace HungryPizza.Api.AutoMapper
{
    public class PedidoMapper : Profile
    {
        public PedidoMapper()
        {
            CreateMap<Pedido, PedidoModel>()
                .ForMember(pm => pm.Logradouro, a => a.MapFrom(pm => pm.EnderecoEntrega.Logradouro))
                .ForMember(pm => pm.Numero, a => a.MapFrom(pm => pm.EnderecoEntrega.Numero))
                .ForMember(pm => pm.Cidade, a => a.MapFrom(pm => pm.EnderecoEntrega.Cidade))
                .ForMember(pm => pm.UF, a => a.MapFrom(pm => pm.EnderecoEntrega.UF))
                .ForMember(pm => pm.ValorTotal, a => a.MapFrom(pm => pm.ValorPedido))
                .ForMember(pm => pm.CPF, a => a.MapFrom(pm => pm.Cpf.ObterCpfFormatado()));

            CreateMap<PedidoItem, PedidoItemModel>()
                .ForMember(pim => pim.Sabor1, a => a.MapFrom(pi => pi.Sabor1.Id))
                .ForMember(pim => pim.NomeSabor1, a => a.MapFrom(pi => pi.Sabor1.Sabor))
                .ForMember(pim => pim.Sabor2, a => a.MapFrom(pi => pi.Sabor2.Id))
                .ForMember(pim => pim.NomeSabor2, a => a.MapFrom(pi => pi.Sabor2.Sabor));                
        }
    }
}
