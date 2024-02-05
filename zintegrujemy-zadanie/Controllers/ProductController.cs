namespace Zintegrujemy_Zadanie.Controllers
{
    #region Using
    using System.Data;
    using Microsoft.AspNetCore.Mvc;
    using Zintegrujemy_Zadanie.Context;
    using Zintegrujemy_Zadanie.Entities;
    #endregion

    /// <summary>
    /// Product controller class.
    /// </summary>
    public class ProductController : ControllerBase
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
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuarion properties.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Unsupported database type.
        /// </exception>
        public ProductController(IConfiguration configuration)
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
        /// Get product information.
        /// </summary>
        /// <param name="SKU">
        /// Product SKU, unique value created by warehouse.
        /// </param>
        /// <returns>
        /// Ok, if everything went good.
        /// </returns>
        [HttpGet("SKU")]
        public IActionResult GetProductInfo(string SKU)
        {
            ProductInformation? product = this.dataAccess.SelectProductWhereSku(SKU);
            return product != null ? this.Ok(product) : this.NotFound($"There is no product with SKU: {SKU}");
        }
        #endregion
    }
}
