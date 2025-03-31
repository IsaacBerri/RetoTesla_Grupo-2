using System.ComponentModel.DataAnnotations;

namespace TeslaReto.Data.Models;


public class BaseEntity<TId>
where TId: struct
{
    [Key]
    public TId Id {get;set;}

    [Required]
    public bool IsActive { get; set; }
}