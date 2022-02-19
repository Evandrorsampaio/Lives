using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.DTOS
{
    public class InstrutorDto:BaseDto
    {
        public IEnumerable<LiveDto>? lives { get; set; }
        public int pessoaId { get; set; }
        public PessoaDto? pessoa  { get; set; }

    }

}