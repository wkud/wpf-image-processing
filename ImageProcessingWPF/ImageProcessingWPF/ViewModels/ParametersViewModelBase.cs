﻿using ImageProcessingWPF.Models;
using ImageProcessingWPF.Utility;
using System.ComponentModel;

namespace ImageProcessingWPF.ViewModels
{
    abstract class ParametersViewModelBase : Observer<FilterType>, INotifyPropertyChanged
    {
        private bool _isVisible;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                PropertyChanged.Notify(this, "IsVisible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private FilterType _associatedFilterType;
        public ParametersViewModelBase(FilterHandler filterHandler, FilterType associatedFilterType) : base(filterHandler)
        {
            _associatedFilterType = associatedFilterType;
            IsVisible = filterHandler.SelectedFilterType == associatedFilterType; 
        }

        protected override void Notify(FilterType value)
        {
            IsVisible = value == _associatedFilterType;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Notify(this, propertyName);
        }
    }
}
