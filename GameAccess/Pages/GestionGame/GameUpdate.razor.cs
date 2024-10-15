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
        public Game CurrentGame { get; set; }

        [Parameter]
        public EventCallback NotifyUpdatedGame { get; set; }
        protected override void OnParametersSet()
        {
            CurrentGame = Service.GetById(Id);
        }

        public void OnValidSubmit()
        {
            Service.Update(CurrentGame);
            NotifyUpdatedGame.InvokeAsync();

        }
    }
}
