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
        /// The current project directory.
        /// </summary>
        private readonly string projectDirectory = Directory.GetCurrentDirectory();

        /// <summary>
        /// The configuarion properties.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The data access class.
        /// </summary>
        private DataAccess dataContext;

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
            this.dataContext = new DataAccess(configuration);
            this.configuration = configuration;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Download and save required files to project directory.
        /// </summary>
        [HttpGet("ReadData")]
        public async Task Download()
        {
            //foreach (KeyValuePair<string, string> file in GlobalVariables.FilesToDownload)
            //{
            //    bool downloadResult = FileDownloader.Download(
            //        fileName: file.Key,
            //        url: file.Value,
            //        projectDirectory: this.projectDirectory);

            //    if (!downloadResult)
            //    {
            //        Console.WriteLine($"Was not able to download {file.Key}!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{file.Key} downloaded successful!");
            //    }
            //}

            await this.dataContext.InitializeDataBase();
        }
        #endregion
    }
}
