namespace ImageProcessingWPF.Models.Interfaces
{
    interface IFilter
    {
        void Execute(IFilterParameters parameters);
    }
}
