namespace Zintegrujemy_Zadanie.Controllers
{
    #region Usings
    using Microsoft.AspNetCore.Mvc;
    using Zintegrujemy_Zadanie.Context;
    using Zintegrujemy_Zadanie.Helpers;
    #endregion

    /// <summary>
    /// Data controller class.
    /// </summary>
    [ApiController]
    [Route("api/MagazineDataAPI")]
    public class DataController : ControllerBase
    {
        #region Fields and Constants

        /// <summary>
        /// The configuarion properties.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The data access class.
        /// </summary>
        private readonly IDataAccess dataAccess;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataController"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuarion properties.
        /// </param>
        public DataController(IConfiguration configuration)
        {
            switch (configuration["DatabaseType"])
            {
                case "MYSQL":
                    this.dataAccess = new MySqlDataAccess(configuration);
                    break;

                case "SQLSERVER":
                    this.dataAccess = new SqlServerDataAccess(configuration);
                    break;
                default:
                    throw new ArgumentException("Unsupported database type");
            }

            this.configuration = configuration;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Download and save required files to project directory.
        /// </summary>
        [HttpGet("ReadData")]
        public void Download()
        {
            this.dataAccess.InitializeDataBase().Wait();

            foreach (KeyValuePair<string, string> file in GlobalVariables.FilesToDownload)
            {
                object records;
                bool downloadResult = FileDownloader.Download(
                    fileName: file.Key,
                    url: file.Value).Result;

                if (!downloadResult)
                {
                    Console.WriteLine($"Was not able to download {file.Key}!");
                }
                else
                {
                    Console.WriteLine($"{file.Key} downloaded successful!");
                    records = CsvReaderHelper.ReadFileAndSaveToList(file.Key);
                    this.dataAccess.InsertDataToTable(records, file.Key);
                }
            }
        }
        #endregion
    }
}
