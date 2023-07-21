using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace LazarGalic10420;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
	}

	public async void Korisnici_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AdminUsersPage());

    }
    public async void Objave_Clicked(object sender, EventArgs e)
    {
        //Application.Current.MainPage = new AdminPostsPage();
        await Navigation.PushAsync(new AdminPostsPage());
    }
}
