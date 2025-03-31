using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TeslaReto.Business.Interfaces;
using TeslaReto.Data.Models;

namespace TeslaReto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")] 
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // Obtener libros con filtros
        [HttpGet]
        [Route("SearchBooks")]
         public async Task<IActionResult> SearchBooks(
            [FromQuery] string? titulo = null,
            [FromQuery] int? autorId = null,
            [FromQuery] string? genero = null,
            [FromQuery] string? idioma = null,
            [FromQuery] string? formato = null,
            [FromQuery] int? anioPublicacion = null,
            [FromQuery] string? editorial = null,
            [FromQuery] string? isbn13 = null)
        {
            var result = await _libroService.SearchBooks(titulo, autorId, genero, idioma, formato, anioPublicacion, editorial, isbn13);
            return StatusCode((int)result.StatusCode, result);
        }

        // Agregar un libro
        [HttpPost]
        [Route("AddLibro")]
        public async Task<IActionResult> AddLibro([FromBody] Libro libro)
        {
            var result = await _libroService.AddLibro(libro);
            return StatusCode((int)result.StatusCode, result);
        }

        // Actualizar un libro por ID
        [HttpPut]
        [Route("UpdateLibro/{id}")]
        public async Task<IActionResult> UpdateLibro(int id, [FromBody] Libro libro)
        {
            var result = await _libroService.UpdateLibro(id, libro);
            return StatusCode((int)result.StatusCode, result);
        }

        // Eliminar un libro por ID
        [HttpDelete]
        [Route("DeleteLibro/{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var result = await _libroService.DeleteLibro(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
