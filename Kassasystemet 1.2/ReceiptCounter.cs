using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet_1._2
{
    public class ReceiptCounter
    {
        public int rC = 0;
        public int GetReceiptCounter()
        {
            rC++;
            return rC;
        }
    }
}
