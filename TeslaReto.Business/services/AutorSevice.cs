using System.Net;
using TeslaReto.Business.Interfaces;
using TeslaReto.Data.IRepositories;
using TeslaReto.Data.Models;

namespace TeslaACDC.Business.Services;

public class AutorService : IAutorService
{
    private readonly IAutorRepository<int, Autor> _autorRepository;

    public AutorService(IAutorRepository<int, Autor> autorRepository)
    {
        _autorRepository = autorRepository ?? throw new ArgumentNullException(nameof(autorRepository));
    }

    public async Task<BaseMessage<Autor>> GetAll()
    {
        var response = new BaseMessage<Autor>();
        try
        {
            var autores = await _autorRepository.GetAllAsync();

            response.ResponseElements = autores.ToList();
            response.TotalElements = response.ResponseElements.Count;
            response.StatusCode = HttpStatusCode.OK;
            response.Message = response.TotalElements > 0 ? "Autores obtenidos correctamente." : "No se encontraron autores.";
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.Message = $"Error al obtener los autores: {ex.Message}";
        }
        return response;
    }

    public async Task<BaseMessage<Autor>> GetById(int id)
    {
        var response = new BaseMessage<Autor>();
        try
        {
            var autor = await _autorRepository.GetByIdAsync(id);

            if (autor == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Autor no encontrado.";
            }
            else
            {
                response.ResponseElements.Add(autor);
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Autor encontrado correctamente.";
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.Message = $"Error al obtener el autor: {ex.Message}";
        }
        return response;
    }

    public async Task<BaseMessage<Autor>> AddAlbum(Autor autor)
    {
        var response = new BaseMessage<Autor>();
        try
        {
            if (autor == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Los datos del autor no pueden ser nulos.";
                return response;
            }

            await _autorRepository.AddAsync(autor);
            response.ResponseElements.Add(autor);
            response.StatusCode = HttpStatusCode.Created;
            response.Message = "Autor agregado correctamente.";
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.Message = $"Error al agregar el autor: {ex.Message}";
        }
        return response;
    }

    public async Task<BaseMessage<Autor>> UpdateAlbum(int id, Autor autor)
    {
        var response = new BaseMessage<Autor>();
        try
        {
            if (autor == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Los datos del autor no pueden ser nulos.";
                return response;
            }

            var updatedAutor = await _autorRepository.UpdateAsync(id, autor);
            response.ResponseElements.Add(updatedAutor);
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "Autor actualizado correctamente.";
        }
        catch (KeyNotFoundException)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "No se encontró el autor para actualizar.";
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.Message = $"Error al actualizar el autor: {ex.Message}";
        }
        return response;
    }

    public async Task<BaseMessage<Autor>> DeleteAlbum(int id)
    {
        var response = new BaseMessage<Autor>();
        try
        {
            var deletedAutor = await _autorRepository.DeleteAsync(id);
            response.ResponseElements.Add(deletedAutor);
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "Autor eliminado correctamente.";
        }
        catch (KeyNotFoundException)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "No se encontró el autor para eliminar.";
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.Message = $"Error al eliminar el autor: {ex.Message}";
        }
        return response;
    }
}

