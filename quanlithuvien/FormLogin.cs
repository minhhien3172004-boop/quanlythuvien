using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlithuvien
{
    public partial class FormLogin : Form
    {
        // Khai báo chuỗi kết nối ở ĐÂY
        string strCon = @"Data Source=.;Initial Catalog=QuanlyThuVien;Integrated Security=True";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM TaiKhoan WHERE TenDN=@user AND MatKhau=@pass";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", txtUser.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        this.Hide();
                        Form1 fMain = new Form1();
                        fMain.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
