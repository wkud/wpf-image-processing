using ImageProcessingWPF.Models.FilterParameters;

namespace ImageProcessingWPF.Models.Interfaces
{
    interface IKernelContainer
    {
        Kernel Kernel { get; }
        void SetDeserializedKernel(Kernel kernel);
    }
}
