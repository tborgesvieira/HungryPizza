using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Domain.Tests.Domain
{
    public class UsuarioTests
    {

        [Fact]
        public void Usuario_Endereco_Valido()
        {
            //Arrange
            var faker = new Faker();
           
            //Act
            var usuario = new Usuario(faker.Person.FullName, faker.Person.Cpf(), "teste", 1, "teste", "teste", "mg");

            //Assert
            Assert.NotNull(usuario);
        }

        [Fact]
        public void Usuario_Endereco_InvalidoCPF()
        {
            //Arrange
            var faker = new Faker();

            //Act
            var exception = Assert.Throws<Exception>(() => new Usuario(faker.Person.FullName, "00011100011", "teste", 1, "teste", "teste", "mg"));

            //Assert
            Assert.Equal("CPF inválido", exception.Message);
        }

        [Fact]
        public void Usuario_Endereco_EnderecoInvalido()
        {
            //Arrange
            var faker = new Faker();

            //Act
            var exception = Assert.Throws<Exception>(() => new Usuario(faker.Person.FullName, faker.Person.Cpf(), "", 1, "", "", ""));

            //Assert
            Assert.Equal("Informar o endereço completo", exception.Message);
        }
    }
}
