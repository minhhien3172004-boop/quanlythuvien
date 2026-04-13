using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlithuvien
{
    public partial class FormMuonTra : Form
    {
        public FormMuonTra()
        {
            InitializeComponent();
            LoadDataToCombo();
        }

        // Khai báo chuỗi kết nối (Dùng dấu chấm để máy thầy cô cũng chạy được)
        string strCon = @"Data Source=.;Initial Catalog=QuanlyThuVien;Integrated Security=True";

        private void LoadDataToCombo()
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    // 1. Load danh sách Độc giả
                    SqlDataAdapter daDG = new SqlDataAdapter("SELECT MaDG, HoTen FROM DocGia", conn);
                    DataTable dtDG = new DataTable();
                    daDG.Fill(dtDG);
                    cboDocGia.DataSource = dtDG;
                    cboDocGia.DisplayMember = "HoTen"; // Hiển thị tên người
                    cboDocGia.ValueMember = "MaDG";    // Giá trị ẩn là Mã DG

                    // 2. Load danh sách Sách (Chỉ lấy những cuốn còn trong kho)
                    SqlDataAdapter daS = new SqlDataAdapter("SELECT MaSach, TenSach FROM Sach WHERE SoLuong > 0", conn);
                    DataTable dtS = new DataTable();
                    daS.Fill(dtS);
                    cboSach.DataSource = dtS;
                    cboSach.DisplayMember = "TenSach"; // Hiển thị tên sách
                    cboSach.ValueMember = "MaSach";    // Giá trị ẩn là Mã sách
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load danh sách: " + ex.Message);
                }
            }
        }

        private void btnChomuon_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    // Lệnh 1: Thêm vào bảng PhieuMuon
                    string sqlInsert = "INSERT INTO PhieuMuon(MaDG, MaSach, NgayHenTra) VALUES (@madg, @masach, @hentra)";
                    SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@madg", cboDocGia.SelectedValue);
                    cmdInsert.Parameters.AddWithValue("@masach", cboSach.SelectedValue);
                    cmdInsert.Parameters.AddWithValue("@hentra", dtpHenTra.Value);
                    cmdInsert.ExecuteNonQuery();

                    // Lệnh 2: Trừ số lượng sách trong kho đi 1
                    string sqlUpdate = "UPDATE Sach SET SoLuong = SoLuong - 1 WHERE MaSach = @masach";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@masach", cboSach.SelectedValue);
                    cmdUpdate.ExecuteNonQuery();

                    MessageBox.Show("Mượn sách thành công! Kho đã tự động trừ 1 cuốn.");
                    LoadDataToCombo(); // Cập nhật lại danh sách sách (để ẩn sách nếu hết hàng)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
