using HungryPizza.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public Endereco Endereco { get; set; }

        protected Usuario()
        {

        }
        public Usuario(string nome, string cpf, string logradouro, int? numero, string bairro, string cidade, string uf)
        {
            Id = Guid.NewGuid();

            Nome = nome;

            DefinirCpf(cpf);

            DefinirEndereco(logradouro, numero, bairro, cidade, uf);
        }

        private void DefinirCpf(string cpf)
        {
            Cpf = new Cpf(cpf);
        }
       
        private void DefinirEndereco(string logradouro, int? numero, string bairro, string cidade, string uf)
        {            
            Endereco = new Endereco(logradouro, numero, bairro, cidade, uf);
        }
    }
}
