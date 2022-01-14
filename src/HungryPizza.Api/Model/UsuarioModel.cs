using System.ComponentModel.DataAnnotations;

namespace HungryPizza.Api.Model
{
    public class UsuarioModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser informado")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF deve ser informado")]
        [StringLength(14, MinimumLength = 11, ErrorMessage ="Verifique o CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o logradouro")]
        [MaxLength(200, ErrorMessage = "Logradouro deve ter no máximo {0} caracteres")]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        [MaxLength(100, ErrorMessage = "Bairro deve ter no máximo {0} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o cidade")]
        [MaxLength(100, ErrorMessage = "Cidade deve ter no máximo {0} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o UF")]
        [MaxLength(100, ErrorMessage = "UF deve ter no máximo {0} caracteres")]
        public string UF { get; set; }
    }
}
