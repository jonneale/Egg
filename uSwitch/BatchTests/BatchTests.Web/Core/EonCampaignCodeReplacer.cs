using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BatchTests.Web.Core
{
    public class EonCampaignCodeReplacer
    {
        private const int gasCampaignCodeColumnNumber = 41;
        private const int gasCampaignNameColumnNumber = 42;
        private const int electricityCampaignCodeColumnNumber = 90;
        private const int electricityCampaignNameColumnNumber = 91;

        private const int electricityMeterTypeColumnNumber = 93;

        private readonly IDictionary<string, EonReplacementCode> _replacementCodes = new Dictionary<string, EonReplacementCode>();
        private readonly string _originalFilename;

        public EonCampaignCodeReplacer(string originalFilename)
        {
            _originalFilename = originalFilename;
            GenerateProductCodeObjects();
        }

        private void GenerateProductCodeObjects()
        {
            _replacementCodes.Add("FixOnline V8 Dual Fuel", new EonReplacementCode("1446214","1446208", "E.ON FixOnline v8 Gas", "E.ON FixOnline v8 Unrestricted"));
            _replacementCodes.Add("FixOnline V8 Dual Fuel - Economy7", new EonReplacementCode("1446214", "1446210", "E.ON FixOnline v8 Gas", "E.ON FixOnline v8 Economy 7"));
            _replacementCodes.Add("FixOnline V8 Economy7", new EonReplacementCode(string.Empty, "1446212", string.Empty, "E.ON FixOnline v8 E Only_E7"));
            _replacementCodes.Add("FixOnline V8 Electricity", new EonReplacementCode(string.Empty, "1446206", string.Empty, "E.ON FixOnline v8 E Only_Unrestricted"));
        }

        public string GenerateFile()
        {
            string newFullFileName = Path.GetTempFileName();

            var csvToTable = new CSVToDataTable();
            var eonDataTable = csvToTable.GetDataTable(_originalFilename);

            ModifyTable(eonDataTable);

            var tableToCsv = new DataTableToCSV();
            Stream outStream = tableToCsv.GenerateCSVStream(eonDataTable);

            var streamReader = new StreamReader(outStream);
            string entireStr = streamReader.ReadToEnd();

            File.WriteAllText(newFullFileName, entireStr);
            
            streamReader.Dispose();
            outStream.Dispose();

            return newFullFileName;
        }

        private void ModifyRow(DataRow row, EonReplacementCode replacementCode)
        {
            row[gasCampaignCodeColumnNumber] = replacementCode.GasProductCode;
            row[gasCampaignNameColumnNumber] = replacementCode.GasName;
            row[electricityCampaignCodeColumnNumber] = replacementCode.ElecProductCode;
            row[electricityCampaignNameColumnNumber] = replacementCode.ElecName;
        }

        public void ModifyTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                string gasCampaignName = !Convert.IsDBNull(row[gasCampaignNameColumnNumber])
                                             ? (string)row[gasCampaignNameColumnNumber]
                                             : string.Empty;

                string elecCampaignName = !Convert.IsDBNull(row[electricityCampaignNameColumnNumber])
                                             ? (string)row[electricityCampaignNameColumnNumber]
                                             : string.Empty;

                string meterType = !Convert.IsDBNull(row[electricityMeterTypeColumnNumber])
                                             ? (string)row[electricityMeterTypeColumnNumber]
                                             : string.Empty;

                if (gasCampaignName.Equals("British Gas") && meterType.Equals("Economy 7"))
                {
                    //Dual fuel - 7
                    ModifyRow(row, _replacementCodes["FixOnline V8 Dual Fuel - Economy7"]);
                    continue;
                }

                if (gasCampaignName.Equals("British Gas"))
                {
                    //Dual fuel
                    ModifyRow(row, _replacementCodes["FixOnline V8 Dual Fuel"]);
                    continue;
                }

                if (string.IsNullOrEmpty(gasCampaignName) && elecCampaignName.Equals("British Gas") && meterType.Equals("Economy 7"))
                {
                    //single fuel e7
                    ModifyRow(row, _replacementCodes["FixOnline V8 Economy7"]);
                    continue;
                }

                if (string.IsNullOrEmpty(gasCampaignName) && elecCampaignName.Equals("British Gas"))
                {
                    //single fuel
                    ModifyRow(row, _replacementCodes["FixOnline V8 Electricity"]);
                    continue;
                }
            }
        }
    }
}