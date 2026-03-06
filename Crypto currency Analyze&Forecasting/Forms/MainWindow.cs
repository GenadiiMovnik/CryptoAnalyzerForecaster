using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_currency_Analyze_Forecasting
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            ColorBind();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {


        }
        private void ColorBind()
        {
            this.BackColor = System.Drawing.Color.SeaGreen;
        }
    }
}
