

using System.Net;
using Crypto_currency_Analyze_Forecasting.Classes;


namespace CryptoCurrencyAnalyze_ForecastingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetResponseOnRequest_Success()
        {

            var api = new CurrenciesApi();
            var request = (HttpWebRequest)WebRequest.Create("https://api.coincap.io/v2/assets/bitcoin/history?interval=h1");
            request.Method = "GET";


            var result = api.GetResponseOnRequest(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetResponseOnRequest_WithInvalidUrl_ThrowsException()
        {

            var api = new CurrenciesApi();
            var request = (HttpWebRequest)WebRequest.Create("invalid_url");
            request.Method = "GET";

            Assert.ThrowsException<Exception>(() => api.GetResponseOnRequest(request));
        }

        [TestMethod]
        public void ParseResponse_WithValidResponse_ReturnsData()
        {

            var api = new CurrenciesApi();
            var response = "{\"data\":[{\"id\":\"bitcoin\",\"name\":\"Bitcoin\"}]}";

            var result = api.ParseResponse<ActualCurrencyData>(response);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void ParseResponse_WithInvalidResponse_ThrowsException()
        {

            var api = new CurrenciesApi();
            var response = "invalid_response";

            Assert.ThrowsException<Exception>(() => api.ParseResponse<ActualCurrencyData>(response));
        }
        [TestMethod]
        public void GetValidCurrencyData_Success()
        {

            var api = new CurrenciesApi();

            var result = api.GetValidCurrencyData();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetIntervalCurrencyData_WithValidParameters_Success()
        {

            var api = new CurrenciesApi();
            string cryptoName = "bitcoin";
            string interval = "h1";

            var result = api.GetIntervalCurrencyData(cryptoName, interval);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetIntervalCurrencyData_WithInvalidParameters_ReturnsNull()
        {

            var api = new CurrenciesApi();
            string cryptoName = "invalid_crypto_name";
            string interval = "invalid_interval";

            var result = api.GetIntervalCurrencyData(cryptoName, interval);


            Assert.IsNull(result);
        }
        [TestMethod]
        public void MakeForecast_ReturnsPeriodForecast()
        {

            var arimaModel = new myArimaModel();
            var api = new CurrenciesApi();
            var intervalCurrencyData = api.GetIntervalCurrencyData("bitcoin", "m1");
            int periodNumbers = 10;

            var result = arimaModel.MakeForecast(intervalCurrencyData, periodNumbers);

            Assert.IsNotNull(result);
            Assert.AreEqual(periodNumbers, result.Length);

        }

    }

}
