using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class ProductInputHandler
    {
        Receipt receipt = new Receipt();

        public void CustomOrderPromptAndHandler()
        {
            var articles = new Articles();
            var productList = articles.GetArticles();

            while (receipt.products.Count < 10)
            {
                Console.WriteLine("\nMata in valda produkter med produktid följt av mellanslag" +
                    " och därefter kvantitet angett med heltal (exempel: 200 3).");
                Console.WriteLine("Skriv PAY för att avsluta och gå vidare.\n");

                var inputOrder = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(inputOrder))
                {
                    Console.WriteLine("Felaktig inmatning. Var god försök igen.");
                    continue;
                }

                if (string.Equals(inputOrder, "pay", StringComparison.OrdinalIgnoreCase))
                {
                    if (receipt.products.Count > 0)
                    {
                        receipt.WriteReceipt();
                        receipt.PrintAndSaveReceipt(receipt._receiptLines);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Inga produkter har lagts till. Finns inget att betala.");
                        continue;
                    }
                }

                var inputOrderParts = inputOrder.Split(' ');

                if (inputOrderParts.Length != 2 || !int.TryParse(inputOrderParts[0],
                    out int productId) || !int.TryParse(inputOrderParts[1], out int quantity))
                {
                    Console.WriteLine("Felaktig inmatning. Du måste ange en produkt" +
                        " och dess kvantitet på en rad (exempel: 300 3).");
                    continue;
                }

                productId = int.Parse(inputOrderParts[0]);
                quantity = int.Parse(inputOrderParts[1]);
                Product product = articles.GetProductId(productId);

                if (product != null)
                {
                    receipt.products.Add(product, quantity);
                    Console.WriteLine("Tillagd vara");
                    foreach (var item in receipt.products)
                    {
                        Console.WriteLine(item.Key.ProductName + " " + item.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Tyvärr, produkt-ID finns inte.");
                }
            }
        }
    }
}
