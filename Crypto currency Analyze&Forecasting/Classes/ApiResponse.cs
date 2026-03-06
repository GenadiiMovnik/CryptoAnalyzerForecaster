using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_currency_Analyze_Forecasting.Classes
{
    internal class ApiResponse<T>
    {
        public List<T> data { get; set; }
    }
}
