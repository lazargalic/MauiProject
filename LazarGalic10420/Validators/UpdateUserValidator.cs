using FluentValidation;
using LazarGalic10420.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserViewModel>
    {
        public UpdateUserValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            string regexPatternName = @"\b[A-Z][a-zA-Z]*\b";
            //string regexPatternPassword = @"^(?=.*[a-z])(?=.*[A-Z0-9#?!@$%^&*-]).+$";

            RuleFor(x => x.FirstName.Value).NotEmpty().WithMessage("Ime je obavezno polje.")
                                   .NotNull().WithMessage("Ime ne sme biti null.")
                                   .MinimumLength(2).WithMessage("Ime ne sme biti krace od 2 karaktera.")
                                   .MaximumLength(80).WithMessage("Ime ne sme biti duze od 80 karaktera.")
                                   .Matches(regexPatternName).WithMessage("Reci u imenu moraju poceti velikim pocetnim slovom i biti u skladu sa gramatickim formatom.");

            RuleFor(x => x.LastName.Value).NotEmpty().WithMessage("Prezime je obavezno polje.")
                                   .NotNull().WithMessage("Prezime ne sme biti null.")
                                   .MinimumLength(2).WithMessage("Prezime ne sme biti krace od 2 karaktera.")
                                   .MaximumLength(80).WithMessage("Prezime ne sme biti duze od 80 karaktera.")
                                   .Matches(regexPatternName).WithMessage("Reci u prezimenu moraju poceti velikim pocetnim slovom i biti u skladu sa gramatickim formatom.");

            RuleFor(x => x.Email.Value).NotEmpty().WithMessage("Email je obavezno polje.")
                       .NotNull().WithMessage("Email ne sme biti null.")
                       .MinimumLength(5).WithMessage("Email ne sme biti kraci od 5 karaktera.")
                       .MaximumLength(80).WithMessage("Email ne sme biti duzi od 80 karaktera.")
                       .EmailAddress().WithMessage("Email nije u dobrom formatu.");

            RuleFor(x => x.PhoneNumber.Value).MaximumLength(15).WithMessage("Previse karaktera za broj telefona.");
            RuleFor(x => x.IdentityNumber.Value).MaximumLength(20).WithMessage("Previse karaktera za broj licnog dokumenta.");

        }
    }
}
