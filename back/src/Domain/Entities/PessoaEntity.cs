using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PessoaEntity: BaseEntity
    {
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre 3 e 50 caracteres.")]
        public string? nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "{0} deve ter entre 3 e 50 caracteres.")]
        [EmailAddress(ErrorMessage = "Deve ser um e-Mail válido.")]
        public string? email { get; set; }

        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres.")]
        [RegularExpression("@([A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\\.(?!\\.))){0,28}(?:[A-Za-z0-9_]))?)"
                            , ErrorMessage = "Deve ser um perfil do Instagram válido.")]
        public string? instagram { get; set; }

        public DateTime? dtNascimento { get; set; }
    }
}