using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class CsvFileWriter
    {
        private string _filePath = @"..\..\..\Files\products.csv";
        public void WriteProductsToCsv(List<Product> listOfArticles)
        {
            List<string> csvProductList = new List<string>
            {
                string.Format("{0, -10}, {1, -20}, {2, -10}, {3, -15}",
                "ProductId", "ProductName", "ProductPrice", "PriceCategory")
            };
            foreach (var product in listOfArticles)
            {
                string productPriceWithDot = product.ProductPrice.ToString().Replace(',', '.');
                Console.WriteLine($"{product.ProductId},{product.ProductName}," +
                    $"{productPriceWithDot}, {product.PriceCategory}");

                csvProductList.Add(string.Format("{0, -10}, {1, -20}, {2, -10}, {3, -15}",
                    product.ProductId, product.ProductName, productPriceWithDot, product.PriceCategory));
            }

            File.WriteAllLines(_filePath, csvProductList);
            Console.WriteLine("Produkter har skrivits till Csv-filen.");
        }
    }
}
