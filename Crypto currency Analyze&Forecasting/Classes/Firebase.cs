using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Crypto_currency_Analyze_Forecasting.Classes
{
    public class Firebase
    {
        public IFirebaseClient client;
        public IFirebaseConfig cfg = new FirebaseConfig()
        {
            AuthSecret = "Z93FreGeGNViB8vZIu4F77UOlln8IiMnJHGvKim4",
            BasePath = "https://analyze-crypto-forecasting-default-rtdb.firebaseio.com/"
        };
        public Firebase()
        {
            client = new FireSharp.FirebaseClient(cfg);
        }
    }
}
