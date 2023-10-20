using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_Compromissos.Models
{
    [Table("Compromisso")]
    public class Compromisso
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }
      
        [Column("Data")]
        [Display(Name = "Data")]
        [Required(ErrorMessage = "A data do compromisso é um campo obrigatorio!")]
        public DateTime DataCompromisso { get; set; }
     
        [Column("Hora")]
        [Display(Name = "Hora")]
        [Required(ErrorMessage = "A hora do compromisso é um campo obrigatorio!")]
        public string  HoraCompromisso { get; set; }

        [Column("Participantes")]
        public string Participantes { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Adicione uma breve descrição sobre o copromisso")]
        public string Descricao { get; set; }
    }
}
