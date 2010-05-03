namespace BatchTests.Web.Core
{
    public class EonReplacementCode
    {
        public EonReplacementCode(string gasProductCode, string elecProductCode, string gasName, string elecName)
        {
            GasProductCode = gasProductCode;
            ElecProductCode = elecProductCode;
            GasName = gasName;
            ElecName = elecName;
        }

        public string GasProductCode
        {
            get; private set;
        }

        public string ElecProductCode
        {
            get;
            private set;
        }

        public string GasName
        {
            get; private set;
        }

        public string ElecName
        {
            get;
            private set;
        }
    }
}