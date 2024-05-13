using ElfmeterProjekt.ElfmeterProjektCore.ViewModels;

namespace ElfmeterProjekt.ElfmeterProjektApp.Pages;

public partial class TeamList : ContentPage
{
	public TeamList(TeamListViewModel vw)
	{
		InitializeComponent();
		this.BindingContext = vw;
	}
}