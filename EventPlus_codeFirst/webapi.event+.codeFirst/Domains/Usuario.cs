using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.codeFirst.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do usuario obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuario obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        [Required(ErrorMessage = "Senha do usuario obrigatório!")]
        [StringLength(60,MinimumLength =6, ErrorMessage ="Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        //Referencia com a tabela TiposUsuario FK
        [Required(ErrorMessage ="Informe o tipo do usuário!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        //[ForeignKey("IdTipoUsuario)]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
