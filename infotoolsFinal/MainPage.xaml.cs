using System.Collections.ObjectModel;

namespace infotoolsFinal
{
    public partial class MainPage : ContentPage
    {

        List<RendezVous> lesRendezVous = new List<RendezVous>();
        List<Identification> lesIdentifications = new List<Identification>();
        List<Commerciaux> lesCommerciaux = new List<Commerciaux>();

        public MainPage()
        {
            InitializeComponent();


            lesIdentifications.Add(new Identification(0, "chat"));
            lesIdentifications.Add(new Identification(1, "canard"));
            lesIdentifications.Add(new Identification(2, "poisson"));
            lesIdentifications.Add(new Identification(3, "teste"));
            lesIdentifications.Add(new Identification(4, "motdepasse"));

            // Ajout d'exemples de commerciaux à la collection
            lesCommerciaux.Add(new Commerciaux(1001, "Dupont", "Jean", "123 Rue de la République", "Paris", "75001", "jean.dupont@example.com", "01 23 45 67 89", lesIdentifications[0]));
            lesCommerciaux.Add(new Commerciaux(1002, "Martin", "Marie", "456 Avenue des Fleurs", "Lyon", "69000", "marie.martin@example.com", "04 56 78 90 12", lesIdentifications[1]));
            lesCommerciaux.Add(new Commerciaux(1003, "Dubois", "Pierre", "789 Boulevard de l'Indépendance", "Marseille", "13000", "pierre.dubois@example.com", "06 78 90 12 34", lesIdentifications[2]));
            lesCommerciaux.Add(new Commerciaux(1004, "Durand", "Anne", "1010 Rue Principale", "Lille", "59000", "teste@example.com", "03 45 67 89 01", lesIdentifications[3]));
            lesCommerciaux.Add(new Commerciaux(1005, "Lefebvre", "Jacques", "111 Chemin des Collines", "Toulouse", "31000", "jacques.lefebvre@example.com", "05 67 89 01 23", lesIdentifications[4]));


            // Association de chaque rendez-vous à un commercial de la liste
            lesRendezVous.Add(new RendezVous(1, "Dupont", "Jean", "jean.dupont@example.com", "01 23 45 67 89", 123456789, "Société A", "Paris", "75001", "123 Rue de la République", "2024-04-11", "09:00", "10:00", "Présentation produit", "Réunion de présentation des nouveaux produits", 1, lesCommerciaux[0]));
            lesRendezVous.Add(new RendezVous(2, "Martin", "Marie", "marie.martin@example.com", "04 56 78 90 12", 456789123, "Société B", "Lyon", "69000", "456 Avenue des Fleurs", "2024-04-12", "10:00", "11:00", "Démo logiciel", "Présentation des fonctionnalités du logiciel", 0, lesCommerciaux[1]));
            lesRendezVous.Add(new RendezVous(3, "Dubois", "Pierre", "pierre.dubois@example.com", "06 78 90 12 34", 789456123, "Société C", "Marseille", "13000", "789 Boulevard de l'Indépendance", "2024-04-13", "13:00", "14:00", "Formation produit", "Formation sur l'utilisation du produit", 1, lesCommerciaux[2]));
            lesRendezVous.Add(new RendezVous(4, "Durand", "Anne", "anne.durand@example.com", "03 45 67 89 01", 987123456, "Société D", "Lille", "59000", "1010 Rue Principale", "2024-04-14", "15:00", "16:00", "Négociation tarifaire", "Discussion sur les prix et remises", 0, lesCommerciaux[3]));
            lesRendezVous.Add(new RendezVous(5, "Lefebvre", "Jacques", "jacques.lefebvre@example.com", "05 67 89 01 23", 321654987, "Société E", "Toulouse", "31000", "111 Chemin des Collines", "2024-04-15", "09:00", "10:00", "Démo produit", "Démonstration des fonctionnalités du produit", 1, lesCommerciaux[4]));

            // Mettre à jour l'affichage des rendez-vous
            UpdateAppointmentsLayout();
        }

