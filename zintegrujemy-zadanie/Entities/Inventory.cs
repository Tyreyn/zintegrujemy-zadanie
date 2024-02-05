namespace Zintegrujemy_Zadanie.Entities
{
    #region Using
    using CsvHelper.Configuration.Attributes;
    #endregion
    #region Fields and Constants

    /// <summary>
    /// Inventory entity class.
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Gets or sets unique ID of the product.
        /// </summary>
        [Index(0)]
        public string product_id { get; set; }

        /// <summary>
        /// Gets or sets product SKU, unique value created by warehouse.
        /// </summary>
        [Index(1)]
        public string sku { get; set; }

        /// <summary>
        /// Gets or sets type of unit the product is sold as.
        /// </summary>
        [Index(2)]
        public string unit { get; set; }

        /// <summary>
        /// Gets or sets stock quantity.
        /// </summary>
        [Index(3)]
        public string qty { get; set; }

        /// <summary>
        /// Gets or sets product Manufacturer.
        /// </summary>
        [Index(4)]
        public string manufacturer_name { get; set; }

        /// <summary>
        /// Gets or sets shipping time.
        /// </summary>
        [Index(6)]
        public string shipping { get; set; }

        /// <summary>
        /// Gets or sets shipping cost.
        /// </summary>
        [Index(7)]
        public string shipping_cost { get; set; }
        #endregion
    }
}
