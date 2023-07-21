using System.Collections.ObjectModel;

namespace LazarGalic10420;

public partial class MainPage : ContentPage
{
	int count = 0;
    public ObservableCollection<ImgObject> Images { get; set; }

    public class ImgObject
    {
        public string Path { get; set; }
    }

    public MainPage()
	{
        InitializeComponent();

        Images = new ObservableCollection<ImgObject>
        {
           new ImgObject
           {
            Path ="main2.jpg"   
           },
           new ImgObject
           {
            Path ="main3.jpg"
           }

        };
 
        BindingContext = this;
    }

 

}

