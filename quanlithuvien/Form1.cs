using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanlithuvien
{
    public partial class Form1 : Form

    {
        DataTable dtSach = new DataTable();
        string strCon = @"Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";

        List<Sach> dsSach = new List<Sach>();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string sql = "INSERT INTO Sach (TenSach, TacGia, SoLuong) VALUES (@ten, @tg, @sl)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", txtTenSach.Text);
                cmd.Parameters.AddWithValue("@tg", txtTacGia.Text);
                cmd.Parameters.AddWithValue("@sl", (int)nmSoLuong.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu vào SQL thành công!");
                LoadData(); // Cập nhật lại bảng hiển thị
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn sách từ bảng chưa
            if (txtTenSach.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn cuốn sách bạn muốn xóa từ bảng!");
                return;
            }

            // 2. Hiện hộp thoại xác nhận (tránh việc lỡ tay bấm nhầm)
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa cuốn sách này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    try
                    {
                        conn.Open();
                        // 3. Câu lệnh DELETE dựa trên MaSach lưu trong Tag
                        string sql = "DELETE FROM Sach WHERE MaSach = @id";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", txtTenSach.Tag);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa sách khỏi hệ thống!");

                        // 4. Làm sạch các ô nhập liệu và load lại bảng
                        txtTenSach.Clear();
                        txtTacGia.Clear();
                        nmSoLuong.Value = 0;
                        txtTenSach.Tag = null; // Xóa luôn ID đang lưu

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSach.Clear();
            txtTacGia.Clear();
            nmSoLuong.Value = 1;
            txtTenSach.Focus(); // Để con trỏ chuột quay lại ô Tên sách

        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng bạn vừa click vào
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];

                // Đẩy dữ liệu từ dòng đó ngược lên các ô nhập liệu
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                txtTacGia.Text = row.Cells["TacGia"].Value.ToString();
                txtTenSach.Tag = row.Cells["MaSach"].Value.ToString();
                nmSoLuong.Value = Convert.ToInt32(row.Cells["SoLuong"].Value);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn sách từ bảng chưa (thông qua Tag đã lưu ở CellClick)
            if (txtTenSach.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ bảng để sửa!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    // 2. Câu lệnh SQL Update dựa trên MaSach
                    string sql = "UPDATE Sach SET TenSach=@ten, TacGia=@tg, SoLuong=@sl WHERE MaSach=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // 3. Truyền dữ liệu từ TextBox vào tham số
                    cmd.Parameters.AddWithValue("@ten", txtTenSach.Text);
                    cmd.Parameters.AddWithValue("@tg", txtTacGia.Text);
                    cmd.Parameters.AddWithValue("@sl", (int)nmSoLuong.Value);
                    cmd.Parameters.AddWithValue("@id", txtTenSach.Tag); // Lấy ID từ Tag

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu vào SQL thành công!");

                    // 4. Load lại bảng để thấy thay đổi mới nhất
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dtSach != null)
            {
                string filter = string.Format("TenSach LIKE '%{0}%' OR TacGia LIKE '%{0}%'", txtSearch.Text);
                dtSach.DefaultView.RowFilter = filter;
            }
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Sach";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtSach = new DataTable();
                    da.Fill(dtSach);
                    dgvSach.DataSource = dtSach;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnMuontra_Click(object sender, EventArgs e)
        {
            FormMuonTra f = new FormMuonTra();
            f.ShowDialog(); // Mở cửa sổ mượn trả lên
        }
    }
}


