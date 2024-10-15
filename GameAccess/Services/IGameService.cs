﻿using GameAccess.Models;

namespace GameAccess.Services
{
    public interface IGameService
    {
        List<Game> GetAll();
        Game GetById(int id);
        void Save(Game game);
        void Update(Game game);
    }
}