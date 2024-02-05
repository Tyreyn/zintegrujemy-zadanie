namespace Zintegrujemy_Zadanie.Entities
{
    /// <summary>
    /// Product entity class.
    /// </summary>
    public class Products
    {
        #region Fields and Constants

        /// <summary>
        /// Gets or sets unique ID of the product.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets product SKU, unique value created by warehouse.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets product number.
        /// </summary>
        public string EAN { get; set; }

        /// <summary>
        /// Gets or sets supplier name.
        /// </summary>
        public string producer_name { get; set; }

        /// <summary>
        /// Gets or sets product Category.
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// Gets or sets indicator whether the product is a wire
        /// (if value is 1).
        /// </summary>
        public int? is_wire { get; set; }

        /// <summary>
        /// Gets or sets indicator whether the product is available
        /// for order (if value is 1).
        /// </summary>
        public int? available { get; set; }

        /// <summary>
        ///  Gets or sets indicator whether the product is shipped
        ///  by supplier or warehouse. If value is 0,
        ///  it’s shipped by warehouse, if 1,
        ///  it’s shipped by supplier.
        /// </summary>
        public int? is_vendor { get; set; }

        /// <summary>
        /// Gets or sets URL address to product’s image.
        /// </summary>
        public string default_image { get; set; }

        /// <summary>
        /// Gets or sets shipping time.
        /// </summary>
        public string shipping { get; set; }

        #endregion
    }
}
