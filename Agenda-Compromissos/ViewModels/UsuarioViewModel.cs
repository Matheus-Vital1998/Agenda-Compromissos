using Microsoft.Build.Framework;

namespace Agenda_Compromissos.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
