using Agenda_Compromissos.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Compromissos.Context
{
    public class Contexto : DbContext
    {
        public virtual DbSet<Compromisso> Compromisso { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
