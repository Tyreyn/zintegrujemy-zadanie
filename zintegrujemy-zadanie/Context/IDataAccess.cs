namespace Zintegrujemy_Zadanie.Context
{
    #region Usings
    using Zintegrujemy_Zadanie.Entities;
    #endregion

    /// <summary>
    /// Data access interface.
    /// </summary>
    public interface IDataAccess
    {
        #region Public Methods

        /// <summary>
        /// Create MagazineDB database if not exits.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        public Task InitializeDataBase();

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
        public void InsertDataToTable(object records, string tableName);

        /// <summary>
        /// Take information about product.
        /// </summary>
        /// <param name="productSku">
        /// Product SKU.
        /// </param>
        /// <returns>
        /// Product information.
        /// </returns>
        public ProductInformation? SelectProductWhereSku(string productSku);
        #endregion
    }
}