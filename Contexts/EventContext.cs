using apiweb.eventplus.Domains;
using Microsoft.EntityFrameworkCore;

namespace apiweb.eventplus.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<TiposEvento> TiposEventos { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEvento { get; set; }
        public DbSet<ComentariosEvento>ComentariosEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE15-S14; Database= inlock_games_codeFirst_manha; User Id= sa; Pwd= Senai@134; TrustServerCertificate= True;")
            base.OnConfiguring(optionsBuilder);
        }

    }
}
