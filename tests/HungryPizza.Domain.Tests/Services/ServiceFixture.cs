using Bogus;
using Bogus.Extensions.Brazil;

namespace HungryPizza.Domain.Tests.Services
{
    public class ServiceFixture
    {
        public Usuario ObterUsuarioFaker()
        {
            return new Faker<Usuario>("pt_BR")
                                .CustomInstantiator(f => new Usuario(f.Person.FullName,
                                                                     f.Person.Cpf(),
                                                                     "logradorou do usuario",
                                                                     10,
                                                                     "bairro usuario",
                                                                     "Brasília",
                                                                     "DF")).Generate();
        }
    }
}
