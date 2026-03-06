namespace Crypto_currency_Analyze_Forecasting
{
    partial class CryptoCurrencyWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CryptoCurrencyWindow));
            this.chooseCurrentCurrency = new System.Windows.Forms.ComboBox();
            this.textBoxShow = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.currencyNameTextBox = new System.Windows.Forms.TextBox();
            this.infoPrintLabel = new System.Windows.Forms.Label();
            this.chooseAnotherCurrencyButton = new System.Windows.Forms.Button();
            this.explorerLinkLabel = new System.Windows.Forms.LinkLabel();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalComboBox = new System.Windows.Forms.ComboBox();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.forecastingButton = new System.Windows.Forms.Button();
            this.minMaxChangeCurrency = new System.Windows.Forms.ListBox();
            this.getDataFromDatabaseButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseCurrentCurrency
            // 
            this.chooseCurrentCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseCurrentCurrency.FormattingEnabled = true;
            this.chooseCurrentCurrency.Location = new System.Drawing.Point(186, 97);
            this.chooseCurrentCurrency.Name = "chooseCurrentCurrency";
            this.chooseCurrentCurrency.Size = new System.Drawing.Size(121, 21);
            this.chooseCurrentCurrency.TabIndex = 0;
            this.chooseCurrentCurrency.SelectedIndexChanged += new System.EventHandler(this.chooseCurrentCurrency_SelectedIndexChanged);
            // 
            // textBoxShow
            // 
            this.textBoxShow.Location = new System.Drawing.Point(186, 157);
            this.textBoxShow.Name = "textBoxShow";
            this.textBoxShow.Size = new System.Drawing.Size(121, 40);
            this.textBoxShow.TabIndex = 1;
            this.textBoxShow.Text = "Enter name";
            this.textBoxShow.UseVisualStyleBackColor = true;
            this.textBoxShow.Click += new System.EventHandler(this.textBoxShow_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(183, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(154, 13);
            this.Title.TabIndex = 2;
            this.Title.Text = "Choose availabe or enter name";
            // 
            // currencyNameTextBox
            // 
            this.currencyNameTextBox.Location = new System.Drawing.Point(186, 226);
            this.currencyNameTextBox.Name = "currencyNameTextBox";
            this.currencyNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.currencyNameTextBox.TabIndex = 3;
            // 
            // infoPrintLabel
            // 
            this.infoPrintLabel.AutoSize = true;
            this.infoPrintLabel.Location = new System.Drawing.Point(21, 13);
            this.infoPrintLabel.Name = "infoPrintLabel";
            this.infoPrintLabel.Size = new System.Drawing.Size(0, 13);
            this.infoPrintLabel.TabIndex = 4;
            // 
            // chooseAnotherCurrencyButton
            // 
            this.chooseAnotherCurrencyButton.Location = new System.Drawing.Point(631, 388);
            this.chooseAnotherCurrencyButton.Name = "chooseAnotherCurrencyButton";
            this.chooseAnotherCurrencyButton.Size = new System.Drawing.Size(112, 68);
            this.chooseAnotherCurrencyButton.TabIndex = 5;
            this.chooseAnotherCurrencyButton.Text = "Choose Another Currency or Interval";
            this.chooseAnotherCurrencyButton.UseVisualStyleBackColor = true;
            this.chooseAnotherCurrencyButton.Click += new System.EventHandler(this.chooseAnotherCurrencyButton_Click);
            // 
            // explorerLinkLabel
            // 
            this.explorerLinkLabel.AutoSize = true;
            this.explorerLinkLabel.Location = new System.Drawing.Point(21, 209);
            this.explorerLinkLabel.Name = "explorerLinkLabel";
            this.explorerLinkLabel.Size = new System.Drawing.Size(0, 13);
            this.explorerLinkLabel.TabIndex = 6;
            this.explorerLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.explorerLinkLabel_LinkClicked);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(21, 13);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(146, 13);
            this.intervalLabel.TabIndex = 8;
            this.intervalLabel.Text = "Select the data validity period";
            // 
            // intervalComboBox
            // 
            this.intervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalComboBox.FormattingEnabled = true;
            this.intervalComboBox.Location = new System.Drawing.Point(24, 97);
            this.intervalComboBox.Name = "intervalComboBox";
            this.intervalComboBox.Size = new System.Drawing.Size(121, 21);
            this.intervalComboBox.TabIndex = 9;
            this.intervalComboBox.SelectedIndexChanged += new System.EventHandler(this.intervalComboBox_SelectedIndexChanged);
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(421, 388);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(99, 68);
            this.analyzeButton.TabIndex = 7;
            this.analyzeButton.Text = "Analyze\r\n";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // forecastingButton
            // 
            this.forecastingButton.Location = new System.Drawing.Point(526, 388);
            this.forecastingButton.Name = "forecastingButton";
            this.forecastingButton.Size = new System.Drawing.Size(99, 68);
            this.forecastingButton.TabIndex = 10;
            this.forecastingButton.Text = "Forecasting";
            this.forecastingButton.UseVisualStyleBackColor = true;
            this.forecastingButton.Click += new System.EventHandler(this.forecastingButton_Click);
            // 
            // minMaxChangeCurrency
            // 
            this.minMaxChangeCurrency.FormattingEnabled = true;
            this.minMaxChangeCurrency.Location = new System.Drawing.Point(381, 50);
            this.minMaxChangeCurrency.Name = "minMaxChangeCurrency";
            this.minMaxChangeCurrency.Size = new System.Drawing.Size(407, 160);
            this.minMaxChangeCurrency.TabIndex = 11;
            // 
            // getDataFromDatabaseButton
            // 
            this.getDataFromDatabaseButton.Location = new System.Drawing.Point(631, 252);
            this.getDataFromDatabaseButton.Name = "getDataFromDatabaseButton";
            this.getDataFromDatabaseButton.Size = new System.Drawing.Size(112, 68);
            this.getDataFromDatabaseButton.TabIndex = 13;
            this.getDataFromDatabaseButton.Text = "Get data from Database";
            this.getDataFromDatabaseButton.UseVisualStyleBackColor = true;
            this.getDataFromDatabaseButton.Click += new System.EventHandler(this.getDataFromDatabaseButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 68);
            this.button1.TabIndex = 14;
            this.button1.Text = "Currency Top";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // CryptoCurrencyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(900, 579);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.getDataFromDatabaseButton);
            this.Controls.Add(this.minMaxChangeCurrency);
            this.Controls.Add(this.forecastingButton);
            this.Controls.Add(this.intervalComboBox);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.explorerLinkLabel);
            this.Controls.Add(this.chooseAnotherCurrencyButton);
            this.Controls.Add(this.infoPrintLabel);
            this.Controls.Add(this.currencyNameTextBox);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.textBoxShow);
            this.Controls.Add(this.chooseCurrentCurrency);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CryptoCurrencyWindow";
            this.Text = "CryproCurrencyWindow";
            this.Load += new System.EventHandler(this.CryptoCurrencyWindow_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseCurrentCurrency;
        private System.Windows.Forms.Button textBoxShow;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox currencyNameTextBox;
        private System.Windows.Forms.Label infoPrintLabel;
        private System.Windows.Forms.Button chooseAnotherCurrencyButton;
        private System.Windows.Forms.LinkLabel explorerLinkLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.ComboBox intervalComboBox;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Button forecastingButton;
        private System.Windows.Forms.ListBox minMaxChangeCurrency;
        private System.Windows.Forms.Button getDataFromDatabaseButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}