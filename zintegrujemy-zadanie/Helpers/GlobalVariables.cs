namespace Zintegrujemy_Zadanie.Helpers
{
    /// <summary>
    /// The global variables class.
    /// </summary>
    public static class GlobalVariables
    {
        #region Fields and Constants

        /// <summary>
        /// The database name.
        /// </summary>
        public static readonly string DataBaseName = "MagazineDB";

        /// <summary>
        /// The create database command.
        /// </summary>
        public static readonly string[] InitializeDatabaseCommand =
            {
                "IF(DB_ID('MagazineDB') IS NULL) CREATE DATABASE MagazineDB;",
                @"USE MagazineDB;
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products')
                BEGIN
                CREATE TABLE dbo.Product
                (
	                ID int PRIMARY KEY,
	                SKU VARCHAR(255) UNIQUE,
	                name TEXT,
	                reference TEXT,
	                EAN TEXT,
	                producer_name TEXT,
	                category TEXT,
	                is_wire INT,
	                available INT,
	                is_vendor INT,
	                default_image TEXT,
                );
                END;",
                @"USE MagazineDB;
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Inventory')
                BEGIN
                CREATE TABLE dbo.Inventory
                (
	                product_id INT FOREIGN KEY REFERENCES Product(ID),
	                sku VARCHAR(255) FOREIGN KEY REFERENCES Product(SKU),
	                unit INT,
	                qty INT,
	                manufacturer INT,
	                shipping INT,
	                shipping_cost INT
	            );
                END;",
                @"USE MagazineDB;
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Prices')
                BEGIN
                CREATE TABLE dbo.Prices
                (
	                Column1 INT PRIMARY KEY,
	                Column2 VARCHAR(255) FOREIGN KEY REFERENCES Product(SKU),
	                Column3 INT,
	                Column4 INT,
	                Column5 INT,
	                Column6 INT
                );
                END;",
            };

        /// <summary>
        /// The dictionary of downloads files.
        /// Key: File name
        /// Value: URL.
        /// </summary>
        public static readonly Dictionary<string, string> FilesToDownload = new Dictionary<string, string>
        {
            { "Products.csv", "https://rekturacjazadanie.blob.core.windows.net/zadanie/Products.csv" },
            { "Inventory.csv", "https://rekturacjazadanie.blob.core.windows.net/zadanie/Inventory.csv" },
            { "Prices.csv", "https://rekturacjazadanie.blob.core.windows.net/zadanie/Prices.csv" },
        };
        #endregion
    }
}
