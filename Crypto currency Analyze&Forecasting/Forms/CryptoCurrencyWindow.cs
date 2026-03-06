using Crypto_currency_Analyze_Forecasting.Classes;
using Crypto_currency_Analyze_Forecasting.Forms;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Crypto_currency_Analyze_Forecasting
{
    public partial class CryptoCurrencyWindow : MainWindow
    {
        private List<ActualCurrencyData> currentValidCurrencyData;
        private CurrenciesApi currenciesApi;
        private List<IntervalFromChosenToCurrentCurrencyData> currencyDataList;
        private string currencyBlockchainExplorerUrl;
        string selectedInterval;
        AnalyzeWindow analyze;

        Firebase firebase = new Firebase();
        public CryptoCurrencyWindow()
        {
            InitializeComponent();
            currenciesApi = new CurrenciesApi();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.C))
            {
                toolStripButton1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void InitializeComponents()
        {
            InitializeCurrencyComboBoxInfo();
            InitializeIntervalComboBoxInfo();
            InitializeMinMaxChangeCurrency();
        }
        private void CryptoCurrencyWindow_Load(object sender, EventArgs e)
        {
            currentValidCurrencyData = currenciesApi.GetValidCurrencyData();
            InitializeComponents();
            currencyNameTextBox.Visible = false;
            chooseAnotherCurrencyButton.Visible = false;
            analyzeButton.Visible = false;
            currencyNameTextBox.KeyPress += CurrencyNameTextBox_KeyPress;
            infoPrintLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            explorerLinkLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            forecastingButton.Visible = false;
        }
        private void InitializeMinMaxChangeCurrency()
        {
            minMaxChangeCurrency.Items.Clear();
            var currencyWithMaxVolume = currentValidCurrencyData.OrderByDescending(c => c.volumeUsd24Hr).FirstOrDefault();
            var currencyWithMinVolume = currentValidCurrencyData.OrderBy(c => c.volumeUsd24Hr).FirstOrDefault();

            var currencyWithMaxChange = currentValidCurrencyData.OrderByDescending(c => c.changePercent24Hr).FirstOrDefault();
            var currencyWithMinChange = currentValidCurrencyData.OrderBy(c => c.changePercent24Hr).FirstOrDefault();
            minMaxChangeCurrency.Font = new Font("Arial", 16, FontStyle.Bold);

            string[] items =
                {
                 $"The most sold currency {currencyWithMaxVolume.name} ({Math.Round(currencyWithMaxVolume.volumeUsd24Hr, 2).ToString("#,0")} $)",
                 $"The least sold currency {currencyWithMinVolume.name} ({Math.Round(currencyWithMinVolume.volumeUsd24Hr, 2).ToString("#,0")} $)",
                 $"The most increased currency {currencyWithMaxChange.name} ({Math.Round(currencyWithMaxChange.changePercent24Hr, 2)} %)",
                 $"The most decreased currency {currencyWithMinChange.name} ({Math.Round(currencyWithMinChange.changePercent24Hr, 2)} %)"
            };

            int maxWidth = 0;
            foreach (string item in items)
            {
                Size textSize = TextRenderer.MeasureText(item, minMaxChangeCurrency.Font);
                maxWidth = Math.Max(maxWidth, textSize.Width);
            }
            minMaxChangeCurrency.Width = maxWidth + SystemInformation.VerticalScrollBarWidth;
            foreach (string item in items)
            {
                minMaxChangeCurrency.Items.Add(item);
            }
        }
        private void InitializeIntervalComboBoxInfo()
        {
            intervalComboBox.Items.Clear();
            Dictionary<string, string> periodValues = new Dictionary<string, string>
            {
                {"Day", "m1"},
                {"Five Days", "m5"},
                {"Week", "m15"},
                {"Two Weeks", "m30"},
                {"Month", "h1"},
                {"Two Months", "h2"},
                {"Six Months", "h6"},
                {"Twelve Months", "h12"}
            };
            foreach (var pair in periodValues)
            {
                intervalComboBox.Items.Add(new ComboboxItem(pair.Key, pair.Value));
            }
            toolStrip1.Visible = false;
        }
        private void InitializeCurrencyComboBoxInfo()
        {
            int width = 0;

            
            currentValidCurrencyData.Sort((a, b) => string.Compare(a.name, b.name));
            foreach (var currency in currentValidCurrencyData)
            {
                chooseCurrentCurrency.Items.Add(currency.name);
                int txtLength = currency.name.ToString().Length;
                if (txtLength > width)
                {
                    width = txtLength;
                }
            }
            chooseCurrentCurrency.DropDownWidth = TextRenderer.MeasureText(new string('W', width / 2 + 2), chooseCurrentCurrency.Font).Width;
        }

        private void textBoxShow_Click(object sender, EventArgs e)
        {
            currencyNameTextBox.Visible = true;
        }
        private string GetIdFromName(string name)
        {
            ActualCurrencyData selectedCurrency = currentValidCurrencyData.FirstOrDefault(currency => currency.name == name);
            return selectedCurrency != null ? selectedCurrency.id : null;
        }
        private void PrintInfo(ActualCurrencyData selectedCurrency)
        {
            infoPrintLabel.Text = $"Name: {selectedCurrency.name}\n" +
                                 $"ID: {selectedCurrency.id}\n" +
                                 $"Price USD: {Math.Round(selectedCurrency.priceUsd,3)}\n" +
                                 $"Change Percent 24Hr: {Math.Round(selectedCurrency.changePercent24Hr,3)}\n" +
                                 $"Supply: {Math.Round(selectedCurrency.supply, 3)}\n" +
                                 $"Volume USD 24Hr: {Math.Round(selectedCurrency.volumeUsd24Hr, 3)}\n";
            explorerLinkLabel.Text = $"{selectedCurrency.name} Explorer";
            currencyBlockchainExplorerUrl = selectedCurrency.explorer;
        }
        private void CurrencyFromSelection(string id)
        {
            try
            {
                if (id != null)
                {
                    ActualCurrencyData selectedCurrency = currentValidCurrencyData.FirstOrDefault(currency => currency.id == id);
                    if (selectedCurrency != null)
                    {
                        currencyDataList = currenciesApi.GetIntervalCurrencyData($"{selectedCurrency.id}", selectedInterval);
                        SetVisibleElementsOnCurrencySelection();
                        
                        PrintInfo(selectedCurrency);
                    }
                    else throw new Exception("There is no currency with such a name");
                }
                else throw new Exception("Please check the entered data");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void chooseCurrentCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedInterval != null)
            {
                CurrencyFromSelection(GetIdFromName(chooseCurrentCurrency.SelectedItem as string));
            }
            else { MessageBox.Show("Select the data validity period"); }
        }
        private void CurrencyNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CurrencyFromSelection(currencyNameTextBox.Text.ToLower());
            }
        }
        private void SetVisibleElementsOnCurrencySelection()
        {
            infoPrintLabel.Visible = true;
            analyzeButton.Visible = true;
            textBoxShow.Visible = false;
            currencyNameTextBox.Visible = false;
            chooseCurrentCurrency.Visible = false;
            Title.Visible = false;
            intervalComboBox.Visible = false;
            intervalLabel.Visible = false;
            chooseAnotherCurrencyButton.Visible = true;
            forecastingButton.Visible = true;
            minMaxChangeCurrency.Visible = false;
            getDataFromDatabaseButton.Visible = false;
        }
        private void chooseAnotherCurrencyButton_Click(object sender, EventArgs e)
        {
            HideElementsOnCurrencySelection();
        }
        private void HideElementsOnCurrencySelection()
        {
            chooseAnotherCurrencyButton.Visible = false;
            infoPrintLabel.Visible = false;
            textBoxShow.Visible = true;
            currencyNameTextBox.Visible = false;
            chooseCurrentCurrency.Visible = true;
            Title.Visible = true;
            explorerLinkLabel.Visible = false;
            analyzeButton.Visible = false;
            chooseCurrentCurrency.SelectedIndexChanged -= chooseCurrentCurrency_SelectedIndexChanged;
            chooseCurrentCurrency.SelectedItem = null;
            chooseCurrentCurrency.SelectedIndexChanged += chooseCurrentCurrency_SelectedIndexChanged;
            intervalComboBox.SelectedIndexChanged -= intervalComboBox_SelectedIndexChanged;
            intervalComboBox.SelectedItem = null;
            intervalComboBox.SelectedIndexChanged += intervalComboBox_SelectedIndexChanged;
            intervalComboBox.Visible = true;
            intervalLabel.Visible = true;
            forecastingButton.Visible = false;
            minMaxChangeCurrency.Visible = true;
            getDataFromDatabaseButton.Visible = true;
            button1.Visible = true;
        }
        private void explorerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(currencyBlockchainExplorerUrl);
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            AnalyzeWindow analyzeWindow = new AnalyzeWindow();
            
            analyzeWindow.SetCurrencyData(currencyDataList);
            analyzeWindow.BuildChart();
            analyzeWindow.Show();
            analyze = analyzeWindow;
        }

        private void intervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = (ComboboxItem)intervalComboBox.SelectedItem;
            selectedInterval = selectedItem.Value.ToString();
        }

        private void forecastingButton_Click(object sender, EventArgs e)
        {
            ForecastingWindow forecastingWindow = new ForecastingWindow(currencyDataList,analyze);
            forecastingWindow.Show();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void getDataFromDatabaseButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            var response = firebase.client.Get("CurrencyData");
            if (response != null)
            {
                var data = response.ResultAs<Dictionary<string, object>>();

                if (data != null)
                {
                    var dates = data.Keys.ToList();
                    var dateDialog = new Form
                    {
                        Text = "Choose DateTime",
                        Size = new Size(400, 400)
                    };
                    var listBox = new ListBox
                    {
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        Dock = DockStyle.Fill
                    };
                    foreach (var date in dates)
                    {
                        listBox.Items.Add(date);
                    }

                    listBox.SelectedIndexChanged += (senderX, eX) =>
                    {
                        string selectedDate = (string)listBox.SelectedItem;
                        FirebaseResponse selectedDataResponse = firebase.client.Get("CurrencyData/" + selectedDate);
                        List<ActualCurrencyData> selectedData = selectedDataResponse.ResultAs<List<ActualCurrencyData>>();
                        currentValidCurrencyData = selectedData;
                        InitializeComponents();
                        dateDialog.Hide();
                    };
                    dateDialog.Controls.Add(listBox);
                    
                    dateDialog.ShowDialog();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentValidCurrencyData = currenciesApi.GetValidCurrencyData();
            InitializeComponents();
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd_MM_yyyy_HH_mm_ss");
            string path = "CurrencyData/" + formattedDate;
            firebase.client.Set(path + "/", currentValidCurrencyData);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TopCurrenciesForm topForm = new TopCurrenciesForm(currentValidCurrencyData);
            topForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }
    }
}

