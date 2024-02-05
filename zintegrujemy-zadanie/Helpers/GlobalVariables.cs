namespace Zintegrujemy_Zadanie.Helpers
{
    /// <summary>
    /// The global variables class.
    /// </summary>
    public static class GlobalVariables
    {
        #region Fields and Constants

        /// <summary>
        /// The current project directory.
        /// </summary>
        public static readonly string ProjectDirectory = Directory.GetCurrentDirectory();

        /// <summary>
        /// The database name.
        /// </summary>
        public static readonly string DataBaseName = "MagazineDB";

        /// <summary>
        /// The create SQL server database command.
        /// </summary>
        public static readonly string[] InitializeSqlServerDatabaseCommand =
            {
                "IF(DB_ID('MagazineDB') IS NULL) CREATE DATABASE MagazineDB;",
                @"USE MagazineDB;
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Product')
                BEGIN
                CREATE TABLE dbo.Product
                (
	                ID VARCHAR(255) PRIMARY KEY,
	                SKU VARCHAR(255) UNIQUE,
	                name VARCHAR(255),
	                EAN VARCHAR(255),
	                producer_name VARCHAR(255),
	                category VARCHAR(255),
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
	                product_id VARCHAR(255) PRIMARY KEY,
	                sku VARCHAR(255) UNIQUE,
	                unit VARCHAR(255),
	                qty VARCHAR(255),
	                manufacturer_name VARCHAR(255),
	                shipping VARCHAR(255),
	                shipping_cost VARCHAR(255)
	            );
                END;",
                @"USE MagazineDB;
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Prices')
                BEGIN
                CREATE TABLE dbo.Prices
                (
	                Column1 VARCHAR(255) PRIMARY KEY,
	                Column2 VARCHAR(255) UNIQUE,
	                Column3 VARCHAR(255),
	                Column4 VARCHAR(255),
	                Column5 VARCHAR(255),
	                Column6 VARCHAR(255)
                );
                END;",
            };

        /// <summary>
        /// The create MySQL database command.
        /// </summary>
        public static readonly string[] InitializeMySqlDatabaseCommand =
            {
                "CREATE DATABASE IF NOT EXISTS MagazineDB;",
                @"use MagazineDB;
                CREATE TABLE IF NOT EXISTS Product
                (
                    ID VARCHAR(255) PRIMARY KEY,
                    SKU VARCHAR(255) UNIQUE,
                    name VARCHAR(255),
                    EAN VARCHAR(255),
                    producer_name VARCHAR(255),
                    category VARCHAR(255),
                    is_wire INT,
                    available INT,
                    is_vendor INT,
                    default_image TEXT
                );",
                @"USE MagazineDB;
                CREATE TABLE IF NOT EXISTS Inventory
                (
	                product_id VARCHAR(255) PRIMARY KEY,
	                sku VARCHAR(255) UNIQUE,
	                unit VARCHAR(255),
	                qty VARCHAR(255),
	                manufacturer_name VARCHAR(255),
	                shipping VARCHAR(255),
	                shipping_cost VARCHAR(255)
	            );",
                @"USE MagazineDB;
                CREATE TABLE IF NOT EXISTS Prices
                (
	                Column1 VARCHAR(255) PRIMARY KEY,
	                Column2 VARCHAR(255) UNIQUE,
	                Column3 VARCHAR(255),
	                Column4 VARCHAR(255),
	                Column5 VARCHAR(255),
	                Column6 VARCHAR(255)
                );",
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

        /// <summary>
        /// Insert commands dictionary
        /// Key: Table command
        /// Value: SQL command string.
        /// </summary>
        public static readonly Dictionary<string, string> InsertSqlCommandDictionary =
            new Dictionary<string, string>
        {
                {
                    "Products",  @"
                    INSERT INTO
                        MagazineDB.Product(ID,SKU,name,EAN,producer_name,category,
                        is_wire,available,is_vendor,default_image)
                    VALUES(@ID,@SKU,@name,@EAN,@producer_name,@category,
                        @is_wire,@available,@is_vendor,@default_image);" },
                {
                    "Inventory", @"
                    INSERT INTO
                        MagazineDB.Inventory(product_id, sku, unit, qty,
                        manufacturer_name, shipping, shipping_cost)
                    VALUES(@product_id,@sku,@unit,@qty,
                        @manufacturer_name,@shipping,@shipping_cost);"
                },
                {
                    "Prices", @"
                    INSERT INTO
                        MagazineDB.Prices(Column1,Column2,Column3,Column4,Column5,Column6)
                    VALUES(@Column1,@Column2,@Column3,@Column4,@Column5,@Column6);"
                },
        };

        /// <summary>
        /// Select specify product SQL command.
        /// </summary>
        public static readonly string SelectProductWhereSkuCommand = @"
            SELECT
	            MagazineDB.Product.name,
	            MagazineDB.Product.EAN,
	            MagazineDB.Product.producer_name,
	            MagazineDB.Product.category,
	            MagazineDB.Product.default_image,
	            MagazineDB.Inventory.qty,
	            MagazineDB.Inventory.unit,
	            MagazineDB.Prices.Column3,
	            MagazineDB.Inventory.shipping_cost
            FROM MagazineDB.Product
            LEFT JOIN MagazineDB.Inventory on MagazineDB.Product.SKU = MagazineDB.Inventory.sku
            LEFT JOIN MagazineDB.Prices on MagazineDB.Product.SKU = MagazineDB.Prices.Column2
            WHERE MagazineDB.Product.SKU = @sku;";
        #endregion
    }
}
