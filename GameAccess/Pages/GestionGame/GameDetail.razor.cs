using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;

namespace GameAccess.Pages.GestionGame
{
    public partial class GameDetail
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IGameService Service { get; set; }
        public Game CurrentGame { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            CurrentGame = await Service.Get(Id);
            
        }
    }
}
