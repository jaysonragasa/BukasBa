using BukasBa.CoreLibrary.Models.Interfaces;
using GalaSoft.MvvmLight;

namespace BukasBa.CoreLibrary.Models.UI
{
    public class Model_AuthDetails : ViewModelBase, IModelAuthDetails
    {
        private string _Username = null;
        public string Username
        {
            get { return _Username; }
            set { Set(nameof(Username), ref _Username, value); }
        }

        private string _Password = null;
        public string Password
        {
            get { return _Password; }
            set { Set(nameof(Password), ref _Password, value); }
        }

        private bool _IsStore = false;
        public bool IsStore
        {
            get { return _IsStore; }
            set { Set(nameof(IsStore), ref _IsStore, value); }
        }

        private bool _RememberMe = false;
        public bool RememberMe
        {
            get { return _RememberMe; }
            set { Set(nameof(RememberMe), ref _RememberMe, value); }
        }
    }
}