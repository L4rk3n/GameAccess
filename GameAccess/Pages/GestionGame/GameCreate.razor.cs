using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;

namespace GameAccess.Pages.GestionGame
{
    public partial class GameCreate
    {
        [Inject]
        public IGameService Service { get; set; }

        [Parameter]
        public EventCallback NotifyNewGame { get; set; }

        public Game GameForm { get; set; }

        public GameCreate()
        {
            GameForm = new Game();
        }

        public void OnValidSubmit()
        {
            Service.Set(GameForm);
            NotifyNewGame.InvokeAsync();
            GameForm = new Game();

        }
    }
}
