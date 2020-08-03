using System;

namespace ImageProcessingWPF.Models.Interfaces
{
    interface IFilterParametersContainer
    {
        IFilterParameters Parameters { get; set; }
        event Action OnParametersChanged;
    }
}
