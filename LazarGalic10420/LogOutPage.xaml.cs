namespace LazarGalic10420;

public partial class LogOutPage : ContentPage
{
	public LogOutPage()
	{
		InitializeComponent();

		var old = Preferences.Get("jwt", null);
		var old2 = Preferences.Get("user", null);
		//Brise sve
		Preferences.Clear();

        var neww = Preferences.Get("jwt", null);
        var new2 = Preferences.Get("user", null);

    }
}