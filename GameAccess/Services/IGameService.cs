using GameAccess.Models;

namespace GameAccess.Services
{
    public interface IGameService
    {
        Task<Game?> Get(int id);
        Task<IEnumerable<Game>?> GetAll();
        Task Set(Game game);
        Task Delete(int id);
        Task Update(UpdateGame game,int id);

    }
}