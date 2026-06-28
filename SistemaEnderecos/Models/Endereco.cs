using System.ComponentModel.DataAnnotations;

namespace SistemaEnderecos.Models
{
    public class Endereco
    {
        //Chave primaria
        public int Id { get; set; }

        [Required]
        public string Cep { get; set; } = string.Empty;

        [Required]
        public string Logradouro { get; set; } = string.Empty;
        public string? Complemento {  get; set; }

        [Required]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        public string Uf {  get; set; } = string.Empty;

        [Required]
        public string Numero { get; set; } = string.Empty;

        //Chave estrangeira

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}