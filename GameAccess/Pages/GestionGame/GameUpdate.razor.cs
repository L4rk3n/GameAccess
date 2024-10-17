using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;

namespace GameAccess.Pages.GestionGame
{
    public partial class GameUpdate
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IGameService Service { get; set; }
        public UpdateGame CurrentGame { get; set; } = new();

        [Parameter]
        public EventCallback NotifyUpdatedGame { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            Game game = await Service.Get(Id);
            CurrentGame = new UpdateGame() {Title = game.Title,ReleaseYear = game.ReleaseYear,Synopsis=game.Synopsis };
        }

        public async Task OnValidSubmitAsync()
        {
            await Service.Update(CurrentGame, Id);
            NotifyUpdatedGame.InvokeAsync();

        }
    }
}
