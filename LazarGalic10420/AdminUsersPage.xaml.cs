using LazarGalic10420.ViewModel;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LazarGalic10420;

public partial class AdminUsersPage : ContentPage, INotifyPropertyChanged
{
    public AdminUsersPage()
	{
		InitializeComponent();
	}

    public async void SinglePagePush(object sender, EventArgs e)
	{
        //!!!! OVO JE JAKO BITNO 
        Button button = (Button)sender;
		var id = button.AutomationId.ToString();

        await Navigation.PushAsync(new UpdateUserPage(id) );  //



        //Ovde sam direktno pokusavao da vezem za view model da napravim jednu instancu preko singletona i da posle mogu da bindujem  
        //Nije uspelo logicno nego sam u code behindu napravio taj view model sa prosledjenom vrednoscu i njega vezao na drugi nacin za xaml preko BindingContext opcije 
        //_ = new UpdateUserViewModel(id);
        //UpdateUserViewModel.Instance.Id.Value = id;
        // OnPropertyChanged(nameof(UpdateUserViewModel.Instance.Id)); Cak sam i ovo pokusao u komb sa ovim dole
    }

    /*public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));*/
}