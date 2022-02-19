using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class InscricaoEntity: BaseEntity
    {

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public DateTime vencimento { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public SituacaoInscricao situacao {get; set;}

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [ForeignKey("live")]
        public int idLive { get; set; }
        public LiveEntity? live { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [ForeignKey("inscrito")]
        public int idInscrito { get; set; }
        public InscritoEntity? inscrito { get; set; }
    }
}