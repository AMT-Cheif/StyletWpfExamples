using MyFirstStyletProject.IoC;
using MyFirstStyletProject.ViewModels;
using Stylet;
using StyletIoC;

namespace MyFirstStyletProject
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            builder.AddModule(new MyStyletIoCModule());
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }
    }
}
