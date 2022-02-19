using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP.DTOS
{
    public class LiveDto: BaseDto
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
        public int idInstrutor { get; set; }
        public InstrutorDto? instrutor { get; set; }

        public IEnumerable<InscricaoDto>? inscricoes { get; set; }       
   }

}