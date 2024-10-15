using GameAccess.Models;
using GameAccess.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace DemoWASM.Pages.Exercices.GestionGamer
{
    public partial class GamerList
    {
        [Inject]
        public IGameService Service { get; set; }

        public List<Game> Liste { get; set; }

        public int SelectedDetailId { get; set; }
        public int SelectedUpdateId { get; set; }

        protected override void OnInitialized()
        {
            Liste = new List<Game>();
            LoadData();
        }

        public void LoadData() 
        {
            Liste = Service.GetAll();
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
