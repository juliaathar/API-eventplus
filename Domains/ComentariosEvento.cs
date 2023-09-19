using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.eventplus.Domains
{
    [Table(nameof(ComentariosEvento))]
    public class ComentariosEvento
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Dê uma descrição")]
        public string? Descricao { get; set; }

        public bool? Exibe { get; set; }

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
