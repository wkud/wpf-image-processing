using System.Drawing;
namespace ImageProcessingWPF.Models.Interfaces
{
    interface IFilter
    {
        Bitmap Execute(IFilterParameters parameters, Bitmap inputImage);
    }
}
