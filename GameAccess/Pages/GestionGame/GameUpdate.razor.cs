using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Exercices.GestionGamer
{
    public partial class GamerUpdate
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IGameService Service { get; set; }
        public Game CurrentGame { get; set; }

        [Parameter]
        public EventCallback NotifyUpdatedGamer { get; set; }
        protected override void OnParametersSet()
        {
            CurrentGame = Service.GetById(Id);
        }

        public void OnValidSubmit()
        {
            Service.Update(CurrentGame);
            NotifyUpdatedGamer.InvokeAsync();
            
        }
    }
}
