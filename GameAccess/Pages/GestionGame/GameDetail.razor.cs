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
        public Game CurrentGame { get; set; }

        protected override void OnParametersSet()
        {
            CurrentGame = Service.GetById(Id);
        }
    }
}
