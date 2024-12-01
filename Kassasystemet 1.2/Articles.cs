using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class Articles
    {
        public List<Product> listOfArticles = new List<Product>
        {
            new Product(100,"Ägg 10-pack",52.90m,PriceCategory.PerStyck),
            new Product(200,"Kaffe",68.90m,PriceCategory.PerStyck),
            new Product(300,"Banan",27.95m,PriceCategory.PerKilo),
            new Product(400,"Mjölk",15.90m,PriceCategory.PerStyck),
            new Product(500,"Rågrut",21.90m,PriceCategory.PerStyck),
            new Product(600,"Potatis",42.90m,PriceCategory.PerKilo),
            new Product(700,"Clementiner",35.90m,PriceCategory.PerKilo),
            new Product(800,"Gurka",14.90m,PriceCategory.PerStyck),
            new Product(900,"Smör",55.90m,PriceCategory.PerStyck)
        };

        public List<Product> GetArticles()
        {
            return listOfArticles;
        }

        public Product GetProductId(int productId)
        {
            return listOfArticles.Find(p => productId == p.ProductId);
        }
    }
}
