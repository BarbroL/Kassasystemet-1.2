using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class Receipt
    {
        public List<string> _receiptLines = new List<string>();
        public Dictionary<Product, int> products = new Dictionary<Product, int>();
        public string _receiptFilePath;
        public int ReceiptId { get; private set; }
        ReceiptIdHandler receiptIdHandler = new ReceiptIdHandler();
        private static ReceiptCounter receiptCounter = new ReceiptCounter();
        int receiptIdCounter = receiptCounter.GetReceiptCounter();
        public string _receiptDateAndTime;
        decimal totalPrice;
        decimal totalSum;

        public Receipt()
        {
            string filePath = DateTime.Now.ToString("yyyyMMdd");
            _receiptDateAndTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            _receiptFilePath = $"../../../RECEIPT_{filePath}.txt";
            receiptIdCounter = receiptIdHandler.LoadLastReceiptId() + 1;
            ReceiptId = receiptIdCounter;
            receiptIdHandler.SaveLastReceiptId(receiptIdCounter);
        }

        public void WriteReceipt()
        {
            int totalWidth = 38;
            string title = "KASSA";
            string kvitto = "KVITTO";
            string centeredTitle = title.PadLeft((totalWidth + title.Length) / 2).PadRight(totalWidth);
            string leftCenteredKvittoLine = kvitto.PadRight(kvitto.Length + 15);

            _receiptLines.Add(new string('-', totalWidth));
            _receiptLines.Add("");
            _receiptLines.Add(centeredTitle);
            _receiptLines.Add($"Id {receiptIdCounter}");
            _receiptLines.Add(new string('-', totalWidth));
            _receiptLines.Add("");
            _receiptLines.Add(leftCenteredKvittoLine + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));

            foreach (var keyValuePair in products)
            {
                Product product = keyValuePair.Key;
                int quantity = keyValuePair.Value;
                decimal totalPrice = quantity * product.ProductPrice;
                totalSum += totalPrice;

                string line = product.PriceCategory == PriceCategory.PerKilo
                ? $"{product.ProductName} {quantity:F2} kg * {product.ProductPrice} = {totalPrice:F2}"
                : $"{product.ProductName} {quantity} st * {product.ProductPrice} = {totalPrice:F2}";

                _receiptLines.Add(line);
            }
            _receiptLines.Add("");
            _receiptLines.Add($"Total: {totalSum:F2}");
            _receiptLines.Add("");
            _receiptLines.Add(new string('-', totalWidth));
            _receiptLines.Add("");
        }

        public void PrintAndSaveReceipt(List<string> receiptLines)
        {
            if (_receiptLines == null || _receiptLines.Count == 0)
            {
                Console.WriteLine("Kvittot är tomt. Inget att spara.");
                return;
            }
            if (File.Exists(_receiptFilePath))
            {
                File.AppendAllLines(_receiptFilePath, _receiptLines);
            }
            else
            {
                File.WriteAllLines(_receiptFilePath, _receiptLines);
            }
            Console.WriteLine("Kvittot har sparats till fil: " + _receiptFilePath);
            Console.WriteLine("Tryck enter för att komma till startmenyn.");
            Console.ReadKey();

            StartMenu startMenu = new StartMenu();
            startMenu.ShowMenu();
        }
    }
}
