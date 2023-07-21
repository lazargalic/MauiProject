﻿using FluentValidation;
using LazarGalic10420.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            string regexPatternPassword = @"^(?=.*[a-z])(?=.*[A-Z0-9#?!@$%^&*-]).+$";

            RuleFor(x => x.Email.Value)
                .NotNull().WithMessage("Email ne sme biti null.")
                .NotEmpty().WithMessage("Email je obavezno polje.")
                .EmailAddress().WithMessage("Email nije ispravnog formata.");
            RuleFor(x => x.Password.Value).NotEmpty().WithMessage("Sifra je obavezno polje.")
                       .NotNull().WithMessage("Sifra ne sme biti null.")
                       .MinimumLength(8).WithMessage("Sifra ne sme biti kraca od 8 karaktera.")
                       .MaximumLength(50).WithMessage("Sifra ne sme biti duza od 50 karaktera.")
                       .Matches(regexPatternPassword).WithMessage("Sifra mora sadrzati barem jedan karakter koji ce biti, specijalan, velikog formata ili biti broj.");
        }
    }
}
