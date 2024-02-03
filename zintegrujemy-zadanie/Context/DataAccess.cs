﻿namespace Zintegrujemy_Zadanie.Context
{
    #region Usings
    using Microsoft.Data.SqlClient;
    using Zintegrujemy_Zadanie.Helpers;
    #endregion

    /// <summary>
    /// Data access class.
    /// </summary>
    public class DataAccess
    {
        #region Fields and Constants

        /// <summary>
        /// The configuration properties.
        /// </summary>
        private IConfiguration configuration;
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccess"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuarion properties.
        /// </param>
        public DataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create MagazineDB database if not exits.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task InitializeDataBase()
        {
            using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection")))
            {
                foreach (string command in GlobalVariables.InitializeDatabaseCommand)
                {
                    using (SqlCommand myCommand = new SqlCommand(command, myConn))
                    {
                        myConn.Open();
                        Console.WriteLine($"Execute SQL command: {command}");
                        await myCommand.ExecuteNonQueryAsync();
                        myConn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Inserts data to table.
        /// </summary>
        public async Task InsertDataToTable()
        {
            ///TBD
        }
        #endregion
    }
}
