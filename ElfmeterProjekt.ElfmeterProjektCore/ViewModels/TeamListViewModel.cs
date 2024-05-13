using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ElfmeterProjekt.ElfmeterProjektCore.Messages;
using ElfmeterProjekt.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfmeterProjekt.ElfmeterProjektCore.ViewModels
{
    public partial class TeamListViewModel : ObservableObject
    {
        IRepository _repository;
        public TeamListViewModel(IRepository repository)
        {
            _repository = repository;

            WeakReferenceMessenger.Default.
                Register<AddMessage>(this, (r, m) =>
                {
                    //m.Value: unser Entry-Objekt
                    System.Diagnostics.Debug.WriteLine(m.Value);
                    //add to list
                    this.Teams.Add(m.Value);
                });

        }

        private bool _isLoaded = false;

        [ObservableProperty]
        ObservableCollection<Lib.Models.Team> _teams = [];



        [RelayCommand]
        void LoadData()

        {
            this.Teams.Clear();

                var entries = _repository.GetAll();

                foreach (var entry in entries)
                {
                    Teams.Add(entry);
                }
                
            

        }

    }
}
