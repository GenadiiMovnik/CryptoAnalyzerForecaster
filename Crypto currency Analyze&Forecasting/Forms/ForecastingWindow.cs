using Crypto_currency_Analyze_Forecasting.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RDotNet;

namespace Crypto_currency_Analyze_Forecasting.Forms
{
    public partial class ForecastingWindow : MainWindow
    {
        List<IntervalFromChosenToCurrentCurrencyData> currencyDataList;
        List<IntervalFromChosenToCurrentCurrencyData> forecastingDataList = new List<IntervalFromChosenToCurrentCurrencyData>();
        AnalyzeWindow analyzeWindow;
        int periodNumbers;
        int p=50, d=1, q=1;

        public ForecastingWindow(List<IntervalFromChosenToCurrentCurrencyData> data, AnalyzeWindow analyzeWindow )
        {
            InitializeComponent();
            this.currencyDataList = data;
            this.analyzeWindow = analyzeWindow;
        }

        private void ForecastingWindow_Load(object sender, EventArgs e)
        {
            periodNumbersLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            forecastPrintLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            listBox1.Font = new Font("Arial", 16, FontStyle.Bold);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D))
            {
                OpenInputDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OpenInputDialog()
        {
            using (InputDialog dialog = new InputDialog())
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.p = dialog.PValue;
                    this.d = dialog.DValue;
                    this.q = dialog.QValue;
                }
            }
        }

        private void makeForecastButton_Click(object sender, EventArgs e)
        {
            periodNumbers = Convert.ToInt32(periodNumbersTextBox.Text);
            DateTime now = DateTime.Now;
            myArimaModel arimaModel = new myArimaModel();
            double[] forecast = arimaModel.MakeForecast(currencyDataList, periodNumbers, p, d, q);
            for (int i = 0; i < forecast.Length; i++)
            {
                DateTime date = now.AddMinutes(i+1);
                IntervalFromChosenToCurrentCurrencyData item = new IntervalFromChosenToCurrentCurrencyData
                {
                    date = date.ToString(),
                    priceUsd = (decimal)forecast[i]
                };
                forecastingDataList.Add(item);
            }
            forecastPrintLabel.Text = "Forecast value:\n";
            for (int i = 0; i < forecast.Length; i++)
            {
                listBox1.Items.Add($"Period {i + 1}: Date: {DateTime.Now.AddMinutes(i + 1)} PriceUSD: {Math.Round(forecast[i], 4)}\n");
                

            }
            analyzeWindow.AddDataToChart(forecastingDataList);
            if (arimaModel.recFlag)
            {
                listBox1.Items.Add("We do not recommend investing in this currency.");
            }
            else listBox1.Items.Add("We recommend investing in this currency.");
        }
    }
}
