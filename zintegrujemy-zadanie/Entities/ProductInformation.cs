namespace Zintegrujemy_Zadanie.Entities
{
    /// <summary>
    /// Response entity class.
    /// </summary>
    public class ProductInformation
    {
        #region Fields and Constants

        /// <summary>
        /// Product name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Product number.
        /// </summary>
        public string EAN { get; set; }

        /// <summary>
        /// Supplier name.
        /// </summary>
        public string producer_name { get; set; }

        /// <summary>
        /// Product Category.
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// URL address to product’s image.
        /// </summary>
        public string default_image { get; set; }

        /// <summary>
        /// Type of unit the product is sold as.
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// Stock quantity.
        /// </summary>
        public string qty { get; set; }

        /// <summary>
        /// Shipping cost.
        /// </summary>
        public string shipping_cost { get; set; }

        /// <summary>
        /// Nett product price.
        /// </summary>
        public string Column3 { get; set; }
        #endregion
    }
}
