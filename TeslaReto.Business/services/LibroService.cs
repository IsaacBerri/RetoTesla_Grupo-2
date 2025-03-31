using System;
using System.Net;
using TeslaReto.Business.Interfaces;
using TeslaReto.Data.IRepositories;
using TeslaReto.Data.Models;

namespace TeslaReto.Business.Services;

public class LibroService : ILibroService
{
    private readonly ILibroRepository<int, Libro> _libroRepository;

    public LibroService(ILibroRepository<int, Libro> libroRepository)
    {
        _libroRepository = libroRepository ?? throw new ArgumentNullException(nameof(libroRepository));
    }

    public async Task<BaseMessage<IEnumerable<Libro>>> SearchBooks(
    string? titulo = null,
    int? autorId = null,
    string? genero = null,
    string? idioma = null,
    string? formato = null,
    int? anioPublicacion = null,
    string? editorial = null,
    string? isbn13 = null)
{
    var libros = await _libroRepository.SearchBooksAsync(
        titulo, autorId, genero, idioma, formato, anioPublicacion, editorial, isbn13
    );

    if (libros == null || !libros.Any())
        return new BaseMessage<IEnumerable<Libro>>
        {
            StatusCode = HttpStatusCode.NotFound,
            Message = "No se encontraron libros.",
            TotalElements = 0,
            ResponseElements = []
        };

    return new BaseMessage<IEnumerable<Libro>>
    {
        StatusCode = HttpStatusCode.OK,
        Message = "Libros encontrados.",
        TotalElements = libros.Count(),
        ResponseElements = [libros]
    };
}

    public async Task<BaseMessage<Libro>> AddLibro(Libro libro)
    {
        if (libro == null)
            return new BaseMessage<Libro>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "El libro no puede ser nulo."
            };

        await _libroRepository.AddAsync(libro);
        return new BaseMessage<Libro>
        {
            StatusCode = HttpStatusCode.Created,
            Message = "Libro agregado correctamente.",
            ResponseElements = new List<Libro> { libro },
            TotalElements = 1
        };
    }

    public async Task<BaseMessage<Libro>> DeleteLibro(int id)
    {
        var libro = await _libroRepository.DeleteAsync(id);
        if (libro == null)
            return new BaseMessage<Libro>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "No se encontró el libro para eliminar."
            };

        return new BaseMessage<Libro>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Libro eliminado correctamente.",
            ResponseElements = new List<Libro> { libro },
            TotalElements = 1
        };
    }

    public async Task<BaseMessage<Libro>> UpdateLibro(int id, Libro libro)
    {
        if (libro == null)
            return new BaseMessage<Libro>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "El libro no puede ser nulo."
            };

        var updatedLibro = await _libroRepository.UpdateAsync(id, libro);
        if (updatedLibro == null)
            return new BaseMessage<Libro>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "No se pudo actualizar el libro."
            };

        return new BaseMessage<Libro>
        {
            StatusCode = HttpStatusCode.OK,
            Message = "Libro actualizado correctamente.",
            ResponseElements = new List<Libro> { updatedLibro },
            TotalElements = 1
        };
    }
}


