using CsvHelper.Configuration.Attributes;

namespace zintegrujemy_zadanie.Entities
{
    #region Fields and Constants

    /// <summary>
    /// Inventory entity class.
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Unique ID of the product.
        /// </summary>
        [Index(0)]
        public string product_id {  get; set; }

        /// <summary>
        /// Product SKU, unique value created by warehouse.
        /// </summary>
        [Index(1)]
        public string sku { get; set; }

        /// <summary>
        /// Type of unit the product is sold as.
        /// </summary>
        [Index(2)]
        public string unit { get; set; }

        /// <summary>
        /// Stock quantity.
        /// </summary>
        [Index(3)]
        public string qty { get; set; }

        /// <summary>
        /// Product Manufacturer.
        /// </summary>
        [Index(4)]
        public string manufacturer_name { get; set; }

        /// <summary>
        /// Shipping time.
        /// </summary>
        [Index(6)]
        public string shipping { get; set; }

        /// <summary>
        /// Shipping cost.
        /// </summary>
        [Index(7)]
        public string shipping_cost { get; set; }
        #endregion
    }
}
