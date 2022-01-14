using Bogus;
using Bogus.Extensions.Brazil;
using HungryPizza.Api.Model;
using HungryPizza.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace HungryPizza.Api.Tests.Integracao
{
    public class IntegracaoFixture
    {        
        private HttpClient _client;

        public HttpClient ObterClient()
        {
            if (_client == null)
            {
                var builder = new WebHostBuilder()
                                    .UseEnvironment("Testing")
                                    .UseConfiguration(new ConfigurationBuilder()                                        
                                        .AddJsonFile("appsettings.Testing.json")
                                        .Build()
                                    ).UseStartup<Startup>();

                var server = new TestServer(builder);

                var db = (HungryPizzaContext)server.Services.GetService(typeof(HungryPizzaContext));

                db.Database.EnsureDeleted();

                //db.Database.EnsureCreated();

                db.Database.Migrate();

                _client = server.CreateClient();
            }

            return _client;
        }     
        
        public UsuarioModel ObterUsuarioModelFake()
        {
            return new Faker<UsuarioModel>("pt_BR")
                                .RuleFor(c => c.Nome, f => f.Person.FullName)
                                .RuleFor(c => c.Cpf, f => f.Person.Cpf())
                                .RuleFor(c => c.Logradouro, "Nome logradouro")
                                .RuleFor(c => c.Bairro, "Nome bairro")
                                .RuleFor(c => c.Cidade, "Nome cidade")
                                .RuleFor(c => c.UF, "UF")
                                .Generate();
        }
    }
}
