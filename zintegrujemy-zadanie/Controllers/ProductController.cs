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
        private IConfiguration configuration;
        private DataAccess dataAccess;
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        public ProductController(IConfiguration configuration)
        {
            this.dataAccess = new DataAccess(configuration);
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
            ProductInformation? product = this.dataAccess.SelectProductWhereSku(SKU).Result;
            return product != null ? this.Ok(product) : this.NotFound($"There is no product with SKU: {SKU}");
        }
        #endregion
    }
}
