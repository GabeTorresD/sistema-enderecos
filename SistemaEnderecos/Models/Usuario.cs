using System.ComponentModel.DataAnnotations;

namespace SistemaEnderecos.Models 
{
    public class Usuario 
    {
        //Chave primária
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;

        //relação 1 pra muitos. Criação da lista de endereços de cada usuário
        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}