using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Kissafaktoja;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		string responseBody = await GetCatFact();
        Cat kissa = JsonConvert.DeserializeObject<Cat>(responseBody);
        CatLabel.Text = kissa.fact;
        SemanticScreenReader.Announce(Catbtn.Text);
	}

	private async Task<string> GetCatFact()
	{
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
	}
}

