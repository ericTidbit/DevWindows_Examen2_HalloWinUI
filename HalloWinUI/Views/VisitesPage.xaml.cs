using HalloWinUI.Data;
using HalloWinUI.ViewModels.Pages;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;



namespace HalloWinUI.Views
{
    public sealed partial class VisitesPage : Page
    {
        public MainVisitesViewModel ViewModel { get; }

        public VisitesPage()
        {
            InitializeComponent();
            ViewModel = new MainVisitesViewModel(new HalloweenDataProvider());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Recharger les données à chaque navigation
            ViewModel.ChargerDonnees();
        }
    }
}