        void OnAddAppointmentClicked(object sender, EventArgs e)
        {
            // Récupérer les détails du rendez-vous à partir des entrées utilisateur
            string butRendezVous = titleEntry.Text;

            // Récupérer les détails supplémentaires
            string nomRendezVous = nomEntry.Text;
            string prenomRendezVous = prenomEntry.Text;
            string telRendezVous = telEntry.Text;
            string adresseRendezVous = adresseRdvEntry.Text;
            string villeRendezVous = villeEntry.Text;
            string nomSocieteRendezVous = nomSocieteEntry.Text;
            int numSirenEntrepriseRendezVous = Convert.ToInt32(numSirenEntry.Text);

            string mailRendezVous = " ";
            string cpRendezVous = " ";
            string dateRendezVous = Convert.ToString(datePicker.Date);
            string heureDebutRendezVous = Convert.ToString(timePickerBeg.Time);
            string heureFinRendezVous = Convert.ToString(timePickerEnd.Time);
            string descriptionRendezVous = " ";
            int confirmationRendezVous = 0;
            int numCommerciaux = 0;


            //Bdd.InsertRendezVous(nomRendezVous, prenomRendezVous, mailRendezVous, telRendezVous, numSirenEntrepriseRendezVous, nomSocieteRendezVous, villeRendezVous, cpRendezVous, adresseRendezVous, dateRendezVous, heureDebutRendezVous, heureFinRendezVous, butRendezVous, descriptionRendezVous, confirmationRendezVous, numCommerciaux);
            //lesRendezVous.Clear();
            //lesRendezVous = Bdd.SelectRendezVous();

            int numRendezVous = lesRendezVous[^1].NumRendezVous;
            lesRendezVous.Add(new RendezVous(numRendezVous+1, nomRendezVous, prenomRendezVous, mailRendezVous, telRendezVous, numSirenEntrepriseRendezVous, nomSocieteRendezVous, villeRendezVous, cpRendezVous, adresseRendezVous, dateRendezVous, heureDebutRendezVous, heureFinRendezVous, butRendezVous, descriptionRendezVous, confirmationRendezVous, lesCommerciaux[numCommerciaux]));

            // Effacer les champs d'entrée après l'ajout d'un rendez-vous
            ClearInputFields();

            // Rafraîchir l'affichage des rendez-vous
            UpdateAppointmentsLayout();
        }

        void OnAppointmentSelectionChanged(object sender, EventArgs e)
        {
            // Vérifier s'il y a un élément sélectionné
            if (appointmentsCollectionView.SelectedItem != null)
            {
                // Activer les boutons "Modifier" et "Supprimer"
                updateButton.IsEnabled = true;
                deleteButton.IsEnabled = true;
            }
            else
            {
                // Désactiver les boutons "Modifier" et "Supprimer"
                updateButton.IsEnabled = false;
                deleteButton.IsEnabled = false;
            }
        }

        void OnUpdateAppointmentClicked(object sender, EventArgs e)
        {
            // Vérifier s'il y a un rendez-vous sélectionné
            if (appointmentsCollectionView.SelectedItem != null)
            {
                // Récupérer l'élément sélectionné
                var selectedAppointment = (RendezVous)appointmentsCollectionView.SelectedItem;

                // Mettre à jour le titre du rendez-vous avec le texte de titleEntry
                selectedAppointment.ButRendezVous = titleEntry.Text;
                selectedAppointment.DateRendezVous = Convert.ToString(datePicker.Date);
                selectedAppointment.NomRendezVous = nomEntry.Text;
                selectedAppointment.PrenomRendezVous = prenomEntry.Text;
                selectedAppointment.TelRendezVous = telEntry.Text;
                selectedAppointment.AdresseRendezVous = adresseRdvEntry.Text;
                selectedAppointment.VilleRendezVous = villeEntry.Text;
                selectedAppointment.NomSocieteRendezVous = nomSocieteEntry.Text;
                selectedAppointment.NumSirenRendezVous = Convert.ToInt32(numSirenEntry.Text);

                // Mettre à jour l'affichage des rendez-vous
                UpdateAppointmentsLayout();
            }
            else
            {
                DisplayAlert("Error", "Please select an appointment to update", "OK");
            }
        }


        void OnDeleteAppointmentClicked(object sender, EventArgs e)
        {
            // Vérifier s'il y a un élément sélectionné
            if (appointmentsCollectionView.SelectedItem != null)
            {
                // Récupérer l'élément sélectionné
                var selectedAppointment = (RendezVous)appointmentsCollectionView.SelectedItem;

                // Gérer la logique de suppression basée sur l'élément sélectionné
                // Par exemple, vous pouvez demander une confirmation avant de supprimer
                // Dans cet exemple, je vais simplement afficher une boîte de dialogue pour illustrer
                DisplayAlert("Delete", $"Deleting appointment: {selectedAppointment.ButRendezVous}", "OK");

                // Supprimer l'élément sélectionné de la liste
                lesRendezVous.Remove(selectedAppointment);

                // Mettre à jour l'affichage des rendez-vous
                UpdateAppointmentsLayout();
            }
            else
            {
                DisplayAlert("Error", "Please select an appointment to delete", "OK");
            }
        }

        void ClearInputFields()
        {
            titleEntry.Text = string.Empty;
            datePicker.Date = DateTime.Today;
            timePickerBeg.Time = DateTime.Now.TimeOfDay;
            timePickerEnd.Time = DateTime.Now.TimeOfDay;
            nomEntry.Text = string.Empty;
            prenomEntry.Text = string.Empty;
            telEntry.Text = string.Empty;
            adresseRdvEntry.Text = string.Empty;
            villeEntry.Text = string.Empty;
            nomSocieteEntry.Text = string.Empty;
            numSirenEntry.Text = string.Empty;
        }

        void UpdateAppointmentsLayout()
        {
            appointmentsCollectionView.ItemsSource = null; // Pour vider la collection avant de la réinitialiser
            appointmentsCollectionView.ItemsSource = lesRendezVous;
        }
    }



}
