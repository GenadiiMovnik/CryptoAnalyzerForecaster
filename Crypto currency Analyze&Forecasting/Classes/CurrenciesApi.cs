using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Crypto_currency_Analyze_Forecasting.Classes
{
    public class CurrenciesApi
    {
        private const string defaultApiUrl = "https://api.coincap.io/v2/assets/";
        private const string defaultApiIntervalRequest = "/history?interval=";
        public string GetResponseOnRequest(HttpWebRequest request)
        {
            try
            {
                string response;
                HttpWebResponse Response = (HttpWebResponse)request.GetResponse();
                var stream = Response.GetResponseStream();
                if (stream != null)
                    response = new StreamReader(stream).ReadToEnd();
                else throw new Exception("Api response is empty");
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
        public List<IntervalFromChosenToCurrentCurrencyData> GetIntervalCurrencyData(string cryptoName, string interval)
        {
            string url = $"{defaultApiUrl}{cryptoName}{defaultApiIntervalRequest}{interval}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            string response;
            response = GetResponseOnRequest(request);
            return this.ParseResponse<IntervalFromChosenToCurrentCurrencyData>(response);
        }
        public List<ActualCurrencyData> GetValidCurrencyData()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(defaultApiUrl);
            request.Method = "GET";
            return this.ParseResponse<ActualCurrencyData>(this.GetResponseOnRequest(request));
        }
        public List<T> ParseResponse<T>(string response)
        {
            if (string.IsNullOrEmpty(response))
                return null;

            try
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(response);
                if (apiResponse != null || apiResponse.data != null)
                {
                    return apiResponse.data;
                }
                else throw new Exception("Something went wrong with API response");
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
            return null;
        }
    }
}

