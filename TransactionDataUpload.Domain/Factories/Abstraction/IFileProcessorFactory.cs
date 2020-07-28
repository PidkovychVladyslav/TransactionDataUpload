namespace TransactionDataUpload.Domain.Factories.Abstraction
{
    using Executors.Abstraction.Base;

    public interface IFileProcessorFactory
    {
        IFileProcessor GetFileProcessor(string fileName);
    }
}
