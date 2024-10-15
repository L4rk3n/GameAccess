using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercices.GestionGamer
{
    public partial class GamerDetail
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IGameService Service { get; set; }
        public Game CurrentGamer { get; set; }

        protected override void OnParametersSet()
        {
            CurrentGame = Service.GetById(Id);
        }
    }
}
