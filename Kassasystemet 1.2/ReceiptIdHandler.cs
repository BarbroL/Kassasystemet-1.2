using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class ReceiptIdHandler
    {
        public int LoadLastReceiptId()
        {
            string filepath = "lastReceiptId.txt";
            if (File.Exists(filepath))
            {
                string lastRId = File.ReadAllText(filepath);
                if (int.TryParse(lastRId, out int lastId))
                {
                    return lastId;
                }
            }

            return 0;
        }

        public void SaveLastReceiptId(int lastId)
        {
            string filePath = "lastReceiptId.txt";
            File.WriteAllText(filePath, lastId.ToString());
        }
    }
}

