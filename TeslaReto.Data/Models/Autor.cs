using System.ComponentModel.DataAnnotations;

namespace TeslaReto.Data.Models;

public class Autor : BaseEntity<int> 
{
    [Required]
    public string Nombre { get; set;} = "";
    [Required]
    public string Apellido { get; set;} = "";
    public string Pseudonimos { get; set;} = "";
    [Required]
    public DateTime FechaNacimiento { get; set;} = DateTime.Now;
    [Required]
    public string Pais { get; set;} = "";
    public string Nacionalidad { get; set;} = "";
    public bool IsAlive { get; set;} = true;
    public int FechaMuerte { get; set;} = 0;
    public string Idiomas { get; set;} = "";
    public string Generos { get; set;} = "";
    public string Biografia { get; set;} = "";
    public string Galardones { get; set;} = "";
    public bool IsEnable { get; set;} = true;
    // public ICollection<Libro> Libros { get; set; } = new List<Libro>();
}