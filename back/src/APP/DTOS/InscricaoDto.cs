using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Utils;

namespace APP.DTOS
{
    public class InscricaoDto: BaseDto
    {
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public DateTime vencimento { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public SituacaoInscricao situacao {get; set;}

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int idLive { get; set; }
        public LiveDto? live { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int idInscrito { get; set; }
        public InscritoDto? inscrito { get; set; }

        public string codigoBoleto {
            
            get{

                Boleto boleto = new Boleto(valor, vencimento);
                return boleto.getCodigoPagamento();
            
            }
        }

    }

}