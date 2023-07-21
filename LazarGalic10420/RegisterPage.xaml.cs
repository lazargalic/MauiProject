using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using LazarGalic10420.Business;
using LazarGalic10420.Business.Services;
using System.Threading;

namespace LazarGalic10420;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    public async void RegisterClick(object sender, EventArgs e)
	{

		var toRegister = new RegisterUserDto
		{
			FirstName = FirstName.Text,
			LastName = LastName.Text,
			Email = Email.Text,
			Password = Password.Text,
			IdentityNumber = IdentityNumber.Text,
			PhoneNumber = PhoneNumber.Text
		};

		var regiserService = new RegisterService();

		var result = regiserService.RegisterUser(toRegister);

		if (result)
		{
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Green,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
                CharacterSpacing = 0
            };

            string text = "Uspesno ste registrovani";
            string actionButtonText = "U redu";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }
		else
		{
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
                CharacterSpacing = 0
            };

            string text = "Doslo je do greske. ";
            string actionButtonText = "U redu";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }

	}
}