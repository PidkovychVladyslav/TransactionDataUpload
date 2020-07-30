using System.Collections.Generic;
using System.Linq;
using TransactionDataUpload.Domain.Factories.Abstraction;
using TransactionDataUpload.Domain.Services.Abstraction.Base;
using TransactionDataUpload.Core.Exceptions;

namespace TransactionDataUpload.Domain.Factories.Implementation
{
    public class FileProcessorFactory : IFileProcessorFactory
    {
        private readonly IEnumerable<IFileProcessingService> _availableProcessors;

        public FileProcessorFactory(IEnumerable<IFileProcessingService> availableProcessors)
        {
            _availableProcessors = availableProcessors;
        }

        public IFileProcessingService GetFileProcessor(string fileName)
        {
            var supportedParser = _availableProcessors
                    .FirstOrDefault(x => x.SupportsFormat(fileName));

            if (supportedParser == null)
            {
                throw new UnknownFormatException($"System doesn't support format of uploaded file");
            }

            return supportedParser;
        }
    }
}
