using Stylet;
using StyletBasicNavigation.Interfaces;
using System.Collections.ObjectModel;

namespace StyletBasicNavigation.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.StackNavigation
    {
        private IWindowManager windowManager;
        private IDialogFactory dialogFactory;

        public ObservableCollection<string> ViewsCollection { get; set; } = new ObservableCollection<string>();
        public ShellViewModel(IWindowManager windowManager, IDialogFactory dialogFactory)
        {
            this.windowManager = windowManager;
            this.dialogFactory = dialogFactory;
            this.DisplayName = string.Empty;
            this.UpdateViewProperty("red");
        }


        #region Properties
        private string _selectedView;
        public string SelectedView
        {
            get => _selectedView;
            set
            {
                SetAndNotify(ref _selectedView, value);
                UpdateView();
            }
        }

        private bool _isRed;
        public bool IsRed
        {
            get => _isRed;
            set
            {
                SetAndNotify(ref _isRed, value);
            }
        }
        private bool _isBlue;
        public bool IsBlue
        {
            get => _isBlue;
            set
            {
                SetAndNotify(ref _isBlue, value);
            }
        }
        private bool _isGreen;
        public bool IsGreen
        {
            get => _isGreen;
            set
            {
                SetAndNotify(ref _isGreen, value);
            }
        }
        private bool _isPurple;
        public bool IsPurple
        {
            get => _isPurple;
            set
            {
                SetAndNotify(ref _isPurple, value);
            }
        }
        #endregion





        protected override void OnInitialActivate()
        {
            
        }


        public void UpdateView()
        {
            this.IsRed = false;
            this.IsBlue = false;
            this.IsPurple = false;
            this.IsGreen = false;
            switch (this.SelectedView)
            {
                case "blue":
                    this.IsBlue = true;
                    this.ActivateItem(new BlueViewModel());
                    break;
                case "green":
                    this.IsGreen = true;
                    this.ActivateItem(new GreenViewModel());
                    break;
                case "purple":
                    this.IsPurple = true;
                    //this.ActivateItem(new PurpleViewModel());
                    var dialogVm = this.dialogFactory.CreatePurpleDialog();
                    var result = this.windowManager.ShowDialog(dialogVm);
                    this.IsPurple = false;
                    break;
                case "red":
                default:
                    this.IsRed = true;
                    this.ActivateItem(new RedViewModel());
                    break;
            }
            ViewsCollection.Add(SelectedView);
        }
        public void UpdateViewProperty(string view)
        {
            this.SelectedView = view;
            
        }
    }
}
