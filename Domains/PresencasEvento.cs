using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.eventplus.Domains
{
    [Table(nameof(PresencasEvento))]
    public class PresencasEvento
    {
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100")]
        [Required(ErrorMessage = "Informe a situação da presença")]
        public string? Situacao { get; set; }

        [Required(ErrorMessage = "Informe o usuário!")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Informe o evento!")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
