﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels.Store
{
    public class ViewModel_StoreDashboard
    {
        #region events

        #endregion

        #region vars

        #endregion

        #region properties

        #endregion

        #region commands

        #endregion

        #region ctors
        public ViewModel_StoreDashboard()
        {
            InitCommands();

            /*
			// used only in UWP & WPF
			// or anything that supports design time updates
			if(base.IsInDesignMode)
			{
				DesignData();
			}
			else
			{
				RuntimeData();
			}
			*/
        }
        #endregion

        #region command methods

        #endregion

        #region methods
        void InitCommands()
        {

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
        #endregion
    }
}