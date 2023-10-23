using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_Compromissos.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "O nome do usuario é um campo obrigatorio!")]
        public string  Nome { get; set; }

        [Column("Login")]
        [Required(ErrorMessage = "Digite um login!")]
        public string Login { get; set; }

        [Column("Senha")]
        [Required(ErrorMessage = "Digite a senha!")]
        public string Senha { get; set; }
    }
}
