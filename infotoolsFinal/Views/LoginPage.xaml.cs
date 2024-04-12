using infotoolsFinal;

namespace LoginFlow.Views;

public partial class LoginPage : ContentPage
{
    List<RendezVous> lesRendezVous = new List<RendezVous>();
    List<Identification> lesIdentifications = new List<Identification>();
    List<Commerciaux> lesCommerciaux = new List<Commerciaux>();


    public LoginPage()
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
        lesCommerciaux.Add(new Commerciaux(1004, "teste", "teste", "1010 Rue Principale", "Lille", "59000", "teste@gmail.com", "03 45 67 89 01", lesIdentifications[3]));
        lesCommerciaux.Add(new Commerciaux(1005, "Lefebvre", "Jacques", "111 Chemin des Collines", "Toulouse", "31000", "jacques.lefebvre@example.com", "05 67 89 01 23", lesIdentifications[4]));


        // Association de chaque rendez-vous à un commercial de la liste
        lesRendezVous.Add(new RendezVous(1, "Dupont", "Jean", "jean.dupont@example.com", "01 23 45 67 89", 123456789, "Société A", "Paris", "75001", "123 Rue de la République", "2024-04-11", "09:00", "10:00", "Présentation produit", "Réunion de présentation des nouveaux produits", 1, lesCommerciaux[0]));
        lesRendezVous.Add(new RendezVous(2, "Martin", "Marie", "marie.martin@example.com", "04 56 78 90 12", 456789123, "Société B", "Lyon", "69000", "456 Avenue des Fleurs", "2024-04-12", "10:00", "11:00", "Démo logiciel", "Présentation des fonctionnalités du logiciel", 0, lesCommerciaux[1]));
        lesRendezVous.Add(new RendezVous(3, "Dubois", "Pierre", "pierre.dubois@example.com", "06 78 90 12 34", 789456123, "Société C", "Marseille", "13000", "789 Boulevard de l'Indépendance", "2024-04-13", "13:00", "14:00", "Formation produit", "Formation sur l'utilisation du produit", 1, lesCommerciaux[2]));
        lesRendezVous.Add(new RendezVous(4, "Durand", "Anne", "anne.durand@example.com", "03 45 67 89 01", 987123456, "Société D", "Lille", "59000", "1010 Rue Principale", "2024-04-14", "15:00", "16:00", "Négociation tarifaire", "Discussion sur les prix et remises", 0, lesCommerciaux[3]));
        lesRendezVous.Add(new RendezVous(5, "Lefebvre", "Jacques", "jacques.lefebvre@example.com", "05 67 89 01 23", 321654987, "Société E", "Toulouse", "31000", "111 Chemin des Collines", "2024-04-15", "09:00", "10:00", "Démo produit", "Démonstration des fonctionnalités du produit", 1, lesCommerciaux[4]));
    }

    // Méthode pour vérifier les informations d'identification de l'utilisateur
    private bool AuthenticateUser(string username, string password)
    {
        string passwordComfirmer = "";

        foreach(Commerciaux leCommerciaux in lesCommerciaux)
        {
            if(username == leCommerciaux.MailCommerciaux)
            {
                if(password == leCommerciaux.LeIdentification.Password)
                {
                    return true; // Authentification réussie
                }
            }
        }

        return false; // Authentification échouée

    }

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Vérifier les informations d'identification
        bool isAuthenticated = AuthenticateUser(Username.Text, Password.Text);

        // Si l'authentification est réussie, naviguer vers la page principale
        if (isAuthenticated)
        {
            ((App)Application.Current).NavigateToMainPage();
        }
        else
        {
            // Afficher un message d'erreur en cas d'échec de l'authentification
            DisplayAlert("Login Failed", "Invalid username or password", "OK");
        }
    }


    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {

        // Vérifier les informations d'identification
        bool isAuthenticated = AuthenticateUser(Username.Text, Password.Text);

        // Si l'authentification est réussie, naviguer vers la page principale
        if (isAuthenticated)
        {
            ((App)Application.Current).NavigateToMainPage();
        }
        else
        {
            // Afficher un message d'erreur en cas d'échec de l'authentification
            DisplayAlert("Login Failed", "Invalid username or password", "OK");
        }
    }


}