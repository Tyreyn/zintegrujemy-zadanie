namespace Zintegrujemy_Zadanie.Entities
{
    /// <summary>
    /// Response entity class.
    /// </summary>
    public class ProductInformation
    {
        #region Fields and Constants

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
        /// Gets or sets URL address to product’s image.
        /// </summary>
        public string default_image { get; set; }

        /// <summary>
        /// Gets or sets type of unit the product is sold as.
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// Gets or sets stock quantity.
        /// </summary>
        public string qty { get; set; }

        /// <summary>
        /// Gets or sets shipping cost.
        /// </summary>
        public string shipping_cost { get; set; }

        /// <summary>
        /// Gets or sets nett product price.
        /// </summary>
        public string Column3 { get; set; }
        #endregion
    }
}
