using LoginFlow.Views;

namespace infotoolsFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set the main page to LoginPage initially
            MainPage = new NavigationPage(new LoginPage());
        }

        // Method to navigate to the main page after successful login
        public void NavigateToMainPage()
        {
            MainPage = new NavigationPage(new AppShell());
        }
    }
}
