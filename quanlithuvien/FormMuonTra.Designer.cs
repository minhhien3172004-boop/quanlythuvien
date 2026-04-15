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
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHenTra = new System.Windows.Forms.DateTimePicker();
            this.btnChoMuon = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.dvgPhieuMuon = new System.Windows.Forms.DataGridView();
            this.txtHoTenDG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSDTDG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSach
            // 
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(214, 124);
            this.cboSach.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(304, 33);
            this.cboSach.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label1.Location = new System.Drawing.Point(38, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Độc giả:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label2.Location = new System.Drawing.Point(38, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label3.Location = new System.Drawing.Point(600, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày Hẹn Trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.label4.Location = new System.Drawing.Point(442, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 39);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mượn trả sách";
            // 
            // dtpHenTra
            // 
            this.dtpHenTra.Location = new System.Drawing.Point(773, 91);
            this.dtpHenTra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpHenTra.Name = "dtpHenTra";
            this.dtpHenTra.Size = new System.Drawing.Size(335, 32);
            this.dtpHenTra.TabIndex = 6;
            // 
            // btnChoMuon
            // 
            this.btnChoMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnChoMuon.Location = new System.Drawing.Point(608, 166);
            this.btnChoMuon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChoMuon.Name = "btnChoMuon";
            this.btnChoMuon.Size = new System.Drawing.Size(226, 64);
            this.btnChoMuon.TabIndex = 7;
            this.btnChoMuon.Text = "Mượn sách";
            this.btnChoMuon.UseVisualStyleBackColor = true;
            this.btnChoMuon.Click += new System.EventHandler(this.btnChoMuon_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.btnTraSach.Location = new System.Drawing.Point(882, 166);
            this.btnTraSach.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(226, 64);
            this.btnTraSach.TabIndex = 8;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // dvgPhieuMuon
            // 
            this.dvgPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPhieuMuon.Location = new System.Drawing.Point(2, 306);
            this.dvgPhieuMuon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dvgPhieuMuon.Name = "dvgPhieuMuon";
            this.dvgPhieuMuon.RowHeadersWidth = 51;
            this.dvgPhieuMuon.RowTemplate.Height = 24;
            this.dvgPhieuMuon.Size = new System.Drawing.Size(1197, 398);
            this.dvgPhieuMuon.TabIndex = 9;
            // 
            // txtHoTenDG
            // 
            this.txtHoTenDG.Location = new System.Drawing.Point(214, 66);
            this.txtHoTenDG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHoTenDG.Name = "txtHoTenDG";
            this.txtHoTenDG.Size = new System.Drawing.Size(304, 32);
            this.txtHoTenDG.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số Điện Thoại:";
            // 
            // txtSDTDG
            // 
            this.txtSDTDG.Location = new System.Drawing.Point(214, 180);
            this.txtSDTDG.Name = "txtSDTDG";
            this.txtSDTDG.Size = new System.Drawing.Size(304, 32);
            this.txtSDTDG.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 239);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mã sách:";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(214, 239);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(304, 32);
            this.txtMaSach.TabIndex = 14;
            // 
            // FormMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 703);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSDTDG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHoTenDG);
            this.Controls.Add(this.dvgPhieuMuon);
            this.Controls.Add(this.btnTraSach);
            this.Controls.Add(this.btnChoMuon);
            this.Controls.Add(this.dtpHenTra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSach);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMuonTra";
            this.Text = "FormMuonTra";
            this.Load += new System.EventHandler(this.FormMuonTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhieuMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHenTra;
        private System.Windows.Forms.Button btnChoMuon;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.DataGridView dvgPhieuMuon;
        private System.Windows.Forms.TextBox txtHoTenDG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDTDG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaSach;
    }
}