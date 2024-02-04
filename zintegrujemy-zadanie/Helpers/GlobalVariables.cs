using Zintegrujemy_Zadanie.Entities;

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
        /// The create database command.
        /// </summary>
        public static readonly string[] InitializeDatabaseCommand =
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

        public static readonly string InsertProductSqlCommand = @"use MagazineDB;
            INSERT INTO dbo.Product(ID,SKU,name,EAN,producer_name,category,is_wire,available,is_vendor,default_image)
            VALUES(@ID,@SKU,@name,@EAN,@producer_name,@category,@is_wire,@available,@is_vendor,@default_image);";

        public static readonly string InsertInventorySqlCommand = @"use MagazineDB;
            INSERT INTO dbo.Inventory(product_id, sku, unit, qty, manufacturer_name, shipping, shipping_cost)
            VALUES(@product_id,@sku,@unit,@qty,@manufacturer_name,@shipping,@shipping_cost);";
        
        public static readonly string InsertPriceSqlCommand = @"use MagazineDB;
            INSERT INTO dbo.Prices(Column1,Column2,Column3,Column4,Column5,Column6)
            VALUES(@Column1,@Column2,@Column3,@Column4,@Column5,@Column6);";

        public static readonly string SelectProductWhereSku = @"use MagazineDB;
            SELECT 
	            dbo.Product.name,
	            dbo.Product.EAN,
	            dbo.Product.producer_name,
	            dbo.Product.category,
	            dbo.Product.default_image,
	            dbo.Inventory.qty,
	            dbo.Inventory.unit,
	            dbo.Prices.Column3,
	            dbo.Inventory.shipping_cost
            FROM dbo.Product
            LEFT JOIN dbo.Inventory on dbo.Product.SKU = dbo.Inventory.sku
            LEFT JOIN dbo.Prices on dbo.Product.SKU = dbo.Prices.Column2
            WHERE dbo.Product.SKU = @sku;";
        #endregion
    }
}
