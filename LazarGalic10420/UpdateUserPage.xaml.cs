using LazarGalic10420.Common;
using System.ComponentModel;

namespace LazarGalic10420;

using LazarGalic10420.ViewModel;
using Microsoft.Maui.Controls;

public partial class UpdateUserPage : ContentPage
{
    //public string IdToUpdate { get; set; }  = string.Empty; Ovo NE RADI , Bindovanje preko code behinda nece  ****

    private UpdateUserViewModel _viewModel;

    public UpdateUserPage(string value)   //Parametar sve vreme dolazi samo sto nije mogao da se bajnduje
    {
        InitializeComponent();
        //IdToUpdate = value;   NE RADI     ****

        // RADI !! -  IdLabel.Text = value;      //Jedini nacin da se prikaze je ovako direktno preko svojstva text


        //Kada hocemo da prosledimo parametar jednom odredjenom view modelu koji mi napravimo sa parametrom konstruktora odredjenim
        //Onda moramo da ga napravimo ovde odredjen i da vezemo xaml sa njim preko ovog drugog nacina direktno : BindingContext = _viewModel;  . Pisace i dalje u xamlu da ga ne prepoznaje ali to je to u sustini prepoznao ga je . 

        _viewModel = new UpdateUserViewModel(value);
        BindingContext = _viewModel;
    }
    
 
}
