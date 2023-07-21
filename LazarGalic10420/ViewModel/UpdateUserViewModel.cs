using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using FluentValidation.Results;
using LazarGalic10420.Business;
using LazarGalic10420.Business.Services;
using LazarGalic10420.Common;
using LazarGalic10420.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LazarGalic10420.ViewModel
{
    public class UpdateUserViewModel : BaseViewModel
    {
        public MProp<string> Vrednost { get; set; } = new MProp<string>();
        public ICommand UpdateCommand { get; set; }
        public UpdateUserService _updateUserService;

        public ObservableCollection<AdminSelectRegisteredUsersDto> Users { get; set; }  //Za filtirranje jednog
        public AdminSelectRegisteredUsersDto OneUser;
        public UsersService _userService;   // 
        //Za update
        public MProp<int> IdUserToUpdate { get; set; } = new MProp<int>();
        public MProp<string> FirstName { get; set; } = new MProp<string>();
        public MProp<string> LastName { get; set; } = new MProp<string>();
        public MProp<string> Email { get; set; } = new MProp<string>();
        public MProp<string> Password { get; set; } = new MProp<string>();
        public MProp<int> SelectionRole { get; set; } = new MProp<int>();
        public MProp<bool> IsActive { get; set; } = new MProp<bool>();
        public MProp<string> PhoneNumber { get; set; } = new MProp<string>();
        public MProp<string> IdentityNumber { get; set; } = new MProp<string>();
        //
        public bool IsUpdatedButtonEnabled => !FirstName.HasError && !LastName.HasError && !Email.HasError && !PhoneNumber.HasError && !IdentityNumber.HasError;
        public UpdateUserViewModel(string value)    //Dobijen id iz Code Behinda
        {
            //Za dohvatanje Jednog
            _userService = new UsersService();
            Users = new ObservableCollection<AdminSelectRegisteredUsersDto>(_userService.GetUsers());
            OneUser = Users.FirstOrDefault(x => x.Id == Int32.Parse(value) );
            //Popunjavanje jednog
            FirstName.Value = OneUser.FirstName;
            LastName.Value = OneUser.LastName;
            Email.Value = OneUser.Email;
            SelectionRole.Value = OneUser.Role.RoleId;
            IsActive.Value = OneUser.IsActive;
            PhoneNumber.Value = OneUser.PhoneNumber;
            IdentityNumber.Value = OneUser.IdentityNumber;
            Vrednost.Value = value; //Id u naslovu

            //
            //Validacija 
            FirstName.OnValueChange = Validate;
            LastName.OnValueChange = Validate;
            FirstName.OnValueChange = Validate;
            Email.OnValueChange = Validate;
            FirstName.OnValueChange = Validate;
            IdentityNumber.OnValueChange = Validate;
            PhoneNumber.OnValueChange = Validate;


            _updateUserService = new UpdateUserService();
            UpdateCommand = new Command<string>(UpdateUser);  //


        }

        public async void UpdateUser(string value)
        {
            var userToUpdate = new UpdateOneUserDto
            {
                IdUserToUpdate = Int32.Parse(value),
                Email = Email.Value,
                FirstName = FirstName.Value,
                LastName = LastName.Value,
                IsActive = IsActive.Value,
                PhoneNumber = PhoneNumber.Value == null ? "" : PhoneNumber.Value,    //Izgleda da swagger ne daje null da se salje ili validator negde okine mada ne verujem posto ima samo za max proveru
                IdentityNumber = IdentityNumber.Value == null ? "" : IdentityNumber.Value, 
                RoleId = SelectionRole.Value,
                Password = ""
            };

            bool isOk = _updateUserService.UpdateUser(userToUpdate);

            if(isOk)
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

                string text = "Uspesno ste izmenili Usera";
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

                string text = "Doslo je do greske.";
                string actionButtonText = "U redu";
                TimeSpan duration = TimeSpan.FromSeconds(3);

                var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

                await snackbar.Show(cancellationTokenSource.Token);
            }
        }


        private void Validate() //Action
        {
            var validator = new UpdateUserValidator();
            ValidationResult result = validator.Validate(this);   //

            //
            if (!result.IsValid)
            {
                var emailError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Email"));
                if (emailError != null)
                {
                    Email.Error = emailError.ErrorMessage;
                }
                else
                {
                    Email.Error = "";
                }
                ////
 
                ///
                var firstNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("FirstName"));
                if (firstNameError != null)
                {
                    FirstName.Error = firstNameError.ErrorMessage;
                }
                else
                {
                    FirstName.Error = "";
                }
                //
                var lastNameError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("LastName"));
                if (lastNameError != null)
                {
                    LastName.Error = lastNameError.ErrorMessage;
                }
                else
                {
                    LastName.Error = "";
                }
                //
                var identityNumber = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("IdentityNumber"));
                if (identityNumber != null)
                {
                    IdentityNumber.Error = identityNumber.ErrorMessage;
                }
                else
                {
                    IdentityNumber.Error = "";
                }
                //
                var phoneNumberError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("PhoneNumber"));
                if (phoneNumberError != null)
                {
                    PhoneNumber.Error = phoneNumberError.ErrorMessage;
                }
                else
                {
                    PhoneNumber.Error = "";
                }//

            }
            else
            {
                FirstName.Error = "";
                LastName.Error = "";
                Email.Error = "";
                Password.Error = "";
                IdentityNumber.Error = "";
                PhoneNumber.Error = "";
            }
            //
            OnPropertyChanged(nameof(IsUpdatedButtonEnabled));  //Uvek pozivamo iz BaseViewModel
        }




    }

}




//ispod pokusaj preko singletona

/* 
  public class UpdateUserViewModel : BaseViewModel
{
    public MProp<string> Id { get; set; } = new MProp<string>();

    private static UpdateUserViewModel instance;
    public static UpdateUserViewModel Instance
    {
        get
        {
            if (instance == null)
                 instance = new UpdateUserViewModel();

            return instance;
        }
    }
    private UpdateUserViewModel()
    {
    }
    public void Initialize(string toRecive)
    {
        Id.Value = toRecive;
        OnPropertyChanged(nameof(Id.Value)); //Uvek pozivamo iz BaseViewModel
        OnPropertyChanged(nameof(Id)); //Uvek pozivamo iz BaseViewModel
    }

}
 */
