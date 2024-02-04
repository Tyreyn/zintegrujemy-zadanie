namespace Zintegrujemy_Zadanie.Context
{
    using Azure;
    using Dapper;
    #region Usings
    using Microsoft.Data.SqlClient;
    using Zintegrujemy_Zadanie.Entities;
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
        public async Task InsertDataToTable(object records, string tableName)
        {
            string[] tmpTableName = tableName.Split('.');
            switch (tmpTableName[0])
            {
                case "Products":
                    using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection")))
                    {
                        var rowsAffected = myConn.ExecuteAsync(GlobalVariables.InsertProductSqlCommand, records);
                        Console.WriteLine($"{rowsAffected.Result} row(s) inserted.");
                    }

                    break;
                case "Inventory":
                    using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection")))
                    {
                        var rowsAffected = myConn.ExecuteAsync(GlobalVariables.InsertInventorySqlCommand, records);
                        Console.WriteLine($"{rowsAffected.Result} row(s) inserted.");
                    }

                    break;
                case "Prices":
                    using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection")))
                    {
                        var rowsAffected = myConn.ExecuteAsync(GlobalVariables.InsertPriceSqlCommand, records);
                        Console.WriteLine($"{rowsAffected.Result} row(s) inserted.");
                    }

                    break;
                default:
                    throw new ArgumentException($"There is no {tableName} implemented!");
            }
        }

        public async Task<ProductInformation> SelectProductWhereSku(string sku)
        {
            ProductInformation? productInformation = null;
            using (SqlConnection myConn = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    productInformation = myConn.QueryFirst<ProductInformation>(GlobalVariables.SelectProductWhereSku, new { sku = sku });
                    Console.WriteLine($"Read {productInformation.ToString()}");
                    return productInformation;
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"There is no product with SKU:{sku}");
                    return null;
                }
            }          
        }
        #endregion
    }
}
