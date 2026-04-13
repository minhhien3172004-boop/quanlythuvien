namespace quanlithuvien
{
    partial class FormMuonTra
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
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHenTra = new System.Windows.Forms.DateTimePicker();
            this.btnChomuon = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.dvgPhieuMuon = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDocGia
            // 
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(126, 58);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(204, 24);
            this.cboDocGia.TabIndex = 0;
            // 
            // cboSach
            // 
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(126, 105);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(204, 24);
            this.cboSach.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Độc giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label2.Location = new System.Drawing.Point(25, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label3.Location = new System.Drawing.Point(400, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày Hẹn Trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.label4.Location = new System.Drawing.Point(295, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 39);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mượn trả sách";
            // 
            // dtpHenTra
            // 
            this.dtpHenTra.Location = new System.Drawing.Point(552, 62);
            this.dtpHenTra.Name = "dtpHenTra";
            this.dtpHenTra.Size = new System.Drawing.Size(200, 22);
            this.dtpHenTra.TabIndex = 6;
            // 
            // btnChomuon
            // 
            this.btnChomuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnChomuon.Location = new System.Drawing.Point(405, 106);
            this.btnChomuon.Name = "btnChomuon";
            this.btnChomuon.Size = new System.Drawing.Size(151, 41);
            this.btnChomuon.TabIndex = 7;
            this.btnChomuon.Text = "Mượn sách";
            this.btnChomuon.UseVisualStyleBackColor = true;
            this.btnChomuon.Click += new System.EventHandler(this.btnChomuon_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnTraSach.Location = new System.Drawing.Point(588, 106);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(151, 41);
            this.btnTraSach.TabIndex = 8;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            // 
            // dvgPhieuMuon
            // 
            this.dvgPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPhieuMuon.Location = new System.Drawing.Point(1, 196);
            this.dvgPhieuMuon.Name = "dvgPhieuMuon";
            this.dvgPhieuMuon.RowHeadersWidth = 51;
            this.dvgPhieuMuon.RowTemplate.Height = 24;
            this.dvgPhieuMuon.Size = new System.Drawing.Size(798, 255);
            this.dvgPhieuMuon.TabIndex = 9;
            // 
            // FormMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dvgPhieuMuon);
            this.Controls.Add(this.btnTraSach);
            this.Controls.Add(this.btnChomuon);
            this.Controls.Add(this.dtpHenTra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSach);
            this.Controls.Add(this.cboDocGia);
            this.Name = "FormMuonTra";
            this.Text = "FormMuonTra";
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhieuMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHenTra;
        private System.Windows.Forms.Button btnChomuon;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.DataGridView dvgPhieuMuon;
    }
}