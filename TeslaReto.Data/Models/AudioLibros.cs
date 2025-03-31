using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeslaReto.Data.Models;

public class AudioLibros : BaseEntity<int>
{
    [Required]
    public string Titulo { get; set; } = "";

    [Required]
    [ForeignKey("AutorId")]
    public int AutorId { get; set; }

    public string Genero { get; set; } = "";

    public int Duración { get; set; }

    public int Tamaño { get; set; }





}
