using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.Entidades
{
    public class Administrador
    {
        public Administrador(string email, string senha, string perfil)
        {
            Email = email;
            Senha = senha;
            Perfil = perfil;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; } = default!;

        [Required]
        [StringLength(255)]
        public string Email { get; private set; } = default!;
        [Required]
        [StringLength(50)]
        public string Senha { get; private set; } = default!;
        [StringLength(10)]
        public string Perfil { get; private set; } = default!;
    }
}