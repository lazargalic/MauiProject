using LazarGalic10420.Business.Auth;
using LazarGalic10420.Common;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LazarGalic10420;

public partial class AppShell : Shell
{
    //public MProp<bool> IsNowLoggedIn { get; set; } = new MProp<bool>(); 
    public bool IsNowLoggedIn { get; set; } = false;
    //public MProp<bool> IsNotNowLoggedIn { get; set; } = new MProp<bool>(); 
    public bool IsNotNowLoggedIn { get; set; }

    public AppShell()
	{

        //IsNowLoggedIn.Value = false;
        IsNowLoggedIn = false;
        //IsNotNowLoggedIn.Value = true;
        IsNotNowLoggedIn = true;
        
        
        InitializeComponent();

        CheckIfIsLogged();
	}
 
    public void CheckIfIsLogged()
	{
        OnPropertyChanged(nameof(IsNowLoggedIn));

        var user = Preferences.Get("user", null);

        if (user == null)
        {

            //IsNowLoggedIn.Value = false;
            //IsNotNowLoggedIn.Value = true;
        }
        else
        {
            //JAKO BITNO MORA OVAJ REDOSLED DA SE PRVO PITA  'IS USER'  DA BI SE POSLE DESERIJALIZOVALO
            var user2 = JsonConvert.DeserializeObject(user);
            if (user2 is User)
            {
                User user3 = (User)user2;

                if (user3.LoginExpiration > DateTime.Now)
                {
                    //  IsNowLoggedIn.Value = true;
                    // IsNotNowLoggedIn.Value = false;
                }
            }
            else
            {
                //IsNowLoggedIn.Value = false;
                //IsNotNowLoggedIn.Value = true;
            }


        }


    }


}
