namespace Zintegrujemy_Zadanie.Entities
{
    /// <summary>
    /// Prices entity class.
    /// </summary>
    public class Prices
    {
        #region Fields and Constants

        /// <summary>
        /// Gets or sets unique ID, only used by internal warehouse system.
        /// </summary>
        public string Column1 { get; set; }

        /// <summary>
        /// Gets or sets product SKU, unique value created by warehouse.
        /// </summary>
        public string Column2 { get; set; }

        /// <summary>
        /// Gets or sets nett product price.
        /// </summary>
        public string Column3 { get; set; }

        /// <summary>
        /// Gets or sets nett product price after discount.
        /// </summary>
        public string Column4 { get; set; }

        /// <summary>
        /// Gets or sets VAT rate.
        /// </summary>
        public string Column5 { get; set; }

        /// <summary>
        /// Gets or sets nett product price after discount for product logistic unit.
        /// </summary>
        public string Column6 { get; set; }
        #endregion
    }
}
