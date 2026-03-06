using Crypto_currency_Analyze_Forecasting.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_currency_Analyze_Forecasting.Forms
{
    public partial class TopCurrenciesForm : MainWindow
    {
        public TopCurrenciesForm(List<ActualCurrencyData> actualCurrencies)
        {
            InitializeComponent();
            LoadCurrencies(actualCurrencies);
        }

        private void TopCurrenciesForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadCurrencies(List<ActualCurrencyData> actualCurrencies)
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Rank", "Rank");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("PriceUsd", "Price (USD)");
            dataGridView1.Columns.Add("MarketCapUsd", "Market Cap (USD)");
            dataGridView1.Columns.Add("ChangePercent24Hr", "Change (24h %)");
            dataGridView1.Columns["Rank"].DefaultCellStyle.Format = "N0"; 
            dataGridView1.Columns["PriceUsd"].DefaultCellStyle.Format = "N3"; 
            dataGridView1.Columns["MarketCapUsd"].DefaultCellStyle.Format = "N3"; 
            dataGridView1.Columns["ChangePercent24Hr"].DefaultCellStyle.Format = "N3"; 
            dataGridView1.Rows.Clear();
            dataGridView1.Font = new Font("Arial", 16, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            var sortedCurrencies = actualCurrencies.OrderBy(currency => currency.rank);
            foreach (var currency in sortedCurrencies)
            {
                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                row.Cells["Rank"].Value = currency.rank;
                row.Cells["Name"].Value = currency.name;
                row.Cells["PriceUsd"].Value = Math.Round(Convert.ToDouble(currency.priceUsd), 3);
                row.Cells["MarketCapUsd"].Value = Math.Round(Convert.ToDouble(currency.marketCapUsd), 3);
                row.Cells["ChangePercent24Hr"].Value = Math.Round(Convert.ToDouble(currency.changePercent24Hr), 3);
            }
        }
    }
}
