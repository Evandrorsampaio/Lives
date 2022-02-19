using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class LiveEntity: BaseEntity
    {
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre 3 e 50 caracteres.")]

        public string? nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre 3 e 250 caracteres.")]

        public string? descricao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public DateTime? dtHrInicio { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int duracaoMin { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [ForeignKey("instrutor")]
        public int idInstrutor { get; set; }
        public InstrutorEntity? instrutor { get; set; }

        public IEnumerable<InscricaoEntity>? inscricoes { get; set; }       
    }
}