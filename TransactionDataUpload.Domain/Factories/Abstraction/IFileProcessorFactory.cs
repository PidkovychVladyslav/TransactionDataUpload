namespace TransactionDataUpload.Domain.Factories.Abstraction
{
    using Services.Abstraction.Base;

    public interface IFileProcessorFactory
    {
        IFileProcessingService GetFileProcessor(string fileName);
    }
}
