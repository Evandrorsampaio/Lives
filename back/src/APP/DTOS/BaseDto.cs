using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.DTOS
{
    public class BaseDto
    {
        public BaseDto()
        {
            this.ativo = true;
        }
        public int id { get; set; }
        public Boolean ativo { get; set; }
    }

}