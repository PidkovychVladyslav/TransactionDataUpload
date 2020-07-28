namespace TransactionDataUpload.Domain.Factories.Implementation
{
    using Abstraction;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Executors.Abstraction.Base;

    public class FileProcessorFactory : IFileProcessorFactory
    {
        private readonly IEnumerable<IFileProcessor> _availableProcessors;

        public FileProcessorFactory(IEnumerable<IFileProcessor> availableProcessors)
        {
            _availableProcessors = availableProcessors;
        }

        public IFileProcessor GetFileProcessor(string fileName)
        {
            var supportedParser = _availableProcessors
                    .FirstOrDefault(x => x.SupportsFormat(fileName));

            if (supportedParser == null)
            {
                throw new InvalidOperationException($"No supported parser found bla bla'.");
            }

            return supportedParser;
        }
    }
}
