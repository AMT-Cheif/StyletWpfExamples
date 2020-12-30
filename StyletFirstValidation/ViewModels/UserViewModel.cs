using Stylet;
using StyletFirstValidation.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletFirstValidation.ViewModels
{
    public class UserViewModel : Screen
    {
        private IWindowManager windowManager;
        public ObservableCollection<string> ErrorsCollection { get; set; } = new ObservableCollection<string>();
        #region Properties
        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                SetAndNotify(ref _userName, value);
                ValidateProperty();
                this.NotifyOfPropertyChange(() => this.CanSubmit);
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                SetAndNotify(ref _email, value);
                ValidateProperty();
                this.NotifyOfPropertyChange(() => this.CanSubmit);
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetAndNotify(ref _password, value);
                ValidateProperty();
                this.NotifyOfPropertyChange(() => this.CanSubmit);
            }
        }


        private string _passwordConfirmation;
        public string PasswordConfirmation
        {
            get => _passwordConfirmation;
            set
            {
                SetAndNotify(ref _passwordConfirmation, value);
                ValidateProperty();
                this.NotifyOfPropertyChange(() => this.CanSubmit);
            }
        }

        private Stringable<int> _age;
        public Stringable<int> Age
        {
            get => _age;
            set
            {
                SetAndNotify(ref _age, value);
                ValidateProperty();
                this.NotifyOfPropertyChange(() => this.CanSubmit);
            }
        }
        #endregion
        

        public UserViewModel(IWindowManager windowManager, IModelValidator<UserViewModel> validator) : base(validator)
        {
            this.windowManager = windowManager;
            // Force initial validation
            this.Validate();
            // Whenever password changes, we need to re-validate PasswordConfirmation
            this.Bind(x => x.Password, (o, e) => this.ValidateProperty(() => this.PasswordConfirmation));
        }

        public void Submit()
        {
            if (this.Validate())
                this.windowManager.ShowMessageBox("Successfully submitted", "success");
        }

        public void SubmitAlways()
        {
            ErrorsCollection.Clear();
            if (this.Validate())
            {
                this.windowManager.ShowMessageBox("Successfully submitted", "success");
            }
            else
            {
                var errors = this.Validator.ValidateAllPropertiesAsync().Result;
                foreach (var error in errors.Values.ToList().SelectMany(d=>d))
                { 
                    ErrorsCollection.Add(error.ToString());
                }
                
            }
            
        }

        public bool CanSubmit
        {
            get { return !this.HasErrors; }
        }

    }
}
