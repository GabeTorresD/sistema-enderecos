using System.ComponentModel.DataAnnotations;

namespace SistemaEnderecos.Models
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o UF")]
        [Display(Name = "UF")]
        public string Uf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o número")]
        [Display(Name = "Número")]
        public string Numero { get; set; } = string.Empty;
    }
}