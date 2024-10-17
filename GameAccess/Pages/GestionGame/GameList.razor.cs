using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace GameAccess.Pages.GestionGame
{
    public partial class GameList
    {
        [Inject]
        public IGameService Service { get; set; }

        public List<Game> Liste { get; set; }

        public int SelectedDetailId { get; set; }
        public int SelectedUpdateId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Liste = new List<Game>();
            await LoadData();
        }

        public async Task LoadData()
        {
            Liste = (List<Game>)await Service.GetAll();
            SelectedUpdateId = 0;
        }

        public void SelectDetail(int id)
        {
            SelectedDetailId = id;
            SelectedUpdateId = 0;
        }

        public void SelectUpdate(int id)
        {
            SelectedUpdateId = id;
            SelectedDetailId = 0;
        }
    }
}
