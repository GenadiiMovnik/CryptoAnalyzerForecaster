
using System.Collections.Generic;
using Extreme.Statistics;
using Extreme.Mathematics;
using Extreme.Statistics.TimeSeriesAnalysis;
using System.Linq;
using System.Windows;

namespace Crypto_currency_Analyze_Forecasting.Classes
{
    public class myArimaModel
    {    
        public bool recFlag=true;

        public double[] MakeForecast(List<IntervalFromChosenToCurrentCurrencyData> intervalCurrencyData, int periodNumbers, int p, int d, int q)
        {

            const int n = 1440;
            double[] timeSeries = intervalCurrencyData.Select(data => (double)data.priceUsd).ToArray();
            double[] forecast = new double[n];

            double alpha = 0.1;
            for (int i = 1; i < n; i++)
            {
                forecast[i] = alpha * timeSeries[i - 1] + (1 - alpha) * forecast[i - 1];
            }
            double[] periodForecast = new double[periodNumbers];
            for (int i = n - periodNumbers, a = 0; i < n; a++, i++)
            {
                periodForecast[a] = forecast[i];
            }
            return periodForecast;
        }
        /* public double[] MakeForecast(List<IntervalFromChosenToCurrentCurrencyData> intervalCurrencyData, int periodNumbers,int p,int d, int q )
         {
             Extreme.License.Verify("22250-35654-17818-06084");
             double[] timeSeries = intervalCurrencyData.Select(data => (double)data.priceUsd).ToArray();

             var arimaModel = new ArimaModel(timeSeries, p, d, q);

             arimaModel.Fit();

             Vector<double> forecastVector = arimaModel.Forecast(periodNumbers);

             double[] forecast = forecastVector.ToArray();

             return forecast;
         }*/
    }
}
