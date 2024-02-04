using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Components;
using zintegrujemy_zadanie.Entities;
using Zintegrujemy_Zadanie.Entities;

namespace Zintegrujemy_Zadanie.Helpers
{
    /// <summary>
    /// CSV reader class.
    /// </summary>
    public static class CsvReaderHelper
    {
        /// <summary>
        /// Read the specified csv file and write it in the corresponding class.
        /// </summary>
        public static object ReadFileAndSaveToList(string fileName)
        {
            string pathToFile = Path.Combine(GlobalVariables.ProjectDirectory, fileName);
            string[] tmpFileName = fileName.Split('.');
            CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
                MissingFieldFound = null
            };

            using (StreamReader streamReader = new StreamReader(pathToFile))
            {
                object records;

                switch (tmpFileName[0])
                {
                    case "Products":
                        csvConfig.MissingFieldFound = null;
                        using (CsvReader csvReader = new CsvReader(streamReader, csvConfig))
                        {
                            return csvReader.GetRecords<Products>().ToList().Where(x => x.is_wire == 0).Where(x => x.shipping == "24h");
                        }

                    case "Prices":
                        csvConfig.Delimiter = ",";
                        csvConfig.HasHeaderRecord = false;
                        using (CsvReader csvReader = new CsvReader(streamReader, csvConfig))
                        {
                            return csvReader.GetRecords<Prices>().ToList();
                        }

                    case "Inventory":
                        csvConfig.Delimiter = ",";
                        csvConfig.MissingFieldFound = null;
                        csvConfig.IgnoreBlankLines = true;
                        csvConfig.BadDataFound = null;
                        using (CsvReader csvReader = new CsvReader(streamReader, csvConfig))
                        {
                            return csvReader.GetRecords<Inventory>().ToList().Where(x => x.shipping == "24h");
                        }

                    default:
                        throw new ArgumentException("File is not recognized");
                }
            }
        }
    }
}
