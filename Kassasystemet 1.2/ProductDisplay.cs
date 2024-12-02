using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class ProductDisplay
    {
        private CsvFileReader _csvReader;
        private CsvFileWriter _csvWriter;

        public ProductDisplay()
        {
            _csvReader = new CsvFileReader();
            _csvWriter = new CsvFileWriter();
        }

        public void ShowProductsInConsole()
        {
            var products = _csvReader.ReadProductsFromCsv();

            if (products.Count == 0)
            {
                Console.WriteLine("Inga produkter hittades.");
                var articles = new Articles();
                var listOfArticles = articles.GetArticles();
                _csvWriter.WriteProductsToCsv(listOfArticles);
                products = _csvReader.ReadProductsFromCsv();
            }

            Console.Clear();
            Console.WriteLine("{0, -10} {1, -17} {2, -18} {3, -15}",
                "Produktid", "Produktnamn", "Produktpris", "Produktkategori");

            foreach (var product in products)
            {
                Console.WriteLine("{0, -9} {1, -18} {2, -18} {3, -15}",
                    product.ProductId, product.ProductName, product.ProductPrice,
                    product.PriceCategory);
            }

            var productInputHandler = new ProductInputHandler();
            productInputHandler.CustomOrderPromptAndHandler();
        }
    }
}
