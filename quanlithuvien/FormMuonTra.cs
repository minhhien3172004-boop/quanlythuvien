using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlithuvien
{
    public partial class FormMuonTra : Form
    {
        // 1. Chuỗi kết nối (Dùng dấu chấm để chạy được trên nhiều máy có cài SQL Express)
        string strCon = @"Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";

        public FormMuonTra()
        {
            InitializeComponent();
        }
        private void FormMuonTra_Load(object sender, EventArgs e)
        {
            LoadDataToCombo(); 
            LoadDataGridView(); 
        }

        private void LoadDataToCombo()
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    string sql = "SELECT MaSach, TenSach FROM Sach";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboSach.DisplayMember = "TenSach"; 
                    cboSach.ValueMember = "MaSach";  
                    cboSach.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi nạp sách: " + ex.Message); }
            }
        }
        private void LoadDataGridView()
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    // Lấy thông tin từ 3 bảng đã JOIN với nhau
                    string sql = @"SELECT dg.HoTen AS [Người mượn], s.TenSach AS [Tên sách], pm.NgayHenTra AS [Hạn trả] 
                                   FROM PhieuMuon pm
                                   JOIN DocGia dg ON pm.MaDG = dg.MaDG
                                   JOIN Sach s ON pm.MaSach = s.MaSach";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dvgPhieuMuon.DataSource = dt;
                    dvgPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi bảng: " + ex.Message); }
            }
        }

        // HÀM 3: Xử lý nút Mượn Sách
        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTenDG.Text) || cboSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập tên và chọn sách!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Bước A: Lưu thông tin độc giả
                    string sqlDG = "INSERT INTO DocGia (HoTen, SDT) OUTPUT INSERTED.MaDG VALUES (@hoten, @sdt)";
                    SqlCommand cmdDG = new SqlCommand(sqlDG, conn, trans);
                    cmdDG.Parameters.AddWithValue("@hoten", txtHoTenDG.Text);
                    cmdDG.Parameters.AddWithValue("@sdt", txtSDTDG.Text);
                    int maDGvuaTao = (int)cmdDG.ExecuteScalar();

                    // Bước B: Lưu phiếu mượn
                    string sqlPM = "INSERT INTO PhieuMuon (MaDG, MaSach, NgayHenTra) VALUES (@madg, @masach, @hentra)";
                    SqlCommand cmdPM = new SqlCommand(sqlPM, conn, trans);
                    cmdPM.Parameters.AddWithValue("@madg", maDGvuaTao);
                    cmdPM.Parameters.AddWithValue("@masach", cboSach.SelectedValue);
                    cmdPM.Parameters.AddWithValue("@hentra", dtpHenTra.Value);
                    cmdPM.ExecuteNonQuery();

                    // Bước C: Trừ số lượng sách trong kho
                    string sqlUpdate = "UPDATE Sach SET SoLuong = SoLuong - 1 WHERE MaSach = @masach AND SoLuong > 0";
                    SqlCommand cmdUp = new SqlCommand(sqlUpdate, conn, trans);
                    cmdUp.Parameters.AddWithValue("@masach", cboSach.SelectedValue);
                    
                    int rows = cmdUp.ExecuteNonQuery();
                    if (rows == 0) throw new Exception("Sách này đã hết!");

                    trans.Commit();
                    MessageBox.Show("Mượn sách thành công!");

                    LoadDataGridView(); 
                    txtHoTenDG.Clear();
                    txtSDTDG.Clear();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi thực thi: " + ex.Message);
                }
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text;
            string sdt = txtSDTDG.Text;

            if (string.IsNullOrEmpty(maSach) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            MessageBox.Show($"Đã nhận yêu cầu trả sách: {maSach} của số ĐT: {sdt}");

        }
        }
}