using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_currency_Analyze_Forecasting.Classes
{
    internal class ARIMA
    {
        private List<double> data;
        private int p, d, q;
        private List<double> arCoefficients;
        private List<double> maCoefficients;

        public ARIMA(List<double> data, int p, int d, int q)
        {
            this.data = data;
            this.p = p;
            this.d = d;
            this.q = q;
            this.arCoefficients = new List<double>();
            this.maCoefficients = new List<double>();
        }

        private List<double> Difference(List<double> series, int order)
        {
            var diff = new List<double>();
            for (int i = order; i < series.Count; i++)
            {
                diff.Add(series[i] - series[i - order]);
            }
            return diff;
        }

        private List<double> CalculateARCoefficients(List<double> diffSeries, int p)
        {

            var arCoeffs = new List<double>();
            for (int i = 1; i <= p; i++)
            {
                arCoeffs.Add(1.0 / p); 
            }
            return arCoeffs;
        }

        private List<double> CalculateMACoefficients(List<double> diffSeries, int q)
        {
            var maCoeffs = new List<double>();
            for (int i = 1; i <= q; i++)
            {
                maCoeffs.Add(1.0 / q); 
            }
            return maCoeffs;
        }

        public List<double> Fit()
        {
            var diffSeries = Difference(data, d);

            arCoefficients = CalculateARCoefficients(diffSeries, p);
            maCoefficients = CalculateMACoefficients(diffSeries, q);

            return diffSeries;
        }

        public double Forecast(int steps)
        {
            double forecast = 0.0;

            for (int i = 0; i < steps; i++)
            {
                forecast += arCoefficients.Sum() - maCoefficients.Sum(); 
            }


            for (int i = 0; i < d; i++)
            {
                forecast += data.Last();
            }

            return forecast;
        }
    }
}
