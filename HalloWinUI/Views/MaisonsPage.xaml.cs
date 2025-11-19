using HalloWinUI.Data;
using HalloWinUI.Models;
using HalloWinUI.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Diagnostics;

namespace HalloWinUI.Views
{

    public sealed partial class MaisonsPage : Page
    {
        public MainMaisonsViewModel ViewModel { get; }

        public MaisonsPage()
        {
            InitializeComponent();
            ViewModel = new MainMaisonsViewModel(new HalloweenDataProvider());
            root.Loaded += Root_Loaded;
        }

        private void Root_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ChargerMaisons();
        }

        private async void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.MaisonSelectionnee == null)
            {
                return;
            }

            // Affichage d'une boîte de dialogue de confirmation de suppression
            ContentDialog dialog = new ContentDialog
            {
                Title = "Confirmer la suppression",
                Content = $"Êtes-vous sûr de vouloir supprimer la maison à l'adresse :\n{ViewModel.MaisonSelectionnee.Adresse}?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler",
                DefaultButton = ContentDialogButton.Close
            };

            dialog.XamlRoot = this.Content.XamlRoot;

            ContentDialogResult result = await dialog.ShowAsync();

            // Si l'utilisateur a cliqué sur le bouton "Supprimer"
            if (result == ContentDialogResult.Primary)
            {
                ViewModel.SupprimerMaison();
            }
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Utiliser viewmodel pour la vérification. Tout le traitement de données dans ViewModel.
            //      Côté code behind on garde un minimum de manpulation (ex.: événements UI, minimum de manipulations
            //      d'éléments xaml, appels méthodes du ViewModel)
            if (nouvelleMaisonTextBox.Text != "")
            {
                // TODO: Pas be binding manuel, laisser x:Bind le faire!
                ViewModel.NouvelleMaison = nouvelleMaisonTextBox.Text;
                ViewModel.AjouterMaison();

                // TODO: Côté ViewModel, NouvelleMaison doit être mise
                //          à jour VIA BINDING. Ce n'est pas le cas actuellement.
                nouvelleMaisonTextBox.Text = "";
            }
        }
    }
}
