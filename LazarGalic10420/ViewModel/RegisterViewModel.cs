using FluentValidation.Results;
using LazarGalic10420.Common;
using LazarGalic10420.Validators;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        public MProp<string> FirstName { get; set; } = new MProp<string>();
        public MProp<string> LastName { get; set; } = new MProp<string>();
        public MProp<string> Email { get; set; } = new MProp<string>();
        public MProp<string> Password { get; set; } = new MProp<string>();
        public MProp<string> IdentityNumber { get; set; } = new MProp<string>();
        public MProp<string> PhoneNumber { get; set; } = new MProp<string>();
        public bool IsRegisterButtonEnabled => !FirstName.HasError && !LastName.HasError && !Email.HasError && !Password.HasError && !PhoneNumber.HasError && !IdentityNumber.HasError;


        public RegisterViewModel()
        {
            FirstName.OnValueChange = Validate;
            LastName.OnValueChange = Validate;
            FirstName.OnValueChange = Validate;
            Email.OnValueChange = Validate;
            FirstName.OnValueChange = Validate;
            Password.OnValueChange = Validate;
            IdentityNumber.OnValueChange = Validate;
            PhoneNumber.OnValueChange = Validate;

            // 

            PhoneNumber.Value = null; //Da se izbegne obavezan parametar za opciona polja nzm zasto al radi
            IdentityNumber.Value = null; // 

        }

        private void Validate() //Action
        {
            var validator = new RegisterUserValidator();
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
                var passwordError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Password"));
                if (passwordError != null)
                {
                    Password.Error = passwordError.ErrorMessage;
                }
                else
                {
                    Password.Error = "";
                }
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
                if (phoneNumberError != null )
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
            OnPropertyChanged(nameof(IsRegisterButtonEnabled));  //Uvek pozivamo iz BaseViewModel
        }

    }


}
