
namespace DataWarehouseProject
{
    partial class Form1
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
            this.cbView = new System.Windows.Forms.ComboBox();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.tbCabang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbReseller = new System.Windows.Forms.TextBox();
            this.tbProduk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // cbView
            // 
            this.cbView.FormattingEnabled = true;
            this.cbView.Items.AddRange(new object[] {
            "ALL",
            "CABANG",
            "RESELLER",
            "PRODUK",
            "CABANG + PRODUK",
            "CABANG + RESELLER",
            "RESELLER + PRODUK"});
            this.cbView.Location = new System.Drawing.Point(125, 61);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(189, 24);
            this.cbView.TabIndex = 1;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // dgvView
            // 
            this.dgvView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(67, 134);
            this.dgvView.Name = "dgvView";
            this.dgvView.RowHeadersWidth = 51;
            this.dgvView.RowTemplate.Height = 24;
            this.dgvView.Size = new System.Drawing.Size(1142, 493);
            this.dgvView.TabIndex = 2;
            this.dgvView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvView_RowStateChanged);
            // 
            // tbCabang
            // 
            this.tbCabang.Location = new System.Drawing.Point(698, 63);
            this.tbCabang.Name = "tbCabang";
            this.tbCabang.Size = new System.Drawing.Size(141, 22);
            this.tbCabang.TabIndex = 3;
            this.tbCabang.TextChanged += new System.EventHandler(this.tbCabang_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(695, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search by Cabang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(882, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Search by Reseller";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1065, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Search by Produk";
            // 
            // tbReseller
            // 
            this.tbReseller.Location = new System.Drawing.Point(885, 63);
            this.tbReseller.Name = "tbReseller";
            this.tbReseller.Size = new System.Drawing.Size(141, 22);
            this.tbReseller.TabIndex = 9;
            this.tbReseller.TextChanged += new System.EventHandler(this.tbReseller_TextChanged);
            // 
            // tbProduk
            // 
            this.tbProduk.Location = new System.Drawing.Point(1068, 64);
            this.tbProduk.Name = "tbProduk";
            this.tbProduk.Size = new System.Drawing.Size(141, 22);
            this.tbProduk.TabIndex = 10;
            this.tbProduk.TextChanged += new System.EventHandler(this.tbProduk_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "0 Rows";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 732);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbProduk);
            this.Controls.Add(this.tbReseller);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCabang);
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Jam Tangan";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbView;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.TextBox tbCabang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbReseller;
        private System.Windows.Forms.TextBox tbProduk;
        private System.Windows.Forms.Label label5;
    }
}

