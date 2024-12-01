using Kassasystemet_1._2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Kassasystemet_1._2
{
    public class CsvFileReader
    {
        private string _filePath = @"..\..\..\Files\products.csv";

        public List<Product> ReadProductsFromCsv()
        {
            List<Product> products = new List<Product>();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);

                for (int i = 1; i < lines.Length; i++)
                {
                    string productLine = lines[i];
                    string[] productLineParts = productLine.Split(',');

                    if (productLineParts.Length == 4)
                    {
                        int.TryParse(productLineParts[0], out int productId);
                        var productName = productLineParts[1];

                        decimal.TryParse(productLineParts[2], System.Globalization.NumberStyles.Any,
                            CultureInfo.InvariantCulture, out decimal productPriceWithDot);
                        Enum.TryParse(productLineParts[3], out PriceCategory priceCategory);

                        products.Add(new Product(productId, productName, productPriceWithDot, priceCategory));
                    }
                    else
                    {
                        Console.WriteLine($"Produktsträngen har inte rätt format");
                    }
                }

            }
            return products;
        }
    }
}


















