namespace ApiValidation
{
    public interface IValidator
    {
        void SetSuccessor(IValidator validator);
        bool Validate();
    }
}