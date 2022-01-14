namespace HungryPizza.Domain.ValueObjects
{
    public class Endereco
    {
        public const int LogradouroMaxLength = 200;

        public const int BairroMaxLength = 100;

        public const int CidadeMaxLength = 100;

        public const int UFMaxLength = 2;

        public string Logradouro { get; private set; }
        public int? Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }

        protected Endereco()
        {

        }
        //Está com exception por ser uma solução mais simples mas o correto é disparar um domainvalidation e utilizar FluentValidation
        public Endereco(string logradouro, int? numero, string bairro, string cidade, string uf)
        {
            if (string.IsNullOrWhiteSpace(logradouro) ||
                string.IsNullOrWhiteSpace(bairro) ||
                string.IsNullOrWhiteSpace(cidade) ||
                string.IsNullOrWhiteSpace(uf))
            {
                throw new Exception("Informar o endereço completo");
            }

            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }
    }
}
