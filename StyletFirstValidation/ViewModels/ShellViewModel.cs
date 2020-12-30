using Stylet;

namespace StyletFirstValidation.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>
    {
        public ShellViewModel(UserViewModel userViewModel)
        {
            this.DisplayName = "Stylet.Samples.ModelValidation";

            this.ActiveItem = userViewModel;
        }
    }
}
