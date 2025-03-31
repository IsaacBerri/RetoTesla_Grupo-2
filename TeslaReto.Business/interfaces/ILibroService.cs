using System.Threading.Tasks;
using TeslaReto.Data.Models;

namespace TeslaReto.Business.Interfaces;
public interface ILibroService
{

    Task<BaseMessage<IEnumerable<Libro>>> SearchBooks(
        string? titulo = null,
        int? autorId = null,
        string? genero = null,
        string? idioma = null,
        string? formato = null,
        int? anioPublicacion = null,
        string? editorial = null,
        string? isbn13 = null
    );
    Task<BaseMessage<Libro>> AddLibro(Libro libro);
    Task<BaseMessage<Libro>> UpdateLibro(int id, Libro libro);
    Task<BaseMessage<Libro>> DeleteLibro(int id);
}

