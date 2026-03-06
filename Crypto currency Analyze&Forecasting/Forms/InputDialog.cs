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
    public partial class InputDialog : Form
    {
        public int PValue { get; private set; }
        public int DValue { get; private set; }
        public int QValue { get; private set; }
        public InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PValue = Convert.ToInt32(textBox1.Text);
            DValue = Convert.ToInt32(textBox2.Text);
            QValue = Convert.ToInt32(textBox3.Text);
            this.Close();
        }
    }
}
