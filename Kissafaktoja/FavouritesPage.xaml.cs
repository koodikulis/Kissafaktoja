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
            Label label = new();
            label.Text = item;
        }
    }
}