using AutoMapper;
using HungryPizza.Api.Model;
using HungryPizza.Domain;

namespace HungryPizza.Api.AutoMapper
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioModel>()
                .ForMember(c => c.Cpf, a => a.MapFrom(u => u.Cpf.ObterCpfFormatado()))
                .ForMember(c => c.Logradouro, a => a.MapFrom(u => u.Endereco.Logradouro))
                .ForMember(c => c.Numero, a => a.MapFrom(u => u.Endereco.Numero))
                .ForMember(c => c.Bairro, a => a.MapFrom(u => u.Endereco.Bairro))
                .ForMember(c => c.Cidade, a => a.MapFrom(u => u.Endereco.Cidade))
                .ForMember(c => c.UF, a => a.MapFrom(u => u.Endereco.UF));

            CreateMap<UsuarioModel, Usuario>()
                .ConstructUsing(u => new Usuario(u.Nome, u.Cpf, u.Logradouro, u.Numero, u.Bairro, u.Cidade, u.UF));
        }
    }
}
