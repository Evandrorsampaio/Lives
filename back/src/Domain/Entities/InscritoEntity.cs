using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InscritoEntity: BaseEntity
    {
        public IEnumerable<InscricaoEntity>? inscricoes { get; set; }

        [ForeignKey("pessoa")]
        public int pessoaId { get; set; }
        public PessoaEntity? pessoa  { get; set; }
    }
}