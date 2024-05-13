using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElfmeterProjekt.Lib.Interfaces;
using ElfmeterProjekt.Lib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfmeterProjekt.ElfmeterProjektCore.ViewModels
{
    public partial class MainViewModel(IRepository repository, IAlertService alertService) : ObservableObject
    {

        IRepository _repository = repository;
        IAlertService _alertService = alertService;

        private bool _isLoaded = false;

        [ObservableProperty]
        ObservableCollection<Lib.Models.Team> _teams = [];

        [ObservableProperty]
        Lib.Models.Team _selectedTeam = null;

        [ObservableProperty]
        Lib.Models.Team _selectedTeam2= null;

        [RelayCommand]
        void Load()
        {

            this.Teams.Clear();

            
            
                var teams = _repository.GetAll();

                foreach (var entry in teams)
                {
                    Teams.Add(entry);
                }
               
        }

        [RelayCommand]
        public void Delete()
        {
            if (SelectedTeam != null)
            {
                
                _repository.Delete(SelectedTeam);
                this.Teams.Remove(SelectedTeam);
                _alertService.ShowAlert("Erfolg!",
                    "Das Team wurde gelöscht!");


            }
            else
            {
                _alertService.ShowAlert("Fehler!",
                    "Bitte wählen sie ein Team aus!");
            }
        }

        [RelayCommand]
        public void Update(Team team)
        {
            team = SelectedTeam;

            if (team != null)
            {
                var result = _repository.Update(team);


                this.Teams.Clear();

                foreach (var entry in _repository.GetAll())
                {
                    this.Teams.Add(entry);
                }
                    
                        _alertService.ShowAlert("Erfolg!",
                            "Das Team wurde bearbeitet!");
               
                    
                
            }
        }


        [RelayCommand]
        public void Play()
        {
            if (SelectedTeam.Id == SelectedTeam2.Id)
            {
                _alertService.ShowAlert("Fehler!",
                    "Ein Team kann nicht gegen sich Selbst spielen!");
            }
            else
            {
                _alertService.ShowAlert($"Elfmeterschießen beginnt! {SelectedTeam.TeamName} gegen {SelectedTeam2.TeamName}",
                    "Klicke 'Ok' um zu starten!");

                _alertService.ShowAlert($"{SelectedTeam.TeamName}",
                    "beginnt zu schießen!");

                int count = 0;
                int count2 = 0;

                for (int i = 0; i < 5; i++)
                {
                    Random random = new Random();
                    int gen = random.Next(1,11);

                    if (gen > 5)
                    {
                        _alertService.ShowAlert($"Treffer für {SelectedTeam.TeamName}",
                            $"{SelectedTeam.TeamName} hat getroffen und erhalten 1nen Punkt!");
                        count++;
                    }
                    else
                    {
                        _alertService.ShowAlert("Knapp Vorbei!",
                            $"{SelectedTeam.TeamName} konnte das Tor nicht treffen!");
                    }
                }

                _alertService.ShowAlert("ZwischenStand!",
                   $"{SelectedTeam.TeamName} konnte {count} Punkte erzielen!");

                _alertService.ShowAlert($"{SelectedTeam2.TeamName}",
                    "beginnt zu schießen!");

                for (int i = 0; i < 5; i++)
                {
                    Random random = new Random();
                    int gen = random.Next(1, 11);

                    if (gen > 5)
                    {
                        _alertService.ShowAlert($"Treffer für {SelectedTeam2.TeamName}",
                            $"{SelectedTeam2.TeamName} hat getroffen und erhalten 1nen Punkt!");
                        count2++;
                    }
                    else
                    {
                        _alertService.ShowAlert("Knapp Vorbei!",
                            $"{SelectedTeam2.TeamName} konnte das Tor nicht treffen!");
                    }
                }

                _alertService.ShowAlert("ZwischenStand!",
                   $"{SelectedTeam2.TeamName} konnte {count2} Punkte erzielen!");

                if (count == count2)
                {
                    _alertService.ShowAlert("Unentschieden!",
                        "Beide Teams haben gleich viele Tore geschossen!");
                }
                else if (count > count2)
                {
                    _alertService.ShowAlert($"Gewinner {SelectedTeam.TeamName}!",
                        $"{SelectedTeam.TeamName} hat {count - count2} Tor(e) mehr geschossen!");
                }
                else
                {
                    _alertService.ShowAlert($"Gewinner {SelectedTeam2.TeamName}!",
                        $"{SelectedTeam2.TeamName} hat {count2 - count} Tor(e) mehr geschossen!");
                }



            }
        }

    }
}
