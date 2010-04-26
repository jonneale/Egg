namespace BatchTests.Web
{
    public class CompareResult
    {
        public string Id
        {
            get;
            set;
        }

        public bool AreEqual
        {
            get; set;
        }

        public string ResultsOld
        {
            get; set;
        }

        public string ResultsNew
        {
            get;
            set;
        }

        public int ColumnNumber
        {
            get; set;
        }
    }
}