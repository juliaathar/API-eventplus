using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.eventplus.Domains
{
    [Table(nameof(Instituicao))]
    public class Instituicao
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }


        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Endereco obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string? NomeFantasia { get; set; }
    }
}
