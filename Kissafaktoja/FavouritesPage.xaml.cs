namespace Kissafaktoja;

public partial class FavouritesPage : ContentPage
{
	public FavouritesPage()
	{


        InitializeComponent();
        List<string> listOfFavourites = new List<string>();
        listOfFavourites = Favourites.getListOfFavourites();

        foreach (string item in listOfFavourites)
        {

            FavLabel.Text += item + "\n\n\n";
        }
    }

    private void GoBackBtn_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new MainPage());
    }

    private void ClearBtn_Clicked(object sender, EventArgs e)
    {

        Favourites.clearFavs();
        App.Current.MainPage = new NavigationPage(new FavouritesPage());
    }
}