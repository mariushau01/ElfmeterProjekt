using ElfmeterProjekt.ElfmeterProjektCore.ViewModels;

namespace ElfmeterProjekt.ElfmeterProjektApp.Pages;

public partial class AddTeam : ContentPage
{
	public AddTeam(AddTeamViewModel vw)
	{
		InitializeComponent();
		this.BindingContext = vw;
	}
}