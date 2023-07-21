using FluentValidation.Results;
using LazarGalic10420.Common;
using LazarGalic10420.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LazarGalic10420.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public MProp<string> Email { get; set; } = new MProp<string>();
        public MProp<string> Password { get; set; } = new MProp<string>();
        public bool IsLoginButtonEnabled => !Email.HasError && !Password.HasError;
        //public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            Email.OnValueChange = Validate;   
            Password.OnValueChange = Validate;

             Email.Value = ""; //Kad nije bar jedan iz forme value definisan, IsLoginButtonEnabled nije setovan default da ne moze da se izvrsi 
        }


        private void Validate() //Action
        {
            var validator = new LoginValidator();
            ValidationResult result = validator.Validate(this);  //

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

                var passwordError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Password"));
                if (passwordError != null)
                {
                    Password.Error = passwordError.ErrorMessage;
                }
                else
                {
                    Password.Error = "";
                }

            }
            else
            {
                Email.Error = "";
                Password.Error = "";
            }

            OnPropertyChanged(nameof(IsLoginButtonEnabled));  //Uvek pozivamo iz BaseViewModel
        }

      //  private void LoginClick() { var x = 5; } u Code Behind je zbog IsEnabled Koji reaguje na click ne command

    }
}
