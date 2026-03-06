namespace Crypto_currency_Analyze_Forecasting.Forms
{
    partial class ForecastingWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.periodNumbersLabel = new System.Windows.Forms.Label();
            this.periodNumbersTextBox = new System.Windows.Forms.TextBox();
            this.makeForecastButton = new System.Windows.Forms.Button();
            this.forecastPrintLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // periodNumbersLabel
            // 
            this.periodNumbersLabel.AutoSize = true;
            this.periodNumbersLabel.Location = new System.Drawing.Point(49, 23);
            this.periodNumbersLabel.Name = "periodNumbersLabel";
            this.periodNumbersLabel.Size = new System.Drawing.Size(119, 13);
            this.periodNumbersLabel.TabIndex = 0;
            this.periodNumbersLabel.Text = "Enter numbers of period";
            // 
            // periodNumbersTextBox
            // 
            this.periodNumbersTextBox.Location = new System.Drawing.Point(52, 66);
            this.periodNumbersTextBox.Name = "periodNumbersTextBox";
            this.periodNumbersTextBox.Size = new System.Drawing.Size(100, 20);
            this.periodNumbersTextBox.TabIndex = 1;
            // 
            // makeForecastButton
            // 
            this.makeForecastButton.Location = new System.Drawing.Point(52, 113);
            this.makeForecastButton.Name = "makeForecastButton";
            this.makeForecastButton.Size = new System.Drawing.Size(100, 45);
            this.makeForecastButton.TabIndex = 2;
            this.makeForecastButton.Text = "Make Forecast";
            this.makeForecastButton.UseVisualStyleBackColor = true;
            this.makeForecastButton.Click += new System.EventHandler(this.makeForecastButton_Click);
            // 
            // forecastPrintLabel
            // 
            this.forecastPrintLabel.AutoSize = true;
            this.forecastPrintLabel.Location = new System.Drawing.Point(52, 208);
            this.forecastPrintLabel.Name = "forecastPrintLabel";
            this.forecastPrintLabel.Size = new System.Drawing.Size(0, 13);
            this.forecastPrintLabel.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 190);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 251);
            this.listBox1.TabIndex = 4;
            // 
            // ForecastingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.forecastPrintLabel);
            this.Controls.Add(this.makeForecastButton);
            this.Controls.Add(this.periodNumbersTextBox);
            this.Controls.Add(this.periodNumbersLabel);
            this.Name = "ForecastingWindow";
            this.Text = "ForecastingWindow";
            this.Load += new System.EventHandler(this.ForecastingWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label periodNumbersLabel;
        private System.Windows.Forms.TextBox periodNumbersTextBox;
        private System.Windows.Forms.Button makeForecastButton;
        private System.Windows.Forms.Label forecastPrintLabel;
        private System.Windows.Forms.ListBox listBox1;
    }
}