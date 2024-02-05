namespace Zintegrujemy_Zadanie.Context
{
    #region Usings
    using Dapper;
    using MySqlConnector;
    using Zintegrujemy_Zadanie.Entities;
    using Zintegrujemy_Zadanie.Helpers;
    #endregion

    /// <summary>
    /// MySQL data access class.
    /// </summary>
    public class MySqlDataAccess : IDataAccess
    {
        #region Fields and Constants

        /// <summary>
        /// The configuration properties.
        /// </summary>
        private readonly IConfiguration configuration;
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlDataAccess"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuarion properties.
        /// </param>
        public MySqlDataAccess(IConfiguration configuration)
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
            using (MySqlConnection myConn = new MySqlConnection(this.configuration.GetConnectionString("MYSQL")))
            {
                foreach (string command in GlobalVariables.InitializeMySqlDatabaseCommand)
                {
                    myConn.Open();
                    Console.WriteLine($"Execute SQL command: {command}");
                    await myConn.ExecuteAsync(command);
                    myConn.Close();
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
            using (MySqlConnection myConn = new MySqlConnection(this.configuration.GetConnectionString("MYSQL")))
            {
                var rowsAffected = await myConn.ExecuteAsync(
                    string.Format(GlobalVariables.InsertSqlCommandDictionary[tmpTableName[0]], GlobalVariables.MySqlDatabaseName),
                    records);

                Console.WriteLine($"{rowsAffected.ToString()} row(s) inserted.");
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
            using (MySqlConnection myConn = new MySqlConnection(this.configuration.GetConnectionString("MYSQL")))
            {
                try
                {
                    myConn.Open();
                    productInformation = myConn.QueryFirst<ProductInformation>(
                        sql: string.Format(GlobalVariables.SelectProductWhereSkuCommand, GlobalVariables.MySqlDatabaseName),
                        param: new { sku = productSku });
                    Console.WriteLine($"Read {productInformation.ToString()}");
                    myConn.Close();
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
