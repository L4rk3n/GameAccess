using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;

namespace GameAccess.Pages.GestionGame
{
    public partial class GameDelete
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]

        public IGameService Service { get; set; }
        public Game DeletedGame { get; set; } = new();

        [Parameter]
        public EventCallback NotifyDeletedGame { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            DeletedGame = await Service.Get(Id);

        }
        public async Task OnValidSubmitAsync()
        {
            await Service.Delete(Id);
            NotifyDeletedGame.InvokeAsync(DeletedGame);
        }
    }
}