using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minimal_api.Dominio.Entidades
{
    public class Veiculo
    {
        public Veiculo(string nome, string marca, int ano)
        {
            Nome = nome;
            Marca = marca;
            Ano = ano;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; } = default!;

        [Required]
        [StringLength(255)]
        public string Nome { get; set; } = default!;
        [Required]
        [StringLength(50)]
        public string Marca { get; set; } = default!;
        [Required]
        [StringLength(10)]
        public int Ano { get; set; } = default!;
    }
}