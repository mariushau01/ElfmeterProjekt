using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElfmeterProjekt.ElfmeterProjektCore.ViewModels;
using ElfmeterProjekt.Lib.Interfaces;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ElfmeterProjekt.ElfmeterProjektCore.Messages;

namespace ElfmeterProjekt.ElfmeterProjektCore.ViewModels
{
    public partial class AddTeamViewModel(IRepository repository, IAlertService alertService ) : ObservableObject
    {

        IRepository _repository = repository;
        IAlertService _alertService = alertService;

        [ObservableProperty]
        
        public string teamName;

        [ObservableProperty]
        
        public string liga;

        [RelayCommand]
        public void Add()
        {
            try
            {
                Lib.Models.Team team = new(this.TeamName, this.Liga);

                var result = _repository.Add(team);

                _alertService.ShowAlert("Erfolg",
                    "Das Team konnte hinzugefügt werden!");



                if (result)
                {
                    this.TeamName = "";
                    this.Liga = "";

                    
                }

            }
            catch (Exception ex)
            {
                _alertService.ShowAlert("Fehler",
                    "Ein Fehler ist aufgetreten!");
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
