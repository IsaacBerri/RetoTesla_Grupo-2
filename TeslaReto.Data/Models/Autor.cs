using TeslaACDC.Data.Models;

namespace TeslaReto.Data.Models;

public class Autor : BaseEntity<int> 
{
    public string Nombre { get; set;} = "";
    public string Apellido { get; set;} = "";
    public string Pseudonimos { get; set;} = "";
    public DateTime FechaNacimiento { get; set;} = DateTime.Now;
    public string Pais { get; set;} = "";
    public string Nacionalidad { get; set;} = "";
    public Boolean IsAlive { get; set;} = true;
    public int FechaMuerte { get; set;} = 0;
    public string Idiomas { get; set;} = "";
    public string Generos { get; set;} = "";
    public string Biografia { get; set;} = "";
    public string Galardones { get; set;} = "";
    public Boolean IsEnable { get; set;} = true;
}