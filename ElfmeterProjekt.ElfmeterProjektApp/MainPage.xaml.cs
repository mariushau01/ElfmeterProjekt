using ElfmeterProjekt.ElfmeterProjektCore.ViewModels;

namespace ElfmeterProjekt.ElfmeterProjektApp
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel vw)
        {
            InitializeComponent();
            this.BindingContext = vw;   
        }

        
    }

}
