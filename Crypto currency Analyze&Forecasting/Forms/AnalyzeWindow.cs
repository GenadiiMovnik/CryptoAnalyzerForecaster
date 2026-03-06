using Crypto_currency_Analyze_Forecasting.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Media;
using Color = System.Drawing.Color;
using System.Drawing;
using LiveCharts.Defaults;

namespace Crypto_currency_Analyze_Forecasting.Forms
{
    public partial class AnalyzeWindow : MainWindow
    {
        public List<IntervalFromChosenToCurrentCurrencyData> currencyData;
        List<string> dates1 = new List<string>();
        
        Color forecastColor;
        public AnalyzeWindow()
        {
            InitializeComponent();
        }
        public void BuildChart()
        {
            ChartValues<DateTimePoint> prices = new ChartValues<DateTimePoint>();
            foreach (var item in currencyData)
            {
                DateTime dateTime = DateTime.Parse(item.date);
                prices.Add(new DateTimePoint(dateTime, Convert.ToDouble(item.priceUsd)));
            }

            cartesianChart1.AxisX.Clear(); // Очищаем ось X перед добавлением новых значений
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date",
                LabelFormatter = value => new DateTime((long)value).ToString("dd.MM.yyyy HH:mm")
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Price (USD)"
            });

            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "Actual Data",
                Values = prices,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(RandomColor().R, RandomColor().G, RandomColor().B))
            });
        }


        public Color RandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(256), random.Next(256), 0);
        }
        public void AddDataToChart(List<IntervalFromChosenToCurrentCurrencyData> data)
        {
            ChartValues<DateTimePoint> prices = new ChartValues<DateTimePoint>();
            foreach (var item in data)
            {
                DateTime dateTime = DateTime.Parse(item.date);
                prices.Add(new DateTimePoint(dateTime, Convert.ToDouble(item.priceUsd)));
            }

            cartesianChart1.Series.Add(new LineSeries
            {
                Title = "Forecast Data",
                Values = prices,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(RandomColor().R, RandomColor().G, RandomColor().B))
            });
        }

        private void AnalyzeWindow_Load(object sender, EventArgs e)
        {
            SetupChart();
            forecastColor = RandomColor();
        }
        private void SetupChart()
        {
            panel1.Dock = DockStyle.Fill;
            panel1.Controls.Add(cartesianChart1);
            cartesianChart1.Dock = DockStyle.Fill;
        }
        public void SetCurrencyData(List<IntervalFromChosenToCurrentCurrencyData> data)
        {
            currencyData = data;
        }
    }
}
