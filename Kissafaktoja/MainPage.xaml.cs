using Newtonsoft.Json;
using System.Diagnostics;
using TextCopy;

namespace Kissafaktoja;

public partial class MainPage : ContentPage
{

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
        CatLabel.Text = kissa.fact;
        SemanticScreenReader.Announce(Catbtn.Text);
        CatArgs catArgs = new CatArgs() { CatImage = pixelcat };
        GetCatClick(catArgs);

    }

    private async Task<string> GetCatFact()
    {
        HttpClient client = new HttpClient();
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

}
