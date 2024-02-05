namespace Zintegrujemy_Zadanie.Context
{
    #region Usings
    using Dapper;
    using Microsoft.Data.SqlClient;
    using MySqlConnector;
    using Zintegrujemy_Zadanie.Entities;
    using Zintegrujemy_Zadanie.Helpers;
    #endregion

    /// <summary>
    /// SQL server data access class.
    /// </summary>
    public class SqlServerDataAccess : IDataAccess
    {
        #region Fields and Constants

        /// <summary>
        /// The configuration properties.
        /// </summary>
        private readonly IConfiguration configuration;
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDataAccess"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuarion properties.
        /// </param>
        public SqlServerDataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create MagazineDB database if not exits.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        public async Task InitializeDataBase()
        {
            using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("SQLSERVER")))
            {
                foreach (string command in GlobalVariables.InitializeSqlServerDatabaseCommand)
                {
                    using (SqlCommand myCommand = new SqlCommand(command, myConn))
                    {
                        myConn.Open();
                        Console.WriteLine($"Execute SQL server command: {command}");
                        await myCommand.ExecuteNonQueryAsync();
                        myConn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Inserts data to table.
        /// </summary>
        /// <param name="records">
        /// The data that will be inserted.
        /// </param>
        /// <param name="tableName">
        /// The table name into which data will be inserted.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown out when no such table is supported.
        /// </exception>
        public async void InsertDataToTable(object records, string tableName)
        {
            string[] tmpTableName = tableName.Split('.');
            using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("MYSQL")))
            {
                var rowsAffected = await myConn.ExecuteAsync(
                    GlobalVariables.InsertSqlCommandDictionary[tmpTableName[0]],
                    records);

                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
        }

        /// <summary>
        /// Take information about product.
        /// </summary>
        /// <param name="productSku">
        /// Product SKU.
        /// </param>
        /// <returns>
        /// Product information.
        /// </returns>
        public ProductInformation? SelectProductWhereSku(string productSku)
        {
            ProductInformation? productInformation = null;
            using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("SQLSERVER")))
            {
                try
                {
                    productInformation = myConn.QueryFirst<ProductInformation>(
                        GlobalVariables.SelectProductWhereSkuCommand,
                        new { sku = productSku });
                    Console.WriteLine($"Read {productInformation.ToString()}");
                    return productInformation;
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"There is no product with SKU:{productSku} {ioe}");
                    return productInformation;
                }
            }
        }
        #endregion
    }
}
