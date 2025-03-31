using TeslaReto.Data.Models;

namespace TeslaReto.Business.Interfaces;

public interface IAutorService
{
    Task<BaseMessage<Autor>> GetById(int id);
    Task<BaseMessage<Autor>> GetAll();
    Task<BaseMessage<Autor>> AddAlbum(Autor autor);
    Task<BaseMessage<Autor>> UpdateAlbum(int id, Autor autor);
    Task<BaseMessage<Autor>> DeleteAlbum(int id);
}