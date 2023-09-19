using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.eventplus.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data obrigatória")]
        public DateTime? DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatório")]
        public string? NomeEvento { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do evento obrigatório")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Tipo de evento obrigatório")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set; }

        [Required(ErrorMessage = "Tipo de evento obrigatório")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }

    }
}
