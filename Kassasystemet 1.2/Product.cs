using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public enum PriceCategory
    {
        PerKilo,
        PerStyck
    }
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public PriceCategory PriceCategory { get; private set; }

        public Product
            (int productId, string productName, decimal productPrice,
            PriceCategory priceCategory)
        {
            (ProductId, ProductName, ProductPrice, PriceCategory) =
            (productId, productName, productPrice, priceCategory);
        }
    }
}
