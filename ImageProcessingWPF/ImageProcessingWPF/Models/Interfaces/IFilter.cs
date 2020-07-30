using System.Drawing;
namespace ImageProcessingWPF.Models.Interfaces
{
    interface IFilter
    {
        Bitmap Execute(Bitmap inputImage, IFilterParameters parameters);
    }
}
