namespace TeslaReto.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TeslaReto.Business.Interfaces;
using TeslaReto.Data.Models;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

[ApiController]
[Route("api/autor")]
[EnableCors("AllowAll")] 
public class AutorController : ControllerBase
{
    private readonly IAutorService _autorService;

    public AutorController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    // 🔹 Obtener todos los autores
    [HttpGet]
    [Route("GetAllAuthors")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _autorService.GetAll();
        return StatusCode((int)result.StatusCode, result);
    }

    // 🔹 Obtener un autor por ID
    [HttpGet]
    [Route("GetAuthor/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _autorService.GetById(id);
        if (result.StatusCode == HttpStatusCode.NotFound)
            return NotFound(result);
        
        return Ok(result);
    }

    // 🔹 Crear un nuevo autor
    [HttpPost]
    [Route("addAutor")]
    public async Task<IActionResult> Add([FromBody] Autor autor)
    {
        if (autor == null)
            return BadRequest("El autor no puede ser nulo.");

        var result = await _autorService.AddAlbum(autor);
        return StatusCode((int)result.StatusCode, result);
    }

    // 🔹 Actualizar un autor existente
    [HttpPut]
    [Route("UpdateAuthor/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Autor autor)
    {
        if (autor == null)
            return BadRequest("El autor no puede ser nulo.");

        var result = await _autorService.UpdateAlbum(id, autor);
        if (result.StatusCode == HttpStatusCode.NotFound)
            return NotFound(result);
        
        return Ok(result);
    }

    // 🔹 Eliminar un autor por ID
    [HttpDelete]
    [Route("DeleteAuthor/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _autorService.DeleteAlbum(id);
        if (result.StatusCode == HttpStatusCode.NotFound)
            return NotFound(result);
        
        return Ok(result);
    }
}
