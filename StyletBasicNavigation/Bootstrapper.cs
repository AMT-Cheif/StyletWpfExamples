using Stylet;
using StyletBasicNavigation.Interfaces;
using StyletBasicNavigation.ViewModels;
using StyletIoC;

namespace StyletBasicNavigation
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            base.ConfigureIoC(builder);

            builder.Bind<IDialogFactory>().ToAbstractFactory();
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }
    }
}
