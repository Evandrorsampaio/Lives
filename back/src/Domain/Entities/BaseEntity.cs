using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public abstract class BaseEntity
{
    [Key]
    public int id { get; set; }

    public Boolean ativo { get; set; }
}
