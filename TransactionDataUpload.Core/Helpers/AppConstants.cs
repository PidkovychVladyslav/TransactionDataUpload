namespace TransactionDataUpload.Core.Helpers
{
    public static class AppConstants
    {
        public static readonly string CsvDelimiterCharacter = ",";
        public static readonly string CsvDateFormat = "dd/MM/yyyy hh:mm:ss";

        public static class SupportedFormats
        {
            public static readonly string Csv = ".csv";
            public static readonly string Xml = ".xml";
        }

        public static class CsvStatuses
        {
            public const string Approved = nameof(Approved);
            public const string Failed = nameof(Failed);
            public const string Finished = nameof(Finished);
        }

        public static class XmlStatuses
        {
            public const string Approved = nameof(Approved);
            public const string Rejected = nameof(Rejected);
            public const string Done = nameof(Done);
        }
    }
}
