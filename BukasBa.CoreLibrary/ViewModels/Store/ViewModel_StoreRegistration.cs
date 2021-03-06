﻿using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Helpers;
using BukasBa.CoreLibrary.Models;
using BukasBa.CoreLibrary.Models.Interfaces;

using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels.Store
{
    public class ViewModel_StoreRegistration : VMBase
    {
        #region events
        public event EventHandler OnCameraTapped;
        public event EventHandler OnImageGalleryTapped;
        public event EventHandler OnNewStore;
        public event EventHandler<string> OnReloadPicture;
        #endregion

        #region vars

        #endregion

        #region properties
        private bool _IsUpdate = false;
        public bool IsUpdate
        {
            get { return _IsUpdate; }
            set
            {
                Set(nameof(IsUpdate), ref _IsUpdate, value);

                if (value)
                {
                    PageTitle = "Update Store";
                    ButtonText = "Update";
                }
                else
                {
                    PageTitle = "Store Registration";
                    ButtonText = "Register";
                }
            }
        }

        public string SelectedImagePath { get; set; } = string.Empty;

        private Model_StoreDetails _storeDetails = new Model_StoreDetails();
        public Model_StoreDetails StoreDetails
        {
            get { return _storeDetails; }
            set { Set(nameof(StoreDetails), ref _storeDetails, value); }
        }

        private string _PageTitle = "Store Registration";
        public string PageTitle
        {
            get { return _PageTitle; }
            set { Set(nameof(PageTitle), ref _PageTitle, value); }
        }

        private string _ButtonText = "Register";
        public string ButtonText
        {
            get { return _ButtonText; }
            set { Set(nameof(ButtonText), ref _ButtonText, value); }
        }
        #endregion

        #region commands
        public ICommand Command_OpenCamera { get; set; }
        public ICommand Command_Register { get; set; }
        public ICommand Command_OpenMap { get; set; }
        public ICommand Command_OpenGallery { get; set; }
        public ICommand Command_Remove { get; set; }
        #endregion

        #region ctors
        public ViewModel_StoreRegistration(IDataLocator dataLocator)
        {
            InitCommands();

            this._data = dataLocator;
        }
        #endregion

        #region command methods
        async void Command_Register_Click()
        {
            await Save();
        }

        void Command_OpenMap_Click()
        {

        }

        void Command_OpenCamera_Click()
        {
            this.OnCameraTapped?.Invoke(this, null);
        }

        void Command_OpenGallery_Click()
        {
            this.OnImageGalleryTapped?.Invoke(this, null);
        }

        async void Command_Remove_Click()
        {
            await this._data.StoresService.DeleteStoreAsync(this.StoreDetails);

            Clean();

            this.Nav.GoBack();
        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

            if (Command_Register == null) Command_Register = new RelayCommand(Command_Register_Click);
            if (Command_OpenMap == null) Command_OpenMap = new RelayCommand(Command_OpenMap_Click);
            if (Command_OpenCamera == null) Command_OpenCamera = new RelayCommand(Command_OpenCamera_Click);
            if (Command_OpenGallery == null) Command_OpenGallery = new RelayCommand(Command_OpenGallery_Click);
            if (Command_Remove == null) Command_Remove = new RelayCommand(Command_Remove_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {

        }

        async Task Update()
        {

        }

        public void ReloadImage(string imageurl)
        {
            OnReloadPicture?.BeginInvoke(this, imageurl, null, null);
        }

        async Task Save()
        {
            this.ShowDialog("Saving", "Please wait while uploading and saving your store.");

            string imageurl = this.SelectedImagePath;
            bool isimageuploaded = false;

            if (!string.IsNullOrEmpty(this.SelectedImagePath))
            {
                try
                {
                    if(this.SelectedImagePath != this.StoreDetails.ImagePath)
                    {
                        this.StoreDetails.ImagePath = this.SelectedImagePath;
                    }

                    imageurl = await _data.StoresService.UploadFileAsync(this.StoreDetails.ImagePath, _data.Token);
                    isimageuploaded = true;
                }
                catch(Exception ex)
                {
                    isimageuploaded = false;
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                // will just set this to true if the user 
                // do not want to upload an image of their store.
                isimageuploaded = true;
            }

            this.StoreDetails.IsOperational = true;

            var store = Mappy.I.Map<IModelStoreDetails>(this.StoreDetails);
            store.ImagePath = imageurl;

            if (!this.IsUpdate)
            {
                store.Id = Guid.NewGuid().ToString();
            }

            store.OwnerId = _data.UserId;

            var result = await _data.StoresService.CreateNewAsync(store);

            if(result.IsOk)
            {
                if (!isimageuploaded)
                {
                    await this.Dialog.ShowMessage("There was a problem uploading the image this time but you can always update your store in your store lists.", "Unable to upload", "ok", null);
                }

                Clean();

                //OnNewStore?.Invoke(this, null);

                this.Nav.GoBack();
            }
            else
            {
                this.HideDialog();

                await this.Dialog.ShowMessage("Unable to save your store at the moment. Please try again", "Hmmm...", "ok", null);
            }

            this.HideDialog();
        }

        public void Clean()
        {
            this.StoreDetails.Address = null;
            this.StoreDetails.ContactNumber = null;
            this.StoreDetails.Geo_Latitude = 0.0d;
            this.StoreDetails.Geo_Longitude = 0.0d;
            this.StoreDetails.ImagePath = null;
            this.StoreDetails.IsOpen = false;
            this.StoreDetails.StoreOpen = new TimeSpan(8, 0, 0);
            this.StoreDetails.StoreClosed = new TimeSpan(17, 0, 0);
            this.StoreDetails.StoreName = null;
            this.StoreDetails.IsOperational = false;
            this.SelectedImagePath = null;
            this.IsUpdate = false;
        }
        #endregion
    }
}