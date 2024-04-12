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

        // Ajout d'exemples de commerciaux � la collection
        lesCommerciaux.Add(new Commerciaux(1001, "Dupont", "Jean", "123 Rue de la R�publique", "Paris", "75001", "jean.dupont@example.com", "01 23 45 67 89", lesIdentifications[0]));
        lesCommerciaux.Add(new Commerciaux(1002, "Martin", "Marie", "456 Avenue des Fleurs", "Lyon", "69000", "marie.martin@example.com", "04 56 78 90 12", lesIdentifications[1]));
        lesCommerciaux.Add(new Commerciaux(1003, "Dubois", "Pierre", "789 Boulevard de l'Ind�pendance", "Marseille", "13000", "pierre.dubois@example.com", "06 78 90 12 34", lesIdentifications[2]));
        lesCommerciaux.Add(new Commerciaux(1004, "teste", "teste", "1010 Rue Principale", "Lille", "59000", "teste@gmail.com", "03 45 67 89 01", lesIdentifications[3]));
        lesCommerciaux.Add(new Commerciaux(1005, "Lefebvre", "Jacques", "111 Chemin des Collines", "Toulouse", "31000", "jacques.lefebvre@example.com", "05 67 89 01 23", lesIdentifications[4]));


        // Association de chaque rendez-vous � un commercial de la liste
        lesRendezVous.Add(new RendezVous(1, "Dupont", "Jean", "jean.dupont@example.com", "01 23 45 67 89", 123456789, "Soci�t� A", "Paris", "75001", "123 Rue de la R�publique", "2024-04-11", "09:00", "10:00", "Pr�sentation produit", "R�union de pr�sentation des nouveaux produits", 1, lesCommerciaux[0]));
        lesRendezVous.Add(new RendezVous(2, "Martin", "Marie", "marie.martin@example.com", "04 56 78 90 12", 456789123, "Soci�t� B", "Lyon", "69000", "456 Avenue des Fleurs", "2024-04-12", "10:00", "11:00", "D�mo logiciel", "Pr�sentation des fonctionnalit�s du logiciel", 0, lesCommerciaux[1]));
        lesRendezVous.Add(new RendezVous(3, "Dubois", "Pierre", "pierre.dubois@example.com", "06 78 90 12 34", 789456123, "Soci�t� C", "Marseille", "13000", "789 Boulevard de l'Ind�pendance", "2024-04-13", "13:00", "14:00", "Formation produit", "Formation sur l'utilisation du produit", 1, lesCommerciaux[2]));
        lesRendezVous.Add(new RendezVous(4, "Durand", "Anne", "anne.durand@example.com", "03 45 67 89 01", 987123456, "Soci�t� D", "Lille", "59000", "1010 Rue Principale", "2024-04-14", "15:00", "16:00", "N�gociation tarifaire", "Discussion sur les prix et remises", 0, lesCommerciaux[3]));
        lesRendezVous.Add(new RendezVous(5, "Lefebvre", "Jacques", "jacques.lefebvre@example.com", "05 67 89 01 23", 321654987, "Soci�t� E", "Toulouse", "31000", "111 Chemin des Collines", "2024-04-15", "09:00", "10:00", "D�mo produit", "D�monstration des fonctionnalit�s du produit", 1, lesCommerciaux[4]));
    }

    // M�thode pour v�rifier les informations d'identification de l'utilisateur
    private bool AuthenticateUser(string username, string password)
    {
        string passwordComfirmer = "";

        foreach(Commerciaux leCommerciaux in lesCommerciaux)
        {
            if(username == leCommerciaux.MailCommerciaux)
            {
                if(password == leCommerciaux.LeIdentification.Password)
                {
                    return true; // Authentification r�ussie
                }
            }
        }

        return false; // Authentification �chou�e

    }

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // V�rifier les informations d'identification
        bool isAuthenticated = AuthenticateUser(Username.Text, Password.Text);

        // Si l'authentification est r�ussie, naviguer vers la page principale
        if (isAuthenticated)
        {
            ((App)Application.Current).NavigateToMainPage();
        }
        else
        {
            // Afficher un message d'erreur en cas d'�chec de l'authentification
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

        // V�rifier les informations d'identification
        bool isAuthenticated = AuthenticateUser(Username.Text, Password.Text);

        // Si l'authentification est r�ussie, naviguer vers la page principale
        if (isAuthenticated)
        {
            ((App)Application.Current).NavigateToMainPage();
        }
        else
        {
            // Afficher un message d'erreur en cas d'�chec de l'authentification
            DisplayAlert("Login Failed", "Invalid username or password", "OK");
        }
    }


}