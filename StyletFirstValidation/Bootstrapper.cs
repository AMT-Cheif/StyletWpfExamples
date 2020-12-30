using FluentValidation;
using Stylet;
using StyletFirstValidation.ViewModels;
using StyletIoC;

namespace StyletFirstValidation
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            builder.Bind(typeof(IModelValidator<>)).To(typeof(FluentModelValidator<>));
            //builder.Bind<IValidator<UserViewModel>>().To<UserViewModelValidator>();
            builder.Bind(typeof(IValidator<>)).ToAllImplementations();
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }
    }
}
