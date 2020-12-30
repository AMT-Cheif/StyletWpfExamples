using FluentValidation;
using StyletFirstValidation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletFirstValidation.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;
            RuleFor(x => x.UserName).NotEmpty().Length(1, 20);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Matches("[0-9]").WithMessage("{PropertyName} must contain a number");
            RuleFor(x => x.PasswordConfirmation).Equal(s => s.Password).WithMessage("{PropertyName} should match Password");
            RuleFor(x => x.Age).Must(x => x.IsValid).WithMessage("{PropertyName} must be a valid number");
            When(x => x.Age.IsValid, () =>
            {
                RuleFor(x => x.Age.Value).GreaterThan(0).WithName("Age");
            });
        }
    }
}
