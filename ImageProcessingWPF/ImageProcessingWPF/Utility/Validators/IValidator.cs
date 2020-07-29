namespace ImageProcessingWPF.Utility.Validators
{
    interface IValidator<T>
    {
        bool IsValid(T value);
        string GetInvalidInfoMessage();
        T MakeValid(T value);
    }
}
