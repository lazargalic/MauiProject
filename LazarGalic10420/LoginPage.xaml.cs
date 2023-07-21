using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using LazarGalic10420.Business.Auth;
using Newtonsoft.Json;

namespace LazarGalic10420;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	public async void LoginClick(object sender, EventArgs e)
	{
        AuthService authService = new AuthService();
        User loginUser = authService.Auth(this.Email.Text, this.Password.Text);

        if (loginUser == null)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.Green,
                ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(10),
            };

            string text = "Ovaj korisnik ne postoji u bazi.";
            string actionButtonText = "U redu.";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }
        else
        {
            // await SecureStorage.Default.SetAsync("jwt", loginUser.Token);
            // await SecureStorage.Default.SetAsync("user", JsonConvert.SerializeObject(loginUser));


            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Green,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(10),
            };

            string text = "Uspesno ste se ulogovali.";
            string actionButtonText = "Ponisti";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);



            //var xds1 = Preferences.Get("user", null);
            
            //Upis 
            Preferences.Default.Set("jwt", loginUser.Token);
            Preferences.Default.Set("user", JsonConvert.SerializeObject(loginUser));

            var xds2 = Preferences.Get("user", null);


            await snackbar.Show(cancellationTokenSource.Token);

            await Navigation.PushAsync(new ArticlesPage());
            //Application.Current.MainPage = new MainPage();

            //Application.Current.MainPage = new ArticlesPage();
        }


    }
}