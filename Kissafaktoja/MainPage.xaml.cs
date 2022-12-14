using Newtonsoft.Json;
using System.Diagnostics;
using TextCopy;
using Plugin.Maui.Audio;

namespace Kissafaktoja;

public partial class MainPage : ContentPage
{
    int fontsizeSmall = 16;
    int fontsizeNormal = 24;
    
    public MainPage()
    {
        InitializeComponent();
        if (DeviceInfo.Current.Platform != DevicePlatform.WinUI)
        {
            Copybtn.IsVisible = false;
        }

        GetCatEvent += CatEvents.OnGetCatEvent;
    }


    private async void OnCounterClicked(object sender, EventArgs e)
    {
        string responseBody = await GetCatFact();
        Cat kissa = JsonConvert.DeserializeObject<Cat>(responseBody);
        Debug.WriteLine(kissa.fact.Length);
        
        if (kissa.fact.Length > 125)
        {
            CatLabel.FontSize = fontsizeSmall;
            CatLabel.Text = kissa.fact;
        }
        else
        {
            CatLabel.FontSize = fontsizeNormal;
            CatLabel.Text = kissa.fact;
        }

        
        SemanticScreenReader.Announce(CatLabel.Text);
        CatArgs catArgs = new() { CatImage = pixelcat };
        GetCatClick(catArgs);

    }

    private static async Task<string> GetCatFact()
    {
        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }

    private async void OnCopyClicked(object sender, EventArgs e)
    {

        try
        {
            await ClipboardService.SetTextAsync(CatLabel.Text);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex, "MOBILE NOT SUPPORTED.");
        }

    }


    public event EventHandler<CatArgs> GetCatEvent;
    public void GetCatClick(CatArgs e)
    {
        GetCatEvent?.Invoke(this, e);
    }

    private void favourite_Clicked(object sender, EventArgs e)
    {
        if (CatLabel.Text != "Hi. Press button and get started.")
        {
            Favourites.addFavouriteCatFact(CatLabel.Text);
        }
    }

    private void favPage_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new FavouritesPage());
    }

    private async void pixelcat_Clicked(object sender, EventArgs e)
    {
        try
        {
            var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("catpurr.wav"));

            audioPlayer.Play();
           
        }
        catch (Exception evirhe)
        {
            Debug.WriteLine("Soundplayer failure" + evirhe);
        }
    }
}
