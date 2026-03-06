using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_currency_Analyze_Forecasting.Classes
{
    public class ActualCurrencyData
    {
        public int rank;
        public string name, id, explorer;
        public decimal priceUsd, changePercent24Hr, supply, volumeUsd24Hr, marketCapUsd;
    }
}
