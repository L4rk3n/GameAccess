using GameAccess.Models;

namespace GameAccess.Services
{
    public class GameService : IGameService
    {
        private Dictionary<int, Game> games;
        public GameService()
        {
            games = new Dictionary<int, Game>();
            games.Add(1, new Game
            {
                Id = 1,
                Title = "Test",
                ReleaseYear = 2024,
                Synopsis="blablabla"

            });
        }

        public List<Game> GetAll() { return games.Values.ToList(); }

        public Game GetById(int id)
        {
            return games[id];
        }

        public void Save(Game game)
        {
            game.Id = games.Values.Max(g => g.Id) + 1;

            games.Add(game.Id, game);
        }

        public void Update(Game game)
        {
            games[game.Id] = game;
        }
    }
}
